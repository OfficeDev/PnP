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
# API REST de notifications Outlook avec une API Web ASP.NET #

### Résumé ###
Il s’agit d’un exemple de projet d’API Web ASP.NET qui valide et répond aux notifications Outlook, créé avec l’API REST de notifications Outlook. L’exemple aborde le concept d’abonnement pour les notifications, validant les URL de notification et inspectant les entités surveillées en appelant l’API REST Outlook à l’aide de jetons persistants.

En savoir plus sur l’API REST de notifications Outlook et ses opérations : <https://msdn.microsoft.com/en-us/office/office365/api/notify-rest-operations>

L’utilisation de cette approche, basée sur les événements, est un moyen bien plus solide de gérer les modifications apportées aux ressources et aux entités dans Outlook. Contrairement à l’interrogation direct des API REST Outlook, cette opération est bien plus légère (en particulier lorsque la quantité d’éléments est grande). Avec l’échelle, cette approche devient essentielle pour une architecture de service viable.

![UI additionnel et détails sur le jeton reçu de Office 365](http://i.imgur.com/r3rNNGV.png)

Pour en savoir plus sur cet exemple, consultez la rubrique <http://simonjaeger.com/call-me-back-outlook-notifications-rest-api>

### Produits concernés ###
-  Exchange Online
-  Office 365
-  Hotmail.com
-  Live.com
-  MSN.com
-  Outlook.com
-  Passport.com

### Conditions préalables ###
L’API REST de notifications Outlook est disponible pour plusieurs services. Vous devrez inscrire votre application avant d’effectuer des appels vers l’API REST de notifications Outlook. Pour plus d’informations, voir : <https://dev.outlook.com/RestGettingStarted>

Si vous créez pour Office 365 et qu’il vous manque un locataire Office 365, procurez-vous un compte développeur sur : <http://dev.office.com/devprogram>

Enfin, vous devrez héberger et déployer votre API Web, par exemple, une application Web sur Microsoft Azure : <https://azure.microsoft.com/en-us/documentation/scenarios/web-app/>.

### Solution ###
Solution | Auteur(s) 
---------|---------- 
OutlookNotificationsAPI.WebAPI | Simon Jäger (**Microsoft**)

### Historique des versions ###
Version | Date | Commentaires 
---------| -----| --------
1.2 | 18 janvier 2016 | Ajout de rappels API REST Outlook (à l’aide de jetons persistants) 
1.1 | 13 janvier 2016 | Interface utilisateur ajoutée pour souscrire un abonnement 
1.0 | 12 décembre 2015 | Publication initiale

### Clause d’exclusion de responsabilité ###
**CE CODE EST FOURNI *EN L’ÉTAT*, SANS GARANTIE D'AUCUNE SORTE, EXPRESSE OU IMPLICITE, Y COMPRIS TOUTE GARANTIE IMPLICITE D'ADAPTATION À UN USAGE PARTICULIER, DE QUALITÉ MARCHANDE ET DE NON-CONTREFAÇON.**

----------

# Utilisation #
La première étape consiste à créer et à héberger votre API Web quelque part : elle doit être déployée et validée par l’API REST de notifications Outlook avant de pouvoir recevoir des notifications. En termes de validation, c’est assez simple. Lorsque vous demandez à l’API REST de notifications Outlook de commencer à envoyer des notifications (en créant un abonnement) à votre API Web, vous devez lui envoyer un jeton de validation. 

L’API Web doit répondre avec le même jeton de validation dans un délai de 5 secondes. Si c’est le cas, un abonnement aux notifications est créé et renvoyé à l’application cliente (créant l’abonnement).

#### S’inscrire dans Azure AD ####

La première étape consiste à inscrire votre application web dans votre locataire Azure AD (associé à votre locataire Office 365). L’application web utilise OWIN et OpenID Connect pour gérer l'authentification et l'autorisation. Vous trouverez plus d’informations sur OWIN et OpenID Connect ici, ainsi que sur l'enregistrement de votre application sur le locataire Azure AD ici : <http://www.cloudidentity.com/blog/2014/07/28/protecting-an-mvc4-vs2012-project-with-openid-connect-and-azure-ad/>

Comme l’application rappelle dans Office 365, il est important de lui accorder des autorisations pour lire le calendrier de l’utilisateur.

Une fois votre application web inscrite dans Azure AD, vous devez configurer les paramètres suivants dans le fichier Web.config :

    <add key="ida:ClientId" value="[YOUR APPLICATION CLIENT ID]" />
    <add key="ida:ClientSecret" value="[YOUR APPLICATION CLIENT SECRET]" />
    <add key="ida:Domain" value="[YOUR DOMAIN]" />
    <add key="ida:TenantId" value="[YOUR TENANT ID]" />
    <add key="ida:PostLogoutRedirectUri" value="[YOUR POST LOGOUT REDIRECT URI]" />
    
#### Déploiement ####

Déployer votre API Web auprès d’un fournisseur d’hébergement, par exemple, une application web sur Microsoft Azure : <https://azure.microsoft.com/en-us/documentation/scenarios/web-app/>. Notez que cette application a besoin d’un serveur SQL Azure, car les informations de l’abonnement et du jeton sont conservées dans une base de données. Vous pouvez utiliser l’assistant de publication dans Visual Studio et publier une nouvelle application web et un serveur DB. Si vous avez déjà créé l’application web ou si vous souhaitez utiliser un serveur de base de données SQL Azure existant, vous devez télécharger le profil de publication à partir de l’application web et l’utiliser dans l’assistant de publication. Assurez-vous également de définir la chaîne de connexion de votre base de données pour qu’elle pointe vers votre serveur SQL Azure existant, comme illustré ci-dessous :

```XML
<add name="DefaultConnection" connectionString="Data Source=tcp:<sqlazuredbserver>.database.windows.net;Initial Catalog=OutlookNotifications;User ID=user@<sqlazuredbserver>;Password=*****" providerName="System.Data.SqlClient" />
```

Une fois l’exemple déployé auprès d’un fournisseur d’hébergement, configurez un point d’arrêt pour intercepter et valider le flux dans l’API Web (NotifyController). Une fois la validation effectuée, vous recevez des notifications et vous pouvez examiner les réponses.

Vous pouvez utiliser Visual Studio 2015 pour joindre un débogueur à une application Web Azure (voir <https://azure.microsoft.com/sv-se/documentation/articles/web-sites-dotnet-troubleshoot-visual-studio/#remotedebug>)

**Attention : si vous utilisez le débogage distant, des retards peuvent entraîner une interruption du délai de réponse de 5 secondes lors de la validation des URL de notification.**

Accédez à votre exemple hébergé et cliquez sur le bouton « inscrire l’abonnement » pour commencer à recevoir des notifications.

# Modèles de réponse #
L’exemple implémente quelques modèles de réponse. Ils servent à vous aider lorsque vous traitez des demandes de notification (analyse du JSON reçu). Les modèles de réponse clés utilisés dans l’exemple sont répertoriés ici. 

La classe générique ResponseModel est le conteneur principal de la réponse elle-même. Dans l’exemple, elle contient une collection de la classe NotificationModel.

```C#
public class ResponseModel<T>
{
    public List<T> Value { get; set; }
}
```
La classe NotificationModel représente la notification envoyée à votre service d’écoute (API Web).

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
La classe ResourceDataModel représente l’entité (par exemple, un e-mail, un contact, un événement) qui a déclenché une modification. C’est une propriété de navigation. 

```C#
public class ResourceDataModel
{
    public string Id { get; set; }
}
```
La classe PushSubscriptionModel représente l’entité d’abonnement. Celle-ci est utilisée à la fois comme modèle de requête et de réponse lors de la création de l’abonnement.
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

# Contrôleur de l’API Web #
Le NotifyController implémente une seule méthode de publication. Les requêtes de validation et de notification sont envoyées sous la forme de messages de publication à votre API Web.

En ce qui concerne le jeton de validation, il l’accepte comme paramètre facultatif.
S’il est présent dans la demande, nous savons qu’une validation de l’URL (API Web) se produit. Sinon, nous pouvons supposer que nous obtenons une notification d’un abonnement actif. Donc, si un paramètre de jeton de validation est présent, il est immédiatement renvoyé de la bonne manière, en définissant l'en-tête du type de contenu comme text/brut et HTTP 200 est retourné comme code de réponse.

Comme pour aucun jeton de validation de présentation dans la demande, nous pouvons commencer l’analyse du corps de la requête et rechercher les notifications. 

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

Il est recommandé de faire attention à l'en-tête d'état du client dans la demande (nommé ClientState). Si vous créez l’abonnement avec une propriété d’état client, celui-ci est transmis en même temps que la requête de notification. De cette façon, vous pouvez vérifier la légitimité de la notification.

De plus, cet exemple examine également les éléments surveillés (événements de calendrier créés) lorsqu’une notification est déclenchée en appelant l’API REST Outlook à l’aide d’un jeton persistant.

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
# Fichiers de code source #
Les principaux fichiers de code source de ce projet sont les suivants :

- `OutlookNotificationsAPI.WebAPI\Controllers\NotifyController.cs` : le contrôleur de l’API Web contenant la méthode de publication unique et qui gère les requêtes de validation et de notification.
- `OutlookNotificationsAPI.WebAPI\Controllers\HomeController.cs` : le contrôleur de l’API Web contenant l’action d’inscription qui configure l’abonnement pour les notifications.
- `OutlookNotificationsAPI.WebAPI\Models\ResponseModel.cs` représente la collection d’entités envoyées dans la requête de notification à votre service d’écoute (API Web).
- `OutlookNotificationsAPI.WebAPI\Models\NotificationModel.cs` représente l’entité de notification envoyée dans la requête de notification à votre service d’écoute (API Web).
- `OutlookNotificationsAPI.WebAPI\Models\ResourceDataModel.cs` représente l’entité (par exemple, un e-mail, un contact, un événement) qui a déclenché une modification. C’est une propriété de navigation. 
- `OutlookNotificationsAPI.WebAPI\Models\PushSubscriptionModel.cs` représente l’entité d’abonnement. Celle-ci est utilisée à la fois comme modèle de requête et de réponse lors de la création de l’abonnement.

# Autres ressources #
- Découvrir développement Office à l’adresse : <https://msdn.microsoft.com/en-us/office/>
- Prendre en main de Microsoft Azure : <https://azure.microsoft.com/en-us/>
- En savoir plus sur webhooks : <http://culttt.com/2014/01/22/webhooks/>
- En savoir plus sur API REST de notifications Outlook et ses opérations : <https://msdn.microsoft.com/en-us/office/office365/api/notify-rest-operations> 
- Pour en savoir plus sur cet exemple, consultez la rubrique <http://simonjaeger.com/call-me-back-outlook-notifications-rest-api/>

<img src="https://telemetry.sharepointpnp.com/pnp/samples/OutlookNotificationsAPI.WebAPI" />