---
page_type: sample
products:
- office-outlook
- office-365
- office-sp
- ms-graph
languages:
- javascript
- nodejs
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
  services:
  - Outlook
  - Office 365
  - SharePoint
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Mobile
---
# Microsoft Graph - 快速查找联系人

### 摘要

本示例演示如何使用 Microsoft Graph 在移动设备上快速找到联系人。

![屏幕截图](assets/search-results.png)

### 适用于

- Office 365 多租户 (MT)

### 先决条件

- Office 365 租户
- Azure Active Directory (AAD) 中的应用配置
    - 权限
        - Office 365 SharePoint Online
            - 以用户身份运行搜索查询
        - Microsoft Graph
            - 读取用户的相关人员列表（预览版）
            - 以登录用户身份访问目录
            - 读取所有用户的基本个人资料
        - Microsoft Azure Active Directory
            - 登录和读取用户个人资料
    - 已启用 OAuth 隐式流
    
### 解决方案

解决方案|作者
--------|---------
MicrosoftGraph.Office.QuickContacts|Waldek Mastykarz (MVP, Rencore, @waldekm), Stefan Bauer (n8d, @StfBauer)

### 版本历史记录

版本|日期|注释
-------|----|--------
1.0|2016 年 3 月 24 日|首次发布

### 免责声明
**此代码*按原样提供*，不提供任何明示或暗示的担保，包括对特定用途适用性、适销性或不侵权的默示担保。**

---

## Office 快速查找联系人

这是一个示例应用程序，演示如何利用 Microsoft Graph 快速查找手机上的相关联系人。

![在 Office 快速查找联系人应用程序中显示找到的联系人](assets/search-results.png)

通过使用新的人脉 API，该应用程序可让你查找联系人，包括其联系方式信息。

![显示有关联系人的快速操作](assets/quick-actions.png)

由于新的人脉 API 使用了语音搜索，因此即使联系人的姓名拼写不正确，也无关紧要。

![误输入联系人姓名的搜索结果](assets/typo.png)

通过点击联系人，你可以获取访问更多信息，如果该联系人来自你的组织，你甚至可获得其电子邮件地址的直接链接。

![在应用程序中打开联系人卡片](assets/person-card.png)

## 先决条件

需要先完成一些配置步骤，然后才能启动此应用程序。

### 配置 Azure AD 应用程序

此应用程序使用 Microsoft Graph 搜索相关联系人。为使其能够访问 Microsoft Graph，必须在 Azure Active Directory 中配置相应的 Azure Active Directory 应用程序。下面是在 AAD 中创建并正确配置应用程序的步骤。 

- 在 Azure Active Directory 中创建新的 Web 应用程序
- 将“**登录 URL**”设置为 `https://localhost:8443`
- 复制“**客户端 ID**”，我们会将其用于进一步配置应用程序
- 在“**回复 URL**”中添加 `https://localhost:8443`。如果要在移动设备上测试应用程序，你还需要添加在使用 `$ gulp serve` 启动应用程序之后由 browserify 显示的 **外部** URL
- 向应用程序授予以下权限：
    - Office 365 SharePoint Online
        - 以用户身份运行搜索查询
    - Microsoft Graph
        - 读取用户的相关人员列表（预览版）
        - 以登录用户身份访问目录
        - 读取所有用户的基本个人资料
    - Microsoft Azure Active Directory
        - 登录和读取用户个人资料
- 启用 OAuth 隐式流

### 配置应用程序

为了能够启动应用程序，需要先将其链接到新创建的 Azure Active Directory 应用程序和 SharePoint 租户。这两种设置均可在 `app/app.config.js` 文件中加以配置。

- 克隆该存储库
- 作为 **appId** 常量的值，为新创建的 AAD 应用程序设置先前复制的“**客户端 ID**”
- 作为 **sharePointUrl** 常量的值，设置 SharePoint 租户的 URL（不带尾随反斜杠），即 `https://contoso.sharepoint.com`

## 运行此应用程序

完成以下步骤以启动应用程序：

- 在命令行中执行
```
$ npm i && bower i
```
- 在命令行中执行
```
$ gulp serve
```
以启动应用程序

![在浏览器中启动了应用程序](assets/app.png) 

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office.QuickContacts" />