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

このプラグインは、Cordova 4.0 でアプリケーション WebView を移動するためのホワイトリスト ポリシーを実装します。

:警告:[Apache Cordova 問題トラッカー](https://issues.apache.org/jira/issues/?jql=project%20%3D%20CB%20AND%20status%20in%20%28Open%2C%20%22In%20Progress%22%2C%20Reopened%29%20AND%20resolution%20%3D%20Unresolved%20AND%20component%20%3D%20%22Plugin%20Whitelist%22%20ORDER%20BY%20priority%20DESC%2C%20summary%20ASC%2C%20updatedDate%20DESC)に関する問題を報告する


## サポートされる Cordova プラットフォーム

* Android 4.0.0 以降

## ナビゲーション ホワイトリスト
WebView 自体に移動できる URL を制御します。
トップレベル ナビゲーションにのみ適用されます。

互換: Android では、非 HTTP(S) スキームの iframe にも適用されます。

既定では、`file://` URL に対するナビゲーションのみが許可されます。他の URL を許可するには、次のように `<allow-navigation>` タグを `config.xml` に追加してください。

    <!-- example.com に対するリンクを許可する -->
    <allow-navigation href="http://example.com/*" />

    <!-- ワイルドカードをホストに対するプレフィックス、
         パスに対するサフィックスとして、プロトコルに使用できます -->
    <allow-navigation href="*://*.example.com/*" />

    <!-- ワイルドカードを使用して、HTTP および HTTPS 上で
         ネットワーク全体をホワイトリストかできます。
         *非推奨* -->
    <allow-navigation href="*" />

    <!-- 上記はこれら 3 つの宣言と同等です -->
    <allow-navigation href="http://*/*" />
    <allow-navigation href="https://*/*" />
    <allow-navigation href="data:*" />

## インテント ホワイトリスト
アプリケーションがシステムに開くことを要求することができる URL を制御します。
既定では、外部 URL は許可されません。

Android の場合、これは、BROWSEABLE 型のインテントを送信することと同じです。

このホワイトリストは、プラグインには適用されません。ハイパーリンクと `window.open()` に対する呼び出しにのみ適用されます。

`config.xml` で、次のように `<allow-intent>` タグを追加します。

    <!-- Web ページに対するリンクを許可し、ブラウザーで開きます -->
    <allow-intent href="http://*/*" />
    <allow-intent href="https://*/*" />

    <!-- example.com に対するリンクを許可し、ブラウザーで開きます -->
    <allow-intent href="http://example.com/*" />

    <!-- ワイルドカードをホストに対するプレフィックス、
         パスに対するサフィックスとして、プロトコルに使用できます -->
    <allow-intent href="*://*.example.com/*" />

    <!-- messaging app を開くために SMS リンクを許可します -->
    <allow-intent href="sms:*" />

    <!-- ダイヤラーを開くために tel: リンクを許可します -->
    <allow-intent href="tel:*" />

    <!-- マップを開くために geo: リンクを許可します -->
    <allow-intent href="geo:*" />

    <!-- インストールされたアプリを開くためにすべての未認識 URL を許可します
         *非推奨* -->
    <allow-intent href="*" />

## ネットワーク要求ホワイトリスト
(Cordova ネイティブ フック経由で) 実行を許可するネットワーク要求 (画像、XHR など) を制御します。

注:コンテンツ セキュリティ ポリシー (後述) の使用をお勧めします。これはより安全です。このホワイトリストは、CSP をサポートしていない WebView に対してほとんどが歴史的なものです。

`config.xml` で、次のように `<access>` タグを追加します。

    <!-- 画像、XHR などを google.com に許可します -->
    <access origin="http://google.com" />
    <access origin="https://google.com" />

    <!-- サブドメイン maps.google.com にアクセスします -->
    <access origin="http://maps.google.com" />

    <!-- google.com 上のすべてのドメインにアクセスします -->
    <access origin="http://*.google.com" />

    <!-- コンテンツに対する要求を有効にします:URL -->
    <access origin="content:///*" />

    <!-- 要求をブロックしません -->
    <access origin="*" />

`<access>` タグを使用することなく、`file://` URL へのアクセスのみを許可します。ただし、既定の Cordova アプリケーションには `<access origin="*">` が既定で含まれます。

互換:Android では、TalkBack が正常に機能するために、https://ssl.gstatic.com/accessibility/javascript/android/ に対する要求を既定で許可することもできます。

### コンテンツ セキュリティ ポリシー
(WebView 経由で直接) 実行を許可するネットワーク要求 (画像、XHR など) を制御します。

Android および iOS では、ネットワーク要求ホワイトリスト (上記を参照) は、すべての種類の要求をフィルター処理することはできません (たとえば、`<video>` & Websocket はブロックされていません)。したがって、ホワイトリストに加えて、すべてのページ上の[コンテンツ セキュリティ ポリシー](http://content-security-policy.com/) `<meta>` タグを使用する必要があります。

Android では、システム WebView 内の CSP のサポートは KitKat で始まります (ただし、Crosswalk WebView を使用して、すべてのバージョンで使用できます)。

ここでは、`.html` ページ用の CSP 宣言の例を示します。

    <!-- 良い既定の宣言:
        * gap: iOS (UIWebView を使用する場合) の場合のみ必要です。また、JS->native communication の場合に必要です
        * https://ssl.gstatic.com は、 Android の場合のみ必要です。また、TalkBack の場合、正常に機能するために必要です。
        * XSS 脆弱性のリスクを軽減するために、eval () およびインライン スクリプトの使用を無効にします。この設定は次の方法で変更できます。
            * インライン JS の有効化: 'unsafe-inline' を default-src に追加します
            * eval() の有効化: 'unsafe-eval' を default-src に追加します
    -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self' data: gap: https://ssl.gstatic.com; style-src 'self' 'unsafe-inline'; media-src *">

    <!-- 同じ起源および foo.com からのみのすべてを許可します -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self' foo.com">

    <!-- このポリシーは以下を除くすべて (CSS、AJAX、オブジェクト、フレーム、メディアなど) を許可します 
        * 同じ起源およびインライン スタイルからの CSS のみ、
        * 同じ起源およびインライン スタイルからのスクリプトと eval()
    -->
    <meta http-equiv="Content-Security-Policy" content="default-src *; style-src 'self' 'unsafe-inline'; script-src 'self' 'unsafe-inline' 'unsafe-eval'">

    <!-- 同じドメインの HTTPS 上の XHR のみを許可します。 -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self' https:">

    <!-- https://cordova.apache.org/ に対して iframe を許可します -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self'; frame-src 'self' https://cordova.apache.org">
