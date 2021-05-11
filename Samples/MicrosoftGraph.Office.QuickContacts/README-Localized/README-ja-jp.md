---
page_type: sample
products:
- office-outlook
- office-365
- office-sp
- ms-graph
languages:
- javascript
- nodejs
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
  services:
  - Outlook
  - Office 365
  - SharePoint
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Mobile
---
# Microsoft Graph のクイック連絡先

### 概要

このサンプルでは、Microsoft Graph を使用してモバイル デバイス上の連絡先をすばやく見つける方法を示しています。

![スクリーンショット](assets/search-results.png)

### 適用対象

- Office 365 マルチテナント (MT)

### 前提条件

- Office 365 テナント
- Azure Active Directory (AAD) のアプリ構成
    - アクセス許可
        - Office 365 SharePoint Online
            - ユーザーとしての検索クエリの実行
        - Microsoft Graph
            - ユーザーに関係する連絡先リストの読み取り (プレビュー)
            - サインインしたユーザーとしてディレクトリにアクセス
            - すべてのユーザーの基本プロファイルの読み取り
        - Windows Azure Active Directory
            - サインインとユーザー プロファイルの読み取り
    - OAuth 暗黙的フローの有効化
    
### ソリューション

ソリューション|作成者
--------|---------
MicrosoftGraph.Office.QuickContacts|Waldek Mastykarz (MVP、Rencore、@waldekm), Stefan Bauer (n8d、@StfBauer)

### バージョン履歴

バージョン|日付|コメント
-------|----|--------
1.0|2016 年 3 月 24 日|初期リリース

### 免責事項
**このコードは、明示または黙示のいかなる種類の保証なしに*現状のまま*提供されるものであり、特定目的への適合性、商品性、権利侵害の不存在についての暗黙的な保証は一切ありません。**

---

## Office のクイック連絡先

このサンプル アプリケーションは、Microsoft Graph を利用して携帯電話で関連する連絡先をすばやく検索する方法を示しています。

![Office クイック連絡先アプリケーションに表示されている見つかった連絡先](assets/search-results.png)

新しい People API を使用すると、連絡先情報を含む連絡先を検索できます。

![連絡先に表示されるクイック操作](assets/quick-actions.png)

新しい People API はフリガナ検索を使用しているので、探している人の名前が正しく入力されていなくても問題ありません。

![間違った連絡先名の検索結果](assets/typo.png)

連絡先をタップすると、追加情報にアクセスでき、連絡先が組織内にある場合は、メールへの直接リンクも取得できます。

![アプリケーションで開いている連絡先カード](assets/person-card.png)

## 前提条件

このアプリケーションを開始する前に、いくつかの構成手順を完了する必要があります。

### Azure AD アプリケーションを構成する

このアプリケーションは、Microsoft Graph を使用して関連する連絡先を検索します。Microsoft Graph にアクセスできるようにするには、対応する Azure Active Directory アプリケーションが Azure Active Directory に構成されている必要があります。次に、AAD でアプリケーションを作成して正しく構成する手順を示します。 

- Azure Active Directory で新しい Web アプリケーションを作成する
- **サインオン URL** を `https://localhost:8443` に設定する
- **クライアント ID** をコピーする (アプリケーションの構成に、必要になるため)
- **返信 URL** に `https://localhost:8443` を追加します。モバイル デバイスでアプリケーションをテストする場合は、`$ gulp serve` を使用してアプリケーションを起動した後に Browserify によって表示される**外部** URL も追加する必要があります。
- アプリケーションに次の権限を付与する:
    - Office 365 SharePoint Online
        - ユーザーとしての検索クエリの実行
    - Microsoft Graph
        - ユーザーに関係する連絡先リストの読み取り (プレビュー)
        - サインインしたユーザーとしてディレクトリにアクセス
        - すべてのユーザーの基本プロファイルの読み取り
    - Windows Azure Active Directory
        - サインインとユーザー プロファイルの読み取り
- OAuth 暗黙的フローを有効にする

### アプリケーションを構成する

アプリケーションを起動する前に、新しく作成された Azure Active Directory アプリケーションと SharePoint テナントにリンクする必要があります。両方の設定は、`app/app.config.js` ファイルで構成できます。

- このリポジトリの複製を作成する
- **appId** 定数の値として、新しく作成した AAD アプリケーションの以前にコピーした**クライアント ID** を設定する
- **sharePointUrl** 定数の値として、末尾のスラッシュを付けずに SharePoint テナントの URL を設定する (例: `https://contoso.sharepoint.com`)

## このアプリケーションを実行する

次の手順を完了して、アプリケーションを起動します。

- コマンド ラインで、
```
$ npm i && bower i
```を実行します。
- コマンド ラインで、
```
$ gulp serve
```
を実行して、アプリケーションを起動します。

![ブラウザーで起動したアプリケーション](assets/app.png) 

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office.QuickContacts" />