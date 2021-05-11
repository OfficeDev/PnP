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
- swift
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
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
  - iOS
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Mobile
---
# Swift を 使用した iOS 用 Microsoft Graph SDK #

### 概要 ###
聞いたことがない場合は、1 つのエンドポイントを使用して、大量の Microsoft API を簡単に呼び出すことができます。このエンドポイントは、Microsoft Graph (<https://graph.microsoft.io/>) と呼ばれ、データから、Microsoft クラウドが提供するインテリジェンスや分析情報に至るすべてにアクセスできます。

ソリューション内の異なるエンドポイントやトークンを追跡する必要はなくなりました。とても素晴らしいでしょう?この投稿は、Microsoft Graph の概要の入門編です。Microsoft Graph の変更点については、<https://graph.microsoft.io/changelog> を参照してください。

このサンプルでは、新しい Swift 言語 (<https://developer.apple.com/swift/>) を使用した単純な iOS アプリケーションでの iOS 用 Microsoft Graph SDK (<https://github.com/OfficeDev/Microsoft-Graph-SDK-iOS>) を示しています。アプリケーションでは、自分宛てにメールを送付します。目的は、Microsoft Graph とその機能について十分に理解することです。

![iPhone とメールのアプリ UI](http://simonjaeger.com/wp-content/uploads/2016/03/app.png)

ただし、iOS 用 Microsoft Graph SDK はまだプレビュー中です。条件の詳細については、https://github.com/OfficeDev/Microsoft-Graph-SDK-iOS を参照してください。

このサンプルの詳細について:<http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/>

### 適用対象 ###
-  Exchange Online
-  Office 365
-  Hotmail.com
-  Live.com
-  MSN.com
-  Outlook.com
-  Passport.com

### 前提条件 ###
Microsoft Graph の呼び出しを行うには、最初にアプリケーションを登録する必要があります。詳細については、<http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/#step-11-register-the-application-in-azure-ad> を参照してください。

Office 365 用の構築を行う際に Office 365 テナントがない場合は、<http://dev.office.com/devprogram> から開発者アカウントを取得してください。

サンプルを実行するには、マシンに Xcode をインストールする必要があります。Xcode は <https://developer.apple.com/xcode/> から入手してください。

### プロジェクト ###
プロジェクト | 作成者
---------|----------
MSGraph.MailClient | Simon Jäger (**Microsoft**)

### バージョン履歴 ###
バージョン | 日付 | コメント
---------| -----| --------
1.0 | 2016 年 3 月 9 日 | 初期リリース

### 免責事項 ###
**このコードは、明示または黙示のいかなる種類の保証なしに*現状のまま*提供されるものであり、特定目的への適合性、商品性、権利侵害の不存在についての暗黙的な保証は一切ありません。**

----------

# 使用方法 #

最初の手順として、アプリケーションを (Office 365 テナントと関連付けられている) Azure AD テナントで登録します。Azure AD テナントにアプリを登録する方法の詳細については、こちらをご覧ください。<http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/#step-11-register-the-application-in-azure-ad>

アプリケーションは Microsoft Graph にコール バックし、サインインしたユーザーの代わりメールを送るので、メールを送信する許可を与えることが重要です。

アプリケーションを Azure AD で登録するときは、**adal_settings.plist** ファイルで次の設定を構成する必要があります。
    
```xml
<plist version="1.0">
<dict>
	<key>ClientId</key>
	<string>[YOUR CLIENT ID]</string>
	<key>ResourceId</key>
	<string>https://graph.microsoft.com/</string>
	<key>RedirectUri</key>
	<string>[YOUR REDIRECT URI]</string>
	<key>AuthorityUrl</key>
	<string>[YOUR AUTHORITY]</string>
</dict>
</plist>
```

Xcode でワークスペース ファイル (**MSGraph.MailClient.xcworkspace**) を起動します。**⌘R** ショートカットを使用するか、または [**製品**] メニューの [**実行**] ボタンを押して、プロジェクトを実行します。
    
# ソース コード ファイル #
このプロジェクトの主なソース コード ファイルは、次のとおりです。

- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\MailClient.swift` \- このクラスは、ユーザーのサインイン、ユーザー プロファイルの取得、および最後にメッセージ付きのメールの送信を行います。
- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\ViewController.swift` \- これは iOS アプリの単一ビュー コントローラーです。MailClient をトリガーします。
- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\adal_settings.plist` \- これは、ADAL 構成プロパティのリスト ファイルです。このサンプルを実行する前に、必ずこのファイルで必要な設定を構成してください。

# その他のリソース #
- Office の開発について: <https://msdn.microsoft.com/en-us/office/>
- Microsoft Azure の使用の開始について: <https://azure.microsoft.com/en-us/>
- Microsoft Graph とその操作について: <http://graph.microsoft.io/en-us/> 
- このサンプルの詳細について:<http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/>


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.iOS.Swift.SendMail" />