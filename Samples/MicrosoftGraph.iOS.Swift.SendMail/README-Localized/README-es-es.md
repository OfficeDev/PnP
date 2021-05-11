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
# SDK de Microsoft Graph para iOS usando SWIFT #

### Resumen ###
Si aún no lo oyó, existe una forma fácil de llamar una gran cantidad de API de Microsoft, usando un único punto de conexión. Este punto de conexión, denominado Microsoft Graph (<https://graph.microsoft.io/>) permite obtener acceso a todo, desde datos hasta inteligencia e información con tecnología de Microsoft Cloud.

Ya no tendrá que realizar un seguimiento de los distintos puntos de conexión y los tokens separados en sus soluciones ¿No es maravilloso? Esta publicación es el comienzo de la introducción a Microsoft Graph. Para los cambios en Microsoft Graph, vaya a: <https://graph.microsoft.io/changelog>

Este ejemplo muestra el SDK de Microsoft Graph para iOS (<https://github.com/OfficeDev/Microsoft-Graph-SDK-iOS>) en una aplicación de iOS simple mediante el nuevo lenguaje SWIFT (<https://developer.apple.com/swift/>). En la aplicación, nos enviaremos un correo a nosotros mismos. El objetivo es familiarizarse con Microsoft Graph y sus posibilidades.

![Interfaz de usuario de la aplicación en iPhone y correo electrónico](http://simonjaeger.com/wp-content/uploads/2016/03/app.png)

Tener en cuenta que el SDK de Microsoft Graph para iOS aún está en versión preliminar. Obtener más información sobre las condiciones en: https://github.com/OfficeDev/Microsoft-Graph-SDK-iOS

Obtener más información sobre este ejemplo en: <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/>

### Se aplica a ###
-  Exchange Online
-  Office 365
-  Hotmail.com
-  Live.com
-  MSN.com
-  Outlook.com
-  Passport.com

### Requisitos previos ###
Tendrá que registrar la aplicación antes de poder realizar llamadas a Microsoft Graph. Obtener más información en: <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/#step-11-register-the-application-in-azure-ad>

Si está creando para Office 365 y le falta un espacio empresarial de Office 365, obtenga una cuenta de desarrollador en: <http://dev.office.com/devprogram>

Tendrá que tener Xcode instalado en el equipo para poder ejecutar el ejemplo. Obtener Xcode en: <https://developer.apple.com/xcode/>

### Proyecto ###
Proyecto | Autores
---------|----------
MSGraph.MailClient | Simon Jäger (**Microsoft**)

### Historial de versiones ###
Versión | Fecha | Comentarios
---------| -----| --------
1.0 | 9 de marzo de 2016 | Lanzamiento inicial

### Aviso de declinación de responsabilidades ###
**ESTE CÓDIGO ES PROPORCIONADO *TAL CUAL* SIN GARANTÍA DE NINGÚN TIPO, YA SEA EXPLÍCITA O IMPLÍCITA, INCLUIDAS LAS GARANTÍAS IMPLÍCITAS DE IDONEIDAD PARA UN FIN DETERMINADO, COMERCIABILIDAD O AUSENCIA DE INFRACCIÓN.**

----------

# ¿Cómo se usa? #

El primer paso es registrar la aplicación en el espacio empresarial de Azure AD (asociado a su espacio empresarial de Office 365). Puede encontrar más información sobre cómo registrar la aplicación en el espacio empresarial de Azure AD aquí: <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/#step-11-register-the-application-in-azure-ad>

Como la aplicación está llamando a Microsoft Graph y envía un correo en nombre del usuario con la sesión iniciada, es importante concederle permisos para enviar mensajes de correo.

Cuando haya registrado la aplicación en Azure AD tendrá que configurar las siguientes opciones en el archivo **adal_settings.plist**:
    
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

Iniciar el archivo de área de trabajo (**MSGraph.MailClient.xcworkspace**) en Xcode. Ejecutar el proyecto utilizando el método abreviado de teclado **⌘R** o presionando el botón **Ejecutar** en el menú **Producto**.
    
# Archivos de código fuente #
Los archivos de código fuente principales en este proyecto son:

- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\MailClient.swift`, esta clase se ocupa de iniciar sesión en el usuario, obtener el perfil de este y, por último, enviar el correo con un mensaje.
- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\ViewController.swift`, este es el controlador de vista único para la aplicación iOS, que activa a MailClient.
- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\adal_settings.plist`, este es el archivo de lista de propiedades de la configuración de ADAL. Asegúrese de configurar las opciones necesarias en este archivo antes de ejecutar el ejemplo.

# Más recursos #
- Descubra el desarrollo de Office en: <https://msdn.microsoft.com/en-us/office/>
- Introducción a Microsoft Azure en: <https://azure.microsoft.com/en-us/>
- Explore Microsoft Graph y sus operaciones en: <http://graph.microsoft.io/en-us/> 
- Obtener más información sobre este ejemplo en: <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/>


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.iOS.Swift.SendMail" />