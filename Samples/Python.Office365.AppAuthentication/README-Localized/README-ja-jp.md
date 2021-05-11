---
page_type: sample
products:
- office-sp
- office-365
- ms-graph
languages:
- python
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
  services:
  - SharePoint
  - Office 365
  createdDate: 1/1/2016 12:00:00 AM
---
# Office 365 Python Flask アプリ認証 #

### 概要 ###
このシナリオでは、Python アプリ (Flask マイクロフレームワークを使用) と Office 365 SharePoint Online サイトの間の認証を設定する方法を示します。このサンプルの目的は、ユーザーが認証を受けて、Office 365 SharePoint サイトのデータを操作する方法を示すことです。

### 適用対象 ###
- Office 365 マルチテナント (MT)
- Office 365 専用 (D)

### 前提条件 ###
- Office 365 Developer のテナント
- Visual Studio 2015 がインストールされている
- Visual Studio 用の Python ツールがインストールされている
- Python 2.7 または 3.4 がインストールされている 
- Flask、要求、PyJWT Python パッケージが pip 経由でインストールされている

### 解決方法 ###
ソリューション | 作成者 
---------|---------- 
Python.Office365.AppAuthentication | Velin Georgiev (**OneBit Software**)、Radi Atanassov (**OneBit Software**)

### バージョン履歴 ###
バージョン | 日付 | コメント 
---------| -----| -------- 
1.0 | 2016 年 2 月 9 日 | 初期リリース (Velin Georgiev)

### 免責事項 ###
**このコードは、明示または黙示のいかなる種類の保証なしに*現状のまま*提供されるものであり、特定目的への適合性、商品性、権利侵害の不存在についての暗黙的な保証は一切ありません。**

----------

# Office 365 Python Flask アプリ認証サンプル #
このセクションでは、現在のソリューションに含まれる Office 365 Python Flask アプリ認証のサンプルについて説明します。

# Office 365 Python Flask アプリ認証サンプル用のシナリオを準備する #
Office 365 Python Flask アプリケーションは次のことを行います。

- Azure AD 承認エンドポイントを使用して認証を実行する
- Office 365 SharePoint API を使用して認証されたユーザーのタイトルを表示する

これらのタスクを成功させるには、次に説明する追加設定を行う必要があります。 

- Office 365 アカウントで Azure 試用版のアカウントを作成し、アプリを登録するか、PowerShell に登録します。このリンクでいいチュートリアルを見つけることができます。 https://github.com/OfficeDev/PnP/blob/497b0af411a75b5b6edf55e59e48c60f8b87c7b9/Samples/AzureAD.GroupMembership/readme.md
- Azure ポータルにアプリを登録し、サインオン URL と返信 URL に http://localhost:5555 を割り当てます。
- クライアント シークレットを生成します。
- Python Flask アプリに次のアクセス許可を付与します。[Office 365 SharePoint オンライン] > [委任されたアクセス許可] > [ユーザー プロファイルの読み取り]

![Azure ポータルのアクセス許可の設定](https://lh3.googleusercontent.com/-LxhYrbik6LQ/VrnZD-0Uf0I/AAAAAAAACaQ/jsUjHDQlmd4/s732-Ic42/office365-python-app2.PNG)

- クライアント シークレットとクライアント ID を Azure ポータルからコピーし、Python Flask 構成ファイルに置き換えます。
- リソース構成変数にアクセスする SharePoint サイトに URL を割り当てます。

![構成ファイル内のアプリの詳細](https://lh3.googleusercontent.com/-ETtW5MBuOcA/VrnZDQBAxQI/AAAAAAAACaY/ppp4My1JTlE/s616-Ic42/office365-python-app-config.PNG)

- Visual Studio 2015 でサンプルを開きます。
- [プロジェクト]、[プロパティ]、[デバッグ] の順に進み、ポート番号に 5555 を入力します。

![デバッグ オプションのポートの変更](https://lh3.googleusercontent.com/-M3upxeCKBN0/VrnZDSHnDoI/AAAAAAAACaA/BF4CTeKlUMs/s426-Ic42/office365-python-app-vs-config.PNG)

- [Python 環境] でアクティブな Python 環境から「Install from requirements.txt」を実行します。これにより、必要な Python パッケージがすべてインストールされます。

![メニュー オプションの選択](https://lh3.googleusercontent.com/-At6Smrxg9DQ/VrnZD6KMvfI/AAAAAAAACaM/gcgJUATPigE/s479-Ic42/office365-python-packages.png)

## Office 365 Python Flask アプリ サンプルを実行する ##
サンプルを実行すると、タイトルとログイン URL が表示されます。

![アドイン UI](https://lh3.googleusercontent.com/-GDdAcmYylZE/VrnZD8sVGwI/AAAAAAAACaI/1gB0jvULLBo/s438-Ic42/office365-python-app.PNG)


サインイン リンクをクリックすると、Office 365 API は認証ハンドシェイクを実行し、Python Flask ホーム画面が再度読み込まれ、ログインしたユーザー タイトルとアクセス トークンが表示されます。

![サインイン UI](https://lh3.googleusercontent.com/-44rsAE2uGFQ/VrnZDdJAseI/AAAAAAAACaE/70N8UX8ErIk/s569-Ic42/office365-python-app-result.PNG)

<img src="https://telemetry.sharepointpnp.com/pnp/samples/Provisioning.Office365.AppAuthentication" />