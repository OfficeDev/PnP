---
page_type: sample
products:
- office-365
- office-sp
- ms-graph
languages:
- aspx
- csharp
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
  services:
  - Office 365
  - Groups
  - SharePoint
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Connect
---
# Office 365 API - グループ エクスプローラー #

### 概要 ###
コンパニオン Web アプリケーションに、すべてのプロパティとともに、ユーザーのテナント内のすべてのグループが一覧表示されます。

### 適用対象 ###
-  Office 365 マルチテナント (MT)

### 前提条件 ###
このサンプルには、2014 年 11 月にリリースされた Office 365 API バージョンが必要です。詳細については、http://msdn.microsoft.com/en-us/office/office365/howto/platform-development-overview を参照してください。

### 解決方法 ###
ソリューション | 作成者
---------|----------
Office365Api.Groups | Paul Schaeflein (Schaeflein Consulting、@paulschaeflein)

### バージョン履歴 ###
バージョン | 日付 | コメント
---------| -----| --------
1.0 | 2016 年 2 月 8 日 | 初期リリース

### 免責事項 ###
**このコードは、明示または黙示のいかなる種類の保証なしに*現状のまま*提供されるものであり、特定目的への適合性、商品性、権利侵害の不存在についての暗黙的な保証は一切ありません。**


----------

# Office 365 グループ API について理解する #
このサンプルは、Office 365 グループのプロパティおよびリレーションシップの確認を支援するために提供されています。
詳細については、http://www.schaeflein.net/exploring-the-office-365-groups-api/ のブログ投稿をご覧ください。



# ASP.NET MVC のサンプル #
このセクションでは、現在のソリューションに含まれている ASP.NET MVC のサンプルについて説明します。

## ASP.NET MVC のサンプル用のシナリオを準備する ##
ASP.NET MVC のサンプル アプリケーションは、新しい Microsoft Graph API を使用して、次のタスクのリストを実行します。

-  現在のユーザーのディレクトリ内のグループの一覧を読み取る
-  "統合された" グループの会話、イベント、ファイルを読み取る
-  現在のユーザーが参加しているグループを一覧表示する

Web アプリケーションを実行するには、開発用 Azure AD テナントに登録する必要があります。
Web アプリケーションは、OWIN と OpenId Connect を使用して、Office 365 テナントを装っている Azure AD に対して認証を行います。
OWIN と OpenId Connect の詳細および Azure AD テナントでアプリを登録する方法については、次を参照してください: http://www.cloudidentity.com/blog/2014/07/28/protecting-an-mvc4-vs2012-project-with-openid-connect-and-azure-ad/ 

Azure AD テナントでアプリを登録した後、Web.config ファイルで次の設定を構成する必要があります。

		<add key="ida:ClientId" value="[Your ClientID here]" />
		<add key="ida:ClientSecret" value="[Your ClientSecret here]" />
		<add key="ida:TenantId" value="[Your TenantId here]" />
		<add key="ida:Domain" value="your_domain.onmicrosoft.com" />

# サンプルを装って #
アプリケーションは、Graph API のベータ版エンドポイントに対してコーディングされます。GroupsController クラスは、各呼び出しの URL を指定します。

```
string apiUrl = String.Format("{0}/beta/myorganization/groups/{1}/conversations/{2}/threads", 
                              SettingsHelper.MSGraphResourceId, 
                              id, itemId);
```

ユーザーインターフェイスは、Office UI Fabric (http://dev.office.com/fabric) を使用します。Fabric CSS に必要なスタイル設定を処理するカスタム DisplayTemplate ビューがいくつかあります。

## 開発者情報 ##
ASP.NET MVC および OpenID Connect のマルチテナント機能は、こちらで利用可能な GitHub プロジェクトのおかげで提供されています:
https://github.com/Azure-Samples/active-directory-dotnet-webapp-multitenant-openidconnect

開発者情報は、https://github.com/dstrockis および https://github.com/vibronet をご覧ください。

Office Fabric UI のスタイル設定は、こちらのブログ投稿によって支援されました: http://chakkaradeep.com/index.php/using-office-ui-fabric-in-sharepoint-add-ins/

開発者情報は、https://github.com/chakkaradeep をご覧ください。

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.GroupsExplorer" />