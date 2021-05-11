---
page_type: sample
products:
- office-365
- office-sp
- ms-graph
languages:
- aspx
- csharp
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
  - Microsoft identity platform
  services:
  - Office 365
  - Microsoft identity platform
  - SharePoint
  createdDate: 1/1/2016 12:00:00 AM
---
# Exemples sur le kit de développement logiciel API Microsoft Graph pour .NET

### Résumé ###
Il s’agit d’un exemple de solution qui illustre comment utiliser le Kit de développement logiciel
(SDK) de l’API Microsoft Graph pour .NET. La solution inclut :
* Une application de console qui utilise le nouvel aperçu MSAL (Microsoft Authentication Library)
pour l’authentification sur le nouveau point de terminaison d’authentification v2
* Une application web MVC ASP.NET,
qui utilise ADAL (Bibliothèque d’authentification Active Directory) pour l’authentification sur le point de terminaison Azure AD

Cet exemple fait partie des exemples de code liés au livre [« Programming Microsoft Office 365 »](https://www.microsoftpressstore.com/store/programming-microsoft-office-365-includes-current-book-9781509300914) rédigé par [Paolo Pialorsi](https://twitter.com/PaoloPia) et publié par Microsoft Press.

### S’applique à ###
-  Microsoft Office 365

### Solution ###
Solution | Auteur (s) | Twitter
---------|-----------|--------
MicrosoftGraph. 365. DotNetSDK.sln | Paolo Pialorsi (PiaSys.com) | [@PaoloPia](https://twitter.com/PaoloPia)

### Historique des versions ###
Version | Date | Commentaires
---------| -----| --------
1.0 | 12 mai 2016 | Publication initiale

### Instructions d'installation ###
Pour lire cet exemple, vous devez :

-  S’inscrive à un abonnement pour les développeurs pour Office 365 [Centre de développement Office](http://dev.office.com/), si vous n’en avez pas
-  Enregistrer l’application web dans [Azure AD](https://manage.windowsazure.com/) pour obtenir un ClientID et une clé secrète client 
-  Configurer l’application Azure AD avec les autorisations déléguées suivantes pour Microsoft Graph : Afficher le profil de base des utilisateurs, afficher l’adresse e-mail des utilisateurs
-  Mettre à jour le fichier web.config de l’application web avec les paramètres appropriés (ClientID, ClientSecret, Domain, IDClient)
-  Enregistrer l’application console pour le point de terminaison d’authentification v2 dans le nouveau [Portail d’inscription des applications](https://apps.dev.microsoft.com/) 
-  Configurer le fichier. config de l’application console avec les paramètres appropriés (MSAL_ClientID)

 
<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.DotNetSDK" />