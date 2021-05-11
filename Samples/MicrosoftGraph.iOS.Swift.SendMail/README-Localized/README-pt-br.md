---
page_type: sample
products:
- office-365
- office-excel
- office-planner
- office-teams
- office-outlook
- office-onedrive
- office-sp
- office-onenote
- ms-graph
languages:
- swift
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  services:
  - Office 365
  - Excel
  - Planner
  - Microsoft Teams
  - Outlook
  - OneDrive
  - SharePoint
  - OneNote
  platforms:
  - iOS
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Mobile
---
# SDK do Microsoft Graph para iOS usando o Swift #

### Resumo ###
Caso ainda não tenha ouvido, há uma maneira fácil de chamar uma grande quantidade de APIs da Microsoft usando um único ponto de extremidade. Esse ponto de extremidade, chamado de Microsoft Graph (<https://graph.microsoft.io/>), permite que você acesse todos os dados, de inteligência a informações, usando a nuvem da Microsoft.

Não será mais necessário controlar os diferentes pontos de extremidade e tokens separados nas suas soluções, e isso não é ótimo? Esta postagem é uma parte da introdução ao Microsoft Graph. Para alterações no Microsoft Graph, vá para: <https://graph.microsoft.io/changelog>

Este exemplo demonstra o SDK do Microsoft Graph para iOS (<https://github.com/OfficeDev/Microsoft-Graph-SDK-iOS>) em um aplicativo iOS simples usando a linguagem Swift (<https://developer.apple.com/swift/>). No aplicativo, enviaremos um email para nós mesmos. O objetivo é se familiarizar com o Microsoft Graph e suas possibilidades.

![IU do aplicativo no iPhone e no email](http://simonjaeger.com/wp-content/uploads/2016/03/app.png)

Lembre-se de que o SDK do Microsoft Graph para iOS ainda está em versão prévia. Leia mais sobre as condições em: https://github.com/OfficeDev/Microsoft-Graph-SDK-iOS

Leia mais sobre este exemplo em: <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/>

### Aplicável a ###
-  Exchange Online
-  Office 365
-  Hotmail.com
-  Live.com
-  MSN.com
-  Outlook.com
-  Passport.com

### Pré-requisitos ###
Será necessário registrar o aplicativo para poder fazer chamadas para o Microsoft Graph. Saiba mais em: <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/#step-11-register-the-application-in-azure-ad>

Se você estiver criando algo para o Office 365 e não tiver um locatário do Office 365, adquira uma conta de desenvolvedor em: <http://dev.office.com/devprogram>

Será necessário instalar o Xcode no computador a fim de executar o exemplo. Obtenha o Xcode em: <https://developer.apple.com/xcode/>

### Projeto ###
Projeto | Autor(es)
---------|----------
MSGraph.MailClient | Simon Jäger (**Microsoft**)

### Histórico de versão ###
Versão | Data | Comentários
---------| -----| --------
1.0 | 09 de março de 2016 | Lançamento inicial

### Aviso de isenção de responsabilidade ###
**ESSE CÓDIGO É FORNECIDO *NAS CIRCUNTÂNCIAS ATUAIS*SEM GARANTIA DE QUALQUER TIPO, SEJA EXPLÍCITA OU IMPLÍCITA, INCLUINDO QUAISQUER GARANTIAS IMPLÍCITAS DE ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA, COMERCIABILIDADE OU NÃO VIOLAÇÃO.**

----------

# Como usar? #

A primeira etapa é registrar seu aplicativo em seu locatário do Azure AD (associado ao seu locatário do Office 365). Encontre mais detalhes sobre como registrar seu aplicativo no locatário do Azure AD aqui: <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/#step-11-register-the-application-in-azure-ad>

Como o aplicativo está chamando o Microsoft Graph de volta e envia um email em nome do usuário conectado, é importante conceder a ele permissões para o envio de emails.

Depois de registrar o aplicativo no inquilino do Azure AD, você precisará definir as configurações a seguir no arquivo **adal_settings.plist**:
    
```xml
<plist version="1.0">
<dict>
	<key>ClientId</key>
	<string>[YOUR CLIENT ID]</string>
	<key>ResourceId</key>
	<string>https://graph.microsoft.com/</string>
	<key>RedirectUri</key>
	<string>[YOUR REDIRECT URI]</string>
	<key>AuthorityUrl</key>
	<string>[YOUR AUTHORITY]</string>
</dict>
</plist>
```

Inicie o arquivo do espaço de trabalho (**MSGraph.MailClient.xcworkspace**) no Xcode. Execute o projeto usando o atalho **⌘R** ou pressionando o botão **Executar** no menu **Produto**.
    
# Arquivos de código-fonte #
Os principais arquivos de código-fonte neste projeto são os seguintes:

- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\MailClient.swift` – essa classe cuida da entrada do usuário, da obtenção do perfil de usuário e, por fim, do envio do email com uma mensagem.
- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\ViewController.swift` – esse é o controlador de modo de exibição individual do aplicativo iOS, que aciona o MailClient.
- `MicrosoftGraph.iOS.Swift.SendMail\MSGraph.MailClient\adal_settings.plist` – esse é o arquivo da lista de propriedades de configuração do ADAL. Certifique-se de definir as configurações necessárias neste arquivo antes de executar este exemplo.

# Mais recursos #
- Descubra o desenvolvimento do Office em: <https://msdn.microsoft.com/en-us/office/>
- Introdução ao Microsoft Azure em: <https://azure.microsoft.com/en-us/>
- Explore o Microsoft Graph e suas operações em: <http://graph.microsoft.io/en-us/> 
- Leia mais sobre este exemplo em: <http://simonjaeger.com/get-going-swiftly-with-the-microsoft-sdk-for-ios/>


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.iOS.Swift.SendMail" />