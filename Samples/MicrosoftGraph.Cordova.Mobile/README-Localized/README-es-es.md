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
- javascript
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
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
  - REST API
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Mobile
---
# Ejemplo que usa Microsoft Graph con Apache Cordova y un complemento de ADAL Cordova  #

### Información general ###
En este ejemplo, se muestra cómo usar la API de Microsoft Graph para recuperar datos de Office
365 con la API de REST y OData. Este ejemplo es sencillo de forma intencionada y no usa ningún marco de SPA,
ni bibliotecas de enlace de datos, jQuery, etc.
Su finalidad no es ofrecer una demostración de una aplicación móvil de características completas.
Se puede usar en varias plataformas de Windows, así como en Android y iOS,
con el mismo código JavaScript.

El token de acceso se obtiene mediante el complemento ADAL Cordova.
Este es uno de los complementos principales de Visual Studio y está disponible en el editor de config.xml.
Esta es una alternativa al Asistente para agregar un servicio conectado que genera
varios archivos JavaScript, entre los que se incluyen una biblioteca (o365auth.js)
que se puede usar para obtener tokens con un explorador en la aplicación que controle
la redirección de usuario al punto de conexión de autorización. En su lugar, el complemento de ADAL Cordova usa las bibliotecas
nativas de ADAL para cada plataforma y, por lo tanto, puede aprovechar las características nativas,
como el almacenamiento en caché de tokens y los exploradores protegidos.

### Se aplica a ###
-  Office 365 multiempresa (MT)
-  Microsoft Graph

### Requisitos previos ###
- Visual Studio Tools para Apache Cordova (opción de configuración VS-TACO)
- Complemento ADAL Cordova (cordova-plugin-ms-adal)

### Solución ###
Solution | Author(s)
---------|----------
Mobile.MicrosoftGraphCordova | Bill Ayers (@SPDoctor, spdoctor.com, flosim.com)

### Historial de versiones ###
Versión | Día | Comentarios
---------| -----| --------
1.0 | 15 de mayo de 2016 | Lanzamiento inicial

### Aviso de declinación de responsabilidades ###
**ESTE CÓDIGO ES PROPORCIONADO *TAL CUAL* SIN GARANTÍA DE NINGÚN TIPO, YA SEA EXPLÍCITA O IMPLÍCITA, INCLUIDAS LAS GARANTÍAS IMPLÍCITAS DE IDONEIDAD PARA UN FIN DETERMINADO, COMERCIABILIDAD O AUSENCIA DE INFRACCIÓN.**


----------

### Ejecutar el ejemplo ###

Cuando se ejecuta el ejemplo, puede hacer clic en el botón "cargar datos".
Si esta es la primera vez que lo ejecuta, se le pedirá que autorice la aplicación.
Este es el conocido símbolo del sistema de inicio de sesión de Office 365.
Como estamos usando Microsoft Graph, también es posible
usar una "cuenta de Microsoft" (por ejemplo, una cuenta de live.com o hotmail). 

Si ha introducido el nombre de espacio empresarial de Office 365,
funcionará en esta cuenta.
Si deja el espacio empresarial en blanco, se usa el punto de conexión "común"
y el espacio empresarial real usado se determinará a partir de las credenciales de usuario utilizadas para autenticar con el punto de conexión de autorización.

Puede escribir una consulta válida en el
cuadro de entrada (aunque no todas serán analizadas sin modificar el código).
Como alternativa, puede seleccionar en el cuadro desplegable y seleccionar una consulta predefinida.

![Ejecutar en Windows 10](MicrosoftGraphCordova.png)

Una vez que se obtiene un token, se analiza y se muestra solo para fines de demostración.
El token no está cifrado (por lo que es necesario usar seguridad de nivel de transporte como SSL),
pero se debe tratar como opaco, es decir,
no escriba código que se base en la información contenida en el token, use las API en su lugar.

Al usar el token de acceso, la solicitud de REST se hace a la API de Microsoft Graph y se muestran los datos.
Es posible que observe un retraso entre que el token que se recibe y los datos se devuelven desde el punto de conexión de REST.
Tenga en cuenta que la biblioteca ADAL
también se puede usar para obtener tokens para los puntos de conexión de REST de Office 365 originales,
pero en el código de ejemplo el ámbito se ha establecido en Microsoft Graph.

Puede ver que el token de acceso tiene una duración de aproximadamente una hora.
Puede seguir realizando más solicitudes con el token hasta que expire sin obtener más solicitudes.
Esto funciona incluso si cierra la aplicación y la vuelve a iniciar porque el token se almacena en la caché.
Después de una hora, el token expirará y el token de actualización se usará para obtener un nuevo token de acceso.
Esto también genera un nuevo token de actualización y este
proceso se puede repetir durante varios meses siempre y cuando el token de actualización,
que también se almacena en la caché, no expire.

Si hace clic en el botón "Borrar caché", la caché de token se eliminará.
La próxima vez que haga clic en cargar datos obtendrá una solicitud de autorización. 

### Entre bastidores ###

Toda la administración de la memoria caché (que depende de la plataforma),
que trabaja con los tokens de acceso expirados y el uso del token de actualización,
se controla mediante las bibliotecas de ADAL. Solo tiene que obtener un contexto de autenticación
y seguir el patrón actual recomendado que es llamar primero a acquireTokenSilentAsync.
Si no puede obtenerse un token de forma silenciosa (es decir, de la caché o mediante un token de actualización),
la devolución de llamada "fail" invocará a acquireTokenAsync,
que tiene el comportamiento del mensaje establecido en "always".

```javascript

    context.acquireTokenSilentAsync(resourceUrl, appId).then(success, function () {
      context.acquireTokenAsync(resourceUrl, appId, redirectUrl).then(success, fail);
    });

```

A pesar de que la documentación actual y algunas de las bibliotecas ADAL tienen acquireTokenAsync
con el comportamiento de solicitud establecido en "auto", lo que significa preguntar al usuario solo si es necesario,
el diseño del complemento de Cordova es que acquireTokenAsync siempre se mostrará. 

Nota: Entiendo que el resto de bibliotecas ADAL aplicarán este patrón en adelante. 


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Cordova.Mobile" />