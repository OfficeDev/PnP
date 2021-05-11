---
page_type: sample
products:
- office-outlook
- office-onedrive
- office-sp
- office-365
- ms-graph
languages:
- aspx
- csharp
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Office UI Fabric
  - Azure AD
  services:
  - Outlook
  - OneDrive
  - SharePoint
  - Office 365
  createdDate: 1/1/2016 12:00:00 AM
---
# Microsoft Graph - 查询个人文件和电子邮件 #

### 摘要 ###
这是一个非常简单的 ASP.net MVC 应用程序，它使用 Microsoft Graph 来查询个人电子邮件和文件，此外通过 ajax 查询来显示信息的动态查询。本示例还使用 Office UI Fabric，通过标准化的控件和呈现方法提供一致的用户界面体验。

### 适用于 ###
-  Office 365 多租户 (MT)

### 先决条件 ###
Azure AD 中的应用配置

### 解决方案 ###
解决方案 | 作者
---------|----------
Office365Api.Graph.Simple.MailAndFiles | Vesa Juvonen

### 版本历史记录 ###
版本 | 日期 | 备注
---------| -----| --------
1.0 | 2016 年 2 月 5 日 | 初次发布

### 免责声明 ###
**此代码*按原样提供*，不提供任何明示或暗示的担保，包括对特定用途适用性、适销性或不侵权的默示担保。**

----------

# 简介 #
本示例将演示如何通过与 Microsoft Graph 的简单连接来显示特定用户的电子邮件和文件。如果有新项到达电子邮件收件箱或添加到用户的 OneDrive for Business 网站，则 UI 将自动刷新 UI 的不同部分。

![应用 UI](http://i.imgur.com/Rt4d8Py.png)

# Azure Active Directory 设置 #
为了能够执行此示例，你需要先向 Azure AD 注册该应用程序并提供所需的权限以便 Graph 查询正常工作。我们将为 Azure Active Directory 创建一个应用程序条目，并配置所需的权限。

- 打开 Azure 门户 UI 并移动到 Active Directory UI；在撰写本文时，这仅适用于旧的门户 UI。
- 移动到“**应用程序**”选项
- 单击“**添加**”以开始创建新的应用
- 单击“**添加我的组织正在开发的应用程序**”

![Azure AD 中的“你想做什么”UI](http://i.imgur.com/dNtLtnl.png)

- 为应用程序提供一个**名称**，并选择“**Web 应用程序和 Web API**”作为类型

![添加应用程序 UI](http://i.imgur.com/BrxalG7.png)

- 更新如下的应用属性以便进行调试
	- **URL** - https://localhost:44301/
	- **应用 ID URL** - 诸如 http://pnpemailfiles.contoso.local 之类的有效 URI - 这只是一个标识符，因此不必是实际的有效 URL

![应用详细信息 UI](http://i.imgur.com/1IaNxLm.png)

- 移动到“**配置**”页面以及键值周围区域
- 为生成的密码选择 1 年或 2 年持续时间

![密码生命周期设置](http://i.imgur.com/7kX396J.png)

- 在页面中单击“**保存**”并复制生成的密码以供将来使用。请注意，密码仅在这段时间内可见，因此你需要将其保存到其他安全位置。

![客户端密码](http://i.imgur.com/5vnkkTA.png)

- 向下滚动以查看权限配置

![授予其他应用程序的权限](http://i.imgur.com/tF4R75w.png)

- 选择 Office 365 Exchange Online 和 Office 365 SharePoint Online 作为要向其分配权限的应用程序

![权限分配](http://i.imgur.com/XGOba3Y.png)

- 在 Exchange Online 权限下给予“**读取用户邮件**”权限

![为 Exchange 选择所需的权限](http://i.imgur.com/CyH9gg2.png)

- 在 SharePoint Online 权限下给予“**读取用户文件**”权限

![为 SharePoint 选择所需的权限](http://i.imgur.com/NSZiHsh.png)

- 单击“**保存**” 

现在你已经完成 Azure Active Directory 部分所需的配置。请注意，你仍然需要在项目的 web.config 文件中配置客户端 ID 和密码。正确更新 ClientID 和 ClientSecret 键值。

![web.config 的配置](http://i.imgur.com/pihBvR5.png)

# 运行解决方案 #
只要配置了 Azure AD 端并根据环境值更新了 web.config，便可正常运行该示例。

- 在 Visual Studio 中按 F5
- 在套件栏中单击“**连接到 Office 365**”或“**登录**”，随即将显示 AAD 许可 UI 以登录到正确的 Azure AD

![应用 UI](http://i.imgur.com/YMCrG4O.png)

- 使用正确的 Azure Active Directory 凭据登录到应用程序

![登录 Azure AD - 许可 UI](http://i.imgur.com/gNz5Wgz.png)

- 你将看到应用程序的 UI

![应用程序的 UI 以及个人数据](http://i.imgur.com/Rt4d8Py.png)


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.Simple.MailAndFiles" />