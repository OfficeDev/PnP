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
# API de Office 365: Groups Explorer#

### Resumen ###
La aplicación web complementaria muestra una lista de todos los grupos del espacio empresarial del usuario, así como todas las propiedades.

### Se aplica a ###
-  Office 365 multiempresa (MT)

### Requisitos previos ###
Este ejemplo requiere la versión de la API de Office 365 publicada en noviembre de 2014. Para obtener más información, vea http://msdn.microsoft.com/es-es/office/office365/howto/platform-development-overview.

### Solución ###
Solución | Autor
--------|----------
Office365Api.Groups | Paul Schaeflein (Schaeflein Consulting, @paulschaeflein)

### Historial de versiones ###
Versión | Fecha | Comentarios
---------| -----| --------
1.0 | 8 de febrero de 2016 | Versión inicial

### Aviso de declinación de responsabilidades ###
**ESTE CÓDIGO ES PROPORCIONADO *TAL CUAL* SIN GARANTÍA DE NINGÚN TIPO, YA SEA EXPLÍCITA O IMPLÍCITA, INCLUIDAS LAS GARANTÍAS IMPLÍCITAS DE IDONEIDAD PARA UN FIN DETERMINADO, COMERCIABILIDAD O AUSENCIA DE INFRACCIÓN.**


----------

# Explorar la API de Grupos de Office 365 #
Este ejemplo se proporciona para ayudar en la revisión de propiedades y relaciones de Grupos de Office 365.
Puede encontrar más información en esta entrada de blog: http://www.schaeflein.net/exploring-the-office-365-groups-api/.



# Ejemplo de ASP.NET MVC #
En esta sección se describe el ejemplo de ASP.NET MVC incluido en la solución actual.

## Preparar el entorno para el ejemplo de ASP.NET MVC ##
La aplicación de ejemplo de ASP.NET MVC usará la nueva API de Microsoft Graph para realizar la siguiente lista de tareas:

-  Leer la lista de grupos en el directorio del usuario actual
-  Leer las conversaciones, eventos y archivos en los grupos "unificados"
-  Mostrar la lista de grupos a los que se ha unido el usuario actual

Para ejecutar la aplicación web tendrá que registrarla en su espacio empresarial de desarrollo de Azure AD.
La aplicación web usa OWIN y OpenId Connect para autenticarse en el Azure AD que se encuentra en su espacio empresarial de Office 365.
Puede encontrar más información sobre OWIN y OpenId Connect, además de instrucciones para registrar la aplicación en el espacio empresarial de Azure AD, aquí: http://www.cloudidentity.com/blog/2014/07/28/protecting-an-mvc4-vs2012-project-with-openid-connect-and-azure-ad/ 

Después de registrar la aplicación en el espacio empresarial de Azure AD, tendrá que configurar las siguientes opciones en el archivo web.config:

		<add key="ida:ClientId" value="[Ingrese su ClientID aquí]" />
		<add key="ida:ClientSecret" value="[Ingrese su ClientSecret aquí]" />
		<add key="ida:TenantId" value="[Ingrese su TenantId aquí]" />
		<add key="ida:Domain" value="su_dominio.enmicrosoft.com" />

# Qué contiene el código del ejemplo #
La aplicación está codificada con el punto de conexión beta de la API de Graph. La clase GroupsController especifica la dirección URL de cada llamada:

```
string apiUrl = String.Format("{0}/beta/myorganization/groups/{1}/conversations/{2}/threads", 
                              SettingsHelper.MSGraphResourceId, 
                              id, itemId);
```

La interfaz de usuario de usa Office UI Fabric (http://dev.office.com/fabric). Hay algunas vistas DisplayTemplate personalizadas que controlan el estilo necesario del CSS del tejido.

## Créditos ##
Los espacios multiempresariales con ASP.NET MVC y OpenID Connect se proporcionan gracias al proyecto de GitHub disponible aquí:
https://github.com/Azure-Samples/active-directory-dotnet-webapp-multitenant-openidconnect

Créditos para https://github.com/dstrockis y https://github.com/vibronet.

El estilo de Office UI Fabric contó con la ayuda de esta entrada de blog: http://chakkaradeep.com/index.php/using-office-ui-fabric-in-sharepoint-add-ins/ 

Crédito para https://github.com/chakkaradeep

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.GroupsExplorer" />