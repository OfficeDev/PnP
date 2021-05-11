---
page_type: sample
products:
- office-outlook
- office-sp
languages:
- aspx
- csharp
extensions:
  contentType: samples
  technologies:
  - Azure AD
  platforms:
  - REST API
  createdDate: 1/1/2016 12:00:00 AM
---
# API de REST de notificaciones de Outlook con API web de ASP.NET #

### Resumen ###
Este es un ejemplo de un proyecto de API web de ASP.NET para validar y responder a notificaciones de Outlook creadas con la API de REST de notificaciones de Outlook. En este ejemplo, se muestra el concepto de suscribirse a notificaciones, validar direcciones URL de notificación e inspeccionar las entidades supervisadas al realizar llamadas a la API de REST de Outlook con tokens persistentes.

Puede obtener más información sobre la API de REST de notificaciones de Outlook y sus operaciones en: <https://msdn.microsoft.com/en-us/office/office365/api/notify-rest-operations>

El uso de este enfoque basado en sucesos es una forma mucho más sólida de trabajar con los cambios en los recursos y entidades de Outlook. En lugar de sondear las API de REST de Outlook directamente, este es mucho más sencillo (especialmente cuando la cantidad de elementos es grande). A mayor escala, este enfoque pasa a ser indispensable para una arquitectura de servicio sostenible.

![Interfaz de usuario de complementos y detalles sobre el token recibido de Office 365](http://i.imgur.com/r3rNNGV.png)

Obtenga más información sobre este ejemplo en: <http://simonjaeger.com/call-me-back-outlook-notifications-rest-api>

### Se aplica a ###
-  Exchange Online
-  Office 365
-  Hotmail.com
-  Live.com
-  MSN.com
-  Outlook.com
-  Passport.com

### Requisitos previos ###
La API de REST de notificaciones de Outlook está disponible para varios servicios. Para poder realizar llamadas a la API de REST de notificaciones de Outlook, debe registrar su aplicación. Más información: <https://dev.outlook.com/RestGettingStarted>

Si está compilando para Office 365 y le falta un espacio empresarial de Office 365, obtenga una cuenta de desarrollador en: <http://dev.office.com/devprogram>

Por último, tendrá que hospedar e implementar su API Web, por ejemplo, en una aplicación web de Microsoft Azure: <https://azure.microsoft.com/en-us/documentation/scenarios/web-app/>.

### Solución ###
Solución | Autor(es) 
---------|---------- 
OutlookNotificationsAPI.WebAPI | Simon Jäger (**Microsoft**)

### Historial de versiones ###
Versión | Fecha | Comentarios 
---------| -----| -------- 
1.2 | 18 de enero de 2016 | Se han agregado devoluciones de llamadas de API de REST de Outlook (mediante tokens persistentes) 
1.1 | 13 de enero de 2016 | Interfaz de usuario agregada para registrar una suscripción 
1.0 | 12 de diciembre de 2015 | Lanzamiento inicial

### Aviso de declinación de responsabilidades ###
**ESTE CÓDIGO ES PROPORCIONADO *TAL CUAL* SIN GARANTÍA DE NINGÚN TIPO, YA SEA EXPLÍCITA O IMPLÍCITA, INCLUIDAS LAS GARANTÍAS IMPLÍCITAS DE IDONEIDAD PARA UN FIN DETERMINADO, COMERCIABILIDAD O AUSENCIA DE INFRACCIÓN.**

----------

# Cómo se usa #
El primer paso es la creación y el hospedaje de la API Web en alguna parte: necesita implementarse y validarse con la API de REST de notificaciones de Outlook para poder recibir notificaciones. En lo que respecta a la validación, es bastante sencillo. Cuando pedimos a la API de REST de notificaciones de Outlook que empiece a enviar notificaciones (mediante la creación de una suscripción) a la API Web, enviará un token de validación. 

La API Web debe responder con el mismo token de validación en un plazo de 5 segundos, si se logra esto, se creará una suscripción para las notificaciones y se devolverá a la aplicación cliente (creando la suscripción).

#### Registrarse en Azure AD ####

El primer paso es registrar la aplicación web en el espacio empresarial de Azure AD (asociada a su espacio empresarial de Office 365). La aplicación web usa OWIN y OpenID Connect para administrar la autenticación y la autorización. Puede encontrar más información sobre OWIN y OpenId Connect aquí, así como sobre el registro de la aplicación en el espacio empresarial de Azure AD aquí: <http://www.cloudidentity.com/blog/2014/07/28/protecting-an-mvc4-vs2012-project-with-openid-connect-and-azure-ad/>

Como la aplicación llama a Office 365, es importante conceder permisosla para leer el calendario del usuario.

Cuando haya registrado la aplicación web en Azure AD, tendrá que configurar las siguientes opciones en el archivo Web.config:

    <add key="ida:ClientId" value="[ID. DE CLIENTE DE SU APLICACIÓN]" />
    <add key="ida:ClientSecret" value="[SECRETO DE CLIENTE DE SU APLICACIÓN]" />
    <add key="ida:Domain" value="[SU DOMINIO]" />
    <add key="ida:TenantId" value="[ID. DE SU ESPACIO EMPRESARIAL]" />
    <add key="ida:PostLogoutRedirectUri" value="[LA URI DE REDIRECCIONAMIENTO TRAS CERRAR SESIÓN]" />
    
#### Implementar ####

Implemente la API Web en un proveedor de hospedaje, por ejemplo, una aplicación web en Microsoft Azure: <https://azure.microsoft.com/en-us/documentation/scenarios/web-app/>. Tenga en cuenta que esta aplicación requiere un servidor SQL Azure, ya que la información de la suscripción y los tokens se mantiene en una base de datos. Puede usar el asistente para publicación en Visual Studio y publicar una nueva aplicación web + servidor de BD. Si ya ha creado la aplicación web o desea usar un servidor de bases de datos de SQL Azure existente, debe descargar el perfil de publicación de la aplicación web y usarlo en el asistente para publicación. Asegúrese también de establecer la cadena de conexión de base de datos para que apunte a su servidor SQL Azure existente, como se muestra a continuación:

```XML
<add name="DefaultConnection" connectionString="Data Source=tcp:<sqlazuredbserver>.database.windows.net;Initial Catalog=OutlookNotifications;User ID=user@<sqlazuredbserver>;Password=*****" providerName="System.Data.SqlClient" />
```

Una vez que haya implementado el ejemplo en un proveedor de hospedaje, configure un punto de interrupción para detectar y validar el flujo en la API Web (NotifyController). Cuando se produzca la validación, recibirá notificaciones y podrá investigar las respuestas.

Puede usar Visual Studio 2015 para adjuntar un depurador a una aplicación web de Azure (consulte <https://azure.microsoft.com/sv-se/documentation/articles/web-sites-dotnet-troubleshoot-visual-studio/#remotedebug>)

**Tenga en cuenta lo siguiente: si usa la depuración remota, los retrasos pueden causar que se interrumpa el tiempo de respuesta de 5 segundos al validar las URL de notificación.**

Desplácese hasta el ejemplo hospedado y haga clic en el botón "registrar suscripción" para empezar a obtener notificaciones.

# Modelos de respuesta #
El ejemplo implementa algunos modelos de respuesta. Sirven para ayudarle a tratar con las solicitudes de notificación (analizando el JSON recibido). Aquí se muestran los modelos de respuesta clave utilizados en el ejemplo. 

La clase ResponseModel genérica es la contenedora principal para la respuesta. En el ejemplo contendrá una colección de la clase NotificationModel.

```C#
public class ResponseModel<T>
{
    public List<T> Value { get; set; }
}
```
la clase NotificationModel representa la notificación enviada al servicio de escucha (API Web).

```C#
public class NotificationModel
{
    public string SubscriptionId { get; set; }
    public string SubscriptionExpirationDateTime { get; set; }
    public int SequenceNumber { get; set; }
    public string ChangeType { get; set; }
    public string Resource { get; set; }
    public ResourceDataModel ResourceData { get; set; }
}
```
la clase ResourceDataModel representa la entidad (correo, contacto, evento...) que ha activado un cambio. Esta es una propiedad de navegación. 

```C#
public class ResourceDataModel
{
    public string Id { get; set; }
}
```
la clase PushSubscriptionModel representa la entidad suscripción. Se usa como un modelo de solicitud y de respuesta al crear la suscripción. 
```C#
public class PushSubscriptionModel
{
    [JsonProperty("@odata.type")]
    public string Type
    {
        get
        {
            return "#Microsoft.OutlookServices.PushSubscription";
        }
    }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }
    public string Resource { get; set; }
    public string NotificationURL { get; set; }
    public string ChangeType { get; set; }
    public Guid ClientState { get; set; }
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string SubscriptionExpirationDateTime { get; set; }
}
```

# Controlador Web API #
NotifyController implementa un único método POST. Tanto las solicitudes de validación como las de notificación se enviarán como mensajes POST a la API Web.

Si se trata de un token de validación, lo aceptará como parámetro opcional. Si está presente en la solicitud, sabemos que se está realizando una validación de la URL (API Web).
Si no es así, podemos dar por sentado que estamos recibiendo una notificación de una suscripción activa. Por lo tanto, si hay un parámetro de token de validación, lo devolvemos inmediatamente, al establecer el encabezado de tipo de contenido en text/plain y devolver HTTP 200 como el código de respuesta.

En caso de que no haya ningún token de validación en la solicitud, podemos empezar a analizar el cuerpo de la solicitud y buscar las notificaciones. 

```C#
public async Task<HttpResponseMessage> Post(string validationToken = null)
{
    // If a validation token is present, we need to respond within 5 seconds.
    if (validationToken != null)
    {
        var response = Request.CreateResponse(HttpStatusCode.OK);
        response.Content = new StringContent(validationToken);
        return response;
    }

    // Present only if the client specified the ClientState property in the 
    // subscription request. 
    IEnumerable<string> clientStateValues;
    Request.Headers.TryGetValues("ClientState", out clientStateValues);

    if (clientStateValues != null)
    {
        var clientState = clientStateValues.ToList().FirstOrDefault();
        if (clientState != null)
        {
            // TODO: Use the client state to verify the legitimacy of the notification.
        }
    }

    // Read and parse the request body.
    var content = await Request.Content.ReadAsStringAsync();
    var notifications = JsonConvert.DeserializeObject<ResponseModel<NotificationModel>>(content);

    // TODO: Do something with the notification.

    return new HttpResponseMessage(HttpStatusCode.OK);
}
```

Le recomiendo que preste atención al encabezado de estado de cliente en la solicitud (denominada ClientState). Si crea la suscripción con una propiedad de estado de cliente, se pasará junto con la solicitud de notificación. De esta forma, puede comprobar la legitimidad de la notificación.

Además, este ejemplo también inspecciona los elementos supervisados (eventos de calendario creados) cuando se activa una notificación llamando a la API de REST de Outlook con un token persistente.

```C#
// Read and parse the request body.
var content = await Request.Content.ReadAsStringAsync();
var notifications = JsonConvert.DeserializeObject<ResponseModel<NotificationModel>>(content).Value;

// TODO: Do something with the notification.
var entities = new ApplicationDbContext();
foreach (var notification in notifications)
{
    // Get the subscription from the database in order to locate the
    // user identifiers. This is used to tap the token cache.
    var subscription = entities.SubscriptionList.FirstOrDefault(s =>
        s.SubscriptionId == notification.SubscriptionId);

    try
    {
        // Get an access token to use when calling the Outlook REST APIs.
        var token = await TokenHelper.GetTokenForApplicationAsync(
            subscription.SignedInUserID,
            subscription.TenantID,
            subscription.UserObjectID,
            TokenHelper.OutlookResourceID);
        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        // Send a GET call to the monitored event.
        var responseString = await httpClient.GetStringAsync(notification.Resource);
        var calendarEvent = JsonConvert.DeserializeObject<CalendarEventModel>(responseString);

        // TODO: Do something with the calendar event.
    }
    catch (AdalException)
    {
        // TODO: Handle token error.
    }
    // If the above failed, the user needs to explicitly re-authenticate for 
    // the app to obtain the required token.
    catch (Exception)
    {
        // TODO: Handle exception.
    }
}
```
# Archivos de código fuente #
Los archivos de código fuente clave en este proyecto son los siguientes:

- `OutlookNotificationsAPI.WebAPI\Controllers\NotifyController.cs`: el controlador API Web que contiene el método "POST" (control de solicitudes de validación y de notificación).
- `OutlookNotificationsAPI.WebAPI\Controllers\HomeController.cs`: el controlador API Web que contiene la acción de registro que configura la suscripción para las notificaciones.
- `OutlookNotificationsAPI.WebAPI\Models\ResponseModel.cs`: representa la colección de entidades enviadas en la solicitud de notificación al servicio de escucha (API Web).
- `OutlookNotificationsAPI.WebAPI\Models\NotificationModel.cs`: representa la entidad de notificación enviada al servicio de escucha (API Web).
- `OutlookNotificationsAPI.WebAPI\Models\ResourceDataModel.cs`: representa la entidad (correo, contacto, evento...) que ha activado un cambio. Esta es una propiedad de navegación. 
- `OutlookNotificationsAPI.WebAPI\Models\PushSubscriptionModel.cs`: representa la entidad de suscripción. Se usa como modelo de solicitud y de respuesta al crear la suscripción.

# Más recursos #
- Descubra el desarrollo de Office en: <https://msdn.microsoft.com/en-us/office/>
- Introducción a Microsoft Azure en: <https://azure.microsoft.com/en-us/>
- Obtenga más información sobre webhooks en: <http://culttt.com/2014/01/22/webhooks/>
- Explore la API de REST de notificaciones de Outook y sus operaciones en: <https://msdn.microsoft.com/en-us/office/office365/api/notify-rest-operations> 
- Obtenga más información sobre este ejemplo en: <http://simonjaeger.com/call-me-back-outlook-notifications-rest-api/>

<img src="https://telemetry.sharepointpnp.com/pnp/samples/OutlookNotificationsAPI.WebAPI" />