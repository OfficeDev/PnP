---
page_type: sample
products:
- office-sp
- office-365
- ms-graph
languages:
- python
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
  services:
  - SharePoint
  - Office 365
  createdDate: 1/1/2016 12:00:00 AM
---
# Authentification de l’application Python Flask d’Office 365 #

### Résumé ###
Ce scénario montre comment configurer l’authentification entre une application Python (à l’aide de la micro-infrastructure Flask) et un site SharePoint Online d’Office 365. Cet exemple vise à montrer comment un utilisateur peut s’authentifier et interagir avec des données à partir du site SharePoint d’Office 365.

### S’applique à ###
- Office 365 multi-locataire (MT).
- Office 365 dédié (D)

### Conditions préalables ###
- Client de développeur Office 365
- Visual Studio 2015 installé
- Python Tools pour Visual Studio installés
- Python 2.7 ou 3.4 installé
- Flasks, demandes, packages Python PyJWT installés via pip

### Solution ###
Solution | Auteur (s) 
---------|---------- 
Python.Office365.AppAuthentication | Velin Georgiev (**OneBit Software**), Radi Atanassov (**OneBit Software**)

### Historique des versions ###
Version | Date | Commentaires 
---------| -----| -------- 
1.0 | 9 février 2016 | Publication initiale (Velin Georgiev)

### Clause d’exclusion ###
**CE CODE EST FOURNI *EN L’ÉTAT*, SANS GARANTIE D'AUCUNE SORTE, EXPRESSE OU IMPLICITE, Y COMPRIS TOUTE GARANTIE IMPLICITE D'ADAPTATION À UN USAGE PARTICULIER, DE QUALITÉ MARCHANDE ET DE NON-CONTREFAÇON.**

----------

# Exemple d’authentification de l’application Python Flask d’Office 365 #
Cette section décrit l’exemple d’authentification de l’application Python Flask d’Office 365 incluse dans la solution actuelle.

# Préparer le scénario pour l’exemple d’authentification de l’application Python Flask d’Office 365 #
L’application Python Flask d’Office 365 permettra de :

- Utiliser des points de terminaison d’autorisation Azure AD pour effectuer l’authentification
- Utiliser les API SharePoint Office 365 pour afficher le titre de l’utilisateur authentifié

Pour que ces tâches réussissent, vous devez effectuer d’autres configurations décrites ci-dessous. 

- Créer un compte d’évaluation Azure avec le compte Office 365 de sorte que l’application puisse être inscrite ou que vous puissiez l’enregistrer avec PowerShell. Un bon didacticiel est disponible sur ce lien https://github.com/OfficeDev/PnP/blob/497b0af411a75b5b6edf55e59e48c60f8b87c7b9/Samples/AzureAD.GroupMembership/readme.md.
- Inscrire l’application dans le Portail Microsoft Azure et affecter http://localhost:5555 à l’URL de connexion et à l’URL de réponse
- Générer une clé secrète client
- Accorder l’autorisation suivante à l’application Python Flask : Office 365 SharePoint Online > Autorisations déléguées > Lire les profils utilisateur

![Paramétrage des autorisations du Portail Microsoft Azure](https://lh3.googleusercontent.com/-LxhYrbik6LQ/VrnZD-0Uf0I/AAAAAAAACaQ/jsUjHDQlmd4/s732-Ic42/office365-python-app2.PNG)

- Copiez la clé secrète cliente et l’ID client à partir du Portail Microsoft Azure et remplacez-les dans le fichier de configuration de Python Flask
- Affectez l’URL au site SharePoint auquel vous accédez comme la variable de configuration RESSOURCE.

![Détails de l’application dans le fichier de configuration](https://lh3.googleusercontent.com/-ETtW5MBuOcA/VrnZDQBAxQI/AAAAAAAACaY/ppp4My1JTlE/s616-Ic42/office365-python-app-config.PNG)

- Ouvrez l’exemple dans Visual Studio 2015
- Accédez à Projet > Propriétés > Déboguer et dédier 5555 pour le numéro de port

![Changer le port en option débogage](https://lh3.googleusercontent.com/-M3upxeCKBN0/VrnZDSHnDoI/AAAAAAAACaA/BF4CTeKlUMs/s426-Ic42/office365-python-app-vs-config.PNG)

- Accédez aux environnements Python > votre environnement python actif > exécutez « Installation à partir de la configuration requise.txt ». Ainsi, vous serez certain que tous les packages Python requis sont installés.

![Sélection de l’option de menu](https://lh3.googleusercontent.com/-At6Smrxg9DQ/VrnZD6KMvfI/AAAAAAAACaM/gcgJUATPigE/s479-Ic42/office365-python-packages.png)

## Exécuter l’exemple de l’application Python Flask d’Office 365 ##
Lorsque vous exécutez l’exemple, le titre et l’URL de connexion s’affichent.

![Interface utilisateur du complément](https://lh3.googleusercontent.com/-GDdAcmYylZE/VrnZD8sVGwI/AAAAAAAACaI/1gB0jvULLBo/s438-Ic42/office365-python-app.PNG)


Une fois que vous avez cliqué sur le lien de connexion, l’API d’Office 365 passe par le protocole de transfert d’authentification et l’écran d’accueil de Python Flask se recharge avec le titre de l’utilisateur connecté et le jeton d’accès affichés :

![Interface utilisateur de connexion](https://lh3.googleusercontent.com/-44rsAE2uGFQ/VrnZDdJAseI/AAAAAAAACaE/70N8UX8ErIk/s569-Ic42/office365-python-app-result.PNG)

<img src="https://telemetry.sharepointpnp.com/pnp/samples/Provisioning.Office365.AppAuthentication" />