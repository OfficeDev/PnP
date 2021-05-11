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
  services:
  - Office 365
  - Groups
  - SharePoint
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Connect
---
# API Office 365 : Explorateur de groupes #

### Résumé ###
L’application web compagnon répertorie tous les groupes dans le client de l’utilisateur, ainsi que toutes les propriétés.

### S’applique à ###
-  Office 365 multi-locataire (MT).

### Conditions préalables ###
Cet exemple nécessite la version de l’API Office 365 publiée en novembre 2014. Pour plus d’informations, consultez http://msdn.microsoft.com/en-us/office/office365/howto/platform-development-overview.

### Solution ###
Solution | Auteur (s)
---------|----------
Office365Api.Groups | Paul Schaeflein (Schaeflein Consulting, @paulschaeflein)

### Historique des versions ###
Version | Date | Commentaires
---------| -----| --------
1.0 | 8 février 2016 | Publication initiale

### Clause d’exclusion ###
**CE CODE EST FOURNI *EN L’ÉTAT*, SANS GARANTIE D'AUCUNE SORTE, EXPRESSE OU IMPLICITE, Y COMPRIS TOUTE GARANTIE IMPLICITE D'ADAPTATION À UN USAGE PARTICULIER, DE QUALITÉ MARCHANDE ET DE NON-CONTREFAÇON.**


----------

# Exploration de l’API de groupes Office 365 #
Cet exemple est fourni pour vous aider à examiner les propriétés et les relations entre les groupes Office 365.
Pour plus d’informations, consultez le billet de blog sur http://www.schaeflein.net/exploring-the-office-365-groups-api/.



# Exemple de ASP.NET MVC #
Cette section décrit l’exemple de ASP.NET MVC inclus dans la solution actuelle.

## Préparer le scénario pour l’exemple de ASP.NET MVC ##
L’exemple d’application ASP.NET MVC utilise les nouvelles API Microsoft Graph pour effectuer la liste des tâches suivantes :

-  Lire la liste des groupes dans le répertoire de l’utilisateur actuel
-  Lire les conversations, événements et fichiers dans les groupes « unifiés »
-  Répertorier les groupes auxquels appartient l’utilisateur actuel

Pour exécuter l’application web, vous devez l’inscrire dans votre locataire Azure AD de développement.
L’application web utilise OWIN et OpenId Connect pour s’authentifier auprès de Azure AD qui se trouve sous la couverture de votre locataire Office 365.
Vous trouverez des informations supplémentaires sur OWIN et OpenId Connect ici, ainsi que sur l’inscription de l’application sur le locataire Azure AD : http://www.cloudidentity.com/blog/2014/07/28/protecting-an-mvc4-vs2012-project-with-openid-connect-and-azure-ad/ 

Une fois l’application inscrite dans le locataire Azure AD, vous devez configurer les paramètres suivants dans le fichier web. config :

		<add key="ida:ClientId" value="[Your ClientID here]" />
		<add key="ida:ClientSecret" value="[Your ClientSecret here]" />
		<add key="ida:TenantId" value="[Your TenantId here]" />
		<add key="ida:Domain" value="your_domain.onmicrosoft.com" />

# Sous le couvert de l'exemple  #
L’application est codée sur le point de terminaison de la version bêta de l’API Graph. La classe GroupsController spécifie l’URL de chaque appel :

```
string apiUrl = String.Format("{0}/beta/myorganization/groups/{1}/conversations/{2}/threads", 
                              SettingsHelper.MSGraphResourceId, 
                              id, itemId);
```

L’interface utilisateur utilise l’interface utilisateur Office avec Fabric (http://dev.office.com/fabric). Il existe quelques affichages DisplayTemplate personnalisés qui gèrent le style nécessaire au style CSS du fabric.

## Crédits ##
L’architecture mutualisée avec ASP.NET MVC et OpenID Connect est fournie grâce au projet GitHub disponible ici :
https://github.com/Azure-Samples/active-directory-dotnet-webapp-multitenant-openidconnect

Crédits sur https://github.com/dstrockis and https://github.com/vibronet.

Le style de l’interface utilisateur d’Office Fabric a été aidé par un billet de blog ici : http://chakkaradeep.com/index.php/using-office-ui-fabric-in-sharepoint-add-ins/

Crédit sur https://github.com/chakkaradeep

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.GroupsExplorer" />