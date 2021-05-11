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
# 适用于 .NET 的 Microsoft Graph API SDK 的相关示例

### 摘要 ###
本示例解决方案介绍如何使用适用于
.NET 的 Microsoft Graph API SDK。解决方案包括：
* 一个控制台应用程序，使用新的 MSAL（Microsoft 身份验证库）预览版对新的
v2 身份验证终结点进行身份验证
* 一个 ASP.NET MVC Web 应用程序，
使用 ADAL（Azure Active Directory 身份验证库）对 Azure AD 终结点进行身份验证

本示例是与[《Microsoft Office 365 编程》](https://www.microsoftpressstore.com/store/programming-microsoft-office-365-includes-current-book-9781509300914)一书相关的代码示例的一部分；该书由 [Paolo Pialorsi](https://twitter.com/PaoloPia) 编写，由 Microsoft Press 出版。

### 适用于 ###
-  Microsoft Office 365

### 解决方案 ###
解决方案 | 作者 | Twitter
---------|-----------|--------
MicrosoftGraph.Office365.DotNetSDK.sln | Paolo Pialorsi (PiaSys.com) | [@PaoloPia](https://twitter.com/PaoloPia)

### 版本历史记录 ###
版本 | 日期 | 备注
---------| -----| --------
1.0 | 2016 年 5 月 12 日 | 首次发布

### 设置说明 ###
为了尝试本示例，需要执行以下操作：

-  注册 Office 365 [Office 开发人员中心](http://dev.office.com/)的开发人员订阅（如果还没有）
-  在 [Azure AD](https://manage.windowsazure.com/) 中注册 Web 应用程序，以便获取 ClientID 和客户端密码 
-  使用 Microsoft Graph 的以下委派权限配置 Azure AD 应用程序：查看用户的基本个人资料、查看用户的电子邮件地址
-  使用正确的设置（ClientID、ClientSecret、Domain、TenantID）更新 Web 应用程序的 web.config 文件
-  在新的[应用程序注册门户](https://apps.dev.microsoft.com/)中注册 v2 身份验证终结点的控制台应用程序 
-  使用正确的设置 (MSAL_ClientID) 配置控制台应用程序的 .config 文件

 
<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.DotNetSDK" />