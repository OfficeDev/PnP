# SDK do Microsoft Graph para iOS (Visualização)

Integre com facilidade serviços e dados do Microsoft Graph a aplicativos nativos iOS usando essa biblioteca Objetiva-C.

---

:exclamação:**Observação**: Esse código e os binários associados são lançados como *visualização*de desenvolvedor. Você tem liberdade para usar essa biblioteca de acordo com os termos da [licença](/LICENSE) incluída e para abrir questões neste repositório para obter suporte não oficial.

As informações sobre o suporte oficial da Microsoft estão disponíveis [aqui][support-placeholder].

[support-placeholder]: https://support.microsoft.com/

---

Essa biblioteca é gerada a partir dos metadados da API do Microsoft Graph usando [ViPR] e [ViPR-T4TemplateWriter] e usa uma[pilha de cliente compartilhada][orc-for-ios].

[Vipr]: https://github.com/microsoft/vipr
[Vipr-T4TemplateWriter]: https://github.com/msopentech/vipr-t4templatewriter
[orc-for-ios]: https://github.com/msopentech/orc-for-ios

## Início Rápido

Para usar essa biblioteca em seu projeto, siga estas etapas gerais, conforme descrito abaixo:

1. Configurar um [Podfile].
2. Configure a autenticação.
3. Construir um cliente da API.

[Podfile]: https://guides.cocoapods.org/syntax/podfile.html

### Configuração

1. Crie um novo projeto do aplicativo Xcode na tela inicial do Xcode. Na caixa de diálogo, escolha iOS > aplicativo de modo de exibição único. Nomeie seu aplicativo como desejar; Vamos dar o nome *MSGraphQuickStart* aqui.

2. Adicionar um arquivo ao projeto. Escolha iOS > outras > Esvaziar da caixa de diálogo e nomeie seu arquivo `Podfile`.

3. Adicione estas linhas ao Podfile para importar o SDK do Microsoft Graph

 ```ruby
 source 'https://github.com/CocoaPods/Specs.git'
 xcodeproj 'MSGraphQuickStart'
 pod 'MSGraph-SDK-iOS'
 ```

 > OBSERVAÇÃO: Para obter informações detalhadas sobre Cocoapods e as práticas recomendadas para Podfiles, leia o guia [using Cocoapods].

4. Baixar o projeto do XCode.

5. Na linha de comando, altere para o diretório do seu projeto. Então execute `instalar pod`.

 > OBSERVAÇÃO: Primeiro, instale o Cocoapods. Instruções [aqui](https://guides.cocoapods.org/using/getting-started.html).

6. No mesmo local no terminal, execute `abrir MSGraphQuickStart. xcworkspace` para abrir um espaço de trabalho que contenha seu projeto original juntamente com o pods importados no Xcode.

---

### Autenticar e construir cliente

Com o projeto preparado, a próxima etapa é inicializar o gerenciador de dependências e um cliente API.

:exclamação: Se você ainda não registrou seu aplicativo no Azure AD, é necessário fazer isso antes de concluir esta etapa, seguindo [estas instruções][MSDN Add Common Consent].

1. Clique com o botão direito do mouse na pasta MSGraphQuickStart e escolha "Novo Arquivo". Na caixa de diálogo, selecione *iOS* > *Recurso* > *Lista de Propriedades*. Nomeie o arquivo `adal_settings. plist`. Adicione as seguintes teclas à lista e defina seus valores às do registro do aplicativo. **Esses são apenas exemplos; Use seus próprios valores.**

 |Tecla|Valor |
|---|-----|
| ClientId | Exemplo: e59f95f8-7957-4C2E-8922-c1f27e1f14e0 |
| RedirectUri | Exemplo: https://my.client.app/|
| ResourceId | Exemplo: https://graph.microsoft.com |
| AuthorityUrl | https://login.microsoftonline.com/Common/|

2. Abra ViewController.m na pasta MSGraphQuickStart. Adicione o cabeçalho abrangente para cabeçalhos relacionados ao Microsoft Graph e ADAL.

 ```objective-c
 #import <MSGraphService.h>
 #import <impl/ADALDependencyResolver.h>
 #import <ADAuthenticationResult.h>
 ```

3. Adicione Propriedades para o ADALDependencyResolver e MSGraph na seção extensão da classe do ViewController.m.

 ```objective-c
 @interface ViewController ()
 
 @property (strong, nonatomic) ADALDependencyResolver *resolver;
 @property (strong, nonatomic) MSGraphServiceClient *graphClient;
 
 @end
 ```

4. Inicialize o solucionador e o cliente no método viewDidLoad do arquivo ViewController.m.

 ```objective-c
 - (void)viewDidLoad {
     [super viewDidLoad];
     
    self.resolver = [[ADALDependencyResolver alloc] initWithPlist];
    
    self.graphClient = [[MSGraphServiceClient alloc] initWithUrl:@"https://graph.microsoft.com/" dependencyResolver:self.resolver];
    }
 ```

5. Antes de usar o cliente, certifique-se de que o usuário tenha sido conectado interativamente pelo menos uma vez.  Você pode usar `interactiveLogon` ou `interactiveLogonWithCallback:` para iniciar a sequência de logon. Neste exercício, adicione o seguinte ao método viewDidLoad na última etapa:

 ```objective-c
 [self.resolver interactiveLogonWithCallback:^(ADAuthenticationResult *result) {
     if (result.status == AD_SUCCEEDED) {
         [self.resolver.logger logMessage:@"Connected." withLevel:LOG_LEVEL_INFO];
     } else {
         [self.resolver.logger logMessage:@"Authentication failed." withLevel:LOG_LEVEL_ERROR];
     }
 }];
 ```

6. Agora você pode usar o cliente da API com segurança.

[Using Cocoapods]: https://guides.cocoapods.org/using/using-cocoapods.html
[MSDN Add Common Consent]: https://msdn.microsoft.com/en-us/office/office365/howto/add-common-consent-manually

## Exemplos
- [O365-iOS-conexão] - Introdução e autenticação <br />
- [O365-iOS-Snippets] - solicitações e respostas da API

[O365-iOS-Connect]: https://github.com/OfficeDev/O365-iOS-Connect
[O365-iOS-Snippets]: https://github.com/OfficeDev/O365-iOS-Snippets

## Colaboração
Assine o [Contrato de Licença de Colaborador](https://cla2.msopentech.com/) antes de enviar a solicitação pull. Para concluir o Contributor License Agreement (Contrato de Licença do Colaborador), você deve enviar uma solicitação através do formulário e assinar eletronicamente o CLA quando receber o e-mail com o link para o documento. Isso só precisa ser feito uma vez em qualquer projeto da Microsoft Open Technologies OSS.

## Licença
Copyright (c) Microsoft. Todos os direitos reservados. Licenciado na licença do Apache, versão 2,0.
