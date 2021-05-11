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
# 使用 Swift 的 Microsoft Graph SDK for iOS #

### 摘要 ###
如果没有听说过，有一种调用大量 Microsoft API 的轻松方法：使用单一终结点。此终结点，即 Microsoft Graph (<https://graph.microsoft.io/>) 允许你访问所有内容，从数据到 Microsoft cloud 提供支持的情报和见解。

无需跟踪解决方案中的不同终结点和单独令牌，很棒吧？此文章是 Microsoft Graph 入门的介绍部分。有关 Microsoft Graph 中的变化，请转到： <https://graph.microsoft.io/changelog>

本示例展示在简单的 iOS 应用程序中使用新 Swift 语言 (<https://developer.apple.com/swift/>) IOS (<https://github.com/OfficeDev/Microsoft-Graph-SDK-iOS>) 版 Microsoft Graph SDK。我们将在应用程序中向自己发送一封邮件。目标是熟悉 Microsoft Graph 及其可能性。

![iPhone 和电子邮件中的应用用户界面](http://simonjaeger.com/wp-content/uploads/2016/03/app.png)

请注意，Microsoft Graph SDK for iOS 目前仍是预览版。有关以下条件的详细信息，请参阅： https://github.com/OfficeDev/Microsoft-Graph-SDK-iOS

关于此示例的更多信息，请访问：<http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/>

### 适用于 ###
-  Exchange Online
-  Office 365
-  Hotmail.com
-  Live.com
-  MSN.com
-  Outlook.com
-  Passport.com

### 先决条件 ###
你将需要注册你的应用，然后才能向 Microsoft Graph 进行任何调用。需要更多信息，请访问：<http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/#step-11-register-the-application-in-azure-ad>

如果您是针对 Office 365 构建的，而你缺少 Office 365 租户，请在以下位置获得开发人员帐户： <http://dev.office.com/devprogram>

运行示例需要安装 Xcode 至计算机上。获取 Xcode：<https://developer.apple.com/xcode/>

### 项目 ###
项目 | 作者
---------|----------
MSGraph.MailClient | Simon Jäger (**Microsoft**)

### 版本历史记录 ###
版本 | 日期 | 批注
---------| -----| --------
1.0 | 2016 年 3 月 9 日| 初始发行版

### 免责声明 ###
**此代码*按原样提供*，不提供任何明示或暗示的担保，包括对特定用途适用性、适销性或不侵权的默示担保。**

----------

# 如何使用 #

第一步是在 Azure AD 租户（与 Office 365 租户相关联）中注册应用程序。可在下面链接中找到注册应用程序至 Azure AD 租户的详细信息：<http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/#step-11-register-the-application-in-azure-ad>

因为应用被回调至 Microsoft Graph 并代表已登录用户发送邮件 - 务必授予权限以发送邮件。

在 Azure AD 中注册应用程序后，必须在 **adal_settings.plist** 文件中配置以下设置：
    
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

在 Xcode 中启动工作区文件（**MSGraph.MailClient.xcworkspace**）。使用 **⌘R** 快捷方式或按下“**产品**”菜单中的“**运行**”按钮，来运行项目。
    
# 源代码文件 #
此项目中的主要源代码文件如下所示：

- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\MailClient.swift` \- 此类负责用户登录、获取用户配置文件并最终发送邮件及消息。
- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\ViewController.swift` \- 这是适用于触发 MailClient 的 iOS 应用的单独视图控制程序。
- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\adal_settings.plist` \- 这是 ADAL 配置属性列表文件。确保在运行此示例前，在文件中配置所需的设置。

# 更多资源 #
- 关于 Office 的开发情况，请访问：<https://msdn.microsoft.com/en-us/office/>
- Microsoft Azure 入门指南：<https://azure.microsoft.com/en-us/>
- 浏览 Microsoft Graph 和其操作：<http://graph.microsoft.io/en-us/> 
- 关于此示例的更多信息，请访问：<http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/>


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.iOS.Swift.SendMail" />