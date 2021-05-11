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
# Образец пакета SDK API Microsoft Graph для .NET.

### Сводка ###
Этот пример решения иллюстрирует использование пакета SDK API Microsoft Graph для
.NET. Решение включает:
* Консольное приложение с использованием новой
ознакомительной версии MSAL — библиотеки проверки подлинности (Майкрософт) — для аутентификации при помощи новой конечной точки версии 2
* Веб-приложение ASP.NET с использованием ADAL
(библиотеки проверки подлинности Azure Active Directory) для аутентификации при помощи конечной точки Azure AD.

Этот пример взят из книги [Паоло Пиалорси](https://twitter.com/PaoloPia) ["Программирование Microsoft Office 365"](https://www.microsoftpressstore.com/store/programming-microsoft-office-365-includes-current-book-9781509300914), опубликованной издательством Microsoft Press.

### Сфера применения ###
-  Microsoft Office 365

### Решение ###
Решение | Авторы | Twitter
---------|-----------|--------
MicrosoftGraph.Office365.DotNetSDK.sln |  Паоло Пиалорси (PiaSys.com) | [@PaoloPia](https://twitter.com/PaoloPia)

### Журнал версий ###
Версия | Дата | Примечания
---------| -----| --------
1.0 | 12 мая 2016 г. | Первый выпуск

### Инструкции по настройке ###
Чтобы воспроизвести этот образец, выполните следующее:

-  Получите подписку разработчика Office 365 [Центр разработчиков Office](http://dev.office.com/), если у вас ее нет.
-  Зарегистрируйте веб-приложение в [Azure AD](https://manage.windowsazure.com/), чтобы получить идентификатор и секрет клиента 
-  Настройте следующие разрешения Microsoft Graph для приложения Azure AD: Просмотр базовых профилей пользователей, Просмотр электронных адресов пользователей
-  Обновите файл web.config с помощью правильных параметров (ClientID, ClientSecret, Domain, TenantID)
-  Зарегистрируйте консольное приложение для аутентификации при помощи новой конечной точки версии 2 на новом [Портале регистрации приложений](https://apps.dev.microsoft.com/) 
-  Настройте файл консольного приложения .config с помощью правильных параметров (MSAL_ClientID)

 
<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.DotNetSDK" />