#Библиотека проверки подлинности Microsoft Azure Active Directory (ADAL) для iOS и OSX
=====================================

[![Состояние сборки](https://travis-ci.org/MSOpenTech/azure-activedirectory-library-for-ios.png)](https://travis-ci.org/MSOpenTech/azure-activedirectory-library-for-ios)
[![Охват](https://coveralls.io/repos/MSOpenTech/azure-activedirectory-library-for-ios/badge.png?branch=master)](https://coveralls.io/r/MSOpenTech/azure-activedirectory-library-for-ios?branch=master)

С помощью SDK ADAL для iOS можно добавлять поддержку рабочих учетных записей в приложение, используя лишь несколько строк дополнительного кода. Этот пакет SDK обеспечивает приложению доступ ко всем функциям Microsoft Azure AD, в том числе поддержку стандартного протокола OAuth2, интеграцию веб-API с согласием пользователя, а также поддержку двухфакторной проверки подлинности. Самое главное, это свободное и открытое программное обеспечение (FOSS), поэтому вы можете участвовать в разработке при создании этих библиотек. 

**Что такое рабочая учетная запись?**

Рабочая учетная запись — это удостоверение, используемое для работы в любом месте: в организациях и учебных заведениях. Рабочая учетная запись применяется, если нужно получить доступ к рабочим данным из любого места. Рабочую учетную запись можно привязать к серверу Active Directory, работающему в центре обработки данных, или полностью разместить в облаке, как при использовании Office 365. При использовании рабочей учетной записи ваши пользователи понимают, что обращаются к важным документам и данным, защищенным с помощью системы безопасности Майкрософт.

## Выпущена версия ADAL для iOS 1.0!

С использованием ваших отзывов мы выпустили версию ADAL для iOS 1.0.0 [Получить выпуск можно здесь] (https://github.com/AzureAD/azure-activedirectory-library-for-objc/releases/tag/1.0.1)

## Примеры и документация

[Мы предоставляем полный набор примеров приложений и документов в GitHub](https://github.com/AzureADSamples), чтобы вы могли приступить к изучению системы удостоверений Azure. Сюда входят учебники для собственных клиентов, таких как Windows, Windows Phone, iOS, OSX, Android и Linux. Кроме того, мы предоставляем полные пошаговые инструкции для таких потоков проверки подлинности, как OAuth2, OpenID Connect, API Graph и другие потрясающие функции. 

См. примеры удостоверений Azure для iOS здесь: [https://github.com/AzureADSamples/NativeClient-iOS](https://github.com/AzureADSamples/NativeClient-iOS)

## Помощь и поддержка сообщества

Для работы с сообществом по поддержке Azure Active Directory и пакетов SDK, включая этот, мы используем [Stack Overflow](http://stackoverflow.com/). Настоятельно рекомендуем задавать свои вопросы на сайте Stack Overflow (мы все находимся там!). Вы также можете просматривать существующие проблемы, чтобы узнать, задавался ли уже ваш вопрос. 

Рекомендуем использовать тег adal, чтобы мы могли увидеть его! Последние вопросы и ответы на Stack Overflow для ADAL: [http://stackoverflow.com/questions/tagged/adal](http://stackoverflow.com/questions/tagged/adal)

## Участие

Весь код предоставляется по лицензии Apache 2.0, и мы активно рассматриваем его на GitHub. Мы будем рады вашему участию и отзывам. Вы можете клонировать репозиторий и приступить к участию. 

## Быстрое начало работы

1. Клонируйте репозиторий на компьютер.
2. Создайте библиотеку.
3. Добавьте библиотеку ADALiOS в проект.
4. Добавьте раскадровки из ADALiOSBundle в ресурсы проекта.
5. Добавьте libADALiOS для этапа "Связь с библиотеками". 


##Скачивание

Существует несколько способов использования этой библиотеки в проекте для iOS:

###Способ 1. Исходный ZIP-файл

Чтобы скачать копию исходного кода, в правой части страницы щелкните "Download ZIP" (Скачать ZIP) или щелкните [здесь](https://github.com/AzureAD/azure-activedirectory-library-for-objc/archive/1.0.0.tar.gz).

###Способ 2. Cocoapods

    pod 'ADALiOS', '~> 1.0.2'

## Использование

### ADAuthenticationContext

Исходная точка API находится в заголовке ADAuthenticationContext.h. ADAuthenticationContext — это основной класс для получения, кэширования и предоставления маркеров доступа.

#### Быстрое получение маркера из пакета SDK:

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

#### Добавление маркера в authHeader для доступа к API:

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

### Диагностика

Ниже представлены основные источники информации для диагностики проблем.

+ NSError
+ Журналы
+ Данные трассировки сети

Также следует отметить, что в библиотеке наиболее важными для диагностики являются идентификаторы корреляции. Вы можете установить собственные идентификаторы корреляции для отдельных запросов, если требуется сопоставить запрос ADAL с другими операциями в коде. Если идентификатор корреляции не задан, библиотека ADAL создает случайный идентификатор, и все сообщения журнала и сетевые вызовы будут помечены этим идентификатором корреляции. Генерируемый идентификатор изменяется при каждом запросе.

#### NSError

Это первая диагностика. Мы стараемся предоставить содержательные сообщения об ошибках. Если вы не считаете какое-либо сообщение содержательным, сообщите нам об этом. Также укажите такие сведения об устройстве, как модель и SDK#. Сообщение об ошибке возвращается в составе ADAuthenticationResult с состоянием AD_FAILED.

#### Журналы

Можно настроить библиотеку на создание сообщений журнала, которые будут использоваться для диагностики проблем. ADAL использует NSLog по умолчанию для регистрации сообщений. В каждом вызове метода API указывается версия API, а во всех остальных сообщениях указывается идентификатор корреляции и временная метка UTC. Эти данные важны для поиска диагностики на стороне сервера. С помощью SDK также можно предусмотреть настраиваемый обратный вызов средства ведения журнала, как показано ниже. ```Objective-C [ADLogger setLogCallBack:
```Objective-C
    [ADLogger setLogCallBack:^(ADAL_LOG_LEVEL logLevel, NSString *message, NSString *additionalInformation, NSInteger errorCode) {
        //HANDLE LOG MESSAGE HERE
    }]
```

##### Уровни ведения журнала
+ No_Log (отключить ведение журнала);
+ Error (исключения. Устанавливается по умолчанию);
+ Warn (предупреждение);
+ Info (информирование);
+ Verbose (дополнительные сведения).

Настройка уровня ведения журнала происходит следующим образом.
```Objective-C
[ADLogger setLevel:ADAL_LOG_LEVEL_INFO]
 ```
 
#### Данные трассировки сети

Для перехвата HTTP-трафика, который создает библиотека ADAL, можно использовать различные инструменты. Это очень удобно, если вы знакомы с протоколом OAuth или если необходимо предоставить диагностические сведения в корпорацию Майкрософт или другие каналы поддержки.

Charles является простым инструментом трассировки HTTP в OSX. Используйте следующие ссылки для его правильной настройки с целью записи сетевого трафика библиотеки ADAL. Чтобы достичь положительного результата, средство Charles должно быть настроено для записи незашифрованного трафика SSL. ПРИМЕЧАНИЕ. Данные трассировки, записанные таким образом, могут содержать конфиденциальные сведения, такие как маркеры доступа, имена пользователей и пароли. При использовании рабочих учетных записей не передавайте данные трассировки третьим сторонам. Если для получения поддержки необходимо предоставить данные трассировки другому пользователю, воспроизведите проблему с временной учетной записью, используя имена пользователей и пароли, которые не будут использоваться для реальных пользователей.

+ [Настройка SSL для симуляторов и устройств iOS](http://www.charlesproxy.com/documentation/faqs/ssl-connections-from-within-iphone-applications/)



##Распространенные проблемы

**В приложении, использующем библиотеку ADAL, возникает сбой со следующим исключением:**<br/> \*\** Завершение работы приложения из-за неисследованного исключения "NSInvalidArgumentException", причина: '+[NSString isStringNilOrBlank:]: нераспознанный селектор, отправленный в класс 0x13dc800'<br/>
**Решение.** Добавьте флаг -ObjC в параметр сборки приложения "Other Linker Flags" (Другие флаги компоновщика). Дополнительные сведения см. в документации Apple по использованию статических библиотек:<br/> https://developer.apple.com/library/ios/technotes/iOSStaticLibraries/Articles/configuration.html#//apple_ref/doc/uid/TP40012554-CH3-SW1.

## Лицензия

(c) Microsoft Open Technologies, Inc. Все права защищены. Предоставляется по лицензии Apache версии 2.0 ("Лицензия"); 
