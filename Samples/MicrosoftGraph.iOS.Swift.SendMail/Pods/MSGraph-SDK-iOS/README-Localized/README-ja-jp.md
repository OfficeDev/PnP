# iOS 用 Microsoft Graph SDK (プレビュー)

この Objective-C ライブラリを使用して、Microsoft Graph からネイティブ iOS アプリに簡単にサービスとデータを統合できます。

---

:exclamation:**注**:このコードと関連するバイナリは開発者向け*プレビュー*としてリリースされています。このライブラリは、付属する[ライセンス](/LICENSE)の条件に従って自由にお使いいただけます。このレポジトリでの問題を報告すると、非公式のサポートを得られます。

公式の Microsoft サポートの詳細については、[こちら][support-placeholder]を参照してください。

[support-placeholder]: https://support.microsoft.com/

---

このライブラリは、Vipr および Vipr-T4TemplateWriter を使用して Microsoft Graph API メタデータから生成されており、[共有のクライアント スタック][orc-for-ios]を使用しています。

[Vipr]: https://github.com/microsoft/vipr
[Vipr-T4TemplateWriter]: https://github.com/msopentech/vipr-t4templatewriter
[orc-for-ios]: https://github.com/msopentech/orc-for-ios

## クイック スタート

このライブラリをプロジェクトで使用するには、次の一般的な手順を後述する詳細に従って実行します。

1. Podfile を構成します。
2. 認証をセットアップします。
3. API クライアントを構築します。

[Podfile]: https://guides.cocoapods.org/syntax/podfile.html

### セットアップ

1. Xcode スプラッシュ画面から新しい Xcode アプリケーション プロジェクトを作成します。ダイアログ ボックスで、[iOS]、[単一ビュー アプリケーション] の順に選択します。アプリケーションには任意の名前を付けられます。ここでは、"*MSGraphQuickStart*" という名前を使用します。

2. ファイルをプロジェクトに追加します。ダイアログ ボックスから [iOS]、[その他]、[空] の順に選択し、ファイルに "`Podfile`" という名前を付けます。

3. Podfile に次の行を追加して、Microsoft Graph SDK をインポートします。

 ```ruby
 source 'https://github.com/CocoaPods/Specs.git'
 xcodeproj 'MSGraphQuickStart'
 pod 'MSGraph-SDK-iOS'
 ```

 > 注:Cocoapods についての詳細および Podfiles に関するベスト プラクティスについては、ガイド「Using Cocoapods (Cocoapods を使用する)」を参照してください。

4. XCode プロジェクトを閉じます。

5. コマンド ラインから、プロジェクトのディレクトリに移動します。次に、`pod install` を実行します。

 > 注:最初に Cocoapods をインストールします。手順は[こちら](https://guides.cocoapods.org/using/getting-started.html)で確認できます。

6. Terminal の同じ場所から、`open MSGraphQuickStart.xcworkspace` を実行して、元のプロジェクトとともに Xcode 上のインポートされたポッドが含まれているワークスペースを開きます。

---

### クライアントを認証して構築する

プロジェクトの準備が整ったら、次の手順として、依存関係マネージャーと API クライアントを初期化します。

:exclamation:アプリを Azure AD でまだ登録していない場合、この手順を完了するには、[こちらの手順][MSDN Add Common Consent]に従って登録を行う必要があります。

1. MSGraphQuickStart フォルダーを右クリックし、[New File (新しいファイル)] を選択します。 ダイアログ ボックスで、[*iOS*]、[*Resource (リソース)*]、[*Property List (プロパティ一覧)*] の順に選択します。ファイルに "`adal_settings.plist`" と名前を付けます。次のキーを一覧に追加し、その値をアプリ登録時に取得したのものに設定します。**これらは単なる例です。必ず皆様ご自身の値を使用してください。**

 |Key|Value|
|---|-----|
|ClientId|Example: e59f95f8-7957-4c2e-8922-c1f27e1f14e0|
|RedirectUri|Example: https://my.client.app/|
|ResourceId|Example: https://graph.microsoft.com|
|AuthorityUrl|https://login.microsoftonline.com/common/|

2. MSGraphQuickStart フォルダーから ViewController.m を開きます。Microsoft Graph のアンブレラ ヘッダーと ADAL 関連のヘッダーを追加します。

 ```objective-c
 #import <MSGraphService.h>
 #import <impl/ADALDependencyResolver.h>
 #import <ADAuthenticationResult.h>
 ```

3. ViewController.m のクラス拡張セクションに ADALDependencyResolver および MSGraph のプロパティを追加します。

 ```objective-c
 @interface ViewController ()
 
 @property (strong, nonatomic) ADALDependencyResolver *resolver;
 @property (strong, nonatomic) MSGraphServiceClient *graphClient;
 
 @end
 ```

4. ViewController.m ファイルの viewDidLoad メソッド内でリゾルバーとクライアントを初期化します。

 ```objective-c
 - (void)viewDidLoad {
     [super viewDidLoad];
     
    self.resolver = [[ADALDependencyResolver alloc] initWithPlist];
    
    self.graphClient = [[MSGraphServiceClient alloc] initWithUrl:@"https://graph.microsoft.com/" dependencyResolver:self.resolver];
    }
 ```

5. クライアントを使用する前に、ユーザーが少なくとも 1 回は対話型のログオンを行っていること確認する必要があります。`interactiveLogon` または `interactiveLogonWithCallback:` を使用して、ログオン シーケンスを開始できます。この演習では、最後の手順の viewDidLoad メソッドに次を追加します。

 ```objective-c
 [self.resolver interactiveLogonWithCallback:^(ADAuthenticationResult *result) {
     if (result.status == AD_SUCCEEDED) {
         [self.resolver.logger logMessage:@"Connected." withLevel:LOG_LEVEL_INFO];
     } else {
         [self.resolver.logger logMessage:@"Authentication failed." withLevel:LOG_LEVEL_ERROR];
     }
 }];
 ```

6. これで、API クライアントを安全に使用できるようになりました。

[Using Cocoapods]: https://guides.cocoapods.org/using/using-cocoapods.html
[MSDN Add Common Consent]: https://msdn.microsoft.com/en-us/office/office365/howto/add-common-consent-manually

## サンプル
- [O365-iOS-Connect] - 概要と認証 <br />
- [O365-iOS-Snippets] - API 要求と応答

[O365-iOS-Connect]: https://github.com/OfficeDev/O365-iOS-Connect
[O365-iOS-Snippets]: https://github.com/OfficeDev/O365-iOS-Snippets

## 投稿
プル要求を送信する前に、[投稿者のライセンス契約](https://cla2.msopentech.com/)に署名する必要があります。投稿者のライセンス契約 (CLA) を完了するには、ドキュメントへのリンクを含むメールを受信した際に、フォームから要求を送信し、CLA に電子的に署名する必要があります。これを行う必要があるのは、Microsoft Open Technologies のすべての OSS プロジェクトに対して 1 回のみです。

## ライセンス
Copyright (c) Microsoft, Inc.All rights reserved.Licensed under the Apache License, Version 2.0.
