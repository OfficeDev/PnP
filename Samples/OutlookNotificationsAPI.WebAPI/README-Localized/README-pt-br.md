---
page_type: sample
products:
- office-outlook
- office-sp
languages:
- aspx
- csharp
extensions:
  contentType: samples
  technologies:
  - Azure AD
  platforms:
  - REST API
  createdDate: 1/1/2016 12:00:00 AM
---
# API REST de notificações do Outlook com API Web ASP.NET  #

### Resumo ###
Este é um exemplo de um projeto de API Web em ASP.NET que valida e responde a notificações do Outlook, criado com a API REST de notificações do Outlook. O exemplo abrange os conceitos de inscrição para receber notificações, validação de URLs de notificação e inspeção de entidades monitoradas chamando a API REST do Outlook por meio de tokens persistentes.

Saiba mais sobre a API REST de notificações do Outlook e suas operações em: <https://msdn.microsoft.com/en-us/office/office365/api/notify-rest-operations>

Usar essa abordagem orientada por evento é uma maneira muito mais sólida de lidar com as alterações nos recursos e entidades do Outlook. Em vez de sondar as APIs REST do Outlook diretamente, fazer isso é muito mais simples (especialmente quando a quantidade de itens é grande). Com o dimensionamento, esse método torna-se essencial para uma arquitetura de serviço sustentável.

![Interface de usuário do suplemento e detalhes sobre o token recebido do Office 365](http://i.imgur.com/r3rNNGV.png)

Leia mais sobre este exemplo em: <http://simonjaeger.com/call-me-back-outlook-notifications-rest-api>

### Aplicável a ###
-  Exchange Online
-  Office 365
-  Hotmail.com
-  Live.com
-  MSN.com
-  Outlook.com
-  Passport.com

### Pré-requisitos ###
A API REST de notificações do Outlook está disponível para vários serviços. Será necessário registrá-lo para que você possa fazer chamadas na API REST de notificações no Outlook. Saiba mais em: <https://dev.outlook.com/RestGettingStarted>

Se você estiver criando para o Office 365 e não tiver um locatário do Office 365, adquira uma conta de desenvolvedor em: <http://dev.office.com/devprogram>

Por fim, você precisará hospedar e implantar sua API da Web, por exemplo, para um aplicativo Web no Microsoft Azure: <https://azure.microsoft.com/en-us/documentation/scenarios/web-app/>.

### Solução ###
Solution | Author(s)
---------|----------
OutlookNotificationsAPI.WebAPI | Simon Jäger (**Microsoft**)

### Histórico de versão ###
Versão | Data | Comentários
---------| -----| --------
1.2 | 18 de janeiro de 2016 | Chamadas de retorno da API REST do Outlook adicionadas (usando tokens persistentes)
1.1 | 13 de janeiro de 2016 | IU adicionada para registrar uma assinatura
1.0 | 12 de dezembro de 2015 | Versão inicial

### Aviso de isenção de responsabilidade ###
**ESSE CÓDIGO É FORNECIDO *NAS CIRCUNTÂNCIAS ATUAIS*SEM GARANTIA DE QUALQUER TIPO, SEJA EXPLÍCITA OU IMPLÍCITA, INCLUINDO QUAISQUER GARANTIAS IMPLÍCITAS DE ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA, COMERCIABILIDADE OU NÃO VIOLAÇÃO.**

----------

# Como usar? #
A primeira etapa consiste em criar e hospedar sua API da Web em algum lugar. Ela deve ser implantada e validada pela API REST de notificações do Outlook para que possamos receber notificações. Em termos de validação, é bem simples. Quando pedirmos à API REST de notificações do Outlook para começar a enviar notificações (criando uma assinatura) para a sua API da Web, ela irá em frente e enviará um token de validação. 

A API da Web deve responder com o mesmo token de validação em 5 segundos, caso possa conseguir isso. Uma assinatura de notificações será criada e retornada para o aplicativo do cliente (criando a assinatura).

#### Registrar no Azure AD ####

A primeira etapa é registrar seu aplicativo Web em seu locatário do Azure AD (associado ao seu locatário do Office 365). O aplicativo Web está usando o OWIN e o OpenId Connect para lidar com a autenticação e a autorização. Você pode encontrar mais detalhes sobre OWIN e OpenId Connect, bem como sobre o cadastro do seu aplicativo no inquilino do Azure AD aqui: <http://www.cloudidentity.com/blog/2014/07/28/protecting-an-mvc4-vs2012-project-with-openid-connect-and-azure-ad/>

Como o aplicativo está chamando no Office 365, é importante conceder permissões de permissão para que ele leia o calendário do usuário.

Depois de registrar o aplicativo no inquilino do Azure AD, você precisará definir as configurações a seguir no arquivo web.config:

    <add key="ida:ClientId" value="[YOUR APPLICATION CLIENT ID]" />
    <add key="ida:ClientSecret" value="[YOUR APPLICATION CLIENT SECRET]" />
    <add key="ida:Domain" value="[YOUR DOMAIN]" />
    <add key="ida:TenantId" value="[YOUR TENANT ID]" />
    <add key="ida:PostLogoutRedirectUri" value="[YOUR POST LOGOUT REDIRECT URI]" />
    
#### Implantar ####

Implante sua API da Web em um provedor de hospedagem, por exemplo, um aplicativo Web no Microsoft Azure: <https://azure.microsoft.com/en-us/documentation/scenarios/web-app/>. Observe que este aplicativo requer um servidor SQL Azure, uma vez que a assinatura e as informações de token são mantidas em um banco de dados. Você pode usar o assistente de publicação do Visual Studio e publicar um novo aplicativo Web + servidor de BD. Se você já tiver criado o aplicativo Web ou se quiser usar um servidor de banco de dados do SQL Azure existente, será necessário baixar o perfil de publicação do aplicativo Web e usá-lo no assistente de publicação. Além disso, certifique-se de definir sua cadeia de conexão de banco de dados para apontar para o servidor do SQL Azure existente, como mostrado abaixo:

```XML
<add name="DefaultConnection" connectionString="Data Source=tcp:<sqlazuredbserver>.database.windows.net;Initial Catalog=OutlookNotifications;User ID=user@<sqlazuredbserver>;Password=*****" providerName="System.Data.SqlClient" />
```

Depois de implantar o exemplo em um provedor de hospedagem, configure um ponto de interrupção para capturar e validar o fluxo na Web API (NotifyController). Depois que a validação ocorrer, você receberá notificações e poderá investigar as respostas.

Você pode usar o Visual Studio 2015 para anexar um depurador a um aplicativo Web do Azure (consulte <https://azure.microsoft.com/sv-se/documentation/articles/web-sites-dotnet-troubleshoot-visual-studio/#remotedebug>)

**Lembre-se: se você estiver usando a depuração remota, os atrasos podem fazer com que você quebre o tempo de resposta de 5 segundos durante a validação de URLs de notificação.**

Navegue até a sua amostra hospedada e clique no botão "registrar assinatura" para começar a receber notificações.

# Modelos de resposta #
O exemplo implementa alguns modelos de resposta. Eles servem para ajudá-lo a lidar com as solicitações de notificação (analisando o JSON recebido). Aqui estão os modelos de respostas importantes usados no exemplo. 

A classe genérica ResponseModel é o principal recipiente da resposta em si. No exemplo, ele conterá uma coleção da classe NotificationModel.

```C#
public class ResponseModel<T>
{
    public List<T> Value { get; set; }
}
```
A classe NotificationModel representa a notificação enviada para seu serviço de ouvinte (API Web).

```C#
public class NotificationModel
{
    public string SubscriptionId { get; set; }
    public string SubscriptionExpirationDateTime { get; set; }
    public int SequenceNumber { get; set; }
    public string ChangeType { get; set; }
    public string Resource { get; set; }
    public ResourceDataModel ResourceData { get; set; }
}
```
A classe ResourceDataModel representa a entidade (por exemplo, mail, Contact, Event) que acionou uma alteração. Esta é uma propriedade de navegação. 

```C#
public class ResourceDataModel
{
    public string Id { get; set; }
}
```
A classe PushSubscriptionModel representa a entidade de assinatura. Isso é usado como um modelo de solicitação e resposta ao criar a assinatura.
```C#
public class PushSubscriptionModel
{
    [JsonProperty("@odata.type")]
    public string Type
    {
        get
        {
            return "#Microsoft.OutlookServices.PushSubscription";
        }
    }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }
    public string Resource { get; set; }
    public string NotificationURL { get; set; }
    public string ChangeType { get; set; }
    public Guid ClientState { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string SubscriptionExpirationDateTime { get; set; }
}
```

# Controlador de API Web #
O NotifyController implementa um único método de Postagem. As solicitações de validação e notificação serão enviadas como mensagens postadas para a sua API da Web.

Quanto ao token de validação, ele a aceitará como um parâmetro opcional. Se ele estiver presente na solicitação,
saberemos que uma validação da URL (API da Web) está em andamento. Caso contrário, podemos supor que receberemos uma notificação de uma assinatura ativa. Portanto, se um parâmetro de token de validação estiver presente, retornaremos-o imediatamente da maneira adequada, definindo o cabeçalho do tipo de conteúdo como texto/sem formatação e retornaremos HTTP 200 como o código de resposta.

Como não há nenhum token de validação presente na solicitação, podemos começar analisando o corpo da solicitação e procurar notificações. 

```C#
public async Task<HttpResponseMessage> Post(string validationToken = null)
{
    // If a validation token is present, we need to respond within 5 seconds.
    if (validationToken != null)
    {
        var response = Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(validationToken);
        return response;
    }

    // Present only if the client specified the ClientState property in the 
    // subscription request. 
    IEnumerable<string> clientStateValues;
    Request.Headers.TryGetValues("ClientState", out clientStateValues);

    if (clientStateValues != null)
    {
        var clientState = clientStateValues.ToList().FirstOrDefault();
        if (clientState != null)
        {
            // TODO: Use the client state to verify the legitimacy of the notification.
        }
    }

    // Read and parse the request body.
    var content = await Request.Content.ReadAsStringAsync();
    var notifications = JsonConvert.DeserializeObject<ResponseModel<NotificationModel>>(content);

    // TODO: Do something with the notification.

    return new HttpResponseMessage(HttpStatusCode.OK);
}
```

Recomendo que você preste atenção ao cabeçalho do estado do cliente na solicitação (chamado ClientState). Se você criar a assinatura com uma propriedade de estado do cliente, ela será passada juntamente com a solicitação de notificação. Dessa forma, você poderá verificar a legitimidade da notificação.

Além disso, este exemplo também inspeciona os itens monitorados (eventos de calendário criados) quando uma notificação é disparada chamando a API do Outlook REST usando um token persistido.

```C#
// Read and parse the request body.
var content = await Request.Content.ReadAsStringAsync();
var notifications = JsonConvert.DeserializeObject<ResponseModel<NotificationModel>>(content).Value;

// TODO: Do something with the notification.
var entities = new ApplicationDbContext();
foreach (var notification in notifications)
{
    // Get the subscription from the database in order to locate the
    // user identifiers. This is used to tap the token cache.
    var subscription = entities.SubscriptionList.FirstOrDefault(s =>
        s.SubscriptionId == notification.SubscriptionId);

    try
    {
        // Get an access token to use when calling the Outlook REST APIs.
        var token = await TokenHelper.GetTokenForApplicationAsync(
            subscription.SignedInUserID,
            subscription.TenantID,
            subscription.UserObjectID,
            TokenHelper.OutlookResourceID);
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        // Send a GET call to the monitored event.
        var responseString = await httpClient.GetStringAsync(notification.Resource);
        var calendarEvent = JsonConvert.DeserializeObject<CalendarEventModel>(responseString);

        // TODO: Do something with the calendar event.
    }
    catch (AdalException)
    {
        // TODO: Handle token error.
    }
    // If the above failed, the user needs to explicitly re-authenticate for 
    // the app to obtain the required token.
    catch (Exception)
    {
        // TODO: Handle exception.
    }
}
```
# Arquivos de código-fonte #
Os principais arquivos de código-fonte neste projeto são os seguintes:

- `OutlookNotificationsAPI. WebAPI\Controllers\NotifyController.cs`\- O controlador de API da Web que contém o método de postagem simples (tratando solicitações de validação e de notificação).
- `OutlookNotificationsAPI. WebAPI\Controllers\HomeController.cs`\- O controlador Web API contendo a ação de registro que configura a assinatura para as notificações.
- `OutlookNotificationsAPI. WebAPI\Models\ResponseModel.cs`\- Representa o conjunto de entidades enviadas na solicitação de notificação para seu serviço de ouvinte (API Web).
- `OutlookNotificationsAPI. WebAPI\Models\NotificationModel.cs`\- Representa a entidade de notificação enviada para seu serviço de ouvinte (API Web).
- `OutlookNotificationsAPI. WebAPI\Models\ResourceDataModel.cs`\- Representa a entidade (por exemplo, mail, Contact, Event) que acionou uma alteração. Esta é uma propriedade de navegação. 
- `OutlookNotificationsAPI. WebAPI\Models\PushSubscriptionModel.cs`\- Representa a entidade de assinatura. Isso é usado como um modelo de solicitação e resposta ao criar a assinatura.

# Mais recursos #
- Descubra o desenvolvimento do Office em: <https://msdn.microsoft.com/en-us/office/>
- Introdução ao Microsoft Azure em: <https://azure.microsoft.com/en-us/>
- Saiba mais sobre webhooks em: <http://culttt.com/2014/01/22/webhooks/>
- Explore a API REST de notificações do Outlook e suas operações em: <https://msdn.microsoft.com/en-us/office/office365/api/notify-rest-operations> 
- Leia mais sobre este exemplo em: <http://simonjaeger.com/call-me-back-outlook-notifications-rest-api/>

<img src="https://telemetry.sharepointpnp.com/pnp/samples/OutlookNotificationsAPI.WebAPI" />