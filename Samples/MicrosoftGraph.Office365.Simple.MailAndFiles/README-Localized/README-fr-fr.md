---
page_type: sample
products:
- office-outlook
- office-onedrive
- office-sp
- office-365
- ms-graph
languages:
- aspx
- csharp
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Office UI Fabric
  - Azure AD
  services:
  - Outlook
  - OneDrive
  - SharePoint
  - Office 365
  createdDate: 1/1/2016 12:00:00 AM
---
# Microsoft Graph : interroger des fichiers personnels et des courriers électroniques #

### Récapitulatif ###
Il s’agit d’une application ASP.net MVC simple permettant d’interroger des e-mails personnels et des fichiers à l’aide de Microsoft Graph qui affiche également la requête dynamique des informations avec des requêtes ajax. L’exemple utilise également la structure de l’interface utilisateur Office pour offrir une expérience utilisateur cohérente avec des contrôles et une présentation standardisés.

### Produits concernés ###
-  Office 365 multi-locataire (MT).

### Conditions préalables ###
Configuration d'application dans Azure AD

### Solution ###
Solution | Auteur(s)
---------|----------
Office365Api.Graph.Simple.MailAndFiles | Vesa Juvonen

### Historique des versions ###
Version | Date | Commentaires
---------| -----| --------
1.0 | 05 février 2016 | Publication initiale

### Clause d’exclusion de responsabilité ###
**CE CODE EST FOURNI *EN L’ÉTAT*, SANS GARANTIE D'AUCUNE SORTE, EXPRESSE OU IMPLICITE, Y COMPRIS TOUTE GARANTIE IMPLICITE D'ADAPTATION À UN USAGE PARTICULIER, DE QUALITÉ MARCHANDE ET DE NON-CONTREFAÇON.**

----------

# Introduction #
Cet exemple présente une connectivité simpliste à Microsoft Graph pour afficher les messages électroniques et les fichiers de l’utilisateur spécifique. L’interface utilisateur actualise automatiquement les différentes parties de l’interface utilisateur, si de nouveaux éléments se présentent dans la boîte de réception ou s'ils sont ajoutés au site OneDrive Entreprise de l’utilisateur.

![Interface utilisateur de l’application](http://i.imgur.com/Rt4d8Py.png)

# Configuration de Azure Active Directory #
Avant que cet exemple ne puisse être exécuté, vous devrez enregistrer l’application sur Azure Active Directory et fournir les autorisations nécessaires au fonctionnement des requêtes Graph. Nous allons créer une entrée d’application vers Azure Active Directory et configurer les autorisations nécessaires.

- Ouvrez l'interface utilisateur du Portail Azure et progressez vers les interfaces utilisateur d'Active Directory. Au moment de la rédaction de cet article, cette action est uniquement disponible dans les interfaces utilisateur de l'ancien portail.
- Avance vers la sélection des **applications**
- Cliquez sur **Ajouter** pour démarrer la création d’une nouvelle application
- Sélectionnez **Ajouter une application en cours de développement par mon organisation**

![Que voulez-vous faire de l’interface utilisateur dans Azure AD ?](http://i.imgur.com/dNtLtnl.png)

- Donnez à votre application un **nom**, puis sélectionnez **application web et API web** en tant que type

![Ajouter une interface utilisateur de l'application](http://i.imgur.com/BrxalG7.png)

- Mettez à jour les propriétés d’application comme suit pour le débogage
	- **URL** – https://localhost:44301/
	- **URL d’ID de l'application** : une URI valide telle que http://pnpemailfiles.contoso.local. Il s’agit simplement d’un identificateur. Elle ne doit pas impérativement être une URL valide actuelle.

![Interface utilisateur des détails de l’application](http://i.imgur.com/1IaNxLm.png)

- Rendez-vous sur la page **configurer** et la section près des clés
- Sélectionnez 1 ou 2‚ans pendant pour la clé secrète générée

![Paramètre du cycle de vie de la clé secrète](http://i.imgur.com/7kX396J.png)

- Cliquez sur **Enregistrer** et copiez la clé secrète générée pour une utilisation future à partir de la page. Veuillez noter que la clé secrète est visible pendant cette période uniquement. Vous devez donc la sécuriser vers un autre emplacement.

![Clé secrète client](http://i.imgur.com/5vnkkTA.png)

- Faites défiler vers le bas pour accéder à la configuration des autorisations

![Autorisations accordées à d’autres applications](http://i.imgur.com/tF4R75w.png)

- Sélectionnez Office 365 Exchange Online et Office 365 SharePoint Online comme applications auxquelles vous voulez attribuer des autorisations

![Attribution d’autorisations](http://i.imgur.com/XGOba3Y.png)

- Donnez l’autorisation « **Lire les e-mails utilisateur** » sous les autorisations Exchange Online

![Sélection des autorisations nécessaires pour Exchange](http://i.imgur.com/CyH9gg2.png)

- Donnez l’autorisation « **Lire les fichiers utilisateur** » sous les autorisations Exchange Online

![Sélection des autorisations nécessaires pour SharePoint](http://i.imgur.com/NSZiHsh.png)

- Cliquez sur **Enregistrer** 

Vous avez désormais terminé la configuration nécessaire au niveau d'Azure Active Directory. Veuillez noter que vous devez tout de même configurer les ID client et clé secrète du fichier web.config dans le projet. Mettez correctement à jour les clés d'ID client et ClientSecret.

![Configuration de web.config](http://i.imgur.com/pihBvR5.png)

# Exécutez la solution #
Lorsque vous avez configuré le côté Azure Active Directory et mis à jour le fichier web.config selon vos valeurs environnementales, vous pouvez exécuter l’exemple de manière correcte.

- Appuyez sur la touche F5 dans Visual Studio
- Cliquez sur **Se connecter à Office 365** ou **Connexion** à partir de la barre de suite. Ceci génère l'affichage de l'interface utilisateur de consentement Azure Active Directory pour vous connecter à la page Azure AD appropriée

![Interface utilisateur de l’application](http://i.imgur.com/YMCrG4O.png)

- Connectez-vous aux informations d’identification Azure Active Directory appropriées pour l’application

![Connectez-vous à Azure AD-interface – Interface utilisateur de consentement](http://i.imgur.com/gNz5Wgz.png)

- L’interface utilisateur de l’application s’affiche.

![Interface utilisateur de l’application comprenant vos données personnelles](http://i.imgur.com/Rt4d8Py.png)


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.Simple.MailAndFiles" />