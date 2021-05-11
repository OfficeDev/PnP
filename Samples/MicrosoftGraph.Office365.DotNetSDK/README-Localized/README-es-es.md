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
# Ejemplos sobre el SDK de la API de Microsoft Graph para .NET

### Resumen ###
Esta es una solución de ejemplo donde se muestra cómo usar el SDK de la API de Microsoft Graph para
.NET. En la solución, se incluye lo siguiente:
* Una aplicación de consola, que usa la nueva versión preliminar de la MSAL
(biblioteca de autenticación de Microsoft) para autenticarse con el nuevo punto de conexión de autenticación v2.
* Una aplicación web de ASP.NET, que usa ADAL
(Biblioteca de autenticación de Active Directory de Azure) para autenticarse en un punto de conexión de Azure AD.

Este ejemplo forma parte de los ejemplos de código relacionados con el libro ["Programming Microsoft Office 365"](https://www.microsoftpressstore.com/store/programming-microsoft-office-365-includes-current-book-9781509300914) escrito por [Paolo Pialorsi](https://twitter.com/PaoloPia) y publicado por Microsoft Press.

### Se aplica a ###
-  Microsoft Office 365

### Solución ###
Solución | Autor(es) | Twitter
---------|-----------|--------
MicrosoftGraph.Office365.DotNetSDK.sln | Paolo Pialorsi (PiaSys.com) | [@PaoloPia](https://twitter.com/PaoloPia)

### Historial de versiones ###
Versión | Día | Comentarios
---------| -----| --------
1.0 | 12 de mayo de 2016 | Lanzamiento inicial

### Instrucciones de instalación ###
Para poder jugar con este ejemplo, debe:

-  Registrarse para una suscripción para desarrolladores del [Centro de desarrollo de Office](http://dev.office.com/) de Office 365, si no tiene una.
-  Registrar la aplicación web en [Azure AD](https://manage.windowsazure.com/) para obtener un ClientID y un secreto de cliente. 
-  Configurar la aplicación de Azure AD con los siguientes permisos delegados de Microsoft Graph: Ver el perfil básico de los usuarios, Ver la dirección de correo electrónico de los usuarios
-  Actualizar el archivo web.config de la aplicación web con la configuración adecuada (ClientID, ClientSecret,Domain,TenantID).
-  Registrar la aplicación de consola del punto de conexión de autenticación v2 en el nuevo [Portal de registro de aplicaciones](https://apps.dev.microsoft.com/). 
-  Configurar el archivo .config de la aplicación de consola con la configuración adecuada (MSAL_ClientID)

 
<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.DotNetSDK" />