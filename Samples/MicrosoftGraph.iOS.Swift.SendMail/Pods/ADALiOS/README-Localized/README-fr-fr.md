#Bibliothèque d’authentification Azure Active Directory (ADAL) de Microsoft pour iOS et OSX
=====================================

[![État de création](https://travis-ci.org/MSOpenTech/azure-activedirectory-library-for-ios.png)](https://travis-ci.org/MSOpenTech/azure-activedirectory-library-for-ios)
[![État de la couverture](https://coveralls.io/repos/MSOpenTech/azure-activedirectory-library-for-ios/badge.png?branch=master)](https://coveralls.io/r/MSOpenTech/azure-activedirectory-library-for-ios?branch=master)

Le Kit de développement logiciel ADAL pour iOS vous permet d’ajouter une prise en charge des comptes professionnels à votre application en quelques lignes de code supplémentaire. Ce Kit de développement logiciel (SDK) donne à votre application toutes les fonctionnalités de Microsoft Azure AD, y compris la prise en charge du protocole standard OAuth2, l’intégration de l’API web avec consentement au niveau de l’utilisateur, et la prise en charge de l’authentification à deux facteurs. Il s’agit de la solution la plus FOSS (Logiciels gratuits et Open Source) qui vous permet de participer au processus de développement pendant la création de ces bibliothèques. 

**Qu’est-ce qu’un compte professionnel ?**

Un compte professionnel est une identité que vous utilisez pour travailler, que ce soit dans votre entreprise ou sur un campus universitaire. Partout où vous avez besoin d’accéder à votre vie professionnelle, vous allez utiliser un compte professionnel. Le compte professionnel peut être lié à un serveur Active Directory exécuté dans votre centre de données ou en direct dans le cloud, comme lorsque vous utilisez Office 365. Un compte professionnel permet à vos utilisateurs de savoir qu’ils accèdent à leurs documents et données importants sauvegardés mes informations ma sécurité Microsoft.

## ADAL pour iOS 1.0 publié !

Suite à vos commentaires, nous avons publié la version 1.0.0 d’iOS pour ADAL [vous pouvez récupérer la version ici] (https://github.com/AzureAD/azure-activedirectory-library-for-objc/releases/tag/1.0.1)

## Exemples et documentation

[Nous fournissons une suite complète d'exemples d'applications et de documentation sur GitHub](https://github.com/AzureADSamples) pour vous aider à commencer à apprendre le système Azure Identity. Cela inclut des didacticiels pour les clients natifs tels que Windows, Windows Phone, iOS, OSX, Android et Linux. Nous fournissons également des démonstrations complètes pour les flux d’authentification tels que Oauth2, OpenID Connect, Graph API et d’autres fonctionnalités extraordinaire. 

Visitez vos exemples Azure Identity pour iOS : [https://github.com/AzureADSamples/NativeClient-iOS](https://github.com/AzureADSamples/NativeClient-iOS)

## Aide et support de la communauté

Nous utilisons [Dépassement de capacité de la pile](http://stackoverflow.com/) pour collaborer avec la communauté sur la prise en charge d’Azure Active Directory et de ses kits de développement, y compris celui-ci. Nous vous recommandons vivement de poser des questions sur le dépassement de capacité de la pile (nous sommes là !) Consultez également les problèmes existants pour voir si quelqu'un a déjà eu votre question. 

Nous vous recommandons d’utiliser la balise « adal » pour que nous puissions voir ! Voici le dernier groupe de questions et réponses en cas de dépassement de capacité de la pile pour ADAL : [http://stackoverflow.com/questions/tagged/adal](http://stackoverflow.com/questions/tagged/adal)

## Contribution

Tout le code est sous licence Apache 2.0 et nous sommes en train de trier activement sur GitHub. Les contributions et commentaires sont les bienvenus. Vous pouvez cloner le référentiel et commencer à prendre votre contribution. 

## Démarrage rapide

1. Clonez le référentiel sur l’ordinateur
2. Créer la bibliothèque
3. Ajoutez la bibliothèque ADALiOS à votre projet
4. Ajoutez les storyboards de la ADALiOSBundle à vos ressources de projet
5. Ajoutez libADALiOS à la phase « Lien avec des bibliothèques ». 


##Téléchargement

Nous avons fait en sorte que vous puissiez facilement disposer de plusieurs options pour utiliser cette bibliothèque dans votre projet iOS :

###Option 1 : Zip source :

Pour télécharger une copie du code source, cliquez sur « Télécharger ZIP » sur le côté droit de la page ou cliquer [ici](https://github.com/AzureAD/azure-activedirectory-library-for-objc/archive/1.0.0.tar.gz).

###Option 2 : Cocoapods

    pod 'ADALiOS', '~> 1.0.2'

## Utilisation

### ADAuthenticationContext

Le point de départ de l’API se trouve dans l’en-tête ADAuthenticationContext.h. ADAuthenticationContext est la classe principale utilisée pour obtenir, mettre en cache et fournir des jetons d’accès.

#### Comment obtenir rapidement un jeton à partir du kit de développement :

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

#### Ajout du jeton à authHeader pour accéder aux API :

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

### Diagnostics

Voici les principales sources d’informations pour diagnostiquer les problèmes :

+ NSError
+ Journaux
+ Suivis réseau

Notez également que les ID de corrélation sont un élément central des diagnostics dans la bibliothèque. Vous pouvez définir vos ID de corrélation en fonction de chaque demande si vous souhaitez mettre en corrélation une demande de la bibliothèque d’authentification Azure AD (ADAL) avec d’autres opérations dans votre code. Si vous ne configurez pas d’ID de corrélation, ADAL génère une valeur aléatoire et tous les messages du journal et les appels réseau sont estampillés avec l’ID de corrélation. L’ID généré automatiquement change à chaque demande.

#### NSError

Il s’agit évidemment du premier diagnostic. Nous essayons de fournir des messages d’erreur utiles. Si vous en trouvez un qui n’est pas utile, faites-le-nous savoir en signalant un problème. Veuillez également fournir des informations sur l'appareil, notamment le modèle du Kit de développement logiciel (SDK). Le message d’erreur est renvoyé dans le cadre du ADAuthenticationResult dont l’État est AD_FAILED.

#### Journaux

Vous pouvez configurer la bibliothèque pour générer des messages de journal que vous pouvez utiliser pour diagnostiquer les problèmes. ADAL utilise NSLog par défaut pour consigner les messages. Chaque appel de méthode API est décoré avec la version API et tous les autres messages sont décorés avec les ID de corrélation et UTC TIMESTAMP. Ces données sont importantes pour l’examen des diagnostics côté serveur. Le kit de développement logiciel (SDK) présente également la possibilité de fournir un rappel de journal personnalisé comme suit.
```Objective-C
    [ADLogger setLogCallBack:^(ADAL_LOG_LEVEL logLevel, NSString *message, NSString *additionalInformation, NSInteger errorCode) {
        //HANDLE LOG MESSAGE HERE
    }]
```

##### Niveaux d'enregistrement
+ No_Log (désactiver toute la journalisation)
+ Error(Exceptions. Définir par défaut)
+ Warn(Avertissement)
+ Info (informations)
+ Verbose(détails supplémentaires)

Vous définissez le niveau de journal comme suit :
```Objective-C
[ADLogger setLevel:ADAL_LOG_LEVEL_INFO]
 ```
 
#### Suivis réseau

Vous pouvez utiliser différents outils pour capturer le trafic HTTP généré par la bibliothèque ADAL. Cela est particulièrement utile si vous êtes familiarisé avec le protocole OAuth ou si vous avez besoin de fournir des informations de diagnostic à Microsoft ou à d’autres canaux de support.

Charles est l'outil de suivi HTTP le plus simple dans OSX. Utilisez les liens suivants pour le configurer de manière à enregistrer correctement le trafic réseau ADAL. Pour être utile, il est nécessaire de configurer Charles pour enregistrer le trafic SSL non chiffré. REMARQUE : Les suivis générés de cette manière peuvent contenir des informations hautement privilégiées (jetons d’accès, noms d’utilisateur, mots de passe, etc.). Si vous utilisez des comptes de production, ne partagez pas ces suivis avec des tiers. Si vous avez besoin de fournir un suivi à quelqu’un pour obtenir un support technique, reproduisez le problème à l’aide d’un compte temporaire, avec des noms d’utilisateur et des mots de passe que vous êtes prêt à partager.

+ [Configuration de SSL pour les appareils ou simulateurs iOS](http://www.charlesproxy.com/documentation/faqs/ssl-connections-from-within-iphone-applications/)



##Problèmes courants

**Application, l’utilisation de la bibliothèque ADAL se bloque avec l’exception suivante :**<br/> \*\** Fin de l’application en raison d’une exception non interceptée 'NSInvalidArgumentException', raison : '+[NSString isStringNilOrBlank:]: sélecteur non reconnu envoyé à la classe 0x13dc800'<br/>
**Solution :** Veillez à ajouter l’indicateur-ObjC à « Autres indicateurs de l’éditeur de liens » pour le paramètre de génération de l’application. Pour plus d'informations, consultez la documentation Apple sur l'utilisation des bibliothèques statiques :<br/> https://developer.apple.com/library/ios/technotes/iOSStaticLibraries/Articles/configuration.html#//apple_ref/doc/uid/TP40012554-CH3-SW1.

## Licence

Copyright (c) Microsoft Open Technologies, Inc. Tous droits réservés. Sous licence Apache, version 2.0 (la « licence »). 
