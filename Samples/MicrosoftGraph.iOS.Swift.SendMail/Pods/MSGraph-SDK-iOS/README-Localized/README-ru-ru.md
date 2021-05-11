# Microsoft Graph SDK для iOS (предварительный просмотр)

Простая интеграция служб и данных из Microsoft Graph в нативные приложения iOS с помощью этой библиотеки Objective-C.

---

: восклицание:**ЗАМЕТКА**: Этот код и связанные с ним двоичные файлы выпускаются как *ПРЕДВАРИТЕЛЬНАЯ ВЕРСИЯ* разработчика. Вы можете использовать эту библиотеку в соответствии с условиями включенной в нее [ЛИЦЕНЗИИ](/LICENSE) и открывать выпуски в этом репозитории для неофициальной поддержки.

Сведения о официальной поддержке Майкрософт доступны [здесь][support-placeholder].

[support-placeholder]: https://support.microsoft.com/

---

Эта библиотека генерируется из метаданных Microsoft Graph API с использованием [Vipr] и [Vipr-T4TemplateWriter] и использует [общий стек клиента][orc-for-ios].

[Vipr]: https://github.com/microsoft/vipr
[Vipr-T4TemplateWriter]: https://github.com/msopentech/vipr-t4templatewriter
[orc-for-ios]: https://github.com/msopentech/orc-for-ios

## Быстрое начало работы

Чтобы использовать эту библиотеку в проекте, выполните общие действия, как описано ниже:

1. Настройте [Подфайл].
2. Настройте проверки подлинности.
3. Постройте клиент API.

[Podfile]: https://guides.cocoapods.org/syntax/podfile.html

### Настройка

1. Создайте новый проект приложения XCode из заставки XCode. В диалоговом окне выберите iOS > приложении Single View. Назовите вашу заявку как хотите; мы примем имя *MSGraphQuickStart* здесь.

2. Добавьте файл в проект. В диалоговом окне выберите iOS > другие > Очистить и назовите ваш файл `Podfile`.

3. Добавьте эти строки в Podfile, чтобы импортировать пакет SDK Microsoft Graph.

 ```ruby
 source 'https://github.com/CocoaPods/Specs.git'
 xcodeproj 'MSGraphQuickStart'
 pod 'MSGraph-SDK-iOS'
 ```

 > ПРИМЕЧАНИЕ: Для получения подробной информации о Cocoapods и передовых методах для Podfiles прочитайте руководство [Использование Cocoapods].

4. Загрузка проекта XCode.

5. В командной строке перейдите в каталог проекта. Затем запустите `pod install`.

 > ПРИМЕЧАНИЕ: Установите Cocoapods в первую очередь. Инструкции [здесь](https://guides.cocoapods.org/using/getting-started.html).

6. В том же месте в терминале выполните `open MSGraphQuickStart.xcworkspace`, чтобы открыть рабочую область, содержащую ваш оригинальный проект вместе с импортированными модулями в XCode.

---

### Проверка подлинности и создание клиента

После подготовки проекта, на следующем этапе нужно инициализировать диспетчер зависимостей и клиент API.

:восклицание: Если вы еще не зарегистрировали свое приложение в Azure AD, это необходимо сделать до выполнения этого шага, следуя следующим [инструкциям][MSDN Add Common Consent].

1. Щелкните правой кнопкой мыши папку MSGraphQuickStart и выберите команду "Создать файл". В диалоговом окне выберите *iOS* > *Ресурсы* > *Список свойств*. Назовите файл `adal_settings.plist`. Добавьте следующие ключи в список и установите их значения в соответствии с регистрацией вашего приложения. **Это всего лишь примеры; не забудьте использовать собственные значения.**

 | Key | Значение |
| --- | ----- |
| ClientId | Пример: e59f95f8-7957-4c2e-8922-c1f27e1f14e0 |
| RedirectUri | Пример: https: //my.client.app/ |
| ResourceId | Пример: https: //graph.microsoft.com |
| AuthorityUrl | https: //login.microsoftonline.com/common/ |

2. Откройте ViewController.m в папке MSGraphQuickStart. Добавьте заголовок "тег" для заголовков, связанных с Microsoft Graph и ADAL.

 ```objective-c
 #import <MSGraphService.h>
 #import <impl/ADALDependencyResolver.h>
 #import <ADAuthenticationResult.h>
 ```

3. Добавьте свойства для ADALDependencyResolver и MSGraph в разделе расширения класса ViewController.m.

 ```objective-c
 @interface ViewController ()
 
 @property (strong, nonatomic) ADALDependencyResolver *resolver;
 @property (strong, nonatomic) MSGraphServiceClient *graphClient;
 
 @end
 ```

4. Инициализируйте преобразователь и клиент в методе viewDidLoad файла ViewController.m.

 ```objective-c
 - (void)viewDidLoad {
     [super viewDidLoad];
     
    self.resolver = [[ADALDependencyResolver alloc] initWithPlist];
    
    self.graphClient = [[MSGraphServiceClient alloc] initWithUrl:@"https://graph.microsoft.com/" dependencyResolver:self.resolver];
    }
 ```

5. Перед использованием клиента необходимо убедиться в том, что пользователь выполнил вход в систему в интерактивном режиме хотя бы один раз. Для запуска последовательности входа в систему можно использовать `interactiveLogon` или `interactiveLogonWithCallback:`. В этом упражнении добавьте следующее в метод viewDidLoad из последнего шага:

 ```objective-c
 [self.resolver interactiveLogonWithCallback:^(ADAuthenticationResult *result) {
     if (result.status == AD_SUCCEEDED) {
         [self.resolver.logger logMessage:@"Connected." withLevel:LOG_LEVEL_INFO];
     } else {
         [self.resolver.logger logMessage:@"Authentication failed." withLevel:LOG_LEVEL_ERROR];
     }
 }];
 ```

6. Теперь вы можете безопасно использовать API-клиент.

[Using Cocoapods]: https://guides.cocoapods.org/using/using-cocoapods.html
[MSDN Add Common Consent]: https://msdn.microsoft.com/en-us/office/office365/howto/add-common-consent-manually

## Примеры
- [O365-iOS-Connect] — Начало работы и проверка подлинности <br />
- [O365-iOS-Snippets] - API запросы и ответы

[O365-iOS-Connect]: https://github.com/OfficeDev/O365-iOS-Connect
[O365-iOS-Snippets]: https://github.com/OfficeDev/O365-iOS-Snippets

## Помощь
Прежде чем отправить запрос на включение внесенных изменений, необходимо подписать [Лицензионное Соглашение с Участником](https://cla2.msopentech.com/). Чтобы заполнить лицензионное соглашение участника (CLA), вам нужно будет отправить запрос через форму, а затем подписать лицензионное соглашение участника в электронном виде, когда вы получите электронное письмо со ссылкой на документ. Это нужно сделать только один раз для любого проекта Microsoft Open Technologies.

## Лицензия
Авторские права (c) Microsoft, Inc. Все права защищены. Лицензирован в рамках лицензии Apache версии 2,0.
