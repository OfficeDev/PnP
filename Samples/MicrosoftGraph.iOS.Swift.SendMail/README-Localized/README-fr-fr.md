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
- swift
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
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
  - iOS
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Mobile
---
# Kit de développement logiciel (SDK) Microsoft Graph pour iOS à l’aide de Swift #

### Résumé ###
Il existe un moyen simple d'appeler une grande quantité d'API Microsoft à l’aide d’un seul point de terminaison. Ce point de terminaison, appelé Microsoft Graph (<https://graph.microsoft.io/>), vous permet d’accéder à tous les éléments des données aux renseignements et aux idées fournis par le Cloud Microsoft.

Vous n'aurez plus besoin de garder une trace des différents points de terminaison et des jetons séparés dans vos solutions – n'est-ce pas formidable ? Ce publication est une partie introductive de la prise en main de Microsoft Graph. Pour consulter les modifications apportées à Microsoft Graph, rendez-vous sur : <https://graph.microsoft.io/changelog>

Cet exemple illustre le Kit de développement logiciel (SDK) Microsoft Graph pour iOS (<https://github.com/OfficeDev/Microsoft-Graph-SDK-iOS>) dans une application iOS simple utilisant le langage Swift (<https://developer.apple.com/swift/>). Dans l’application, nous nous enverrons un e-mail. L’objectif consiste à se familiariser avec Microsoft Graph et ses possibilités.

![Interface utilisateur d’application dans l’iPhone et le courrier électronique](http://simonjaeger.com/wp-content/uploads/2016/03/app.png)

Sachez que le kit de développement logiciel (SDK) Microsoft Graph pour iOS est encore en préversion. Pour en savoir plus sur les conditions, consultez le lien suivant : https://github.com/OfficeDev/Microsoft-Graph-SDK-iOS

Pour en savoir plus sur cet exemple, consultez la rubrique <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/>

### Produits concernés ###
-  Exchange Online
-  Office 365
-  Hotmail.com
-  Live.com
-  MSN.com
-  Outlook.com
-  Passport.com

### Conditions préalables ###
Vous devez inscrire votre application avant d’effectuer des appels vers Microsoft Graph. Informations supplémentaires disponibles sur : <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/#step-11-register-the-application-in-azure-ad>

Si vous créez pour Office 365 et qu’il vous manque un locataire Office 365, procurez-vous un compte développeur sur : <http://dev.office.com/devprogram>

Vous devez installer Xcode sur votre machine pour pouvoir exécuter l'exemple. Obtenez Xcode sur : <https://developer.apple.com/xcode/>

### Projet ###
Projet | Auteur(s)
---------|----------
MSGraph.MailClient | Simon Jäger (**Microsoft**)

### Historique des versions ###
Version | Date | Commentaires
---------| -----| --------
1.0 | 9 mars 2016 | Publication initiale

### Clause d’exclusion de responsabilité ###
**CE CODE EST FOURNI *EN L’ÉTAT*, SANS GARANTIE D'AUCUNE SORTE, EXPRESSE OU IMPLICITE, Y COMPRIS TOUTE GARANTIE IMPLICITE D'ADAPTATION À UN USAGE PARTICULIER, DE QUALITÉ MARCHANDE ET DE NON-CONTREFAÇON.**

----------

# Utilisation #

La première étape consiste à inscrire votre application web dans le client Azure AD (associé au client Office 365). Pour plus d’informations sur l’inscription de l’application dans le client Azure AD, accédez à : <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/#step-11-register-the-application-in-azure-ad>

Puisque l'application rappelle dans Microsoft Graph et envoie un courrier au nom de l'utilisateur connecté, vous devez lui accorder des autorisations d'envoi de courriers.

Une fois votre application web inscrite dans Azure AD, vous devez configurer les paramètres suivants dans le fichier **adal_settings.plist** :
    
```xml
<plist version="1.0">
<dict>
	<key>ClientId</key>
	<string>[YOUR CLIENT ID]</string>
	<key>ResourceId</key>
	<string>https://graph.microsoft.com/</string>
	<key>RedirectUri</key>
	<string>[YOUR REDIRECT URI]</string>
	<key>AuthorityUrl</key>
	<string>[YOUR AUTHORITY]</string>
</dict>
</plist>
```

Lancez le fichier d’espace de travail (**MSGraph.MailClient.xcworkspace**) dans Xcode. Exécutez le projet à l’aide du raccourci **⌘R** ou en appuyant sur le bouton **Exécuter** dans le menu **Produit**.
    
# Fichiers de code source #
Les principaux fichiers de code source de ce projet sont les suivants :

- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\MailClient.swift` – cette classe se charge de la connexion de l’utilisateur, de l’accès au profil utilisateur et de l’envoi du courrier électronique avec un message.
- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\ViewController.swift` – il s’agit du contrôleur d’affichage unique de l’application iOS, qui déclenche le MailClient.
- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\adal_settings.plist` – il s’agit du fichier de liste de propriétés de configuration ADAL. Assurez-vous de configurer les paramètres requis dans ce fichier avant d'exécuter cet exemple.

# Autres ressources #
- Découvrir développement Office à l’adresse : <https://msdn.microsoft.com/en-us/office/>
- Prendre en main de Microsoft Azure : <https://azure.microsoft.com/en-us/>
- Explorez Microsoft Graph et ses opérations sur : <http://graph.microsoft.io/en-us/> 
- Pour en savoir plus sur cet exemple, consultez la rubrique <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/>


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.iOS.Swift.SendMail" />