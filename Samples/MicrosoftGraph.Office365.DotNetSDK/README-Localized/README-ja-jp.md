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
  - Microsoft identity platform
  services:
  - Office 365
  - Microsoft identity platform
  - SharePoint
  createdDate: 1/1/2016 12:00:00 AM
---
# .NET 用 Microsoft Graph API SDK に関するサンプル

### 概要 ###
これは、Microsoft Graph API SDK for .NET の使用方法を示すサンプル ソリューションです。
このソリューションには以下のものが含まれます。
- 新しい MSAL (Microsoft 認証ライブラリ)
プレビューを使用して新しい v2 認証エンドポイントに対して認証を行うコンソール アプリケーション
- ADAL (Azure Active Directory 認証ライブラリ)
を使用して Azure AD エンドポイントに対して認証を行う ASP.NET MVC Web アプリケーション。

このサンプルは、[Paolo Pialorsi](https://twitter.com/PaoloPia) が執筆し、Microsoft Press から発行された「[Programming Microsoft Office 365](https://www.microsoftpressstore.com/store/programming-microsoft-office-365-includes-current-book-9781509300914)」という書籍に関連したコード サンプルの一部です。

### 適用対象 ###
-  Microsoft Office 365

### ソリューション ###
ソリューション | 作成者 | Twitter
---------|-----------|--------
MicrosoftGraph.Office365.DotNetSDK.sln | Paolo Pialorsi (PiaSys.com) | [@PaoloPia](https://twitter.com/PaoloPia)

### バージョン履歴 ###
バージョン | 日付 | コメント
---------| -----| --------
1.0 | 2016 年 3 月 12 日 | 初期リリース

### セットアップの手順 ###
このサンプルを使用するには、次の操作が必要です。

-  開発者向けサブスクリプションをまだ持っていない場合は、Office 365 の[Office デベロッパー センター](http://dev.office.com/)で新規登録する
-  ClientID およびクライアント シークレットを取得するために、Web アプリケーションを [Azure AD](https://manage.windowsazure.com/) に登録する 
-  Microsoft Graph の次の委任されたアクセス許可を使用して Azure AD アプリケーションを構成する:ユーザーの基本プロファイルの表示、ユーザーのメール アドレスの表示
-  正しい設定 (ClientID、ClientSecret、Domain、TenantID) を使用して Web アプリケーションの web.config ファイルを更新する
-  新しい[アプリケーション登録ポータル](https://apps.dev.microsoft.com/)に v2 認証エンドポイントのコンソール アプリケーションを登録する 
-  正しい設定 (MSAL_ClientID) を使用してコンソール アプリケーションの .config ファイルを構成する

 
<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.DotNetSDK" />