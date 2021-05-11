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
# 将 Microsoft Graph 与 Apache Cordova 和 ADAL Cordova 插件结合使用的示例 #

### 概述 ###
本示例演示如何使用 Microsoft Graph API 从使用 REST API 和 OData 的 Office 365 中检索数据。
示例很简单，且不使用任何 SPA 框架、数据绑定库、
jQuery 等。它不是为了演示功能齐全的移动应用。
你可以使用相同的 JavaScript
代码设定各种 Windows 平台，
以及 Android 和 iOS。

使用 ADAL Cordova 插件获取访问令牌。
这是 Visual Studio 中的核心插件之一，
可从 config.xml 编辑器中获得。
这是“添加已连接服务”向导的替代方法，该向导可生成许多JavaScript 文件，
包括可用于获取令牌的库 (o365auth.js)，
这些令牌使用应用内浏览器来处理向授权终结点的用户重定向。
相反，ADAL Cordova 插件为每个平台使用本机 ADAL 库，
因此能够利用本机功能，例如令牌缓存和强化的浏览器。

### 适用于 ###
-  Office 365 多租户 (MT)
-  Microsoft Graph

### 先决条件 ###
- 适用于 Apache Cordova 的 Visual Studio 工具（VS-TACO 设置选项）
- ADAL Cordova 插件 (cordova-plugin-ms-adal)

### 解决方案 ###
解决方案 | 作者
---------|----------
Mobile.MicrosoftGraphCordova | Bill Ayers (@SPDoctor, spdoctor.com, flosim.com)

### 版本历史记录 ###
版本 | 日期 | 批注
---------| -----| --------
1.0 | 2016 年 3 月 15 日| 初始发行版

### 免责声明 ###
**此代码*按原样提供*，不提供任何明示或暗示的担保，包括对特定用途适用性、适销性或不侵权的默示担保。**


----------

### 运行示例 ###

运行示例时，可单击“加载数据”按钮。
如果是首次运行它，系统将提示你对该应用程序授权。
这是熟悉的 Office 365 登录提示。
由于我们使用的是 Microsoft Graph，
因此也可以使用“Microsoft 帐户”（即 live.com 或 hotmail 帐户）。 

如果你输入了 Office 365 租户名称，
它将对此帐户有效。如果将租户留空，
则使用“常用”终结点，
实际使用的租户由用于对授权终结点进行身份验证的用户凭据确定。

你可以在输入框中输入有效的查询（尽管并非所有查询都可在不修改代码的情况下解析）。
或者，也可以从下拉框中选择，
然后选择预建查询。

![在 Windows 10 上运行](MicrosoftGraphCordova.png)

获得令牌后，将仅出于演示目的对其进行分析和显示。
该令牌未经过加密（因此需要 SSL 之类的传输层安全性），
但是应将其视为不透明的令牌，换句话说，
不要编写依赖于令牌中包含的信息的代码 - 而是使用 API。

使用访问令牌，向 Microsoft Graph API 发出 REST 请求，
并显示数据。你可能注意到接收令牌与从 REST 终结点返回数据之间存在延迟。
请注意，也可以使用 ADAL 库获取原始 Office 365 REST 终结点的令牌，
但是在示例代码中，
作用域已设置为 Microsoft Graph。

你可以看到，访问令牌的生存期约为 1 小时。
你可以继续使用令牌发出更多请求，直到令牌过期而没有其他提示。
即使关闭应用程序并再次启动它，也可以使用此令牌，因为它已缓存。
1 小时后，令牌将到期，
并且会使用刷新令牌获取新的访问令牌。
这也会生成一个新的刷新令牌，并且此过程可重复几个月，
前提是刷新令牌（也会缓存）不会过期。

如果单击“清除缓存”按钮，将清除令牌缓存。
当你下次单击“加载数据”时，将显示授权提示。 

### 后台 ###

由 ADAL 库处理所有缓存管理（与平台相关），
这涉及处理过期的访问令牌和使用刷新令牌。
你只需获取身份验证上下文并按照当前建议的模式
（即先调用 acquireTokenSilentAsync）进行操作。
如果无法以静默方式获取令牌（即从缓存中或使用刷新令牌），
则“失败”回调随后会调用其提示行为设置为“始终”的
acquireTokenAsync。

```javascript

    context.acquireTokenSilentAsync(resourceUrl, appId).then(success, function () {
      context.acquireTokenAsync(resourceUrl, appId, redirectUrl).then(success, fail);
    });

```

虽然当前文档和某些 ADAL 库已将
acquireTokenAsync 的提示行为设置为“自动”（这意味着仅在必要时才提示用户），
但 Cordova 插件的设计是，acquireTokenAsync 将始终提示。 

注意：我知道其余的 ADAL 库将继续采用这种模式。 


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Cordova.Mobile" />