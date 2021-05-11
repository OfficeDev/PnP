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
# Проверка подлинности приложения Office 365 Python Flask #

### Краткое описание ###
В этом сценарии показано, как настроить проверку подлинности между приложением Python (с использованием микроплатформы Flask) и сайтом SharePoint Online в Office 365. В этом примере показано, как пользователь может проходить проверку подлинности и взаимодействовать с данными с сайта SharePoint в Office 365.

### Сфера применения ###
- Office 365 Multi Tenant (MT)
- Office 365 Dedicated (D)

### Необходимые компоненты ###
- Клиент разработчика приложений для Office 365;
- Установить Visual Studio 2015
- Установить Инструменты Python для Visual Studio
- Приложение Python 2,7 или 3,4 установить
- Flask, запросы, пакеты PyJWT Python, установленные через pip

### Решение ###
Решение | Автор(ы) 
---------|----------
Python.Office365.AppAuthentication | Велин Георгиев (**OneBit Software**), Ради Атанасов (**OneBit Software**)

### Журнал версий ###
Версия | Дата | Примечаний 
---------| -----| --------
1,0 | 9 февраля, 2016 | Первый выпуск (Велин Жеоргиев)

### Отказ от ответственности ###
**ЭТОТ КОД ПРЕДОСТАВЛЯЕТСЯ *КАК ЕСТЬ* БЕЗ КАКОЙ-ЛИБО ЯВНОЙ ИЛИ ПОДРАЗУМЕВАЕМОЙ ГАРАНТИИ, ВКЛЮЧАЯ ПОДРАЗУМЕВАЕМЫЕ ГАРАНТИИ ПРИГОДНОСТИ ДЛЯ КАКОЙ-ЛИБО ЦЕЛИ, ДЛЯ ПРОДАЖИ ИЛИ ГАРАНТИИ ОТСУТСТВИЯ НАРУШЕНИЯ ПРАВ ИНЫХ ПРАВООБЛАДАТЕЛЕЙ.**

----------

# Пример проверки подлинности приложения Office 365 Python Flask #
В этом разделе описан пример проверки подлинности приложения Office 365 Python Flask в текущем решении.

# Подготовьте сценарий для образца проверки подлинности приложения Office 365 Python Flask #
Приложение Office 365 Python Flask будет:

- Использовать конечные точки авторизации Azure AD для выполнения проверки подлинности
- Использовать Office 365 SharePoint API для проверки подлинности звания пользователя

Для успешного выполнения этих задач вам необходимо выполнить дополнительные настройки, описанные ниже. 

- Создать пробную учетную запись Azure с учетной записью Office 365, чтобы приложение можно было зарегистрировать, или же вы можете зарегистрировать его с помощью PowerShell. Хороший учебный курс можно найти по этой ссылке https://github.com/OfficeDev/PnP/blob/497b0af411a75b5b6edf55e59e48c60f8b87c7b9/Samples/AzureAD.GroupMembership/readme.md.
- Зарегистрируйте приложение на портале Azure и назначьте http://localhost:5555 для URL-адреса входа и URL-адреса ответа.
- Создайте секрет клиента
- Предоставьте следующие разрешения на доступ приложению Python Flask: Office 365 SharePoint Online> Делегированные разрешения> Чтение профилей пользователей

![Параметры разрешений портала Azure](https://lh3.googleusercontent.com/-LxhYrbik6LQ/VrnZD-0Uf0I/AAAAAAAACaQ/jsUjHDQlmd4/s732-Ic42/office365-python-app2.PNG)

- Скопируйте секрет клиента и идентификатор клиента на портале Azure и замените их на файл Python Flask config
- Присвойте переменную конфигурации RESOURCE для URL-сайта SharePoint, к которому вы собираетесь обращаться.

![Детали приложения в конфигурационном файле](https://lh3.googleusercontent.com/-ETtW5MBuOcA/VrnZDQBAxQI/AAAAAAAACaY/ppp4My1JTlE/s616-Ic42/office365-python-app-config.PNG)

- Откройте пример в Visual Studio 2015
- Перейдите в Проект> Свойства> Отладка и выделите 5555 для номера порта

![Изменение порта в параметрах отладки](https://lh3.googleusercontent.com/-M3upxeCKBN0/VrnZDSHnDoI/AAAAAAAACaA/BF4CTeKlUMs/s426-Ic42/office365-python-app-vs-config.PNG)

- Перейдите в среды Python> ваша активная среда Python> выполните «Install from needs.txt». Это обеспечит установку всех необходимых пакетов Python.

![Выбор пункта меню](https://lh3.googleusercontent.com/-At6Smrxg9DQ/VrnZD6KMvfI/AAAAAAAACaM/gcgJUATPigE/s479-Ic42/office365-python-packages.png)

## Запустите пример приложения Office 365 Python Flask ##
При запуске примера вы увидите заголовок и URL-адрес для входа.

![интерфейс надстройки;](https://lh3.googleusercontent.com/-GDdAcmYylZE/VrnZD8sVGwI/AAAAAAAACaI/1gB0jvULLBo/s438-Ic42/office365-python-app.PNG)


После того как вы нажмете ссылку для входа, интерфейс API Office 365 будет проходить через подтверждение проверки подлинности, а начальный экран Python Flask перезагрузится с показанными заголовком пользователя вошедшего в систему и маркером доступа:

![Вход в пользовательский интерфейс](https://lh3.googleusercontent.com/-44rsAE2uGFQ/VrnZDdJAseI/AAAAAAAACaE/70N8UX8ErIk/s569-Ic42/office365-python-app-result.PNG)

<img src="https://telemetry.sharepointpnp.com/pnp/samples/Provisioning.Office365.AppAuthentication" />