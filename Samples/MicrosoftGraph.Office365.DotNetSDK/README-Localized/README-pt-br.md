---
page_type: sample
products:
- office-365
- office-sp
- ms-graph
languages:
- aspx
- csharp
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
  - Microsoft identity platform
  services:
  - Office 365
  - Microsoft identity platform
  - SharePoint
  createdDate: 1/1/2016 12:00:00 AM
---
# Exemplos relativos ao Microsoft Graph API SDK for .NET

### Resumo ###
Este é um exemplo de solução que mostra como usar o SDK de API do Microsoft Graph para
.NET. A solução inclui:
* um aplicativo de console, que usa a nova visualização MSAL
(biblioteca de autenticação da Microsoft) para autenticar o novo ponto de extremidade de autenticação v2,
* Um aplicativo web ASP.NET MVC, que utiliza ADAL
(Biblioteca de autenticação Azure Active Directory) para autenticar o ponto de extremidade do Azure AD.

Este exemplo faz parte dos exemplos de código relacionados ao livro ["Programming Microsoft Office 365"](https://www.microsoftpressstore.com/store/programming-microsoft-office-365-includes-current-book-9781509300914) escrito por [Paolo Pialorsi](https://twitter.com/PaoloPia) e publicado pela Microsoft Press.

### Aplicável a ###
-  Microsoft Office 365

### Solução ###
Solução | Autor (s) | Twitter
---------|-----------|--------
MicrosoftGraph. Office365. DotNetSDK.sln | Paolo Pialorsi (PiaSys.com) | [@PaoloPia](https://twitter.com/PaoloPia)

### Histórico de versão ###
Versão | Data | Comentários
---------| -----| --------
1.0 | 12 de maio de 2016 | Lançamento inicial

### Instruções de configuração ###
Para trabalhar com este exemplo, você precisa:

-  Inscreva-se para uma assinatura de desenvolvedor do Office 365 [Office Dev Center](http://dev.office.com/), se você não tiver uma
-  Registre o aplicativo Web no [Azure AD](https://manage.windowsazure.com/) para obter um ClientID e um Segredo do Cliente 
-  Configure a aplicação Azure AD com as seguintes permissões delegadas para Microsoft Graph: Exibir o perfil básico do usuário, Exibir o endereço de email dos usuários
-  Atualize o arquivo web.config do aplicativo web com as configurações adequadas (ClientID, ClientSecret, domínio, Tenantid)
-  Registre o aplicativo de console para o ponto de extremidade de autenticação V2 no novo [Portal de Registro de Aplicativo](https://apps.dev.microsoft.com/) 
-  Configurar o arquivo .config do aplicativo de console com as configurações adequadas (MSAL_ClientID)

 
<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.DotNetSDK" />