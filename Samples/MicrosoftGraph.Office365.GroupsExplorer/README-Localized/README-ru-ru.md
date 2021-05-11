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
# API Office 365 — обозреватель групп#

### Сводка ###
В этом вспомогательном веб-приложении отображается список всех групп в клиенте пользователя, а также их свойства.

### Область применения ###
-  Мультитенантная среда (MT) Office 365

### Предварительные требования ###
Для этого примера требуется версия API Office 365, выпущенная в ноябре 2014 г. Дополнительные сведения см. на странице http://msdn.microsoft.com/ru-ru/office/office365/howto/platform-development-overview.

### Решение ###
Решение | Авторы
---------|----------
Office365Api.Groups | Пол Шефлейн (Schaeflein Consulting, @paulschaeflein)

### Журнал версий ###
Версия | Дата | Примечания
---------| -----| --------
1.0 | 8 февраля 2016 г. | Первый выпуск

### Заявление об отказе ###
**ЭТОТ КОД ПРЕДОСТАВЛЯЕТСЯ *КАК ЕСТЬ* БЕЗ КАКОЙ-ЛИБО ЯВНОЙ ИЛИ ПОДРАЗУМЕВАЕМОЙ ГАРАНТИИ, ВКЛЮЧАЯ ПОДРАЗУМЕВАЕМЫЕ ГАРАНТИИ ПРИГОДНОСТИ ДЛЯ КАКОЙ-ЛИБО ЦЕЛИ, ДЛЯ ПРОДАЖИ ИЛИ ГАРАНТИИ ОТСУТСТВИЯ НАРУШЕНИЯ ПРАВ ИНЫХ ПРАВООБЛАДАТЕЛЕЙ.**


----------

# Знакомство с API групп Office 365 #
Этот пример предназначен для рассмотрения свойств и связей групп Office 365.
Дополнительные сведения доступны в записи блога по адресу http://www.schaeflein.net/exploring-the-office-365-groups-api/.



# Пример ASP.NET MVC #
В этом разделе описан пример ASP.NET MVC, включенный в текущее решение.

## Подготовка сценария для примера ASP.NET MVC ##
В примере приложения ASP.NET MVC используется новый API Microsoft Graph для выполнения следующего списка задач:

-  Чтение списка групп в каталоге текущего пользователя
-  Чтение бесед, событий и файлов в "единых" группах
-  Создание списка групп, к которым присоединен текущий пользователь

Чтобы запустить веб-приложение, требуется зарегистрировать его в клиенте разработки Azure AD.
Веб-приложение использует OWIN и OpenId Connect для проверки подлинности в Azure AD в рамках клиента Office 365.
Дополнительные сведения об OWIN и OpenId Connect, а также о регистрации приложения в клиенте Azure AD см. здесь: http://www.cloudidentity.com/blog/2014/07/28/protecting-an-mvc4-vs2012-project-with-openid-connect-and-azure-ad/ 

После регистрации приложения в клиенте Azure AD вам потребуется настроить следующие параметры в файле web.config:

		<add key="ida:ClientId" value="[Ваш ClientID]" />
		<add key="ida:ClientSecret" value="[Ваш ClientSecret]" />
		<add key="ida:TenantId" value="[Ваш TenantId]" />
		<add key="ida:Domain" value="ваш_домен.onmicrosoft.com" />

# Содержимое примера #
Код приложения создан для конечной точки бета-версии API Graph. Класс GroupsController определяет URL-адрес для каждого вызова:

```
string apiUrl = String.Format("{0}/beta/myorganization/groups/{1}/conversations/{2}/threads", 
                              SettingsHelper.MSGraphResourceId, 
                              id, itemId);
```

В пользовательском интерфейсе используется Office UI Fabric (http://dev.office.com/fabric). Существует несколько пользовательских представлений DisplayTemplate, обрабатывающих стили, требующиеся для CSS Fabric.

## Сведения об авторах ##
Мультитенантность с использованием ASP.NET MVC и OpenID Connect представлена с помощью проекта GitHub,
доступного на странице https://github.com/Azure-Samples/active-directory-dotnet-webapp-multitenant-openidconnect

Авторы: https://github.com/dstrockis и https://github.com/vibronet.

Помощь с применением стилей Office Fabric UI получена из записи блога http://chakkaradeep.com/index.php/using-office-ui-fabric-in-sharepoint-add-ins/

Автор: https://github.com/chakkaradeep

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.GroupsExplorer" />