---
page_type: sample
products:
- office-outlook
- office-onedrive
- office-sp
- office-365
- ms-graph
languages:
- aspx
- csharp
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Office UI Fabric
  - Azure AD
  services:
  - Outlook
  - OneDrive
  - SharePoint
  - Office 365
  createdDate: 1/1/2016 12:00:00 AM
---
# Microsoft Graph - 個人用ファイルとメールのクエリを実行する #

### 概要 ###
これは、Microsoft Graph を使用して個人的な電子メールやファイルのクエリを実行する非常に単純な ASP.NET MVC アプリケーションです。AJAX クエリを使用した情報の動的なクエリも示します。標準化されたコントロールとプレゼンテーションによる一貫したユーザー インターフェイス エクスペリエンスを提供するため、サンプルは Office UI Fabric も使用します。

### 適用対象 ###
-  Office 365 マルチテナント (MT)

### 前提条件 ###
Azure AD のアプリ構成

### ソリューション ###
ソリューション | 作成者
---------|----------
Office365Api.Graph.Simple.MailAndFiles | Vesa Juvonen

### バージョン履歴 ###
バージョン | 日付 | コメン
 ---------| -----| --------
 1.0 | 2016 年 2 月 5 日 | 初期リリース

### 免責事項 ###
**このコードは、明示または黙示のいかなる種類の保証なしに*現状のまま*提供されるものであり、特定目的への適合性、商品性、権利侵害の不存在についての暗黙的な保証は一切ありません。**

----------

# 概要 #
このサンプルでは、特定のユーザーのメールとファイルを表示するための Microsoft Graph への単純な接続を示しています。新しいアイテムがメールの受信トレイに届いたり、ユーザーの OneDrive for Business サイトに追加されたりすると、UI は UI のさまざまな部分を自動的に更新します。

![アプリ UI](http://i.imgur.com/Rt4d8Py.png)

# Azure Active Directory のセットアップ #
このサンプルを実行する前に、アプリケーションを Azure AD に登録し、Graph クエリが機能するために必要な権限を提供する必要があります。Azure Active Directory へのアプリケーション エントリを作成し、必要な権限を構成します。

- Azure Portal UI を開き、Active Directory UI に移動する (これは、書き込み時に古いポータル UI でのみ使用可能)
- 選択した**アプリケーション**に移動する
- [**追加**] をクリックして新しいアプリの作成を開始する
- [**所属組織が開発しているアプリケーションの追加**] をクリックする

![Azure AD で UI をどのようにしたいですか](http://i.imgur.com/dNtLtnl.png)

- アプリケーションに**名前**を付け、種類として [**Web アプリケーションと Web API**] を選択する

![アプリケーション UI を追加する](http://i.imgur.com/BrxalG7.png)

- デバッグ用のアプリ プロパティを次のように更新する
	- **URL** - https://localhost:44301/
	- **アプリ ID URL** - http://pnpemailfiles.contoso.local のような有効な URI - これは単なる識別子であるため、実際の有効な URL である必要はありません。

![アプリ詳細 UI](http://i.imgur.com/1IaNxLm.png)

- キーに関するページおよびセクションを**構成**するために移動する
- 生成された機密情報に対して、1 年または 2 年を選択する

![機密情報の有効期間の設定](http://i.imgur.com/7kX396J.png)

- [**保存**] をクリックし、ページから生成された機密情報を今後の使用のためにコピーする - 機密情報は、この期間中にのみ表示されるため、他の場所で保護する必要があります。

![クライアントの秘密情報](http://i.imgur.com/5vnkkTA.png)

- 権限の構成を下にスクロールする

![他のアプリケーションに対する権限](http://i.imgur.com/tF4R75w.png)

- 権限を割り当てるアプリケーションとして、Office 365 Exchange Online と Office 365 SharePoint Online を選択する

![権限の割り当て](http://i.imgur.com/XGOba3Y.png)

- Exchange Online の権限で「**ユーザー メールの読み取り**」権限を付与する

![Exchange に必要な権限の選択](http://i.imgur.com/CyH9gg2.png)

- SharePoint Online の権限で「**ユーザー ファイルの読み取り**」権限を付与する

![SharePoint に必要な権限の選択](http://i.imgur.com/NSZiHsh.png)

- [**保存**] をクリックする 

これで、Azure Active Directory 部分で必要な構成が完了しました。プロジェクトの web.config ファイルには、引き続きクライアント ID と秘密情報を構成する必要があります。クライアント ID と ClientSecret キーを正しく更新します。

![web.config の構成](http://i.imgur.com/pihBvR5.png)

# ソリューションを実行する #
Azure AD 側を構成し、環境値に基づいて web.config を更新すると、サンプルを正しく実行できます。

- Visual Studio で F5 キーを押す
- [**Office 365 に接続**] またはスイート バーの**サインイン**をクリックします。これにより、適切な Azure AD にサインインするための AAD concent UI が表示されます。

![アプリ UI](http://i.imgur.com/YMCrG4O.png)

- 適切な Azure Active Directory の資格情報でアプリケーションにサインインする

![Azure AD へのサインイン - 同意 UI](http://i.imgur.com/gNz5Wgz.png)

- アプリケーションの UI が表示される

![個人データとアプリケーション UI](http://i.imgur.com/Rt4d8Py.png)


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.Simple.MailAndFiles" />