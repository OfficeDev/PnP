# Apache Cordova アプリの Active Directory 認証ライブラリ (ADAL) プラグイン

Active Directory 認証ライブラリ ([ADAL](https://msdn.microsoft.com/en-us/library/azure/jj573266.aspx))
プラグインを使用すると、Windows Server Active Directory と Windows Azure Active Directory を利用して Apache Cordova アプリの認証機能を簡単に使用できるようになります。こちらでライブラリのソース コードを確認できます。

  * [ADAL for Android](https://github.com/AzureAD/azure-activedirectory-library-for-android)
  * [ADAL for iOS](https://github.com/AzureAD/azure-activedirectory-library-for-objc)
  * [ADAL for .NET](https://github.com/AzureAD/azure-activedirectory-library-for-dotnet)

このプラグインは、サポートされている各プラットフォームの ADAL のネイティブ SDK を使用して、すべてのプラットフォームで 1 つの API を提供します。簡単な使用例を次に示します。

```javascript
var AuthenticationContext = Microsoft.ADAL.AuthenticationContext;

AuthenticationContext.createAsync(authority)
.then(function (authContext) {
    authContext.acquireTokenAsync(resourceUrl, appId, redirectUrl)
    .then(function (authResponse) {
        console.log("Token acquired: " + authResponse.accessToken);
        console.log("Token will expire on: " + authResponse.expiresOn);
    }, fail);
}, fail);
```

__注__: `AuthenticationContext` 同期コンストラクターも使用できます。

```javascript
authContext = new AuthenticationContext(authority);
authContext.acquireTokenAsync(resourceUrl, appId, redirectUrl).then(function (authRes) {
    console.log(authRes.accessToken);
    ...
});
```

その他の API ドキュメントについては、[サンプル アプリケーション](https://github.com/AzureAD/azure-activedirectory-library-for-cordova/tree/master/sample)と、[www](https://github.com/AzureAD/azure-activedirectory-library-for-cordova/tree/master/www) サブフォルダーに保存されている公開された機能の JSDoc を参照してください。

## サポートされるプラットフォーム

  * Android
  * iOS
  * Windows (Windows 8.0、Windows 8.1、Windows Phone 8.1)

## 既知の問題と回避策

## Windows の「クラスが登録されていません」エラー

Visual Studio 2013 を使用していて、Windows の「WinRTError: クラスが登録されていません」というランタイム エラーが表示される場合、Visual Studio [更新プログラム 5](https://www.visualstudio.com/news/vs2013-update5-vs) がインストールされていることを確認してください。

## 複数ログイン ウィンドウの問題

複数ログインのダイアログ ウィンドウが表示されるのは、`acquireTokenAsync` が複数回呼び出されていて、トークンを (最初の実行時に) 暗黙的に取得できなかった場合です。この問題を回避するには、アプリコードで [promise queuing](https://www.npmjs.com/package/promise-queue)/セマフォー ロジックを使用します。

## インストール手順

### 前提条件

* [Node.js と NPM](https://nodejs.org/)

* [Cordova CLI](https://cordova.apache.org/)

  Cordova CLI は NPM パッケージ マネージャー: `npm install -g cordova` を使用して簡単にインストールできます。

* 各ターゲット プラットフォームの追加の前提条件は、以下の [Cordova プラットフォームのドキュメント](http://cordova.apache.org/docs/en/edge/guide_platforms_index.md.html#Platform%20Guides)ページで確認できます。
 * [Android 用の手順](http://cordova.apache.org/docs/en/edge/guide_platforms_android_index.md.html#Android%20Platform%20Guide)
 * [iOS 用の手順](http://cordova.apache.org/docs/en/edge/guide_platforms_ios_index.md.html#iOS%20Platform%20Guide)
 * [Windows 用の手順] (http://cordova.apache.org/docs/en/edge/guide_platforms_win8_index.md.html#Windows%20Platform%20Guide)

### サンプル アプリケーションをビルドして実行するには

  * 選択したディレクトリにプラグイン リポジトリの複製を作成する

    `git clone https://github.com/AzureAD/azure-activedirectory-library-for-cordova.git`

  * プロジェクトを作成し、サポートするプラットフォームを追加します

    `cordova create ADALSample --copy-from="azure-activedirectory-library-for-cordova/sample"`

    `cd ADALSample`

    `cordova platform add android`

    `cordova platform add ios`

    `cordova platform add windows`

  * プラグインをプロジェクトに追加します

    `cordova plugin add ../azure-activedirectory-library-for-cordova`

  * アプリケーションをビルドして `cordova run` で実行します。


## アプリケーションを Azure AD でセットアップする

Azure AD で新しいアプリケーションをセットアップする方法の詳細については、[こちら](https://github.com/AzureADSamples/NativeClient-MultiTarget-DotNet#step-4--register-the-sample-with-your-azure-active-directory-tenant)を参照してください。

## テスト

このプラグインには、[Cordova テスト フレームワーク プラグイン](https://github.com/apache/cordova-plugin-test-framework)に基づくテスト スイートが含まれています。テスト スイートは、ルートまたはリポジトリの `tests` フォルダーにある個別のプラグインです。

[インストール手順のセクション](#installation-instructions)で説明されているように、新しいアプリケーションの作成に必要なテストを実行する手順は、次のとおりです。

  * テスト スイートをアプリケーションに追加します

    `cordova plugin add ../azure-activedirectory-library-for-cordova/tests`

  * アプリケーションの config.xml ファイルを更新し、`<content src="index.html" />` を `<content src="cdvtests/index.html" />` に変更します
  * `plugins\cordova-plugin-ms-adal\www\tests.js` ファイルの先頭にある、テスト アプリケーション用の AD 固有の設定を変更します。`AUTHORITY_URL`、`RESOURCE_URL`、`REDIRECT_URL`、`APP_ID` を Azure AD によって提供される値に更新します。Azure AD アプリケーションをセットアップする方法の詳細については、「[アプリケーションを Azure AD でセットアップする](#setting-up-an-application-in-azure-ad)」を参照してください。
  * アプリケーションをビルドし、実行します。

## Windows 互換 ##
[現在 Cordova に問題があり](https://issues.apache.org/jira/browse/CB-8615)、
回避策としてフックを使用する必要があります。回避策は修正プログラムが適用されると削除されます。

### ADFS/SSO の使用
Windows プラットフォーム (Windows Phone 8.1 が現時点でサポートされていません) で ADFS/SSO を使用するには、次の設定を追加します。`config.xml`:
`<preference name="adal-use-corporate-network" value="true" />`

既定では、`adal-use-corporate-network` は `false` です。

true にすることによって必要なすべてのアプリケーション機能が追加され、ADFS をサポートするための authContext が適用されます。`false` に変更して後で戻したり、`config.xml` から adal-use-corporate-network を削除して、変更を適用してから `cordova prepare` を呼び出すこともできます。

__注__: `adal-use-corporate-network` は機能を追加する設定なので、通常は使う必要はありません。これにより、Windows ストアでアプリが公開されなくなります。

## 著作権 ##
Copyright (c) Microsoft Open Technologies, Inc.All rights reserved.

Licensed under the Apache License, Version 2.0 (the "License"); you may not use these files except in compliance with the License.You may obtain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.See the License for the specific language governing permissions and limitations under the License.
