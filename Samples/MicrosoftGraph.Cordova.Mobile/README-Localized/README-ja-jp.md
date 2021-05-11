---
page_type: sample
products:
- office-365
- office-excel
- office-planner
- office-teams
- office-outlook
- office-onedrive
- office-sp
- office-onenote
- ms-graph
languages:
- javascript
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
  services:
  - Office 365
  - Excel
  - Planner
  - Microsoft Teams
  - Outlook
  - OneDrive
  - SharePoint
  - OneNote
  platforms:
  - REST API
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Mobile
---
# Microsoft Graph を Apache Cordova および ADAL Cordova Plugin と併用するサンプル #

### 概要 ###
このサンプルでは、Microsoft Graph API で、REST API と OData を使用して Office 365 からデータを取得する方法を示しています。
このサンプルは意図的にシンプルに作成されており、
SPA フレームワーク、データバインディング ライブラリ、jQuery などは使用していません。
これは、フル機能のモバイル アプリのデモを目的としたものではありません。
同じ JavaScript コードを使用して、
さまざまな Windows プラットフォームだけでなく、Android や iOS をターゲットにすることができます。

アクセス トークンは、ADAL Cordova プラグインを使用して取得されます。これは Visual Studio のコア プラグインの1つであり、config.xml
エディターから入手できます。
これは、[接続されているサービスの追加] ウィザードの代わりに、アプリ内ブラウザーを使用してトークンを取得して、
認証エンドポイントへのユーザー リダイレクトを処理するために使用できる、ライブラリ (o365auth) などの JavaScript
ファイルを複数生成することができます。
代わりに、ADAL Cordova プラグインは、
各プラットフォームにネイティブの ADAL ライブラリを使用するので、
トークン キャッシュ機能や強化されたブラウザーなどのネイティブ機能を利用できます。

### 適用対象 ###
-  Office 365 マルチテナント (MT)
-  Microsoft Graph

### 前提条件 ###
- Visual Studio Tools for Apache Cordova (VS-TACO セットアップ オプション)
- ADAL Cordova プラグイン (cordova-plugin-ms-adal)

### ソリューション ###
ソリューション | 作成者
---------|----------
Mobile.MicrosoftGraphCordova | Bill Ayers (@SPDoctor, spdoctor.com, flosim.com)

### バージョン履歴 ###
バージョン | 日付 | コメント
---------| -----| --------
1.0 | 2016 年 3 月 15 日 | 初期リリース

### 免責事項 ###
**このコードは、明示または黙示のいかなる種類の保証なしに*現状のまま*提供されるものであり、特定目的への適合性、商品性、権利侵害の不存在についての暗黙的な保証は一切ありません。**


----------

### サンプルの実行 ###

サンプルの実行が終わったら、[データの読み込み]
ボタンをクリックします。初めて実行する場合は、アプリケーションの承認を求めるメッセージが表示されます。
これは、使い慣れた Office 365 のログイン プロンプトです。
Microsoft Graph を使用しているため、"Microsoft アカウント"
(つまり、live.com または hotmail アカウント) を使用することもできます。 

Office 365 テナントの名前を入力した場合、このアカウントに対して機能します。
テナントを空白のままにすると、"Common" エンドポイントが使用され、
実際に使用されるテナントは、
認証エンドポイントの認証に使用されるユーザーの資格情報から判断されます。

入力ボックスに有効なクエリを入力することができます
(コードが修正されないと、解析されません)。
または、ドロップダウン ボックスから選択して、事前構築済みのクエリを選択します。

![Windows 10 で実行する](MicrosoftGraphCordova.png)

トークンが取得されると、デモ目的でのみ解析され表示されます。
トークンは暗号化されていません (したがって、SSL のようにトランスポートレイヤのセキュリティが必要になります)。
言い換えれば、トークンに含まれる情報に依存するコードを記述しません。
代わりに、Api を使用します。

アクセス トークンを使用している場合は、Microsoft Graph API に REST 要求が行われ、データが表示されます。
受信されるトークンと REST エンドポイントから返されるデータの間に遅延が発生する場合があります。
ADAL ライブラリを使用して、
元の Office 365 REST エンドポイントのトークンを取得することもできますが、
このサンプル コードでは、スコープが Microsoft Graph に設定されています。

アクセス トークンの有効期間は約 1 時間であることがわかります。
トークンを使用して引き続き要求を行うことができます。
その間、有効期限が切れるまで、メッセージは表示されません。
アプリケーションを終了し、トークンがキャッシュされているために再起動した場合でも、これは動作します。
1 時間経過した後、トークンは期限切れになり、更新トークンが新しいアクセス トークンの取得に使用されます。
これにより、新しい更新トークンが生成されます。また、このプロセスは、キャッシュされた更新トークンが期限切れにならない限り、
数か月繰り返されます。

[キャッシュのクリア] ボタンをクリックすると、トークン キャッシュがクリアされます。
次回、[データの読み込み] をクリックすると、承認の確認メッセージが表示されます。 

### 舞台裏 ###

期限切れしたアクセス トークンを処理し、更新トークンを使用するキャッシュのすべての管理
(プラttフォームに依存します) は、ADAL ライブラリによって処理されます。
最初に認証コンテキストを取得し、acquireTokenSilentAsync を呼び出す現在の推奨パターンに従う必要があります。
トークンが (つまり、キャッシュから、または更新トークンを使用して) 暗黙的に取得できない場合、
"fail" コールバックは、"always"
に設定されたプロンプト動作を持つ
acquireTokenAsync を呼び出します。

```javascript

    context.acquireTokenSilentAsync(resourceUrl, appId).then(success, function () {
      context.acquireTokenAsync(resourceUrl, appId, redirectUrl).then(success, fail);
    });

```

ただし、現在のドキュメントと一部の ADAL ライブラリには、Prompt Behaviour が "auto" に設定された acquireTokenAsync があります。
つまり、必要な場合にのみユーザーにメッセージを表示します。
Cordova プラグインの設計では、acquireTokenAsync は常にメッセージを表示します。 

注:私は、残りの ADAL ライブラリが前倒しでこのパターンを採用していることを理解しています。 


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Cordova.Mobile" />