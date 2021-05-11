---
page_type: sample
products:
- office-outlook
- office-365
- office-sp
- ms-graph
languages:
- javascript
- nodejs
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
  services:
  - Outlook
  - Office 365
  - SharePoint
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Mobile
---
# Microsoft Graph - Contactos Rápidos

### Resumen

En este ejemplo, se muestra cómo usar Microsoft Graph para encontrar contactos rápidamente en dispositivos móviles.

![Captura de pantalla](assets/search-results.png)

### Se aplica a

- Office 365 multiempresa (MT)

### Requisitos previos

- Espacio empresarial de Office 365
- Configuración de la aplicación en Azure Active Directory (AAD)
    - Permisos
        - Office 365 SharePoint Online
            - Ejecutar consultas de búsqueda como usuario
        - Microsoft Graph
            - Leer la lista de contactos relevantes de los usuarios (versión preliminar)
            - Acceder al directorio como el usuario que inició sesión
            - Leer los perfiles básicos de todos los usuarios
        - Windows Azure Active Directory
            - Iniciar sesión y leer el perfil del usuario
    - Habilitar flujo implícito de OAuth
    
### Solución

Solución|Autores
--------|---------
MicrosoftGraph.Office.QuickContacts|Waldek Mastykarz (MVP, Rencore, @waldekm), Stefan Bauer (n8d, @StfBauer)

### Historial de versiones

Versión|Fecha|Comentarios
-------|----|--------
1.0|24 de marzo de 2016|Lanzamiento inicial

### Aviso de declinación de responsabilidades
**ESTE CÓDIGO SE PROPORCIONA *TAL CUAL* SIN GARANTÍA DE NINGÚN TIPO, YA SEA EXPLÍCITA O IMPLÍCITA, INCLUIDA CUALQUIER GARANTÍA IMPLÍCITA DE IDONEIDAD PARA UN FIN DETERMINADO, COMERCIABILIDAD O AUSENCIA DE INFRACCIÓN.**

---

## Contactos rápidos de Office

Esta es una aplicación de ejemplo en la que se muestra cómo puede aprovechar Microsoft Graph para encontrar rápidamente contactos relevantes con el teléfono móvil.

![Los contactos encontrados se muestran en la aplicación contactos rápidos de Office](assets/search-results.png)

Usando la nueva API de contactos la aplicación le permite buscar contactos, incluida la información de estos.

![Las acciones rápidas se muestran en un contacto](assets/quick-actions.png)

Dado que la nueva API de contactos usa la búsqueda fonética, no importa si no escribe correctamente el nombre de la persona que está buscando.

![Resultados de la búsqueda del nombre de un contacto escrito incorrectamente](assets/typo.png)

Si pulsa en un contacto, puede obtener acceso a información adicional y si el contacto proviene de su organización, incluso obtendrá un vínculo directo al correo electrónico.

![La tarjeta de contacto se abre en la aplicación](assets/person-card.png)

## Requisitos previos

Para poder iniciar esta aplicación, es necesario realizar algunos pasos de configuración.

### Configurar la aplicación de Azure AD

Esta aplicación usa Microsoft Graph para buscar contactos relevantes. Para que pueda obtener acceso a Microsoft Graph, tiene que tener una aplicación correspondiente de Azure Active Directory configurada en su Azure Active Directory. Estos son los pasos para crear y configurar correctamente la aplicación en AAD. 

- Crear una nueva aplicación web en Azure Active Directory.
- Establecer la **URL de inicio de sesión** en `https://localhost:8443`.
- Copiar la **Id. de cliente**, debido a que la necesitaremos más tarde para configurar la aplicación.
- En la **URL de respuesta** agregar `https://localhost:8443`. Si desea probar la aplicación en su dispositivo móvil, también tendrá que agregar la dirección URL **externa** que se muestra en browserify después de iniciar la aplicación usando `$ gulp serve`.
- Conceda a la aplicación los siguientes permisos:
    - Office 365 SharePoint Online
        - Ejecutar consultas de búsqueda como usuario
    - Microsoft Graph
        - Leer la lista de contactos relevantes de los usuarios (versión preliminar)
        - Acceder al directorio como el usuario que inició sesión
        - Leer los perfiles básicos de todos los usuarios
    - Windows Azure Active Directory
        - Iniciar sesión y leer el perfil del usuario
- Habilitar el flujo implícito de OAuth

### Configurar la aplicación

Antes de poder iniciar la aplicación, tiene que estar vinculada a la aplicación de Azure Active Directory recién creada y a un espacio empresarial de SharePoint. Ambos ajustes pueden configurarse en el archivo`app/app.config.js`.

- Clonar este repositorio.
- Como valor de la constante **appId** establecer la **Id. de cliente** copiada previamente de la aplicación AAD recién creada.
- Como valor de la constante **sharePointUrl** establecer la URL del espacio empresarial de SharePoint sin la barra diagonal final p. ej. `https://contoso.sharepoint.com`

## Ejecutar esta aplicación

Para iniciar la aplicación complete los pasos siguientes:

- En la línea de comandos ejecutar
```
$ npm i && bower i
```
- En la línea de comandos ejecutar
```
$ gulp serve
```
para iniciar la aplicación.

![La aplicación inicia en el explorador](assets/app.png). 

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office.QuickContacts" />