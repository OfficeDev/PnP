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

此插件可实施用于在 Cordova 4.0 上浏览应用程序 Web 视图的白名单策略

警告：在 [Apache Cordova 问题跟踪器](https://issues.apache.org/jira/issues/?jql=project%20%3D%20CB%20AND%20status%20in%20%28Open%2C%20%22In%20Progress%22%2C%20Reopened%29%20AND%20resolution%20%3D%20Unresolved%20AND%20component%20%3D%20%22Plugin%20Whitelist%22%20ORDER%20BY%20priority%20DESC%2C%20summary%20ASC%2C%20updatedDate%20DESC)中报告问题


## 支持的 Cordova 平台

* Android 4.0.0 或更高版本

## 导航白名单
控制 Web 视图自身可导航到的 URL。
仅适用于顶级导航。

Quirks：在 Android 上，它也适用于非 http(s) 方案的 iframe。

默认情况下，只允许导航到 `file://` URL。若要允许导航到其他 URL，必须将 `<allow-navigation>` 标记添加到你的 `config.xml`：

    <!-- 允许链接到 example.com -->
    <allow-navigation href="http://example.com/*" />

    <!-- 协议允许使用通配符，用作
         主机的前缀或用作路径的后缀 -->
    <allow-navigation href="*://*.example.com/*" />

    <!-- 可以使用通配符为整个网络创建白名单
         - 通过 HTTP 和 HTTPS。
         *不推荐* -->
    <allow-navigation href="*" />

    <!-- 以上相当于这三个声明 -->
    <allow-navigation href="http://*/*" />
    <allow-navigation href="https://*/*" />
    <allow-navigation href="data:*" />

## 意图白名单
控制允许应用让系统打开的 URL。
默认情况下，不允许打开任何外部 URL。

在 Android 上，这相当于发送“可浏览”类型的意图。

此白名单不适用于插件，仅适用于超链接和对 `window.open()` 的调用。

在 `config.xml` 中，添加 `<allow-intent>` 标记，如下所示：

    <!-- 允许链接到要在浏览器中打开的网页 -->
    <allow-intent href="http://*/*" />
    <allow-intent href="https://*/*" />

    <!-- 允许链接到要在浏览器中打开的 example.com -->
    <allow-intent href="http://example.com/*" />

    <!-- 协议允许使用通配符，用作
         主机的前缀或用作路径的后缀 -->
    <allow-intent href="*://*.example.com/*" />

    <!-- 允许短信链接打开消息传递应用 -->
    <allow-intent href="sms:*" />

    <!-- 允许电话链接打开拨号程序 -->
    <allow-intent href="tel:*" />

    <!-- 允许地理位置链接打开地图 -->
    <allow-intent href="geo:*" />

    <!-- 允许所有无法识别的 URL 打开已安装的应用
         *不推荐* -->
    <allow-intent href="*" />

## 网络请求白名单
控制允许（通过 cordova 本机挂钩）发出哪些网络请求（图像、XHR 等）。

注意：建议使用内容安全策略（如下所示），它更安全。对于不支持 CSP 的 Web 视图，此白名单主要是历史性的。

在 `config.xml` 中，添加 `<access>` 标记，如下所示：

    <!-- 允许在 google.com 上访问图像、xhr 等-->
    <access origin="http://google.com" />
    <access origin="https://google.com" />

    <!-- 访问子域 maps.google.com -->
    <access origin="http://maps.google.com" />

    <!-- 访问 google.com 上的所有子域 -->
    <access origin="http://*.google.com" />

    <!-- 启用内容请求：URL -->
    <access origin="content:///*" />

    <!-- 不要阻止任何请求 -->
    <access origin="*" />

如果没有 `<access>` 标记，则只允许请求 `file://` URL。但是，默认情况下，默认的 Cordova 应用程序包括 `<access origin="*">`。

Quirks：默认情况下，Android 还允许请求 https://ssl.gstatic.com/accessibility/javascript/android/，因为这是 TalkBack 正常运行所必需的。

### 内容安全策略
控制允许（直接通过 Web 视图）发出哪些网络请求（图像、XHR 等）。

在 Android 和 iOS 上，网络请求白名单（请参见上文）无法筛选所有类型的请求（例如，未阻止 `<video>` 和 WebSocket）。因此，除了白名单之外，你还应该在所有页面上使用[内容安全策略](http://content-security-policy.com/) `<meta>` 标记。

在 Android 上，系统 Web 视图中的 CSP 支持从 KitKat 开始（但在使用 Crosswalk Web 视图的所有版本中可用）。

以下是针对你的 `.html` 页面的一些示例 CSP 声明：

    <!-- 良好的默认声明：
        * gap: 仅在 iOS 上（使用 UIWebView 时）是必需的，并且 JS-> 本机通信需要它
        * https://ssl.gstatic.com 仅在 Android 上是必需的，并且 TalkBack 需要它才能正常运行
        * 禁用 eval() 和内联脚本，以缓解 XSS 漏洞的风险。若要更改此设置，请执行以下操作：
            * 启用内联 JS：将“unsafe-inline”添加到 default-src
            * 启用 eval()：将“unsafe-eval”添加到 default-src
    -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self' data: gap: https://ssl.gstatic.com; style-src 'self' 'unsafe-inline'; media-src *">

    <!-- 只允许来自相同来源和 foo.com 的所有内容 -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self' foo.com">

    <!-- 此策略允许所有内容（例如 CSS、AJAX、对象、框架、媒体等），但以下除外 
        * 仅来自相同来源和内联样式的 CSS，
        * 仅来自相同来源和内联样式及 eval() 的脚本
    -->
    <meta http-equiv="Content-Security-Policy" content="default-src *; style-src 'self' 'unsafe-inline'; script-src 'self' 'unsafe-inline' 'unsafe-eval'">

    <!-- 仅允许在同一域上通过 HTTPS 提供 XHR。-->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self' https:">

    <!-- 允许 iframe 访问 https://cordova.apache.org/ -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self'; frame-src 'self' https://cordova.apache.org">
