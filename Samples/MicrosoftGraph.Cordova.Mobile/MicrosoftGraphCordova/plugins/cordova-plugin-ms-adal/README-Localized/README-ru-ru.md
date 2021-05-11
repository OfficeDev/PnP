# Плагин Active Directory Authentication Library (ADAL) для приложений Apache Cordova

Подключаемый модуль "Библиотека проверки подлинности Active Directory ([ADAL](https://msdn.microsoft.com/en-us/library/azure/jj573266.aspx))
позволяет легко использовать функции проверки подлинности для приложений Apache Cordova, воспользовавшись преимуществами Windows Server Active Directory и Windows Azure Active Directory. Здесь можно найти исходный код библиотеки.

  * [ADAL для Android](https://github.com/AzureAD/azure-activedirectory-library-for-android)
  * [ADAL для iOS](https://github.com/AzureAD/azure-activedirectory-library-for-objc),
  * [ADAL для .NET](https://github.com/AzureAD/azure-activedirectory-library-for-dotnet).

Этот плагин использует собственные SDK для ADAL для каждой поддерживаемой платформы и предоставляет единый API для всех платформ. Вот пример быстрого использования:

```javascript
var AuthenticationContext = Microsoft.ADAL.AuthenticationContext;

AuthenticationContext.createAsync(authority)
.then(function (authContext) {
    authContext.acquireTokenAsync(resourceUrl, appId, redirectUrl)
    .then(function (authResponse) {
        console.log("Token acquired: " + authResponse.accessToken);
        console.log("Token will expire on: " + authResponse.expiresOn);
    }, fail);
}, fail);
```

__Примечание__. Вы также можете использовать синхронный конструктор `AuthenticationContext`:

```javascript
authContext = new AuthenticationContext(authority);
authContext.acquireTokenAsync(resourceUrl, appId, redirectUrl).then(function (authRes) {
    console.log(authRes.accessToken);
    ...
});
```

Для получения дополнительной документации по API см. [Пример приложения](https://github.com/AzureAD/azure-activedirectory-library-for-cordova/tree/master/sample) и JSDoc, чтобы получить доступ к функциональности, хранящейся в подпапке [www](https://github.com/AzureAD/azure-activedirectory-library-for-cordova/tree/master/www).

## Поддерживаемые платформы

  * Android
  * iOS
  * Windows (Windows 8.0, Windows 8.1 и Windows Phone 8.1)

## Известные проблемы и обходные пути

## Ошибка «Класс не зарегистрирован» в Windows

Если вы используете Visual Studio 2013 и видите «WinRTError: Класс не зарегистрирован »ошибка времени выполнения в Windows, убедитесь, что Visual Studio [Update 5](https://www.visualstudio.com/news/vs2013-update5-vs) установлен.

## Проблема с несколькими окнами входа

Несколько диалоговых окон входа в систему будут отображаться, если `acquireTokenAsync` вызывается несколько раз и токен не может быть получен без вывода сообщений (например, при первом запуске). Чтобы избежать этой проблемы, используйте [очередь "очередь резервирования"](https://www.npmjs.com/package/promise-queue)/семафоре логики.

## Инструкции по установке

### Предварительные требования

* [NodeJS и NPM](https://nodejs.org/)

* [Cordova CLI](https://cordova.apache.org/)

  Cordova CLI можно легко установить через менеджер пакетов NPM: `npm install -g cordova`

* Дополнительные предварительные условия для каждой целевой платформы можно найти на странице [документации по платформам Cordova](http://cordova.apache.org/docs/en/edge/guide_platforms_index.md.html#Platform%20Guides):
 * [Инструкции для Android](http://cordova.apache.org/docs/en/edge/guide_platforms_android_index.md.html#Android%20Platform%20Guide)
 * [Инструкции для iOS](http://cordova.apache.org/docs/en/edge/guide_platforms_ios_index.md.html#iOS%20Platform%20Guide)
 * [Инструкции для Windows] (http://cordova.apache.org/docs/en/edge/guide_platforms_win8_index.md.html#Windows%20Platform%20Guide)

### Создать и запустить пример приложения

  * Клонируйте плагин в репозиторий по вашему выбору

    `git clone https://github.com/AzureAD/azure-activedirectory-library-for-cordova.git`

  * Создайте проект и добавьте платформы, которые вы хотите поддерживать

    `cordova create ADALSample --copy-from="azure-activedirectory-library-for-cordova/sample"`

    `cd ADALSample`

    `cordova platform add android`

    `cordova platform add ios`

    `cordova platform add windows`

  * Добавьте плагин к вашему проекту

    `cordova plugin add ../azure-activedirectory-library-for-cordova`

  * Сборка и запуск приложения: `cordova run`.


## Настройка приложения в Azure AD

Подробные инструкции по настройке нового приложения в Azure AD можно найти [здесь](https://github.com/AzureADSamples/NativeClient-MultiTarget-DotNet#step-4--register-the-sample-with-your-azure-active-directory-tenant).

## Тесты

Этот плагин содержит набор тестов, основанный на плагине [Cordova test-framework](https://github.com/apache/cordova-plugin-test-framework). Набор тестов помещается в папку `тестов` в корне или репозитории и представляет собой отдельный плагин.

Для запуска тестов необходимо создать новое приложение, как описано в разделе [Инструкции по установке](#installation-instructions), а затем выполнить следующие шаги:

  * Добавить тестовый набор в приложение

    `cordova plugin add ../azure-activedirectory-library-for-cordova/tests`

  * Update application's config.xml file: change `<content src="index.html" />` to `<content src="cdvtests/index.html" />`
  * Измените специфические настройки AD для тестового приложения в начале файла `plugins \ cordova-plugin-ms-adal \ www \ tests.js`. `AUTHORITY_URL`, `RESOURCE_URL``REDIRECT_URL``APP_ID` в значения, предоставляемые вашей службой Azure AD. Сведения о том, как настроить приложение Azure AD, см. в статье [настройке приложения в разделе Azure AD](#setting-up-an-application-in-azure-ad).
  * Создайте и запустите приложение.

## Причуды Windows ##
[В настоящее время существует проблема Cordova](https://issues.apache.org/jira/browse/CB-8615),
которая влечет за собой необходимость обходного пути. Обходной путь должен быть отброшен после применения исправления.

### Использование ADFS / SSO
Чтобы использовать ADFS / SSO на платформе Windows (Windows Phone 8.1 на данный момент не поддерживается), добавьте следующее предпочтение в `config.xml`:
`<preference name = "adal-use-corporate-network" value = "true" />`

`adal-use-corporate-network` по умолчанию имеет значение `false`.

Он добавит все необходимые возможности приложения и переключит authContext для поддержки ADFS. Вы можете изменить его значение на `false` и вернуться позже или удалить его из `config.xml` \- после этого вызовите `cordova prepare`, чтобы применить изменения.

__Примечание__. Вы не должны обычно использовать `корпоративную сеть adal-use`-потому что она добавляет возможности, которые препятствуют публикации приложения в Магазине Windows.

## Авторские права ##
(c) Microsoft Open Technologies, Inc. Все права защищены.

Предоставляется по лицензии Apache версии 2.0 ("Лицензия"); эти файлы можно использовать только в соответствии с Лицензией. Копию Лицензии можно получить по адресу:

http://www.apache.org/licenses/LICENSE-2.0

Программное обеспечение, распространяемое по Лицензии, распространяется на условиях «КАК ЕСТЬ», БЕЗ ГАРАНТИЙ ИЛИ УСЛОВИЙ ЛЮБОГО РОДА, явно выраженных или подразумеваемых, если такие гарантии или условия не требуются действующим законодательством или не согласованы в письменной форме. Конкретные юридические формулировки, регулирующие связанные с Лицензией разрешения и ограничения, содержатся в тексте Лицензии.
