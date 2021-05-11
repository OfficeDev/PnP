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
# API REST для уведомлений Outlook с веб-API ASP.NET #

### Сводка ###
Это пример проекта веб-API ASP.NET, который проверяет уведомления Outlook, созданные с помощью REST API уведомлений Outlook, и отвечает на них. В этом примере рассматриваются понятия подписки на уведомления, проверки URL-адресов уведомлений и просмотра отслеживаемых объектов путем вызова REST API Outlook с использованием устойчивых токенов.

Подробнее о API REST Outlook Notifications и его операциях можно узнать по адресу:<https://msdn.microsoft.com/en-us/office/office365/api/notify-rest-operations>

Использование этого подхода, управляемого событиями, является гораздо более надежным способом реагирования на изменения ресурсов и сущностей в Outlook. В отличие от непосредственного опроса API-интерфейсов Outlook REST, он гораздо более легкий (особенно, когда количество элементов велико). С масштабом этот подход становится необходимым для устойчивой архитектуры обслуживания.

![Пользовательский интерфейс надстройки и сведения о полученном токене от Office 365](http://i.imgur.com/r3rNNGV.png)

Узнайте больше об этом образце на:<http://simonjaeger.com/call-me-back-outlook-notifications-rest-api>.

### Сфера применения ###
-  Exchange Online
-  Office 365
-  Hotmail.com
-  Live.com
-  MSN.com
-  Outlook.com
-  Passport.com

### Необходимые компоненты ###
API REST для уведомлений Outlook доступен для нескольких служб. Вам нужно будет зарегистрировать свое приложение, прежде чем вы сможете совершать какие-либо звонки в API REST Outlook Notifcations. Найти больше информации:<https://dev.outlook.com/RestGettingStarted>

Если вы создаете Office 365 и у вас отсутствует клиент Office 365 - создайте учетную запись разработчика по адресу:<http://dev.office.com/devprogram>

Наконец, вам нужно будет разместить и развернуть свой веб-API, например, в веб-приложении в Microsoft Azure:<https://azure.microsoft.com/en-us/documentation/scenarios/web-app/>.

### Решение ###
Решение | Авторы
---------|----------
OutlookNotificationsAPI.WebAPI | Саймон Егерь(**Microsoft**)

### Журнал версий ###
Версия | Дата | Примечаний
---------|----------
1.2 | 18 января 2016 | Добавлены вызовы API REST API для Outlook (с использованием постоянных маркеров)
1.1 | 13 января 2016 | Добавлен пользовательский интерфейс для регистрации подписки
1.0 | 12 декабря 2015 | Первоначальный выпуск

### Заявление об отказе ###
**ЭТОТ КОД ПРЕДОСТАВЛЯЕТСЯ *КАК ЕСТЬ* БЕЗ КАКОЙ-ЛИБО ЯВНОЙ ИЛИ ПОДРАЗУМЕВАЕМОЙ ГАРАНТИИ, ВКЛЮЧАЯ ПОДРАЗУМЕВАЕМЫЕ ГАРАНТИИ ПРИГОДНОСТИ ДЛЯ КАКОЙ-ЛИБО ЦЕЛИ, ДЛЯ ПРОДАЖИ ИЛИ ГАРАНТИИ ОТСУТСТВИЯ НАРУШЕНИЯ ПРАВ ИНЫХ ПРАВООБЛАДАТЕЛЕЙ.**

----------

# Как пользоваться? #
Первым шагом является создание и размещение вашего веб-API где-нибудь - его необходимо развернуть и проверить с помощью REST API уведомлений Outlook, прежде чем мы сможем получать уведомления на него. С точки зрения валидации это довольно просто. Когда мы просим API-интерфейс REST Outlook Notifications начать отправку уведомлений (путем создания подписки) на ваш веб-API, он отправит ему маркер проверки. 

В веб-интерфейсе API необходимо ответить на один и тот же токен проверки в течение 5 секунд, если это достигается за 5 секунд.

#### Зарегистрируйтесь в Azure AD ####

Первый шаг - регистрация веб-приложения в клиенте Azure AD (связанном с клиентом Office 365). Веб-приложение использует OWIN и OpenID Connect для обработки аутентификации и авторизации. Подробнее о OWIN и OpenId Connect можно узнать здесь, а также о регистрации приложения в клиенте Azure AD здесь: <http://www.cloudidentity.com/blog/2014/07/28/protecting-an-mvc4-vs2012-project-with-openid-connect-and-azure-ad/>

Поскольку приложение перезванивает в Office 365, важно предоставить ему разрешения на чтение календаря пользователя.

После регистрации приложения в клиенте Azure AD вам потребуется настроить следующие параметры в файле web.config:

    <add key="ida:ClientId" value="[YOUR APPLICATION CLIENT ID]" />
    <add key="ida:ClientSecret" value="[YOUR APPLICATION CLIENT SECRET]" />
    <add key="ida:Domain" value="[YOUR DOMAIN]" />
    <add key="ida:TenantId" value="[YOUR TENANT ID]" />
    <add key="ida:PostLogoutRedirectUri" value="[YOUR POST LOGOUT REDIRECT URI]" />
    
#### Развертывание ####

Разверните свой веб-API у поставщика услуг размещения, например, веб-приложения в Microsoft Azure:<https://azure.microsoft.com/en-us/documentation/scenarios/web-app/>. Обратите внимание, что для этого приложения требуется сервер SQL Azure, поскольку информация о подписке и токене хранится в базе данных. Вы можете использовать мастер публикации в Visual Studio и опубликовать новое веб-приложение + сервер БД. Если вы уже создали веб-приложение или хотите использовать существующий сервер баз данных SQL Azure, вам необходимо загрузить профиль публикации из веб-приложения и использовать его в мастере публикации. Также убедитесь, что вы указали в строке подключения к базе данных существующий сервер SQL Azure, как показано ниже:

```XML
<add name="DefaultConnection" connectionString="Data Source=tcp:<sqlazuredbserver>.database.windows.net;Initial Catalog=OutlookNotifications;User ID=user@<sqlazuredbserver>;Password=*****" providerName="System.Data.SqlClient" />
```

После того, как вы развернули образец на хостинг-провайдере; настроить точку останова, чтобы перехватить и проверить поток в веб-API (NotifyController). После проверки вы получите уведомления и сможете исследовать ответы.

Visual Studio 2015 можно использовать для подключения отладчика к веб-приложению Azure (см.<https://azure.microsoft.com/sv-se/documentation/articles/web-sites-dotnet-troubleshoot-visual-studio/#remotedebug>).

**Помните: если вы используете удаленную отладку, задержки могут привести к прерыванию 5-секундного времени ответа при проверке URL-адресов уведомлений.**

Перейдите к своему размещенному образцу и нажмите кнопку «Зарегистрировать подписку», чтобы начать получать уведомления.

# Модели ответа #
В примере реализовано несколько моделей ответов. Они служат для помощи при работе с запросами на уведомление (разбор полученного JSON). Здесь перечислены ключевые модели ответа, использованные в образце. 

Универсальный класс ResponseModel является основным контейнером для самого ответа. В этом примере он будет содержать коллекцию класса NotificationModel.

```C#
public class ResponseModel<T>
{
    public List<T> Value { get; set; }
}
```
Класс NotificationModel представляет уведомление, отправленное вашей службе прослушивания (Web API).

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
Класс ResourceDataModel представляет сущность (например, почта, контакт, событие), которая вызвала изменение. Это свойство навигации. 

```C#
public class ResourceDataModel
{
    public string Id { get; set; }
}
```
Класс PushSubscriptionModel представляет объект подписки. Эта возможность используется как при создании подписки, так и в как модель запросов и ответов.
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

# Контроллер Web API #
NotifyController реализует один метод POST. Как запросы на проверку, так и уведомления будут отправляться в виде POST-сообщений в ваш веб-API.

В вашем веб-API-интерфейсе будут отправлены маркеры о проверке. Если он присутствует в запросе, мы знаем,
что происходит проверка URL (веб-API). Если нет, мы можем предположить, что мы получаем уведомление от активной подписки. Таким образом, если присутствует параметр токена проверки, мы сразу же возвращаем его надлежащим образом - устанавливая заголовок типа контента в text / plain и возвращая HTTP 200 в качестве кода ответа.

Поскольку в запросе нет текущего токена проверки, мы можем начать синтаксический анализ тела запроса и искать уведомления. 

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

Рекомендую обратить внимание на заголовок состояния клиента в запросе (с именем ClientState). Если вы создаете подписку со свойством состояния клиента, она будет передана вместе с запросом уведомления. Таким образом, вы можете проверить законность уведомления.

Кроме того, в этом образце также проверяются отслеживаемые элементы (созданные события календаря), когда уведомление инициируется путем вызова API REST Outlook с использованием постоянного маркера.

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
# Файлы с исходным кодом #
Ключевыми файлами исходного кода в этом проекте являются следующие:

- `OutlookNotificationsAPI.WebAPI\Controllers\NotifyController.cs` - контроллер веб-API, содержащий один метод POST (обрабатывает как запросы проверки, так и запросы уведомлений).
- `OutlookNotificationsAPI.WebAPI\Controllers\HomeController.cs` - контроллер веб-API, содержащий действие регистрации, которое настраивает подписку на уведомления.
- `OutlookNotificationsAPI.WebAPI\Models\ResponseModel.cs` - представляет коллекцию сущностей, отправленных в запросе уведомления в службу прослушивания (Web API).
- `OutlookNotificationsAPI.WebAPI\Models\NotificationModel.cs` - представляет объект уведомления, отправляемый в службу прослушивателя (веб-API).
- `OutlookNotificationsAPI.WebAPI\Models\ResourceDataModel.cs` - представляет сущность (то есть почта, контакт, событие), которая инициировала изменение. Это свойство навигации. 
- `OutlookNotificationsAPI.WebAPI\Models\PushSubscriptionModel.cs` - представляет объект подписки. Это используется как модель запроса и ответа при создании подписки.

# Дополнительные ресурсы #
- Узнайте о разработке Office по адресу:<https://msdn.microsoft.com/en-us/office/>
- Начните работу с Microsoft Azure по адресу:<https://azure.microsoft.com/en-us/>
- Узнайте о webhooks на:<http://culttt.com/2014/01/22/webhooks/>
- Изучите API REST Outlook Notifications и его операции по адресу:<https://msdn.microsoft.com/en-us/office/office365/api/notify-rest-operations> 
- Узнайте больше об этом образце на:<http://simonjaeger.com/call-me-back-outlook-notifications-rest-api/>.

<img src="https://telemetry.sharepointpnp.com/pnp/samples/OutlookNotificationsAPI.WebAPI" />