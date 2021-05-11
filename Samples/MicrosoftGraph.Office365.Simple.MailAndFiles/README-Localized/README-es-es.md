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
# Microsoft Graph: consulta de archivos personales y correos electrónicos #

### Resumen ###
Esta es una aplicación simple de ASP.net MVC para consultar correos electrónicos y archivos personales usando Microsoft Graph que muestra también la consulta dinámica de la información con consultas ajax. La muestra también utiliza tela de interfaz de oficina para proporcionar una experiencia de interfaz de usuario consistente con controles y presentación estandarizados.

### Aplica para ###
-  Office 365 multiempresa (MT)

### Requisitos previos ###
Configuración de la aplicación en el Azure AD

### Solución ###
Solución | Autor(es)
---------|----------
Office365Api.Graph.Simple.MailAndFiles | Vesa Juvonen

### Historial de versiones ###
Versión | Fecha | Comentario
 ---------| -----| --------
 1.0 | 5 de febrero de 2016 | Lanzamiento inicial

### Aviso de declinación de responsabilidades ###
**ESTE CÓDIGO ES PROPORCIONADO *TAL CUAL* SIN GARANTÍA DE NINGÚN TIPO, YA SEA EXPRESA O IMPLÍCITA, INCLUYENDO CUALQUIER GARANTÍA IMPLÍCITA DE IDONEIDAD PARA UN PROPÓSITO PARTICULAR, COMERCIABILIDAD O NO INFRACCIÓN.**

----------

# Introducción #
Este ejemplo está demostrando una conectividad simplista con el Microsoft Graph para mostrar los correos electrónicos y archivos del usuario en particular.La interfaz de usuario se actualizará automáticamente en las diferentes partes de la misma, si hay nuevos elementos que lleguen al buzón de correo electrónico o se añadan al sitio OneDrive para la Empresa del usuario.

![App UI](http://i.imgur.com/Rt4d8Py.png)

# Configuración del Azure Active Directory #
Antes de que este ejemplo pueda ser ejecutado, deberá registrar la solicitud en Azure AD y proporcionar los permisos necesarios para que las colas de Graph funcionen. Crearemos una entrada de aplicación en el Azure Active Directory y configuraremos los permisos necesarios.

- Abrir el Portal Azul UI y pasar al Active Directory UIsI: en el momento de escribir esto, sólo está disponible en el antiguo portal UI.
- Mover a la selección de **aplicaciones**
- Haga clic en ** Agregar** para iniciar la creación de una nueva aplicación
- Haga clic en **Agregar aplicación que mi organización está desarrollando **

![ ¿Qué quiere hacer UI en Azure AD? ](http://i.imgur.com/dNtLtnl.png)

- Proporcione un** nombre** a su aplicación y seleccione **Aplicación Web y Web API** como el tipo

![Agregar aplicación UI](http://i.imgur.com/BrxalG7.png)

- Actualice las propiedades de la aplicación como se indica a continuación para la depuración
	- **URL** - https://localhost:44301/
	- **ID de URL de la APP**: URI válida como http://pnpemailfiles.contoso.local - esto es sólo un identificador, por lo que no tiene que ser una URL válida real

![ Detalles de la aplicación UI ](http://i.imgur.com/1IaNxLm.png)

- Mover para **configurar** la página y la sección alrededor de las teclas
- Seleccione 1 o 2 años durante el secreto generado

![ Configuración del ciclo de vida secreto ](http://i.imgur.com/7kX396J.png)

- Haga clic en **guardar**y copie el secreto generado para su futuro uso en la página - note que el secreto es solamente visible durante este tiempo, por lo que tendrá que asegurarlo en algún otro lugar.

![Secreto de cliente](http://i.imgur.com/5vnkkTA.png)

- Desplácese hacia abajo para la configuración de permisos

![Permisos para otras aplicaciones](http://i.imgur.com/tF4R75w.png)

- Seleccione Office 365 Exchange Online y Office 365 SharePoint Online como las aplicaciones a las que desea asignar permisos

![Permisos para asignar](http://i.imgur.com/XGOba3Y.png)

- Conceder permisos de "**leer el correo del usuario**" en permisos de Exchange Online

![Selección de los permisos necesarios para el intercambio](http://i.imgur.com/CyH9gg2.png)

- Conceder permisos de "**leer el correo del usuario**" en permisos de SharePoint Online

![Selección de los permisos necesarios para SharePoint](http://i.imgur.com/NSZiHsh.png)

- Haga clic en **Guardar**. 

Ya has completado la configuración necesaria en la parte del Azure Active Directory. Observe que tendrá que seguir configurando el Id. de cliente y el secreto del archivo web.config en el proyecto. Actualice las claves de Id. de cliente y de ClientSecret correctamente.

![Configuración de web.config](http://i.imgur.com/pihBvR5.png)

# Ejecute la solución #
Cuando haya configurado el lado Azure AD y actualizado el web.config en base a sus valores ambientales, podrá ejecutar la muestra correctamente.

- Presione F5 en el Visual Studio
- Haga clic en **conectarse a Office 365** o en **iniciar sesión** en la barra de conjuntos de programas, lo que mostrará la interfaz de usuario de AAD concent para iniciar sesión correctamente en Azure AD

![App UI](http://i.imgur.com/YMCrG4O.png)

- Inicie sesión con las credenciales correctas del Active Directory para la aplicación

![Iniciar sesión en Azure AD: UI de consentimiento](http://i.imgur.com/gNz5Wgz.png)

- Se le mostrará la UI de la aplicación

![UI de aplicación con sus datos personales](http://i.imgur.com/Rt4d8Py.png)


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.Simple.MailAndFiles" />