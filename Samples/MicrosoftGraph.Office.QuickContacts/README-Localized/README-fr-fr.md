---
page_type: sample
products:
- office-outlook
- office-365
- office-sp
- ms-graph
languages:
- javascript
- nodejs
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
  services:
  - Outlook
  - Office 365
  - SharePoint
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Mobile
---
# Microsoft Graph - Contacts rapides

### Résumé

Cet exemple illustre comment utiliser Microsoft Graph pour rechercher rapidement des contacts sur des appareils mobiles.

![Capture d’écran](assets/search-results.png)

### Produits concernés

- Office 365 multi-locataire (MT).

### Conditions préalables

- Client Office 365
- Configuration de l’ application dans Azure Active Directory (AAD)
    - Autorisations
        - Office 365 SharePoint Online
            - Exécuter des requêtes de recherche en tant qu’utilisateur
        - Microsoft Graph
            - Lire la liste des personnes appropriées des utilisateurs (aperçu)
            - Accéder à l’annuaire en tant qu’utilisateur connecté
            - Lire les profils de base de tous les utilisateurs
        - Windows Azure Active Directory
            - Activer la connexion et lire le profil utilisateur
    - Le flux implicite OAuth activé
    
### Solution

Solution|Author(s)
--------|---------
MicrosoftGraph.Office.QuickContacts|Waldek Mastykarz (MVP, Rencore, @waldekm), Stefan Bauer (n8d, @StfBauer)

### Historique des versions

Version|Date|Commentaires
-------|----|--------
1.0|24 mars 2016|Publication initiale

### Clause d’exclusion de responsabilité
**CE CODE EST FOURNI *EN L’ÉTAT*, SANS GARANTIE D'AUCUNE SORTE, EXPRESSE OU IMPLICITE, Y COMPRIS TOUTE GARANTIE IMPLICITE D'ADAPTATION À UN USAGE PARTICULIER, DE QUALITÉ MARCHANDE ET DE NON-CONTREFAÇON.**

---

## Contacts rapides Office

Il s’agit d’un exemple d’application illustrant la façon dont vous pouvez tirer parti de Microsoft Graph pour trouver rapidement les contacts appropriés à l’aide de votre téléphone mobile.

![Contacts trouvés dans l’application Contacts rapides Office](assets/search-results.png)

Utilisation de la nouvelle API de contacts, l’application vous permet de rechercher des contacts, notamment les informations de contact.

![Afficher les actions rapides sur un contact](assets/quick-actions.png)

Étant donné que la nouvelle API de contacts utilise la recherche phonétique peu importe si vous n’orthographiez pas le nom de la personne que vous recherchez correctement.

![Résultats de recherche pour un nom de contact mal saisi](assets/typo.png)

En appuyant sur un contact, vous pouvez accéder à des informations supplémentaires et, si le contact vient de votre organisation, vous pouvez même obtenir un lien direct vers leur adresse de messagerie.

![Carte de visite ouverte dans l’application](assets/person-card.png)

## Conditions préalables

Avant de pouvoir démarrer cette application, vous devez effectuer quelques étapes de configuration.

### Configurer une application Azure AD

Cette application utilise Microsoft Graph pour rechercher un contact approprié. Afin de pouvoir accéder à Microsoft Graph, une application Azure Active Directory correspondante doit être configurée dans votre Azure Active Directory. Pour créer et configurer correctement l’application dans AAD, procédez comme suit. 

- dans Azure Active Directory créer une nouvelle application Web
- définir **l’URL de connexion** à `https://localhost :8443`
- copier le **ID client**, nous en avons besoin pour configurer l’application.
- dans **l’URL de réponse** ajouter `https://localhost :8443`. Si vous voulez tester l’application sur votre appareil mobile, vous devez également ajouter l’URL de **Externe** affichée par browserify après le démarrage de l’application à l’aide de `$ gulp serve`
- accorder à votre application les autorisations suivantes :
    - Office 365 SharePoint Online
        - Exécuter des requêtes de recherche en tant qu’utilisateur
    - Microsoft Graph
        - Lire la liste des personnes appropriées des utilisateurs (aperçu)
        - Accéder à l’annuaire en tant qu’utilisateur connecté
        - Lire les profils de base de tous les utilisateurs
    - Windows Azure Active Directory
        - Activer la connexion et lire le profil utilisateur
- activer le flux implicite OAuth

### Configurer l’application.

Avant de pouvoir démarrer l’application, celle-ci doit être liée à l’application Azure Active Directory nouvellement créée et à un client SharePoint. Les deux paramètres peuvent être configurés dans le fichier de`app/app.config.js`.

- cloner ce référentiel
- comme la valeur de la constante **appId** définit **l’ID de client** précédemment copiée de l’application AAD nouvellement créée.
- comme la valeur de la constante **sharePointUrl** définit l’URL de votre client SharePoint sans la barre oblique de fin, p.ex. `https://contoso.sharepoint.com`

## Exécution de cette application

Achever les tâches suivantes pour déployer l’application :

- dans la ligne de commande, exécuter
```
$ npm i && bower i
```
- dans la ligne de commande, exécuter
```
$ gulp serve
```
pour démarrer l’application

![Application démarrée dans le navigateur](assets/app.png) 

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office.QuickContacts" />