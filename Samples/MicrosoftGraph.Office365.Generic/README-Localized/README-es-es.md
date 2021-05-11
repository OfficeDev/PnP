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
# Ejemplo genérico de Microsoft Graph para funciones de Office 365 #

### Resumen ###
Este es un ejemplo genérico de Microsoft Graph relacionado con las funciones de Office 365. Se muestran diferentes operaciones que abarcan las siguientes áreas:
- Calendario
- Contactos
- Archivos
- Grupos unificados
- y Usuarios.

Consulte la siguiente difusión Web de PnP para obtener más información y demostración en directo sobre este ejemplo:
- [PnP web Cast: PnP web Cast - Introducción a Microsoft Graph para el desarrollador de Office 365](https://channel9.msdn.com/blogs/OfficeDevPnP/PnP-Web-Cast-Introduction-to-Microsoft-Graph-for-Office-365-developer)

### Se aplica a ###
-  Office 365 multiempresa (MT)

### Requisitos previos ###
Configuración de la aplicación en Azure AD: Id. de cliente y secreto de cliente

### Solución ###
Solución | Autor(es)
 ---------|----------
 OfficeDevPnP.MSGraphAPIDemo | Paolo Pialorsi

### Historial de versiones ###
Versión | Fecha | Comentarios
---------| -----| --------
1.0 | 8 de febrero de 2016 | Versión inicial

### Aviso de declinación de responsabilidades ###
**ESTE CÓDIGO ES PROPORCIONADO *TAL CUAL* SIN GARANTÍA DE NINGÚN TIPO, YA SEA EXPLÍCITA O IMPLÍCITA, INCLUIDAS LAS GARANTÍAS IMPLÍCITAS DE IDONEIDAD PARA UN FIN DETERMINADO, COMERCIABILIDAD O AUSENCIA DE INFRACCIÓN.**


----------

# Guía de instalación #
Detalles de configuración de alto nivel de la siguiente manera:

- Registrar el Id. de cliente y el secreto en Azure Active Directory
- Configurar los permisos necesarios para la aplicación
- Configurar el archivo web.config de acuerdo con la información de la aplicación registrada 

![Detalles de configuración en web.config](http://i.imgur.com/POSJqD7.png)

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.Generic" />