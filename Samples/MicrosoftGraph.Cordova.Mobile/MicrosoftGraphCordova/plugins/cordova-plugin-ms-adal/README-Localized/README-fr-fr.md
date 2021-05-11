# Plug-in de la Bibliothèque d’authentification Active Directory (ADAL) pour les applications Apache Cordova

Le plug-in de la Bibliothèque d’authentification Active Directory ([ADAL](https://msdn.microsoft.com/en-us/library/azure/jj573266.aspx))
vous offre des fonctionnalités d’authentification facilitées à utiliser pour vos applications Apache Cordova en tirant parti de Windows Server Active Directory et de Windows Azure Active Directory. Vous trouverez ici le code source de la bibliothèque.

  * [Bibliothèque ADAL pour Android](https://github.com/AzureAD/azure-activedirectory-library-for-android),
  * [Bibliothèque ADAL pour iOS](https://github.com/AzureAD/azure-activedirectory-library-for-objc),
  * [Bibliothèque ADAL pour .NET](https://github.com/AzureAD/azure-activedirectory-library-for-dotnet).

Ce plug-in utilise des kits de développement de logiciel natifs pour ADAL pour chacune des plateformes prises en charge et fournit une API unique pour toutes les plateformes. Voici un rapide exemple d’utilisation :

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

__Remarque__ : Vous pouvez également utiliser le constructeur synchrone `AuthenticationContext` :

```javascript
authContext = new AuthenticationContext(authority);
authContext.acquireTokenAsync(resourceUrl, appId, redirectUrl).then(function (authRes) {
    console.log(authRes.accessToken);
    ...
});
```

Pour plus d’informations sur les API, voir [exemple d’application](https://github.com/AzureAD/azure-activedirectory-library-for-cordova/tree/master/sample) et JSDoc pour les fonctionnalités exposées stockées dans le sous-dosseier [www](https://github.com/AzureAD/azure-activedirectory-library-for-cordova/tree/master/www).

## Plateformes prises en charge

  * Android
  * iOS
  * Windows (Windows 8.0, Windows 8.1 et Windows Phone 8.1)

## Problèmes connus et solutions de contournement

## Erreur 'Class not registered' sur Windows

Si vous utilisez Visual Studio 2013 et remarquez l'erreur d'exécution 'WinRTError: Class not registered' sur Windows, assurez-vous que la [mise à jour 5](https://www.visualstudio.com/news/vs2013-update5-vs) de Microsoft Visual Studio est installée.

## Problème de connexions multiples Windows

Plusieurs fenêtres de boîte de dialogue de connexion s’affichent si `acquireTokenAsync` est appelée plusieurs fois et que le jeton n’a pas pu être acquis silencieusement (lors de la première exécution, par exemple). Utilisez une [mise en file d'attente de la promesse](https://www.npmjs.com/package/promise-queue)/une logique de sémaphore dans le code d’application pour éviter ce problème.

## Instructions d’installation

### Conditions préalables

* [NodeJS et NPM](https://nodejs.org/)

* [Cordova CLI](https://cordova.apache.org/)

  Cordova CLI peut être facilement installé via le Gestionnaire de package NPM : `npm install -g cordova`

* Vous trouverez d’autres conditions préalables pour chaque plateforme cible sur la page de la [documentation sur les plateformes Cordova](http://cordova.apache.org/docs/en/edge/guide_platforms_index.md.html#Platform%20Guides) :
 * [Instructions pour Android](http://cordova.apache.org/docs/en/edge/guide_platforms_android_index.md.html#Android%20Platform%20Guide)
 * [Instructions pour iOS](http://cordova.apache.org/docs/en/edge/guide_platforms_ios_index.md.html#iOS%20Platform%20Guide)
 * [Instructions pour Windows] (http://cordova.apache.org/docs/en/edge/guide_platforms_win8_index.md.html#Windows%20Platform%20Guide)

### Pour créer et exécuter l’application d'exemple :

  * Clonez le référentiel de plug-in dans un répertoire de votre choix

    `git clone https://github.com/AzureAD/azure-activedirectory-library-for-cordova.git`

  * Créez un projet et ajoutez les plateformes que vous souhaitez prendre en charge :

    `cordova create ADALSample --copy-from="azure-activedirectory-library-for-cordova/sample"`

    `cd ADALSample`

    `cordova platform add android`

    `cordova platform add ios`

    `cordova platform add windows`

  * Ajoutez le plug-in à votre projet

    `cordova plugin add ../azure-activedirectory-library-for-cordova`

  * Créez et exécutez l’application : `exécuter cordova`.


## Configurer une application dans Azure Active Directory

Vous pouvez trouver des instructions détaillées sur la façon de configurer une nouvelle application dans Azure Active Directory [ici](https://github.com/AzureADSamples/NativeClient-MultiTarget-DotNet#step-4--register-the-sample-with-your-azure-active-directory-tenant).

## Tests

Ce plug-in contient une suite de tests, basée sur le [plug-in Cordova test-framework](https://github.com/apache/cordova-plugin-test-framework). La suite de tests est placée sous le dossier `tests` à la racine ou sur le référentiel et il représente un plug-in distinct.

Pour exécuter les tests, vous devez créer une application comme décrit dans la [sectiondes Instructions d’installation](#installation-instructions), puis procédez comme suit :

  * Ajouter une suite de tests à l’application

    `cordova plugin add ../azure-activedirectory-library-for-cordova/tests`

  * Mise à jour du fichier config.xml file: change de `<content src="index.html" />` vers `<content src="cdvtests/index.html" />`
  * Modifiez les paramètres spécifiques à Active Directory pour tester l'application au début du fichier `plugins\cordova-plugin-ms-adal\www\tests.js`. Mettez à jour `AUTHORITY_URL``RESOURCE_URL``REDIRECT_URL``APP_ID` à des valeurs fournies par votre Azure Active Directory. Pour obtenir des instructions sur la configuration d’une application Azure Azure Directory, référez-vous à la [Configuration d’une application dans la section Azure Active Directory](#setting-up-an-application-in-azure-ad).
  * Création et exécution de l’application.

## Windows Quirks ##
[Un problème Cordova existe actuellement](https://issues.apache.org/jira/browse/CB-8615), ce qui nécessite la solution de contournement basée sur un hook.
La solution de contournement doit être rejetée après l'application d'un correctif.

### Utilisation de ADFS/SSO
Pour utiliser ADFS/SSO sur une plateforme Windows (Windows 8.1 n'est pas prise en charge pour le moment), ajoutez la référence suivante dans `config.xml` :
`<nom de préférence="adal-use-corporate-network" value="true" />`

`adal-use-corporate-network` est `false` par défaut.

Elle ajoute toutes les fonctionnalités d'applications utiles et active authContext pour la prise en charge d’ADFS. Vous pouvez modifier sa valeur en `false` et revenir plus tard, ou la supprimer de `config.xml` – call `cordova prepare` après l’application des modifications.

__Remarque__ : Vous ne devez pas utiliser `adal-use-corporate-network` car elle ajoute des fonctionnalités qui empêchent la publication d’une application sur le Windows Store.

## Copyrights ##
Copyright (c) Microsoft Open Technologies, Inc. Tous droits réservés.

Sous licence Apache, version 2.0 (la « License »); vous devez utiliser ces fichiers conformément à la Licence. Vous pouvez obtenir une copie de la Licence sur 

http://www.apache.org/licenses/LICENSE-2.0

Sauf exigence par une loi applicable ou accord écrit, tout logiciel distribué dans le cadre de la Licence est fourni « EN L'ÉTAT », SANS GARANTIE OU CONDITION D'AUCUNE SORTE, explicite ou implicite. Consultez la Licence pour les dispositions linguistiques spécifiques régissant les autorisations et limitations dans le cadre de la License.
