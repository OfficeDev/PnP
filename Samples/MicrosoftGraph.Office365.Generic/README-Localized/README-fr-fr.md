---
page_type: sample
products:
- office-365
- office-outlook
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
  services:
  - Office 365
  - Outlook
  - SharePoint
  - Users
  - Groups
  createdDate: 1/1/2016 12:00:00 AM
---
# Exemple générique pour Microsoft.Graph pour les fonctionnalités d’Office 365 #

### Résumé ###
Il s’agit d’un exemple générique pour Microsoft Graph autour des fonctionnalités d’Office 365. Illustre différentes opérations suivies de zones :
- calendrier
- contacts
- fichiers
- groupes unifiés
- utilisateurs

Pour plus d’informations et pour consulter la démonstration en direct sur cet exemple :
- [pPnP Web Cast - PnP Web Cast - connexion web PNP-présentation de Microsoft Graph pour le développeur Office 365](https://channel9.msdn.com/blogs/OfficeDevPnP/PnP-Web-Cast-Introduction-to-Microsoft-Graph-for-Office-365-developer)

### S’applique à ###
-  Office 365 multi-locataire (MT).

### Conditions préalables ###
Configuration de l’application dans Azure AD - ID client et clé secrète client

### Solution ###
Solution | Author(s)
---------|----------
OfficeDevPnP.MSGraphAPIDemo | Paolo Pialorsi

### Historique des versions ###
Version | Date | Commentaires
---------| -----| --------
1.0 | 8 février 2016 | Publication initiale

### Clause d’exclusion ###
**CE CODE EST FOURNI *EN L’ÉTAT*, SANS GARANTIE D'AUCUNE SORTE, EXPRESSE OU IMPLICITE, Y COMPRIS TOUTE GARANTIE IMPLICITE D'ADAPTATION À UN USAGE PARTICULIER, DE QUALITÉ MARCHANDE ET DE NON-CONTREFAÇON.**


----------

# Conseils de configuration #
La configuration de haut niveau est détaillée comme suit :

- Inscrire l’ID client et le code secret dans Azure Active Directory
- Configurer les autorisations nécessaires pour l’application
- Configurer le fichier web.config en conséquence avec les informations de l’application inscrite 

![Détails de la configuration dans web.config](http://i.imgur.com/POSJqD7.png)

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.Generic" />