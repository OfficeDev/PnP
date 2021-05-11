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
# SDK Microsoft Graph для iOS с использованием Swift #

### Сводка ###
Если вы еще не знаете, существует простой способ вызова большого количества API-интерфейсов Майкрософт с помощью одной конечной точки. Эта конечная точка, называемая Microsoft Graph (<https://graph.microsoft.io/>), обеспечивает доступ к любым элементам: от данных до аналитики на платформе облачных служб Майкрософт.

Вам больше не придется отслеживать различные конечные точки и разделять маркеры в своих решениях. Это здорово, не правда ли? Эта публикация является вводной частью о начале работы с Microsoft Graph. Изменения в Microsoft Graph см. на странице <https://graph.microsoft.io/changelog>

В этом примере демонстрируется пакет SDK Microsoft Graph для iOS (<https://github.com/OfficeDev/Microsoft-Graph-SDK-iOS>) в простом приложении iOS с применением нового языка Swift (<https://developer.apple.com/swift/>). В приложении мы отправим себе сообщение. Цель этого примера — ознакомиться с Microsoft Graph и его возможностями.

![Пользовательский интерфейс приложения в iPhone и электронной почте](http://simonjaeger.com/wp-content/uploads/2016/03/app.png)

Обратите внимание, что пакет SDK Microsoft Graph для iOS пока доступен в предварительной версии. Дополнительные сведения об условиях см. на странице https://github.com/OfficeDev/Microsoft-Graph-SDK-iOS

Дополнительные сведения об этом примере см. на странице <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/>.

### Сфера применения ###
-  Exchange Online
-  Office 365
-  Hotmail.com
-  Live.com
-  MSN.com
-  Outlook.com
-  Passport.com

### Предварительные требования ###
Вам потребуется зарегистрировать свое приложение перед отправкой вызовов к Microsoft Graph. Дополнительные сведения: <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/#step-11-register-the-application-in-azure-ad>

Если вы создаете решение для Office 365 и у вас нет клиента Office 365, получите учетную запись разработчика на сайте <http://dev.office.com/devprogram>

Чтобы запустить пример, потребуется Xcode, установленный на компьютере. Скачайте Xcode на сайте <https://developer.apple.com/xcode/>

### Проект ###
Проект | Авторы
---------|----------
MSGraph.MailClient | Саймон Ягер (**Майкрософт**)

### Журнал версий ###
Версия | Дата | Примечания
---------| -----| --------
1.0 | 9 марта 2016 г. | Первый выпуск

### Заявление об отказе ###
**ЭТОТ КОД ПРЕДОСТАВЛЯЕТСЯ *КАК ЕСТЬ* БЕЗ КАКОЙ-ЛИБО ЯВНОЙ ИЛИ ПОДРАЗУМЕВАЕМОЙ ГАРАНТИИ, ВКЛЮЧАЯ ПОДРАЗУМЕВАЕМЫЕ ГАРАНТИИ ПРИГОДНОСТИ ДЛЯ КАКОЙ-ЛИБО ЦЕЛИ, ДЛЯ ПРОДАЖИ ИЛИ ГАРАНТИИ ОТСУТСТВИЯ НАРУШЕНИЯ ПРАВ ИНЫХ ПРАВООБЛАДАТЕЛЕЙ.**

----------

# Применение #

Сначала нужно зарегистрировать свое приложение в клиенте Azure AD (связанном с клиентом Office 365). Дополнительные сведения о регистрации приложения в клиенте Azure AD доступны здесь: <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/#step-11-register-the-application-in-azure-ad>

Так как приложение выполняет обратный вызов в Microsoft Graph и отправляет почту от имени вошедшего пользователя, важно предоставить ему разрешения на отправку писем.

После регистрации приложения в клиенте Azure AD вам потребуется настроить следующие параметры в файле **adal_settings.plist**:
    
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

Запустите файл рабочей области (**MSGraph.MailClient.xcworkspace**) в Xcode. Запустите проект, используя сочетание клавиш **⌘R** или нажав кнопку **Запуск** в меню **Продукт**.
    
# Файлы с исходным кодом #
Ключевыми файлами исходного кода в этом проекте являются следующие:

- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\MailClient.swift` — этот класс отвечает за вход, получение профиля пользователя и отправку писем с сообщением.
- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\ViewController.swift` — контроллер с одним представлением для приложения iOS, запускающий MailClient.
- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\adal_settings.plist` — это файл списка свойств настройки ADAL. Перед запуском этого примера настройте требуемые параметры в этом файле.

# Дополнительные ресурсы #
- Узнайте о разработке Office по адресу:<https://msdn.microsoft.com/en-us/office/>
- Начните работу с Microsoft Azure по адресу: <https://azure.microsoft.com/en-us/>
- Ознакомьтесь с Microsoft Graph и соответствующими операциями на странице <http://graph.microsoft.io/en-us/> 
- Дополнительные сведения об этом примере см. на странице <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/>.


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.iOS.Swift.SendMail" />