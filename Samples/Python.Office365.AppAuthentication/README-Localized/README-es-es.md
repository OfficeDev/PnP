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
# Autenticación de una aplicación de Office 365 Python Flask #

### Resumen ###
En este escenario, se muestra cómo configurar la autenticación entre una aplicación de Python (con el micromarco Flask) y un sitio de Office 365 SharePoint Online. El objetivo de este ejemplo es mostrar cómo un usuario puede autenticarse e interactuar con datos desde un sitio de Office 365 SharePoint.

### Se aplica a ###
- Office 365 multiempresa (MT)
- Office 365 dedicado (D)

### Requisitos previos ###
- Espacio empresarial de desarrollador de Office 365
- Visual Studio 2015 instalado
- Herramientas de Python para Visual Studio instaladas
- Python 2.7 o 3.4 instalado
- Flask, solicitudes y paquetes PyJWT de Python instalados mediante pip

### Solución ###
Solución | Autores 
---------|----------
 Python.Office365.AppAuthentication | Velin Georgiev (**OneBit Software**), Radi Atanassov (**OneBit Software**)

### Historial de versiones ###
Versión | Fecha | Comentarios 
---------| -----| -------- 
1.0 | 9 de febrero de 2016 | Versión inicial (Velin Georgiev)

### Aviso de declinación de responsabilidades ###
**ESTE CÓDIGO ES PROPORCIONADO *TAL CUAL* SIN GARANTÍA DE NINGÚN TIPO, YA SEA EXPLÍCITA O IMPLÍCITA, INCLUIDAS LAS GARANTÍAS IMPLÍCITAS DE IDONEIDAD PARA UN FIN DETERMINADO, COMERCIABILIDAD O AUSENCIA DE INFRACCIÓN.**

----------

# Ejemplo de la autenticación de una aplicación de Office 365 Python Flask #
En esta sección, se describe el ejemplo de la autenticación de la aplicación de Office 365 Python Flask incluido en la solución actual.

# Preparar el entorno para el ejemplo de la autenticación de una aplicación de Office 365 Python Flask #
La aplicación de Office 365 Python Flask hará lo siguiente:

- Usar los puntos de conexión de autorización de Azure AD para realizar la autenticación
- Usar las API de Office 365 SharePoint para mostrar el título del usuario autenticado

Para que estas tareas se realicen correctamente, debe realizar las configuraciones que se explican a continuación. 

- Cree una cuenta de prueba de Azure con la cuenta de Office 365 para que la aplicación pueda registrarse o puede registrarla con PowerShell. Puede encontrar un buen tutorial en este vínculo: https://github.com/OfficeDev/PnP/blob/497b0af411a75b5b6edf55e59e48c60f8b87c7b9/Samples/AzureAD.GroupMembership/readme.md.
- Registre la aplicación en Azure Portal y asigne http://localhost:5555 a la dirección URL de inicio de sesión y la URL de respuesta.
- Genere un secreto de cliente.
- Conceda el siguiente permiso a la aplicación de Python Flask: Office 365 SharePoint Online > Permisos delegados > Leer perfiles de usuario.

![Configuración de permisos en Azure Portal](https://lh3.googleusercontent.com/-LxhYrbik6LQ/VrnZD-0Uf0I/AAAAAAAACaQ/jsUjHDQlmd4/s732-Ic42/office365-python-app2.PNG)

- Copie el id. de cliente y el secreto de cliente desde Azure Portal y reemplácelos en el archivo de configuración de Python Flask.
- Asigne una URL al sitio de SharePoint al que vaya a tener acceso en la variable de configuración RESOURCE.

![Detalles de la aplicación en el archivo de configuración](https://lh3.googleusercontent.com/-ETtW5MBuOcA/VrnZDQBAxQI/AAAAAAAACaY/ppp4My1JTlE/s616-Ic42/office365-python-app-config.PNG)

- Abra el ejemplo en Visual Studio 2015.
- Vaya a Proyecto > Propiedades > Depurar y establezca 5555 en Número de puerto.

![Cambio de puerto en la opción para depurar](https://lh3.googleusercontent.com/-M3upxeCKBN0/VrnZDSHnDoI/AAAAAAAACaA/BF4CTeKlUMs/s426-Ic42/office365-python-app-vs-config.PNG)

- Vaya a Entornos de Python > el entorno de Python activo > ejecute "Instalar desde requirements.txt". Esto garantizará que todos los paquetes de Python necesarios estén instalados.

![Selección de opción del menú](https://lh3.googleusercontent.com/-At6Smrxg9DQ/VrnZD6KMvfI/AAAAAAAACaM/gcgJUATPigE/s479-Ic42/office365-python-packages.png)

## Ejecute el ejemplo de la aplicación de Office 365 Python Flask ##
Cuando ejecute el ejemplo, verá el título y la dirección URL de inicio de sesión.

![Interfaz de usuario del complemento](https://lh3.googleusercontent.com/-GDdAcmYylZE/VrnZD8sVGwI/AAAAAAAACaI/1gB0jvULLBo/s438-Ic42/office365-python-app.PNG)


Una vez que haya hecho clic en el vínculo de inicio de sesión, la API de Office 365 pasará por el protocolo de enlace de autenticación y la pantalla principal de Python Flask se volverá a cargar con el título de usuario y el token de acceso de inicio de sesión que se muestran a continuación:

![Interfaz de usuario de inicio de sesión](https://lh3.googleusercontent.com/-44rsAE2uGFQ/VrnZDdJAseI/AAAAAAAACaE/70N8UX8ErIk/s569-Ic42/office365-python-app-result.PNG)

<img src="https://telemetry.sharepointpnp.com/pnp/samples/Provisioning.Office365.AppAuthentication" />