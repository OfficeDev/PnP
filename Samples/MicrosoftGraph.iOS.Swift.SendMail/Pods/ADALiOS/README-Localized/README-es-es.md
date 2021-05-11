#Biblioteca de Microsoft para autenticación de Azure Active Directory (ADAL) en iOS y OSX
=====================================

[![Estado de la compilación](https://travis-ci.org/MSOpenTech/azure-activedirectory-library-for-ios.png)](https://travis-ci.org/MSOpenTech/azure-activedirectory-library-for-ios)
[![Estado de cobertura](https://coveralls.io/repos/MSOpenTech/azure-activedirectory-library-for-ios/badge.png?branch=master)](https://coveralls.io/r/MSOpenTech/azure-activedirectory-library-for-ios?branch=master)

El SDK de ADAL para iOS le permite, con tan solo unas pocas líneas de código adicional, hacer que la aplicación sea compatible con las cuentas profesionales. Este SDK proporciona a su aplicación la funcionalidad completa de Microsoft Azure AD, que incluye el soporte técnico del protocolo estándar del sector para OAuth2, la integración de la API web con el consentimiento del usuario y el soporte técnico para la autenticación en dos fases. Y lo mejor de todo es que es FOSS (software de código abierto y libre) por lo que puede participar en el proceso de desarrollo a medida que construimos estas bibliotecas. 

**¿Qué es una cuenta profesional?**

Una cuenta profesional es una identidad que se usa para trabajar, independientemente de si se trata de una empresa o de un campus universitario. Usará una cuenta profesional en cualquier lugar en el que necesite obtener acceso a su vida laboral. La cuenta profesional puede estar ligada a un servidor de Active Directory en ejecución en su centro de datos o residir totalmente en la nube, como cuando se usa Office365. Usará las cuentas profesionales para que los usuarios sepan que están accediendo a documentos importantes y a datos protegidos por la seguridad de Microsoft.

## Hemos publicado ADAL para iOS 1.0.

Gracias a sus comentarios, hemos publicado la versión 1.0.0 de iOS para ADAL [puede obtenerla aquí] (https://github.com/AzureAD/azure-activedirectory-library-for-objc/releases/tag/1.0.1)

## Ejemplos y documentación

[Le ofrecemos un paquete de aplicaciones de ejemplo y documentación en GitHub](https://github.com/AzureADSamples) para ayudarle a comenzar con el aprendizaje del sistema de Identidad de Azure. Esto incluye tutoriales para clientes nativos como Windows, Windows Phone, iOS, OSX, Android y Linux. También ofrecemos tutoriales para los flujos de autenticación como OAuth2, OpenID Connect, Graph API y otras características increíbles. 

Vea las muestras de identidad de Azure para iOS aquí: [https://github.com/AzureADSamples/NativeClient-iOS](https://github.com/AzureADSamples/NativeClient-iOS)

## Ayuda a la comunidad y soporte

Usamos [Stack Overflow](http://stackoverflow.com/) para ayudar a la comunidad con el trabajo de soporte de Azure Active Directory y sus SDK, incluido este. Le recomendamos encarecidamente que formule sus preguntas en Stack Overflow (¡ya estamos listos para responder!). También puede examinar los problemas existentes para ver si alguien ha tenido la misma duda que usted anteriormente. 

Le recomendamos que use la etiqueta "adal" para que podamos ver su pregunta. Esta es la sección de preguntas que Stack Overflow dedica a ADAL: [http://stackoverflow.com/questions/tagged/adal](http://stackoverflow.com/questions/tagged/adal)

## Colaboradores

Todo el código se licencia según Apache 2.0 y se evalúa activamente en GitHub. Agradecemos las contribuciones y los comentarios. Si lo desea, puede clonar el repositorio y empezar a contribuir ya mismo. 

## Inicio rápido

1. Clonar el repositorio en su equipo.
2. Crear la biblioteca.
3. Agregar la biblioteca ADALiOS a su proyecto.
4. Agregar guiones gráficos de ADALiOSBundle a los recursos del proyecto.
5. Agregar libADALiOS a la fase "Vincular con bibliotecas". 


##Descargar

Ahora tiene varias opciones para usar esta librería en su proyecto para iOS:

###Opción 1: Código fuente comprimido en un archivo zip

Para descargar una copia del código fuente, haga clic en Descargar ZIP en el lado derecho de la página o haga clic [aquí](https://github.com/AzureAD/azure-activedirectory-library-for-objc/archive/1.0.0.tar.gz).

###Opción 2 Cocoapods

    pod 'ADALiOS', '~> 1.0.2'

## Uso

### ADAuthenticationContext

El punto de inicio de la API se encuentra en el encabezado ADAuthenticationContext.h. ADAuthenticationContext es la clase principal para la obtención, caché y suministro de tokens de acceso.

#### Cómo obtener rápidamente un token del SDK:

```Objective-C
	ADAuthenticationContext* authContext;
	NSString* authority;
	NSString* redirectUriString;
	NSString* resourceId;
	NSString* clientId;

+(void) getToken : (BOOL) clearCache completionHandler:(void (^) (NSString*))completionBlock;
{
    ADAuthenticationError *error;
    authContext = [ADAuthenticationContext authenticationContextWithAuthority:authority
                                                                        error:&error];
    
    NSURL *redirectUri = [NSURL URLWithString:redirectUriString];
    
    if(clearCache){
        [authContext.tokenCacheStore removeAll];
    }
    
    [authContext acquireTokenWithResource:resourceId
                                 clientId:clientId
                              redirectUri:redirectUri
                          completionBlock:^(ADAuthenticationResult *result) {
        if (AD_SUCCEEDED != result.status){
            // display error on the screen
            [self showError:result.error.errorDetails];
        }
        else{
            completionBlock(result.accessToken);
        }
    }];
}
```

#### Agregar el token a authHeader para tener acceso a las API:

```Objective-C

	+(NSArray*) getTodoList:(id)delegate
	{
    __block NSMutableArray *scenarioList = nil;
    
    [self getToken:YES completionHandler:^(NSString* accessToken){
    
    NSURL *todoRestApiURL = [[NSURL alloc]initWithString:todoRestApiUrlString];
            
    NSMutableURLRequest *request = [[NSMutableURLRequest alloc]initWithURL:todoRestApiURL];
            
    NSString *authHeader = [NSString stringWithFormat:@"Bearer %@", accessToken];
            
    [request addValue:authHeader forHTTPHeaderField:@"Authorization"];
            
    NSOperationQueue *queue = [[NSOperationQueue alloc]init];
            
    [NSURLConnection sendAsynchronousRequest:request queue:queue completionHandler:^(NSURLResponse *response, NSData *data, NSError *error) {
                
            if (error == nil){
                    
            NSArray *scenarios = [NSJSONSerialization JSONObjectWithData:data options:0 error:nil];
                
            todoList = [[NSMutableArray alloc]init];
                    
            //each object is a key value pair
            NSDictionary *keyVauePairs;
                    
            for(int i =0; i < todo.count; i++)
            {
                keyVauePairs = [todo objectAtIndex:i];
                        
                Task *s = [[Task alloc]init];
                        
                s.id = (NSInteger)[keyVauePairs objectForKey:@"TaskId"];
                s.description = [keyVauePairs objectForKey:@"TaskDescr"];
                
                [todoList addObject:s];
                
             }
                
            }
        
        [delegate updateTodoList:TodoList];
        
        }];
        
    }];
    return nil; } 
```

### Diagnósticos

Estas son las principales fuentes de información para diagnosticar problemas:

+ NSError
+ Registros
+ Seguimientos de red

Además, tenga en cuenta que los identificadores de correlación son fundamentales para el diagnóstico en la biblioteca. Si desea establecer una correlación de solicitud de ADAL con otras operaciones en el código, puede establecer sus identificadores de correlación por solicitud. Si no se establece un identificador de correlación, ADAL genera uno aleatoriamente y todos los mensajes de registro y llamadas de red se marcarán con el ID. de correlación. El identificador generado automáticamente se modifica con cada solicitud.

#### NSError

Este es obviamente el primer diagnóstico. Intentamos ofrecerle mensajes de error útiles. Si encuentra alguno que no sea útil, genere un caso y háganoslo saber. Proporcione también información sobre el dispositivo, por ejemplo, el modelo y el número de SDK. El mensaje de error se devuelve como parte del ADAuthenticationResult, donde el estado se establece como AD_FAILED.

#### Registros

Puede configurar la biblioteca para que genere mensajes de registro que podrá utilizar para diagnosticar problemas. ADAL usa NSLog de forma predeterminada para registrar los mensajes. Cada llamada a un método de API aparece con la versión de API. El resto de mensajes aparece con el ID. de correlación y la marca de tiempo UTC. Estos datos son importantes para buscar en el diagnóstico del servidor. El SDK también permite proporcionar una devolución de llamada de registrador personalizada como se muestra a continuación.
```Objective-C
    [ADLogger setLogCallBack:^(ADAL_LOG_LEVEL logLevel, NSString *message, NSString *additionalInformation, NSInteger errorCode) {
        //HANDLE LOG MESSAGE HERE
    }]
```

##### Niveles de registro
+ No_Log (deshabilitar todos los registros)
+ Error (Excepciones. Establecido como predeterminado)
+ Warn (Advertencia)
+ Info (fines informativos)
+ Verbose (más detalles)

El nivel de registro se define de la siguiente forma:
```Objective-C
[ADLogger setLevel:ADAL_LOG_LEVEL_INFO]
 ```
 
#### Seguimientos de red

Puede usar varias herramientas para capturar el tráfico HTTP que genera ADAL. Esto es muy útil si está familiarizado con el protocolo OAuth o si necesita proporcionar información de diagnóstico a Microsoft o a otros canales de soporte técnico.

Charles es la herramienta de seguimiento de HTTP más sencilla para OSX. Utilice los vínculos siguientes para configurarla con el fin de que registre correctamente el tráfico de red de ADAL. Para que Charles sea útil, debe configurarlo para que registre tráfico SSL sin cifrar. NOTA: Los seguimientos generados de esta manera pueden contener información altamente privilegiada, como tokens de acceso, nombres de usuario y contraseñas. Si utiliza cuentas de producción, no comparta esta información con terceras partes. Si necesita transmitir el seguimiento a alguien para obtener soporte técnico, reproduzca el problema con una cuenta temporal con nombres de usuario y contraseñas que no le importe compartir.

+ [Configuración de SSL para simuladores o dispositivos con iOS](http://www.charlesproxy.com/documentation/faqs/ssl-connections-from-within-iphone-applications/)



##Problemas frecuentes

**Al utilizar ADAL, la aplicación se bloquea y muestra la excepción siguiente:**<br/> \*\** Terminating app due to uncaught exception 'NSInvalidArgumentException', reason: '+[NSString isStringNilOrBlank:]: unrecognized selector sent to class 0x13dc800'<br/>
**Solución:** Asegúrese de agregar la marca-ObjC a la configuración de la compilación "Otras marcas del vinculador" de la aplicación. Para obtener más información, consulte la documentación de Apple para usar bibliotecas estáticas:<br/> https://developer.apple.com/library/ios/technotes/iOSStaticLibraries/Articles/configuration.html#//apple_ref/doc/uid/TP40012554-CH3-SW1.

## Licencia

Copyright (c) Microsoft Open Technologies, Inc. Todos los derechos reservados. Licenciado bajo la licencia de Apache, versión 2.0\. (la "Licencia"). 
