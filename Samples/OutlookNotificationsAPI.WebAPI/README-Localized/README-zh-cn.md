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
# 带 ASP.NET Web API 的 Outlook 通知 REST API #

### 摘要 ###
这是 ASP.NET Web API 项目验证和响应 Outlook 通知（通过 Outlook 通知 REST API 而创建）的一个示例。本示例涵盖了订阅通知、验证通知 URL 和检查监视实体的概念，这一系列操作通过调用 Outlook REST API 使用持久令牌完成。

可在以下位置了解有关 Outlook 通知 REST API 及其操作的详细信息： <https://msdn.microsoft.com/en-us/office/office365/api/notify-rest-operations>

使用此事件驱动的方法是一种更可靠的方式，可在 Outlook 中处理资源和实体中的更改。与直接投票 Outlook REST Api 相比，这种方法更加轻便（尤其是当项目量很大时）。借助 "规模"，此方法对可持续服务体系结构至关重要。

![加载项 UI 和有关从 Office 365 接收的令牌的详细信息](http://i.imgur.com/r3rNNGV.png)

关于此示例的更多信息，请访问：<http://simonjaeger.com/call-me-back-outlook-notifications-rest-api>

### 适用于 ###
-  Exchange Online
-  Office 365
-  Hotmail.com
-  Live.com
-  MSN.com
-  Outlook.com
-  Passport.com

### 先决条件 ###
Outlook 通知 REST API 可用于多个服务。你将需要注册你的应用，然后才能向 Outlook Notifcations REST API 进行任何调用。需要更多信息，请访问：<https://dev.outlook.com/RestGettingStarted>

如果您是针对 Office 365 构建的，而你缺少 Office 365 租户，请在以下位置获得开发人员帐户： <http://dev.office.com/devprogram>

最后，需要托管和部署 Web API，例如 Microsoft Azure 上的 web 应用： <https://azure.microsoft.com/en-us/documentation/scenarios/web-app/>。

### 解决方案 ###
解决方案 | 作者
---------|----------
OutlookNotificationsAPI.WebAPI | Simon Jäger (**Microsoft**)

### 版本历史记录 ###
版本 |日期 |批注
---------|-----|--------
1.2 | 2016 年 1 月 18 日 |已添加 Outlook REST API 回调（使用持久性标记）
1.1 | 2016 年 1 月 13 日 |添加了用于注册订阅的 UI
1.0 | 2015 年 12 月 12 日 |初始发布

### 免责声明 ###
**此代码*按原样提供*，不提供任何明示或暗示的担保，包括对特定用途适用性、适销性或不侵权的默示担保。**

----------

# 如何使用 #
第一步是在某处创建并托管您的 Web API：它需要由 Outlook 通知 REST API 部署和验证，然后才能获取发送的通知。从验证的角度来看，它相当直截了当。当我们请求 Outlook 通知 REST API 开始向 Web API 发送通知（通过创建订阅）时，它会继续并向其发送验证令牌。 

Web API 需要在 5 秒内响应同一验证令牌（如果可以实现），则将创建通知的订阅并返回到客户端应用程序（创建订阅）。

#### 在 Azure AD 中注册 ####

第一步是在 Azure AD 租户（与 Office 365 租户相关联）中注册 web 应用程序。该 Web 应用程序使用 OWIN 和 OpenID Connect 来处理身份验证和授权。您可以在此处找到有关 OWIN 和 OpenId Connect 的更多详细信息，以及有关在 Azure AD 租户上注册您的应用程序的详细信息：<http://www.cloudidentity.com/blog/2014/07/28/protecting-an-mvc4-vs2012-project-with-openid-connect-and-azure-ad/>

由于应用程序正回调到 Office 365 中，因此授予其读取用户日历的权限非常重要。

在 Azure AD 中注册 web 应用程序后，必须在 web.config 文件中配置以下设置：

    <add key="ida:ClientId" value="[应用程序客户端 ID]" />
    <add key="ida:ClientSecret" value="[应用程序客户端密码]" />
    <add key="ida:Domain" value="[您的域]" />
    <add key="ida:TenantId" value="[您的租户 ID]" />
    <add key="ida:PostLogoutRedirectUri" value="[注销后重定向 URI]" />
    
#### 部署 ####

将 Web API 部署到托管提供商（例如 Microsoft Azure 上的 web 应用）： <https://azure.microsoft.com/en-us/documentation/scenarios/web-app/>。请注意，由于订阅和令牌信息在数据库中维护，此应用程序需要 SQL Azure 服务器。可使用 Visual Studio 中的发布向导，并发布新的 web 应用 + DB 服务器。如果你已创建 web 应用或想要使用现有 SQL Azure 数据库服务器，则需要从 web 应用下载发布配置文件，并将其用于发布向导。此外，请确保将数据库连接字符串设置为指向你的现有 SQL Azure 服务器，如下所示：

```XML
<add name="DefaultConnection" connectionString="Data Source=tcp:<sqlazuredbserver>.database.windows.net;Initial Catalog=OutlookNotifications;User ID=user@<sqlazuredbserver>;Password=*****" providerName="System.Data.SqlClient" />
```

将示例部署到托管提供商后，配置一个断点来捕捉和验证 Web API 中的流 (NotifyController)。验证发生后，你将收到通知，并能够调查响应。

可使用 Visual Studio 2015 将调试器附加到 Azure web 应用（请参阅 <https://azure.microsoft.com/sv-se/documentation/articles/web-sites-dotnet-troubleshoot-visual-studio/#remotedebug>）

**请注意：如果使用远程调试，延迟可能会导致在验证通知 URL 时中断 5 秒钟的响应时间。**

导航到托管示例，然后单击“注册订阅”按钮以开始获取通知。

# 响应模式 #
示例实现了几种响应模型。它们用于帮助在处理通知请求时（分析收到的 JSON）。下面列出了示例中使用的关键响应模型。 

通用 ResponseModel 类是响应自身的主容器。在示例中，它将包含 NotificationModel 类的集合。

```C#
public class ResponseModel<T>
{
    public List<T> Value { get; set; }
}
```
NotificationModel 类表示发送到监听器服务 (Web API) 的通知.

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
ResourceDataModel 类代表引起改变的实体（即邮件、联系人、事件）。这是一种导航属性。 

```C#
public class ResourceDataModel
{
    public string Id { get; set; }
}
```
PushSubscriptionModel 类表示订阅实体。该操作在创建订阅时用作请求和响应模型。
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

# Web API 控制器 #
NotifyController 实现一个 POST 方法。验证和通知请求都将作为 POST 邮件发送到 Web API。

对于验证令牌，会将其作为可选参数接受。如果请求中存在验证令牌，则知道正在验证该 URL (Web API)。
如果没有，我们可以假设我们正在从活动订阅收到通知。因此，如果存在验证令牌参数，则可以通过将内容类型标头设置为 text/plain 来立即返回，然后将 HTTP 200 作为响应代码返回。

正如在请求中不存在验证令牌一样，我们可以开始分析请求正文并查找通知。 

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

我建议你注意请求中的客户状态标头（名为 ClientState）。如果使用客户状态属性创建订阅，该订阅将与通知请求一起传递。通过这种方式，可验证通知的合法性。

此外，如果通过使用永久令牌调用 Outlook REST API 触发通知，则此示例还会检查受监视的项目（已创建日历事件）。

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
# 源代码文件 #
此项目中的主要源代码文件如下所示：

- `OutlookNotificationsAPI.WebAPI\Controllers\NotifyController.cs` ——包含单个 POST 方法的 Web API 控制器（同时处理验证和通知请求）。
- `OutlookNotificationsAPI.WebAPI\Controllers\HomeController.cs` —— 包含配置通知订阅注册操作的 Web API 控制器。
- `OutlookNotificationsAPI.WebAPI\Models\ResponseModel.cs` ——表示在通知请求中发送到您的侦听器服务 (Web API) 的实体的集合。
- `OutlookNotificationsAPI.WebAPI\Models\NotificationModel.cs` ——表示发送到您的侦听器服务 (Web API) 的通知实体。
- `OutlookNotificationsAPI.WebAPI\Models\ResourceDataModel.cs` —— 表示引起改变的实体（例如：邮件、联系人、事件）。这是一种导航属性。 
- `OutlookNotificationsAPI.WebAPI\Models\PushSubscriptionModel.cs` —— 表示订阅实体。该操作在创建订阅时用作请求和响应模型。

# 更多资源 #
- 关于 Office 的开发情况，请访问：<https://msdn.microsoft.com/en-us/office/>
- Microsoft Azure 入门指南：<https://azure.microsoft.com/en-us/>
- 关于 webhooks，请访问：<http://culttt.com/2014/01/22/webhooks/>
- 可在以下位置了解有关 Outlook 通知 REST API 及其操作的详细信息： <https://msdn.microsoft.com/en-us/office/office365/api/notify-rest-operations> 
- 关于此示例的更多信息，请访问：<http://simonjaeger.com/call-me-back-outlook-notifications-rest-api/>

<img src="https://telemetry.sharepointpnp.com/pnp/samples/OutlookNotificationsAPI.WebAPI" />