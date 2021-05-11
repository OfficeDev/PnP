#Microsoft Azure Active Directory Authentication Library (ADAL) para iOS e OSX
=====================================

[![Status da Compilação](https://travis-ci.org/MSOpenTech/azure-activedirectory-library-for-ios.png)](https://travis-ci.org/MSOpenTech/azure-activedirectory-library-for-ios)
[![Status da Cobertura](https://coveralls.io/repos/MSOpenTech/azure-activedirectory-library-for-ios/badge.png?branch=master)](https://coveralls.io/r/MSOpenTech/azure-activedirectory-library-for-ios?branch=master)

O SDK do ADAL para iOS oferece a capacidade de adicionar suporte a contas de trabalho ao aplicativo com apenas algumas linhas de código adicional. Esse SDK dá ao seu aplicativo toda a funcionalidade do Microsoft Azure AD, incluindo suporte a protocolo padrão do setor para OAuth2, integração de API Web com consentimento no nível do usuário e suporte à autenticação de dois fatores. O melhor de tudo é o software livre e de código aberto (FOSS), para que você possa participar do processo de desenvolvimento à medida que construímos essas bibliotecas. 

**O que é uma conta corporativa?**

Uma conta corporativa é uma identidade que você usa para realizar o trabalho, não importa se está em uma empresa ou em um campus universitário. Em qualquer lugar que você precise ter acesso à sua vida profissional, você usará uma Conta Corporativa. A conta corporativa pode ser vinculada a um servidor do Active Directory que está sendo executado em seu centro de dados ou totalmente na nuvem, como quando você usa o Office 365. Uma conta corporativa será o modo como os usuários saberão que estão acessando seus documentos importantes e dados com o suporte da Minha Segurança da Microsoft.

## O ADAL para iOS 1.0 lançado!

Graças aos seus comentários, lançamos a versão 1.0.0 do iOS para ADAL [você pode obter a versão aqui] (https://github.com/AzureAD/azure-activedirectory-library-for-objc/releases/tag/1.0.1)

## Exemplos e documentação

[Fornecemos um pacote completo de aplicativos de exemplo e documentação sobre o GitHub](https://github.com/AzureADSamples) para ajudá-lo a começar a aprender o sistema de identidade do Azure. Isso inclui tutoriais para clientes nativos, como Windows, Windows Phone, iOS, OSX, Android e Linux. Também fornecemos instruções completas para os fluxos de autenticação como o OAuth2, o OpenID Connect, o Graph API e outros recursos impressionantes. 

Visite seus exemplos de identidade do Azure para iOS aqui: [https://github.com/AzureADSamples/NativeClient-iOS](https://github.com/AzureADSamples/NativeClient-iOS)

## Ajuda e suporte da Comunidade

Aproveitamos [Stack Overflow](http://stackoverflow.com/) para trabalhar com a Comunidade no suporte do Azure Active Directory e de seus SDKs, inclusive este! É altamente recomendável que você tire suas dúvidas no Stack Overflow (estamos todos lá!) Além disso, você também pode ver se alguém já fez a sua pergunta antes. 

Recomendamos que você use a marca "Adal" para que possamos ver! Aqui estão as perguntas e respostas mais recentes no Stack Overflow para ADAL: [http://stackoverflow.com/questions/tagged/adal](http://stackoverflow.com/questions/tagged/adal)

## Colaboração

Todo o código é licenciado na licença Apache 2.0 e fazemos a triagem ativa no GitHub. Gostaríamos de receber contribuições e comentários. Você pode clonar o repositório e começar a colaborar agora. 

## Início Rápido

1. Clonar o repositório para o seu computador
2. Construir a biblioteca
3. Adicionar a biblioteca ADALiOS ao seu projeto
4. Adicionar os storyboards da ADALiOSBundle aos recursos do projeto
5. Adicione libADALiOS à fase "vincular à biblioteca". 


##Baixar

Facilitamos para você ter várias opções para usar esta biblioteca em seu projeto para iOS:

##Opção 1: CEP de origem

Para baixar uma cópia do código-fonte, clique em Baixar ZIP no lado direito da página ou clique [aqui](https://github.com/AzureAD/azure-activedirectory-library-for-objc/archive/1.0.0.tar.gz).

###Option 2: Cocoapods

    pod 'ADALiOS', '~> 1.0.2'

## Uso

### ADAuthenticationContext

O ponto de partida para a API está no cabeçalho ADAuthenticationContext. h. ADAuthenticationContext é a principal classe usada para obter, armazenar em cache e fornecer tokens de acesso.

#### Como obter rapidamente um token no SDK:

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

#### Adicionando o token ao authHeader para acessar APIs:

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

### Diagnóstico

Estas são as principais fontes de informações para diagnosticar problemas:

+ NSError
+ Logs
+ Rastreamentos de rede

Além disso, observe que as IDs de correlação são essenciais para o diagnóstico na biblioteca. Você pode definir suas IDs de correlação com base em cada solicitação se quiser correlacionar uma solicitação da ADAL com outras operações em seu código. Se você não definir uma ID de correlação, o ADAL irá gerar uma aleatória, e todas as mensagens de log e chamadas de rede serão carimbadas com a ID de correlação. A ID gerada automaticamente muda em cada solicitação.

#### NSError

Esse é o primeiro diagnóstico. Tentamos fornecer mensagens de erro úteis. Se você encontrar uma que não é útil, registre um problema e nos informe. Forneça também informações do dispositivo, como modelo e número do SDK#. A mensagem de erro é retornada como parte do ADAuthenticationResult, onde o status é definido para AD_FAILED.

#### Logs

Você pode configurar a biblioteca para gerar mensagens de log que você pode usar para ajudar a diagnosticar problemas. O ADAL usa o NSLog por padrão para registrar as mensagens. Cada chamada de método da API é decorada com a versão da API e todas as outras mensagens são decoradas com ID de correlação e carimbo de data/hora UTC. Esses dados são importantes para a aparência do diagnóstico do lado do servidor. O SDK também expõe a capacidade de fornecer um retorno de chamada personalizado do Logger da seguinte maneira.
```Objective-C
    [ADLogger setLogCallBack:^(ADAL_LOG_LEVEL logLevel, NSString *message, NSString *additionalInformation, NSInteger errorCode) {
        //HANDLE LOG MESSAGE HERE
    }]
```

##### Níveis de log
+ No_Log (desabilitar todos os logs)
+ Error (exceções. Definir como padrão)
+ Warn (aviso)
+ Informações (fins informativos)
+ Detalhado (mais detalhes)

Defina o nível de log da seguinte maneira:)
```Objective-C
[ADLogger setLevel:ADAL_LOG_LEVEL_INFO]
 ```
 
#### Rastreamentos de Rede

Você pode usar várias ferramentas para capturar o tráfego HTTP que a ADAL gera. Isso é mais útil se você estiver familiarizado com o protocolo OAuth ou se você precisar fornecer informações de diagnóstico para a Microsoft ou outros canais de suporte.

Charles é a ferramenta de rastreamento de HTTP mais fácil no OSX. Use os links a seguir para configurá-la até o tráfego de rede da ADAL de registro correto. Para ser útil, é necessário configurar Charles para gravar o tráfego SSL não criptografado. OBSERVAÇÃO: Rastreamentos gerados desta forma podem conter informações altamente privilegiadas como tokens de acesso, nomes de usuário e senhas. Se você estiver usando contas de produção, não compartilhe esses rastreamentos com terceiros. Se precisar fornecer um rastreamento a alguém para obter suporte, reproduza o problema com uma conta temporária com nomes de usuário e senhas que você não se importa de compartilhar.

+ [Configurando o SSL para simulador ou dispositivos iOS](http://www.charlesproxy.com/documentation/faqs/ssl-connections-from-within-iphone-applications/)



##Problemas comuns

**O aplicativo, usando a biblioteca ADAL falha, com a seguinte exceção:**<br/> \*\*\*Encerrando o aplicativo devido a uma exceção não percebida ' NSInvalidArgumentException ', motivo: ' + [NSString isStringNilOrBlank:]: seletor não reconhecido enviado para classe 0x13dc800 '<br/>
**Solução:** Certifique-se de adicionar o sinalizador -ObjC à configuração de compilação "outros sinalizadores do vinculador" do aplicativo. Para saber mais, confira a documentação da Apple para usar bibliotecas estáticas:<br/> https://developer.apple.com/library/ios/technotes/iOSStaticLibraries/Articles/configuration.html#//apple_ref/doc/uid/TP40012554-CH3-SW1.

## Licença

Copyright (c) Microsoft Open Technologies, Inc. Todos os direitos reservados. Licenciado na Licença Apache, versão 2.0\. (Licença) 
