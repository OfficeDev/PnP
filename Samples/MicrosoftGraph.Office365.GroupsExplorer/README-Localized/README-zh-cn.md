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
  services:
  - Office 365
  - Groups
  - SharePoint
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Connect
---
# Office 365 API - 组资源管理器#

### 摘要 ###
此配套 Web 应用程序将列出用户租户中的所有组以及所有属性。

### 适用于 ###
-  Office 365 多租户 (MT)

### 先决条件 ###
本示例需要 2014 年 11 月发布的 Office 365 API 版本。有关详细信息，请参阅 http://msdn.microsoft.com/zh-cn/office/office365/howto/platform-development-overview。

### 解决方案 ###
解决方案 | 作者
---------|----------
Office365Api.Groups | Paul Schaeflein (Schaeflein Consulting, @paulschaeflein)

### 版本历史记录 ###
版本 | 日期 | 备注
---------| -----| --------
1.0 | 2016 年 2 月 8 日 | 初次发布

### 免责声明 ###
**此代码*按原样*提供，不提供任何明示或暗示的担保，包括对特定用途适用性、适销性或不侵权的默示担保。**


----------

# 探索 Office 365 组 API #
本示例旨在帮助查看 Office 365 组的属性和关系。有关详细信息，
请参阅 http://www.schaeflein.net/exploring-the-office-365-groups-api/ 中的博客文章。



# ASP.NET MVC 示例 #
本节介绍当前解决方案中包含的 ASP.NET MVC 示例。

## 准备 ASP.NET MVC 示例的场景 ##
ASP.NET MVC 示例应用程序将使用新的 Microsoft Graph API 来执行以下一系列任务：

-  读取当前用户的目录中的组列表
-  读取“统一”组中的对话、事件和文件
-  列出当前用户已加入的组

为了运行此 Web 应用程序，需要在开发 Azure AD 租户中注册此程序。
此 Web 应用程序使用 OWIN 和 OpenId Connect 针对位于 Office 365 租户表面之下的 Azure AD 进行身份验证。
你可以在此处找到有关 OWIN 和 OpenId Connect 的更多详细信息，以及有关在 Azure AD 租户上注册你的应用的详细信息：http://www.cloudidentity.com/blog/2014/07/28/protecting-an-mvc4-vs2012-project-with-openid-connect-and-azure-ad/ 

在 Azure AD 租户中注册应用后，必须在 web.config 文件中配置以下设置：

		<add key="ida:ClientId" value="[此处是你的 ClientID]" />
		<add key="ida:ClientSecret" value="[此处是你的 ClientSecret]" />
		<add key="ida:TenantId" value="[此处是你的 TenantId]" />
		<add key="ida:Domain" value="your_domain.onmicrosoft.com" />

# 在本示例的表面下 #
此应用程序是针对 Graph API 的测试终结点进行编码的。GroupsController 类指定每次调用的 URL：

```
string apiUrl = String.Format("{0}/beta/myorganization/groups/{1}/conversations/{2}/threads", 
                              SettingsHelper.MSGraphResourceId, 
                              id, itemId);
```

用户界面使用 Office UI Fabric (http://dev.office.com/fabric)。有一些自定义的 DisplayTemplate 视图可处理 Fabric css 所需的样式。

## 鸣谢 ##
能够提供包含 ASP.NET MVC 和 OpenID Connect 的多租户要得益于此处的 GitHub 项目：
https://github.com/Azure-Samples/active-directory-dotnet-webapp-multitenant-openidconnect

感谢 https://github.com/dstrockis 和 https://github.com/vibronet。

此处的博客文章为 Office Fabric UI 样式带来了很大帮助：http://chakkaradeep.com/index.php/using-office-ui-fabric-in-sharepoint-add-ins/

感谢 https://github.com/chakkaradeep

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.GroupsExplorer" />