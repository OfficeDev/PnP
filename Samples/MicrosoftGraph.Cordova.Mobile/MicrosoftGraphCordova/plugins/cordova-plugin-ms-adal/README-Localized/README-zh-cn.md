# 适用于 Apache Cordova 应用的 Active Directory 身份验证库 (ADAL) 插件

Active Directory 身份验证库 ([ADAL](https://msdn.microsoft.com/en-us/library/azure/jj573266.aspx))
插件通过利用 Windows Server Active Directory 和 Windows Azure Active Directory 为 Apache Cordova 应用提供易于使用的身份验证功能。可在此处查找库的源代码。

  * [Android 版 ADAL](https://github.com/AzureAD/azure-activedirectory-library-for-android)、
  * [iOS 版 ADAL](https://github.com/AzureAD/azure-activedirectory-library-for-objc)、
  * [适用于 .NET 的 ADAL](https://github.com/AzureAD/azure-activedirectory-library-for-dotnet)。

此插件对每个受支持的平台使用适用于 ADAL 的本机 SDK，并提供跨所有平台的单一 API。以下是快速使用示例：

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

__注意__：还可以使用 `AuthenticationContext` 同步构造函数：

```javascript
authContext = new AuthenticationContext(authority);
authContext.acquireTokenAsync(resourceUrl, appId, redirectUrl).then(function (authRes) {
    console.log(authRes.accessToken);
    ...
});
```

有关更多 API 文档，请参阅[示例应用程序](https://github.com/AzureAD/azure-activedirectory-library-for-cordova/tree/master/sample)和 JSDoc，了解存储在 [www](https://github.com/AzureAD/azure-activedirectory-library-for-cordova/tree/master/www) 子文件夹中的公开功能。

## 支持的平台

  * Android
  * iOS
  * Windows（Windows 8.0、Windows 8.1 和 Windows Phone 8.1）

## 已知问题和解决方法

## Windows 上的“类未注册”错误

如果你使用的是 Visual Studio 2013，并且在 Windows 上看到“WinRTError：类未注册”运行时错误，请确保已安装 Visual Studio [Update 5](https://www.visualstudio.com/news/vs2013-update5-vs)。

## 多个登录窗口问题

如果多次调用 `acquireTokenAsync`，并且无法以静默方式获取令牌（例如在第一次运行时），将显示多个登录对话框窗口。在应用代码中使用[承诺队列](https://www.npmjs.com/package/promise-queue)/信号量逻辑可避免此问题。

## 安装说明

### 先决条件

* [NodeJS 和 NPM](https://nodejs.org/)

* [Cordova CLI](https://cordova.apache.org/)

  可通过 NPM 程序包管理器轻松安装 Cordova CLI：`npm install -g cordova`

* 可以在“[Cordova 平台文档](http://cordova.apache.org/docs/en/edge/guide_platforms_index.md.html#Platform%20Guides)”页面上找到每个目标平台的其他先决条件：
 * [适用于 Android 的说明](http://cordova.apache.org/docs/en/edge/guide_platforms_android_index.md.html#Android%20Platform%20Guide)
 * [适用于 iOS 的说明](http://cordova.apache.org/docs/en/edge/guide_platforms_ios_index.md.html#iOS%20Platform%20Guide)
 * [适用于 Windows 的说明] (http://cordova.apache.org/docs/en/edge/guide_platforms_win8_index.md.html#Windows%20Platform%20Guide)

### 构建并运行示例应用程序

  * 将插件存储库克隆到所选目录中

    `git clone https://github.com/AzureAD/azure-activedirectory-library-for-cordova.git`

  * 创建项目并添加希望支持的平台

    `cordova create ADALSample --copy-from="azure-activedirectory-library-for-cordova/sample"`

    `cd ADALSample`

    `cordova platform add android`

    `cordova platform add ios`

    `cordova platform add windows`

  * 将插件添加到你的项目

    `cordova plugin add ../azure-activedirectory-library-for-cordova`

  * 构建并运行应用程序：`cordova run`。


## 在 Azure AD 中设置应用程序

可在[此处](https://github.com/AzureADSamples/NativeClient-MultiTarget-DotNet#step-4--register-the-sample-with-your-azure-active-directory-tenant)找到有关如何在 Azure AD 中设置新应用程序的详细说明。

## 测试

此插件包含基于 [Cordova 测试框架插件](https://github.com/apache/cordova-plugin-test-framework)的测试套件。该测试套件位于根目录或存储库中的 `tests` 文件夹下，代表一个单独的插件。

若要运行测试，你需要按照[安装说明部分](#installation-instructions)中的说明创建一个新应用程序，然后执行以下步骤：

  * 为应用程序添加测试套件

    `cordova plugin add ../azure-activedirectory-library-for-cordova/tests`

  * 更新应用程序的 config.xml 文件：将 `<content src="index.html" />` 更改为 `<content src="cdvtests/index.html" />`
  * 在 `plugins\cordova-plugin-ms-adal\www\tests.js` 文件的开头处更改测试应用程序的 AD 特定设置。将 `AUTHORITY_URL`、`RESOURCE_URL`、`REDIRECT_URL` 和 `APP_ID` 更改为由 Azure AD 提供的值。有关如何设置 Azure AD 应用程序的说明，请参阅[“在 Azure AD 中设置应用程序”部分](#setting-up-an-application-in-azure-ad)。
  * 构建并运行应用程序。

## Windows Quirks ##
[当前有一个 Cordova 问题](https://issues.apache.org/jira/browse/CB-8615)，
这必然需要基于挂钩的解决方法。应用修补程序后，将放弃该解决方法。

### 使用 ADFS/SSO
若要在 Windows 平台上使用 ADFS/SSO（目前不支持 Windows Phone 8.1），请将以下首选项添加到 `config.xml`：
`<preference name="adal-use-corporate-network" value="true" />`

默认情况下，`adal-use-corporate-network` 为 `false`。

它将添加所有需要的应用程序功能并切换 authContext 以支持 ADFS。你可以将其值更改为 `false` 并稍后再返回，或将其从 `config.xml` 中删除 - 在应用更改后调用 `cordova prepare`。

__注意__：通常情况下，不应使用 `adal-use-corporate-network`，因为它会添加功能，这会阻止在 Windows 应用商店中发布应用。

## 版权信息 ##
版权所有 (c) Microsoft Open Technologies, Inc.保留所有权利。

按照 Apache 许可 2.0 版本（称为“许可”）授予许可；要使用这些文件，必须遵循“许可”中的说明。你可以从以下网站获取许可的副本

http://www.apache.org/licenses/LICENSE-2.0

除非适用法律要求或书面同意，根据“许可”分配的软件“按原样”分配，不提供任何形式（无论是明示还是默示）的担保和条件。参见“许可”了解“许可”中管理权限和限制的指定语言。
