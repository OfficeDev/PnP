<!--
# license: Licensed to the Apache Software Foundation (ASF) under one
#         or more contributor license agreements.  See the NOTICE file
#         distributed with this work for additional information
#         regarding copyright ownership.  The ASF licenses this file
#         to you under the Apache License, Version 2.0 (the
#         "License"); you may not use this file except in compliance
#         with the License.  You may obtain a copy of the License at
#
#           http://www.apache.org/licenses/LICENSE-2.0
#
#         Unless required by applicable law or agreed to in writing,
#         software distributed under the License is distributed on an
#         "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
#         KIND, either express or implied.  See the License for the
#         specific language governing permissions and limitations
#         under the License.
-->

# cordova-plugin-whitelist

Этот подключаемый модуль реализует политику списка разрешений для навигации веб-представления в Cordova 4.0

:предупреждение: Сообщайте о проблемах в [средстве отслеживания проблем Apache Cordova](https://issues.apache.org/jira/issues/?jql=project%20%3D%20CB%20AND%20status%20in%20%28Open%2C%20%22In%20Progress%22%2C%20Reopened%29%20AND%20resolution%20%3D%20Unresolved%20AND%20component%20%3D%20%22Plugin%20Whitelist%22%20ORDER%20BY%20priority%20DESC%2C%20summary%20ASC%2C%20updatedDate%20DESC)


## Поддерживаемые платформы Cordova

* Android 4.0.0 или более поздней версии

## Список разрешений для навигации
Определяет URL-адреса, на которые может переходить веб-представление.
Применяется только для навигации верхнего уровня.

Совместимость: в Android также применяется к элементам iFrame для схем, отличных от HTTP.

По умолчанию разрешены переходы только на URL-адреса `file://`. Чтобы разрешить другие URL-адреса, необходимо добавить теги `<allow-navigation>` в `config.xml`:

    <!-- Разрешить ссылки на сайт example.com -->
    <allow-navigation href="http://example.com/*" />

    <!-- Подстановочные знаки разрешаются в протоколе в виде префикса
         к узлу или суффикса к пути -->
    <allow-navigation href="*://*.example.com/*" />

    <!-- Подстановочный знак можно использовать для добавления в список разрешений всей сети
         по HTTP и HTTPS.
         *НЕ РЕКОМЕНДУЕТСЯ* -->
    <allow-navigation href="*" />

    <!-- Указанное выше аналогично этим трем объявлениям -->
    <allow-navigation href="http://*/*" />
    <allow-navigation href="https://*/*" />
    <allow-navigation href="data:*" />

## Список разрешений для намерений
Определяет, об открытии каких URL-адресов приложение может просить систему.
По умолчанию внешние URL-адреса не разрешены.

В Android это соответствует отправке намерения типа BROWSEABLE.

Этот список разрешений не применяется к подключаемым модулям, только к гиперссылкам и вызовам `window.open()`.

В `config.xml` добавьте теги `<allow-intent>`, как показано ниже:

    <!-- Разрешить открывать в браузере ссылки на веб-страницы -->
    <allow-intent href="http://*/*" />
    <allow-intent href="https://*/*" />

    <!-- Разрешить открывать в браузере ссылки на сайт example.com -->
    <allow-intent href="http://example.com/*" />

    <!-- Подстановочные знаки разрешаются в протоколе в виде префикса
         к узлу или суффикса к пути -->
    <allow-intent href="*://*.example.com/*" />

    <!-- Разрешить ссылкам в SMS-сообщениях открывать приложение для обмена сообщениями -->
    <allow-intent href="sms:*" />

    <!-- Разрешить ссылкам tel: открывать набиратель номера -->
    <allow-intent href="tel:*" />

    <!-- Разрешить ссылкам geo: открывать карты -->
    <allow-intent href="geo:*" />

    <!-- Разрешить нераспознанным URL-адресам открывать установленные приложения
         *НЕ РЕКОМЕНДУЕТСЯ* -->
    <allow-intent href="*" />

## Список разрешений для сетевых запросов
Определяет, какие сетевые запросы (изображения, XHR и т. д.) разрешается создавать (с помощью собственных перехватчиков Cordova).

Примечание. Для большей надежности рекомендуем использовать политику безопасности содержимого (см. ниже). Этот список разрешений обычно используется для веб-представлений, не поддерживающих CSP.

В `config.xml` добавьте теги `<access>`, как показано ниже:

    <!-- Разрешить изображения, XHR и т. д. для сайта google.com -->
    <access origin="http://google.com" />
    <access origin="https://google.com" />

    <!-- Доступ к поддомену maps.google.com -->
    <access origin="http://maps.google.com" />

    <!-- Доступ ко всем поддоменам на google.com -->
    <access origin="http://*.google.com" />

    <!-- Включить запросы к контенту: URL-адреса -->
    <access origin="content:///*" />

    <!-- Не блокировать запросы -->
    <access origin="*" />

Без тегов `<access>` разрешены только запросы к URL-адресам `file://`. Однако приложение по умолчанию Cordova включает `<access origin="*">` по умолчанию.

Совместимость: В Android также разрешены запросы к https://ssl.gstatic.com/accessibility/javascript/android/ по умолчанию, так как это необходимо для правильной работы TalkBack.

### Политика безопасности содержимого
Определяет, какие сетевые запросы (изображения, XHR и т. д.) разрешается создавать (непосредственно через веб-представление).

В Android и iOS списку разрешений для сетевых запросов (см. выше) не удается отфильтровать все типы запросов (например, `<video>` и соединения WebSocket не блокируются). Поэтому в дополнение к списку разрешений на всех страницах следует использовать тег `<meta>` [политики безопасности содержимого](http://content-security-policy.com/).

В Android поддержка CSP в веб-представлении системы начинается с KitKat (но доступна во всех версиях, использующих веб-представление Crosswalk).

Ниже приведено несколько примеров объявлений CSP для страниц `.html`.

    <!-- Хорошее объявление по умолчанию:
        * разрыв: требуется только для iOS (при использовании UIWebView) и для взаимодействия JS->Native
        * https://ssl.gstatic.com требуется только для Android и для правильной работы TalkBack
        * Отключает использование eval() и встроенных скриптов для снижения риска, связанного с уязвимостями XSS. Чтобы изменить эту настройку, выполните указанные ниже действия.
            * Включите встроенный JS: добавьте 'unsafe-inline' в default-src
            * Включите eval(): добавьте 'unsafe-eval' в default-src
    -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self' data: gap: https://ssl.gstatic.com; style-src 'self' 'unsafe-inline'; media-src *">

    <!-- Разрешить все данные, но только из одного источника и foo.com -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self' foo.com">

    <!-- Эта политика разрешает все (например, CSS, AJAX, объект, кадр, мультимедиа и т. д.), за исключением 
        * CSS только из одного источника и встроенные стили;
        * скрипты только из одного источника и встроенные стили, а также eval()
    -->
    <meta http-equiv="Content-Security-Policy" content="default-src *; style-src 'self' 'unsafe-inline'; script-src 'self' 'unsafe-inline' 'unsafe-eval'">

    <!-- Разрешить XHR только через HTTPS в том же домене. -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self' https:">

    <!-- Разрешить iframe для https://cordova.apache.org/ -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self'; frame-src 'self' https://cordova.apache.org">
