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

Este complemento implementa una directiva de lista blanca para navegar por la vista web de la aplicación en Cordova 4.0

: advertencia: Informar sobre problemas en el [Detector de problemas de Apache Cordova](https://issues.apache.org/jira/issues/?jql=project%20%3D%20CB%20AND%20status%20in%20%28Open%2C%20%22In%20Progress%22%2C%20Reopened%29%20AND%20resolution%20%3D%20Unresolved%20AND%20component%20%3D%20%22Plugin%20Whitelist%22%20ORDER%20BY%20priority%20DESC%2C%20summary%20ASC%2C%20updatedDate%20DESC)


## Plataformas Cordova compatibles

* Android 4.0.0 o superior

## Lista blanca de navegación
Controla a qué direcciones URL se puede navegar en la propia WebView.
Solo aplica a las navegaciones de nivel superior.

No estándar: en Android también se aplica a iframes para los esquemas que no son http.

De forma predeterminada, solo se permiten las navegaciones a direcciones URL del tipo `file://`. Para permitir otras direcciones URL, tiene que agregar etiquetas `<allow-navigation>` a su `config.xml`:

    <!-- Permitir vínculos a example.com -->
    <allow-navigation href="http://example.com/*" />

    <!-- Se permiten comodines para el protocolo, como prefijo
         en el host o como sufijo en la ruta de acceso -->
    <allow-navigation href="*://*.example.com/*" />

    <!-- Puede usarse un comodín para incluir toda la red en la lista blanca,
         para HTTP y HTTPS.
         *NO RECOMENDADO* -->
    <allow-navigation href="*" />

    <!-- Lo anterior es equivalente a estas tres declaraciones -->
    <allow-navigation href="http://*/*" />
    <allow-navigation href="https://*/*" />
    <allow-navigation href="data:*" />

## Lista blanca de intención
Controla qué direcciones URL la aplicación puede pedirle al sistema que abra.
De forma predeterminada, no se permiten direcciones URL externas.

En Android, esto equivale a enviar una intención del tipo EXAMINABLE.

Esta lista blanca no se aplica a los complementos, solo a los hipervínculos y las llamadas a `window.open()`.

En `config.xml`, agregue etiquetas `<allow-intent>` como estas:

    <!-- Permitir que los vínculos a páginas web se abran en un explorador -->
    <allow-intent href="http://*/*" />
    <allow-intent href="https://*/*" />

    <!-- Permitir que los vínculos a example.com se abran en un explorador -->
    <allow-intent href="http://example.com/*" />

    <!-- Se permiten comodines para el protocolo, como prefijo
         en el host o como sufijo en la ruta de acceso -->
    <allow-intent href="*://*.example.com/*" />

    <!-- Permitir que los vínculos de SMS abran la aplicación de mensajería -->
    <allow-intent href="sms:*" />

    <!-- Permitir que los vínculos telefónicos abran el marcador -->
    <allow-intent href="tel:*" />

    <!-- Permitir que los vínculos geográficos abran mapas -->
    <allow-intent href="geo:*" />

    <!-- Permitir que todas las direcciones URL no reconocidas abran aplicaciones instaladas
         *NO RECOMENDADO* -->
    <allow-intent href="*" />

## Lista blanca de solicitud de red
Controla qué solicitudes de red (imágenes, XHR, etc.) se pueden realizar (a través de enlaces nativos de Cordova).

Nota: Le recomendamos que use una directiva de seguridad de contenido (ver abajo), que es más segura. La lista blanca es mayormente histórica para las vistas web que no son compatibles con CSP.

En `config.xml`, agregue etiquetas `<access>` como estas:

    <!-- Permitir el acceso de imágenes, XHR, etc. a google.com -->
    <access origin="http://google.com" />
    <access origin="https://google.com" />

    <!-- Acceso al subdominio maps.google.com -->
    <access origin="http://maps.google.com" />

    <!-- Acceso a todos los subdominios de google.com -->
    <access origin="http://*.google.com" />

    <!-- Habilitar solicitudes a contenido: URL -->
    <access origin="content:///*" />

    <!-- No bloquear ninguna solicitud -->
    <access origin="*" />

Sin ninguna etiqueta `<access>`, solo se permiten las solicitudes a direcciones URL del tipo `file://`. Sin embargo, la aplicación predeterminada de Cordova incluye `<access origin="*">` de forma predeterminada.

No estándar: Android también permite solicitudes para https://ssl.gstatic.com/accessibility/javascript/android/ de forma predeterminada, ya que esto es necesario para que TalkBack funcione correctamente.

### Directiva de seguridad de contenido
Controla qué solicitudes de red (imágenes, XHR, etc.) se pueden realizar (directamente por vistas web).

En Android e iOS, la lista blanca de solicitudes de red (ver arriba) no puede filtrar todos los tipos de solicitudes (por ejemplo, no se bloquea `<video>` ni WebSockets). Por lo tanto, además de la lista blanca, debería usar una etiqueta `<meta>` de [Directiva de seguridad de contenido](http://content-security-policy.com/) en todas sus páginas.

En Android, la compatibilidad con CSP dentro de la vista web del sistema comienza con KitKat (pero está disponible en todas las versiones con la vista web de Crosswalk).

Aquí encontrará algunas declaraciones CSP de ejemplo para sus páginas `.html`:

    <!-- Declaración predeterminada adecuada:
        * gap: solo se requiere en iOS (cuando se usa UIWebView) y es necesario para la comunicación JS->native
        * https://ssl.gstatic.com solo se requiere en Android y es necesario para que TalkBack funcione correctamente
        * Deshabilita el uso de secuencias de comandos en línea y eval() para reducir el riesgo de vulnerabilidades XSS. Para cambiar esto puede realizar lo siguiente:
            * Habilitar JS en línea: agregue 'unsafe-inline' a default-src
            * Habilitar eval(): agregue 'unsafe-eval' a default-src
    -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self' data: gap: https://ssl.gstatic.com; style-src 'self' 'unsafe-inline'; media-src *">

    <!--Permitir todo, pero solo del mismo origen y foo.com -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self' foo.com">

    <!--Esta directiva permite todo (por ejemplo, CSS, AJAX, objeto, marco, multimedia, etc.), con las siguientes excepciones: 
        * CSS solo desde el mismo origen y estilos en línea,
        * scripts solo desde el mismo origen y estilos en línea, y eval()
    -->
    <meta http-equiv="Content-Security-Policy" content="default-src *; style-src 'self' 'unsafe-inline'; script-src 'self' 'unsafe-inline' 'unsafe-eval'">

    <!--Permite XHR solo sobre HTTPS del mismo dominio. -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self' https:">

    <!-- Permitir iframe en https://cordova.apache.org/ -->
    <meta http-equiv="Content-Security-Policy" content="default-src 'self'; frame-src 'self' https://cordova.apache.org">
