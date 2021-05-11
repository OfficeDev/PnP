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
# ASP.NET Web API を使用した Outlook 通知 REST API #

### 概要 ###
これは ASP.NET Web API プロジェクトのサンプルで、Outlook 通知 REST API を使用して作成された Outlook 通知を検証してそれに応答します。このサンプルでは、永続トークンを使用して Outlook REST API を呼び出して行う、通知のサブスクリプション、通知 URL の検証、監視対象エンティティの検査の概念を説明します。

Outlook 通知 REST API とその操作の詳細については、次を参照してください: <https://msdn.microsoft.com/en-us/office/office365/api/notify-rest-operations>

イベント主導型のこの手法を使用することにより、Outlook のリソースとエンティティの変更をより確実に処理することができます。Outlook REST API を直接ポーリングするのに比べ、より軽量な方法です (アイテム数が多い場合は特にそうです)。規模が大きい場合、このアプローチは持続可能なサービス アーキテクチャのために不可欠です。

![アドイン UI と Office 365 から受信したトークンの詳細](http://i.imgur.com/r3rNNGV.png)

このサンプルの詳細については、次を参照してください: <http://simonjaeger.com/call-me-back-outlook-notifications-rest-api>

### 適用対象 ###
-  Exchange Online
-  Office 365
-  Hotmail.com
-  Live.com
-  MSN.com
-  Outlook.com
-  Passport.com

### 前提条件 ###
Outlook 通知 REST API は複数のサービスで利用できます。Outlook 通知 REST API の呼び出しを行うには、最初にアプリを登録する必要があります。詳細については、次を参照してください: <https://dev.outlook.com/RestGettingStarted>

Office 365 用の構築を行う際に Office 365 テナントがない場合は、開発者アカウントを取得してください: <http://dev.office.com/devprogram>

最後に、Web API をホスティングして展開する必要があります (Microsoft Azure 上の Web アプリに対してなど: <https://azure.microsoft.com/en-us/documentation/scenarios/web-app/>)。

### ソリューション ###
ソリューション | 作成者
---------|----------
OutlookNotificationsAPI.WebAPI | Simon Jäger (**Microsoft**)

### バージョン履歴 ###
バージョン | 日付 | コメント
---------| -----| --------
1.2 | 2016 年 1 月 18 日 | (永続トークンを使用した)Outlook REST API コールバック
1.1 を追加 | 2016 年 1 月 13 日 | サブスクリプション
1.0 を登録する UI を追加 | 2015 年 12 月 12 日 | 最初のリリース

### 免責事項 ###
**このコードは、明示または黙示のいかなる種類の保証なしに*現状のまま*提供されるものであり、特定目的への適合性、商品性、権利侵害の不存在についての暗黙的な保証は一切ありません。**

----------

# 使用方法 #
最初の手順として、Web API を作成していずれかの場所にホストします。Microsoft が通知を Web API に送信するには、Web API が展開され、Outlook 通知 REST API によって検証される必要があります。検証は、単純です。(サブスクリプションを作成ることにより) Web API に通知を送信するように Outlook 通知 REST API に求めると、検証トークンが Web API に送信されます。 

Web API は同じ検証トークンを使用して 5 秒以内に応答する必要があります。これが達成された場合、通知のサブスクリプションが作成され、クライアント アプリケーションに返され (サブスクリプションが作成され) ます。

#### Azure AD で登録する ####

最初の手順として、 Web アプリケーションを (Office 365 テナントと関連付けられている) Azure AD テナントで登録します。Web アプリケーションでは、認証と承認の処理に OWIN と OpenID Connect が使用されています。OWIN と OpenId Connect の詳細および Azure AD テナントでアプリを登録する方法については、次を参照してください: <http://www.cloudidentity.com/blog/2014/07/28/protecting-an-mvc4-vs2012-project-with-openid-connect-and-azure-ad/>

アプリケーションは Office 365 へのコール バックを行うことから、ユーザーの予定表の読み取りアクセス許可をアプリケーションに付与することが重要です。

Web アプリケーションを Azure AD で登録するときは、Web.config ファイルで次の設定を構成する必要があります。

    <add key="ida:ClientId" value="[アプリケーションのクライアント ID]" />
    <add key="ida:ClientSecret" value="[アプリケーションのクライアント シークレット]" />
    <add key="ida:Domain" value="[組織のドメイン]" />
    <add key="ida:TenantId" value="[組織のテナント ID]" />
    <add key="ida:PostLogoutRedirectUri" value="[ログアウト後のリダイレクト URI]" />
    
#### 展開 ####

Web API をホスティング プロバイダーに展開します。たとえば、Web アプリを Microsoft Azure 上に展開できます: <https://azure.microsoft.com/en-us/documentation/scenarios/web-app/>サブスクリプションとトークンの情報はデータベースで管理されるため、このアプリケーションでは SQL Azure サーバーが要求される点に注意してください。新しい Web アプリと + DB サーバーを発行するために、Visual Studio の発行ウィザードを使用できます。.Web アプリを既に作成している場合、または既存の SQL Azure データベース サーバーを使用する場合は、Web アプリから発行プロファイルをダウンロードし、発行ウィザードでそれを使用します。また、下に示すように、既存の SQL Azure サーバーにポイントするようにデータベース接続文字列を設定します。

```XML
<add name="DefaultConnection" connectionString="Data Source=tcp:<sqlazuredbserver>.database.windows.net;Initial Catalog=OutlookNotifications;User ID=user@<sqlazuredbserver>;Password=*****" providerName="System.Data.SqlClient" />
```

サンプルをホスティング プロバイダーに展開したら、Web API (NotifyController) でのフローをキャッチして検証するためのブレークポイントを構成します。検証が行われると通知が送信され、応答を調査できるようになります。

Visual Studio 2015 を使用して、Azure Web アプリにデバッガーを添付できます (次を参照してください: <https://azure.microsoft.com/sv-se/documentation/articles/web-sites-dotnet-troubleshoot-visual-studio/#remotedebug>)。

**注: リモート デバッグを使用している場合、通知 URL を検証するときに、遅延が原因となり 5 秒の応答時間を超えてしまう場合があります。**

ホストされているサンプルに移動し、[サブスクリプションを登録する] ボタンをクリックして通知の受信を開始します。

# 応答モデル #
このサンプルにより、いくつかの応答モデルが実装されます。これらのモデルは、通知要求を処理 (受け取った JSON の解析) するときに役立ちます。ここに記載されているのは、サンプルで使用されている主な応答モデルです。 

汎用の ResponseModel クラスは、応答自体のメインのコンテナーです。このサンプルでは、NotificationModel クラスのコレクションがこれに含まれています。

```C#
public class ResponseModel<T>
{
    public List<T> Value { get; set; }
}
```
NotificationModel クラスは、リスナー サービス (Web API) に送信される通知を表します。

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
ResourceDataModel クラスは、変更をトリガーしたエンティティ (つまり、メール、連絡先、イベント) を表します。これはナビゲーションのプロパティです。 

```C#
public class ResourceDataModel
{
    public string Id { get; set; }
}
```
PushSubscriptionModel クラスは、サブスクリプション エンティティを表します。これは、サブスクリプションの作成時に要求と応答モデルの両方として使用されます。
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

# Web API コントローラー #
NotifyController では、単一の POST メソッドが実装されます。検証要求と通知要求の両方が POST メッセージとして Web API に送信されます。

検証トークンの場合、アプリは省略可能なパラメーターとして検証トークンを受け入れます。
検証トークンが要求に含まれている場合は、URL の検証 (Web API) が実行されていることを示します。含まれていない場合は、アクティブなサブスクリプションから通知を受信していると考えられます。そのため、検証トークンのパラメーターが存在する場合は、コンテンツ タイプ ヘッダーを text/plain に設定し、応答コードとして HTTP 200 を返すことで、直ちに正しい方法で返します。

要求に検証トークンがない場合は、要求の本文の解析を開始し、通知を探します。 

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

クライアント状態のヘッダー ("ClientState" という名前です) に注意を払うことをお勧めします。クライアント状態プロパティを使用してサブスクリプションを作成した場合、そのプロパティは通知要求と共に渡されます。こうすることで、通知の正当性を確認できます。

また、このサンプルでは、通知がトリガーされると、永続トークンを使用して Outlook REST API を呼び出すことにより、監視対象のアイテム (作成された予定表イベント) の調査も行います。 

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
# ソース コード ファイル #
このプロジェクトの主なソース コード ファイルは、次のとおりです。

- `OutlookNotificationsAPI.WebAPI\Controllers\NotifyController.cs` \- 単一の POST メソッドが含まれている Web API コントローラー (検証と通知要求の両方を処理します)。
- `OutlookNotificationsAPI.WebAPI\Controllers\HomeController.cs` \- 通知用にサブスクリプションを構成する登録アクションが含まれている Web API コントローラー。
- `OutlookNotificationsAPI.WebAPI\Models\ResponseModel.cs` \- リスナー サービス (Web API) への通知要求で送信されるエンティティのコレクションを表します。
- `OutlookNotificationsAPI.WebAPI\Models\NotificationModel.cs` \- リスナー サービス (Web API) に送信される通知エンティティを表します。
- `OutlookNotificationsAPI.WebAPI\Models\ResourceDataModel.cs` \- 変更をトリガーしたエンティティ (つまり、メール、連絡先、イベント) を表します。これはナビゲーションのプロパティです。 
- `OutlookNotificationsAPI.WebAPI\Models\PushSubscriptionModel.cs` \- サブスクリプション エンティティを表します。これは、サブスクリプションの作成時に要求および応答モデルの両方として使用されます。

# その他のリソース #
- Office の開発について: <https://msdn.microsoft.com/en-us/office/>
- Microsoft Azure の使用を開始する: <https://azure.microsoft.com/en-us/>
- Webhook について: <http://culttt.com/2014/01/22/webhooks/>
- Outook 通知 REST API とその操作を確認する: <https://msdn.microsoft.com/en-us/office/office365/api/notify-rest-operations> 
- このサンプルの詳細:<http://simonjaeger.com/call-me-back-outlook-notifications-rest-api/>

<img src="https://telemetry.sharepointpnp.com/pnp/samples/OutlookNotificationsAPI.WebAPI" />