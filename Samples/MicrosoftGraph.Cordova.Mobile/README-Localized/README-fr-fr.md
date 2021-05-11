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
- javascript
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
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
  - REST API
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Mobile
---
# Exemple utilisant Microsoft Graph avec Apache Cordova et le plug-in ADAL Cordova #

### Présentation ###
Cet exemple montre comment utiliser l’API Microsoft Graph pour récupérer
des données Office 365 en utilisant l’API REST et OData. L’exemple est intentionnellement simple et n’utilise
pas d’infrastructures SPA, de bibliothèque de liaison de données, de jQuery, etc.
Elle n’est pas une démonstration d’une application mobile complète.
Vous pouvez cibler différentes plateformes
Windows ainsi qu’Android et iOS à l’aide du même code JavaScript.

Le jeton d’accès est obtenu à l’aide du plug-in ADAL Cordova.
Il s’agit de l’un des principaux plug-ins de Visual Studio et il est disponible à partir de l’éditeur config.xml.
Il s’agit d’une alternative à l’Assistant Ajouter un service connecté qui génère un certain nombre
de fichiers JavaScript, y compris une bibliothèque (o365auth.js),
qui peuvent être utilisés pour obtenir des jetons à l’aide d’un navigateur intégré pour gérer la redirection de l’utilisateur vers le point de terminaison d’autorisation.
A la place, le plugin ADAL Cordova utilise les bibliothèques natives ADAL pour chaque plateforme.
Il est donc en mesure de tirer parti des
fonctionnalités natives telles que la mise en cache des jetons et les navigateurs renforcés.

### Produits concernés ###
-  Office 365 multi-locataire (MT).
-  Microsoft Graph

### Conditions préalables ###
- Visual Studio Tools pour Apache Cordova (option de configuration de VS-TACO)
- Plug-in ADAL Cordova (Cordova-plug-in-ms-Adal)

### Solution ###
Solution | Auteur (s)
---------|----------
mobile. MicrosoftGraphCordova | Bill Ayers (@SPDoctor, spdoctor.com, flosim.com)

### Historique des versions ###
Version | Date | Commentaires
---------| -----| --------
1.0 | 15 mars 2016 | Publication initiale

### Clause d’exclusion de responsabilité ###
**CE CODE EST FOURNI *EN L’ÉTAT*, SANS GARANTIE D'AUCUNE SORTE, EXPRESSE OU IMPLICITE, Y COMPRIS TOUTE GARANTIE IMPLICITE D'ADAPTATION À UN USAGE PARTICULIER, DE QUALITÉ MARCHANDE ET DE NON-CONTREFAÇON.**


----------

### Exécution de l’exemple ###

Une fois l’exemple exécuté, vous pouvez cliquer sur
le bouton « charger les données ». Si vous l’exécutez pour la première fois, vous êtes invité à autoriser l’application.
Il s’agit de l’invite de connexion Office 365 habituelle.
Comme vous utilisez Microsoft Graph,
il est également possible d’utiliser un « compte Microsoft » (par exemple, un compte live.com ou hotmail). 

Si vous avez saisi votre nom de locataire Office 365, cela fonctionnera avec ce compte.
Si vous laissez le locataire vide, le point de terminaison « commun » est utilisé et le locataire réel
utilisé est déterminé à partir des identifiants de l’utilisateur,
qui ont été utilisés pour s’authentifier auprès du point de terminaison d’autorisation.

Vous pouvez entrer une requête valide dans la zone d’entrée (bien que toutes ne soient pas analysées sans modification du code).
Vous pouvez également faire votre choix dans
la liste déroulante et sélectionner une requête prédéfinie.

![Fonctionnant sur Windows 10](MicrosoftGraphCordova.png)

Une fois qu’un jeton est obtenu, il est analysé et affiché à des fins de démonstration uniquement.
Le jeton n’est pas chiffré (d’où la nécessité d’un protocole TLS comme SSL), mais doit être traité comme opaque.
En d’autres termes, n’écrivez pas de code qui repose sur les informations contenues dans le jeton,
utilisez plutôt les API.

À l’aide du jeton d’accès, la demande REST est envoyée à l’API Microsoft Graph et les données s’affichent.
Vous pouvez remarquer un délai entre la réception du jeton et le retour des données du point de terminaison REST.
Notez que la bibliothèque ADAL permet également d’obtenir des jetons pour les points de terminaison Office 365 REST d’origine,
mais dans l’exemple de code,
l’étendue est définie sur Microsoft Graph.

Vous verrez que le jeton d’accès a une durée de vie d’environ 1 heure.
Vous pouvez continuer à effectuer d'autres demandes à l'aide du jeton jusqu'à son expiration sans autre invite.
Cela fonctionne même si vous fermez l’application et la redémarrez car le jeton est mis en cache.
Après une heure, le jeton arrive à expiration et le jeton d’actualisation est utilisé pour obtenir un nouveau jeton d’accès.
Cela génère également un nouveau jeton
d’actualisation et ce processus peut être répété pendant plusieurs mois tant que le jeton d’actualisation,
qui est également mis en cache, n’expire pas.

Si vous cliquez sur le bouton « vider le cache », le cache de jeton est effacé.
La prochaine fois que vous cliquerez sur Charger les données, vous recevrez une invite d’autorisation. 

### Dans les coulisses ###

Toute la gestion du cache (qui dépend de la plateforme), qui traite les jetons d’accès arrivés à expiration et l’utilisation du jeton d’actualisation,
est prise en charge par les bibliothèques ADAL.
Il vous suffit d’obtenir un contexte d’authentification et de suivre le modèle actuellement recommandé pour
appeler acquireTokenSilentAsync en premier. Si un jeton ne peut pas être obtenu en mode silencieux (c'est-à-dire à partir du cache ou en utilisant un jeton d'actualisation),
le rappel "échec" appelle alors
acquiseTokenAsync dont le comportement
d'invite est défini sur "toujours".

```javascript

    context.acquireTokenSilentAsync(resourceUrl, appId).then(success, function () {
      context.acquireTokenAsync(resourceUrl, appId, redirectUrl).then(success, fail);
    });

```

Bien que la documentation actuelle et certaines bibliothèques ADAL aient acquireTokenAsync avec un comportement
d’invite défini sur « auto » (ce qui signifie que l’utilisateur n’est averti que si cela est nécessaire),
la conception du plug-in Cordova fait que le acquireTokenAsync s’affiche toujours. 

Remarque : Je comprends que le reste des bibliothèques ADAL adoptera ce modèle à l'avenir. 


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Cordova.Mobile" />