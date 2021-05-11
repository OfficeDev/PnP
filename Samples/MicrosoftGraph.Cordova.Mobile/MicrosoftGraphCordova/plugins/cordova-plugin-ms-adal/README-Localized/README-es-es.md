# Plugin de la Biblioteca de autenticación de Active Directory (ADAL) para aplicaciones de Apache Cordova

El plugin de la Biblioteca de autenticación de Active Directory ([ ADAL](https://msdn.microsoft.com/en-us/library/azure/jj573266.aspx))
proporciona una funcionalidad de autenticación fácil de usar para sus aplicaciones de Apache Cordova aprovechando el Directorio Activo del Servidor de Windows y el Directorio Activo de Windows Azure. Aquí puedes encontrar el código fuente de la biblioteca.

  * [ADAL para Android](https://github.com/AzureAD/azure-activedirectory-library-for-android),
  * [ADAL para iOS](https://github.com/AzureAD/azure-activedirectory-library-for-objc),
  * [ADAL para .NET](https://github.com/AzureAD/azure-activedirectory-library-for-dotnet).

Este plugin utiliza SDKs nativos para ADAL para cada plataforma soportada y proporciona una única API en todas las plataformas. Aquí hay una muestra de uso rápido:

```javascript
var AuthenticationContext = Microsoft.ADAL.AuthenticationContext;

AuthenticationContext.createAsync(authority)
.then(function (authContext) {
    authContext.acquireTokenAsync(resourceUrl, appId, redirectUrl)
    .then(function (authResponse) {
        console.log("Token acquired: " + authResponse.accessToken);
        console.log("Token will expire on: " + authResponse.expiresOn);
    }, fail);
}, fail);
```

__Nota__: Puede usar `AuthenticationContext` constructor síncrono también:

```javascript
authContext = new AuthenticationContext(authority);
authContext.acquireTokenAsync(resourceUrl, appId, redirectUrl).then(function (authRes) {
    console.log(authRes.accessToken);
    ...
});
```

Para más documentación de la API, consulte[aplicación de muestra](https://github.com/AzureAD/azure-activedirectory-library-for-cordova/tree/master/sample) y JSDoc para la funcionalidad expuesta almacenada en la subcarpeta [www](https://github.com/AzureAD/azure-activedirectory-library-for-cordova/tree/master/www).

## Plataformas compatibles

  * Android
  * iOS
  * Windows (Windows 8.0, Windows 8.1 y Windows Phone 8.1)

## Problemas conocidos y soluciones provisionales

## Error de "Clase no registrada" en Windows

Si está usando Visual Studio 2013 y ve "WinRTError: Clase no registrada" Error de tiempo de ejecución en Windows, asegúrate de que esté instalada la [actualización 5](https://www.visualstudio.com/news/vs2013-update5-vs) de Visual Studio.

## Problema de múltiples ventanas de acceso

Se mostrarán múltiples ventanas de diálogo de inicio de sesión si se llama varias veces a `acquireTokenAsync` y no se ha podido adquirir el token de forma silenciosa (en la primera ejecución, por ejemplo). Use una lógica de [cola de promesa](https://www.npmjs.com/package/promise-queue) /semáforo en el código de la aplicación para evitar este problema.

## Instrucciones de instalación

### Requisitos previos

* [NodeJS y NPM](https://nodejs.org/)

* [Cordova CLI](https://cordova.apache.org/)

  La CLI de Córdoba puede ser fácilmente instalada a través del administrador de paquetes NPM: `npm install -g cordova `

* En la [página de documentación de las plataformas de Córdova](http://cordova.apache.org/docs/en/edge/guide_platforms_index.md.html#Platform%20Guides) se pueden encontrar requisitos previos adicionales para cada plataforma de destino:
 * [Instrucciones para Android](http://cordova.apache.org/docs/en/edge/guide_platforms_android_index.md.html#Android%20Platform%20Guide)
 * [Instrucciones para iOS](http://cordova.apache.org/docs/en/edge/guide_platforms_ios_index.md.html#iOS%20Platform%20Guide)
 * [Instrucciones para Windows] (http://cordova.apache.org/docs/en/edge/guide_platforms_win8_index.md.html#Windows%20Platform%20Guide)

### Para construir y ejecutar la aplicación de muestra

  * Clonar el repositorio de plugins en un directorio de su elección

    `clon de git https://github.com/AzureAD/azure-activedirectory-library-for-cordova.git`

  * Cree un proyecto y agregue las plataformas que quiere de soporte

    ` cordova crea ADALSample --copy-from="azure-activedirectory-library-for-cordova/sample" `

    `CD ADALSample`

    `agregar a android la plataforma cordova`

    `agregar a ios la plataforma cordova`

    `agregar a windows la plataforma cordova`

  * Agregue el complemento a su proyecto

    `agregar complemento de cordova ../azure-activedirectory-library-for-cordova`

  * Construir y ejecutar la aplicación: `cordova ejecutar`.


## Establecer una aplicación en Azure AD

Puede encontrar instrucciones detalladas de cómo configurar una nueva aplicación en Azure AD[aquí](https://github.com/AzureADSamples/NativeClient-MultiTarget-DotNet#step-4--register-the-sample-with-your-azure-active-directory-tenant).

## Pruebas

Este complemento contiene un paquete de pruebas, basado en el [complemento cordova test-framework](https://github.com/apache/cordova-plugin-test-framework). El conjunto de pruebas se coloca en la carpeta de `pruebas` en la raíz o repo y representa un plugin separado.

Para ejecutar las pruebas es necesario crear una nueva aplicación como se describe en la sección[Instrucciones de instalación](#installation-instructions) y luego realizar los siguientes pasos:

  * Agregar el paquete de pruebas a la aplicación

    ` agregar complemento ../azure-activedirectory-library-for-cordova/tests `

  * Actualizar el archivo config.xml de la aplicación: cambio`<content src="index.html" />` a `<content src="cdvtests/index.html" />`
  * Cambiar los ajustes específicos de la AD para la aplicación de la prueba al principio del archivo`plugins\cordova-plugin-MS-adal\www\tests.js`. Actualización `AUTHORITY_URL`, `RESOURCE_URL`, `REDIRECT_URL`, `APP_ID` a los valores que proporciona su Azure AD. Para instrucciones sobre cómo configurar una aplicación en el Azure AD, consulte la [Establecer una aplicación en la sección Azure AD](#setting-up-an-application-in-azure-ad).
  * Construcción y ejecución de la aplicación.

## Windows Quirks ##
[Actualmente hay una falla de Cordova](https://issues.apache.org/jira/browse/CB-8615), lo que implica la necesidad de la solución basada en el gancho.
La solución debe ser descartada después de que se aplique un arreglo.

### Usando ADFS/SSO
Para usar ADFS/SSO en la plataforma Windows (Windows Phone 8.1 no es compatible por ahora) agregue la siguiente preferencia en`config.xml`: 
`<preference name="adal-use-corporate-network" value="true" />`

`adal-use-corporate-network`es `falso` por defecto.

Agregará todas las capacidades de aplicación necesarias y conmutará el authContext para soportar el ADFS. Puede cambiar su valor a`falso`y volver más tarde, o eliminarlo de `config.xml` \- llamada `preparando cordova`después de él para aplicar los cambios.

__Nota__: Normalmente no debería usar la `adal-use-corporate-network` ya que añade capacidades, lo que impide que una aplicación se publique en la tienda de Windows.

## Derechos de autor ##
Copyright (c) Microsoft Open Technologies, Inc. Todos los derechos reservados.

Con licencia bajo la Licencia de Apache, Versión 2.0 (la "Licencia"); es posible que no pueda usar estos archivos excepto en cumplimiento con la Licencia. Puede obtener una copia de la Licencia en

http://www.apache.org/licenses/LICENSE-2.0

Excepto si lo requiere la legislación vigente o es acordado por escrito, el software distribuido bajo la Licencia se distribuye "TAL CUAL", SIN GARANTÍAS O CONDICIONES DE NINGÚN TIPO, ya sea de forma explícita o implícita. Consulte la licencia para conocer el lenguaje específico que rige los permisos y limitaciones de la licencia.
