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
# Office 365 Python Flask 应用身份验证 #

### 摘要 ###
此场景演示如何在 Python 应用（使用 Flask 微框架）和 Office 365 SharePoint Online 网站之间设置身份验证。本示例旨在介绍用户如何进行身份验证并与 Office 365 SharePoint 网站中的数据进行交互。

### 适用于 ###
- Office 365 多租户 (MT)
- Office 365 专用 (D)

### 先决条件 ###
- Office 365 开发人员租户
- 已安装 Visual Studio 2015
- 已安装针对 Visual Studio 的 Python 工具
- 已安装 Python 2.7 或 3.4
- Flask、请求、PyJWT Python 包（通过 pip 安装）

### 解决方案 ###
解决方案 | 作者 
---------|---------- 
Python.Office365.AppAuthentication | Velin Georgiev (**OneBit Software**)、Radi Atanassov (**OneBit Software**)

### 版本历史记录 ###
版本 | 日期 | 备注 
---------| -----| -------- 
1.0 | 2016 年 2 月 9 日 | 初次发布 (Velin Georgiev)

### 免责声明 ###
**此代码*按原样*提供，不提供任何明示或暗示的担保，包括对特定用途适用性、适销性或不侵权的默示担保。**

----------

# Office 365 Python Flask 应用身份验证示例 #
本节介绍当前解决方案中包含的 Office 365 Python Flask 应用身份验证示例。

# 准备 Office 365 Python Flask 应用身份验证示例的场景 #
Office 365 Python Flask 应用程序将：

- 使用 Azure AD 授权终结点执行身份验证
- 使用 Office 365 SharePoint API 显示经过身份验证的用户的职务

为了成功完成这些任务，需要执行以下说明的额外设置。 

- 使用 Office 365 帐户创建 Azure 试用帐户以便可注册应用，或者也可使用 PowerShell 来注册应用。可在以下链接中找到一个很好的教程：https://github.com/OfficeDev/PnP/blob/497b0af411a75b5b6edf55e59e48c60f8b87c7b9/Samples/AzureAD.GroupMembership/readme.md。
- 在 Azure 门户中注册应用，并将 http://localhost:5555 分配给登录 URL 和回复 URL
- 生成客户端密码
- 授予 Python Flask 应用以下权限：Office 365 SharePoint Online > 委派权限 > 读取用户个人资料

![Azure 门户权限设置](https://lh3.googleusercontent.com/-LxhYrbik6LQ/VrnZD-0Uf0I/AAAAAAAACaQ/jsUjHDQlmd4/s732-Ic42/office365-python-app2.PNG)

- 从 Azure 门户复制客户端密码和客户端 ID，并将它们替换到 Python Flask config 文件中
- 将你要访问的 SharePoint 网站的 URL 分配给 RESOURCE 配置变量。

![配置文件中的应用详细信息](https://lh3.googleusercontent.com/-ETtW5MBuOcA/VrnZDQBAxQI/AAAAAAAACaY/ppp4My1JTlE/s616-Ic42/office365-python-app-config.PNG)

- 在 Visual Studio 2015 中打开本示例
- 转到“项目”>“属性”>“调试”，然后为“端口号”专门分配 5555

![更改调试选项中的端口](https://lh3.googleusercontent.com/-M3upxeCKBN0/VrnZDSHnDoI/AAAAAAAACaA/BF4CTeKlUMs/s426-Ic42/office365-python-app-vs-config.PNG)

- 转到 Python 环境 > 活动的 Python 环境 > 执行“从 requirements.txt 安装”。这样将确保安装所有必需的 Python 包。

![选择菜单选项](https://lh3.googleusercontent.com/-At6Smrxg9DQ/VrnZD6KMvfI/AAAAAAAACaM/gcgJUATPigE/s479-Ic42/office365-python-packages.png)

## 运行 Office 365 Python Flask 应用示例 ##
运行本示例时，你将看到职务和登录 URL。

![加载项 UI](https://lh3.googleusercontent.com/-GDdAcmYylZE/VrnZD8sVGwI/AAAAAAAACaI/1gB0jvULLBo/s438-Ic42/office365-python-app.PNG)


单击登录链接后，Office 365 API 将完成身份验证握手，而 Python Flask 主屏幕将重新加载，并显示已登录用户的职务和访问令牌：

![登录 UI](https://lh3.googleusercontent.com/-44rsAE2uGFQ/VrnZDdJAseI/AAAAAAAACaE/70N8UX8ErIk/s569-Ic42/office365-python-app-result.PNG)

<img src="https://telemetry.sharepointpnp.com/pnp/samples/Provisioning.Office365.AppAuthentication" />