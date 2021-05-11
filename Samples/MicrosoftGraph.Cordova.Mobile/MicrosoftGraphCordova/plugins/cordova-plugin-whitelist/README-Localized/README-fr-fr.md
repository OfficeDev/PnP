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

# cordova-plugin-listeverte

Ce plug-in installe une stratégie de liste verte pour la navigation dans l'affichage web de l’application sur Cordova 4.0

:avertissement: Signaler des problèmes sur le [suivi des problèmes Apache Cordova](https://issues.apache.org/jira/issues/?jql=project%20%3D%20CB%20AND%20status%20in%20%28Open%2C%20%22In%20Progress%22%2C%20Reopened%29%20AND%20resolution%20%3D%20Unresolved%20AND%20component%20%3D%20%22Plugin%20Whitelist%22%20ORDER%20BY%20priority%20DESC%2C%20summary%20ASC%2C%20updatedDate%20DESC)


## Plateformes Cordova prises en charge

* Android 4.0.0 ou version ultérieure

## Liste verte de navigation
Gère les URL auxquelles l'affichage web lui-même peut accéder.
S'applique uniquement aux navigations de niveau élevé.

Quirks : s’appliquent également aux IFrames sur Android pour les schémas autres que http(s).

Par défaut, seules les navigations vers les URL `file://` sont autorisées. Pour autoriser d’autres URL, vous devez ajouter des balises `<allow-navigation>` à votre `config.xml` :

    <!-- Autoriser les liens vers exemple.com -->
    <allow-navigation href="http://exemple.com/*" />

    <!-- Les caractères génériques sont permis pour le protocole, en tant que préfixe
         de l'hôte ou de suffixe vers le chemin d'accès -->
    <allow-navigation href="*://*.exemple.com/*" />

    <!-- Un caractère générique peut être utilisé pour mettre en liste verte le réseau,
         HTTP et HTTPS.
         *DÉCONSEILLÉ* -->
    <allow-navigation href="*" />

    <!-- Ceci est l'équivalent de ces trois déclarations -->
    <allow-navigation href="http://*/*" />
    <allow-navigation href="https://*/*" />
    <allow-navigation href="données:*" />

## Liste verte d’intentions
Gère les URL dont l’application peut demander l’ouverture auprès du système.
Par défaut, les URL externes ne sont pas autorisées.

Ceci équivaut sur Android à l’envoi d’une intention de type CONSULTABLE.

Cette liste verte ne s’applique pas aux plug-ins, mais uniquement aux liens hypertexte et aux appels vers `window.open()`.

Dans `config.xml`, ajoutez les balises `<allow-intent>` comme suit :

    <!-- Autoriser l'ouverture de liens de pages web dans un navigateur -->
    <allow-intent href="http://*/*" />
    <allow-intent href="https://*/*" />

    <!-- Autoriser l'ouverture de liens exemple.com dans un navigateur -->
    <allow-intent href="http://exemple.com/*" />

    <!-- Les caractères génériques sont permis pour le protocole, en tant que préfixe
         de l'hôte ou de suffixe vers le chemin d'accès -->
    <allow-intent href="*://*.exemple.com/*" />

    <!-- Autoriser l'ouverture de l'application de messagerie par des liens SMS -->
    <allow-intent href="sms:*" />

    <!-- Autoriser l'ouverture du numérateur par les liens tél : -->
    <allow-intent href="tél:*" />

    <!-- Autoriser zone géographique : des liens vers des cartes ouvertes -->
    <allow-intent href="zone géographique:*" />

    <!-- Autoriser l'ouverture des applications installées par toutes les URL non reconnues
         *DÉCONSEILLÉ* -->
    <allow-intent href="*" />

## Liste verte de requête réseau
Gère l'autorisation (via des crochets natifs cordova) de requêtes réseau (images, XHRs, etc.).

Remarque : Nous vous suggérons d’utiliser une stratégie de sécurité du contenu (voir ci-dessous) qui est plus sûre. Cette liste verte est historique dans la plupart des cas en ce qui concerne les affichages web ne prenant pas en charge les CSP.

Dans `config.xml`, ajoutez les balises `<access>` comme suit :

    <!-- Autoriser des images, xhrs, etc. sur google.com -->
    <access origin="http://google.com" />
    <access origin="https://google.com" />

    <!-- Autoriser l'accès au sous-domaine maps.google.com -->
    <access origin="http://maps.google.com" />

    <!-- Autoriser l'accès à tous les sous-domaines sur google.com -->
    <access origin="http://*.google.com" />

    <!-- Autoriser les requêtes vers le contenu : URL -->
    <access origin="contenu:///*" />

    <!-- Ne bloquez pas les requêtes -->
    <access origin="*" />

Sans aucune balise `<access>`, seules les requêtes vers des URL `file://` sont autorisées. Toutefois, l’application Cordova par défaut inclut `<access origin="*">` par défaut.

Quirk : Android autorise également les demandes vers d’https://ssl.gstatic.com/accessibility/javascript/android/ par défaut, car elles sont nécessaire au bon fonctionnement de TalkBack.

### Stratégie de sécurité de contenu
Gère l'autorisation (via l'affichage web directement) de requêtes réseau (images, XHRs, etc.).

Sur Android et iOS, la liste verte de requête réseau (voir ci-dessus) n’est pas en mesure de filtrer tous les types de requêtes (par exemple, `<vidéo>` & WebSockets ne sont pas bloqués). Ainsi, outre la liste verte, vous devez utiliser une balise de [Stratégie de sécurité de contenu](http://content-security-policy.com/) `<meta>` sur toutes vos pages.

Sur Android, la prise en charge de CSP dans le système d'affichage web démarre avec KitKat (mais est disponible sur toutes les versions à l’aide de l'affichage web Crosswalk).

Voici quelques exemples de déclarations CSP pour vos pages `.html` :

    <!-- Bonne déclaration par défaut :
        * écart : est seulement exigé sur iOS (lors de l’utilisation de UIWebView) et est nécessaire pour les JS->communications natives
        * https://ssl.gstatic.com est uniquement exigé sur Android et est nécessaire pour le bon fonctionnement de TalkBack
        * Désactive l’utilisation de la fonction eval() et des scripts Inline afin d’atténuer les risques liés aux vulnérabilités XSS. Pour modifier ceci :
            * Active inline JS : ajoute « unsafe-Inline » au SRC par défaut
            * Activer eval() : ajoute « unsafe-eval » au SRC par défaut
    -->
    <meta http-equiv="Stratégie-Sécurité-Contenu" content="default-src 'self' data: gap: https://ssl.gstatic.com; style-src 'self' 'unsafe-inline'; media-src *">

    <!-- Autoriser tout, sauf la même origine et foo.com -->
    <meta http-equiv="Stratégie-Sécurité-Contenu" content="default-src 'self' foo.com">

    <!-- Cette stratégie autorise toutes les actions (par ex. CSS, AJAX, object, frame, media, etc) sauf celles de 
        * CSS uniquement à partir de la même origine et styles inline,
        * CSS uniquement à partir de la même origine et styles inline, et eval()
    -->
    <meta http-equiv="Stratégie-Sécurité-Contenu" content="default-src *; style-src 'self' 'unsafe-inline'; script-src 'self' 'unsafe-inline' 'unsafe-eval'">

    <!-- Autorise uniquement les XHR sur les HTTP sur le même domaine. -->
    <meta http-equiv="Stratégie--Sécurité-Contenu" content="default-src 'self' https:">

    <!-- Autoriser les IFrames sur https://cordova.apache.org/ -->
    <meta http-equiv="Stratégie-Sécurité-Contenu" content="default-src 'self'; frame-src 'self' https://cordova.apache.org">
