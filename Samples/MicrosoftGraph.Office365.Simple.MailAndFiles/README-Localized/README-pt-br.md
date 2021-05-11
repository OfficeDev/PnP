---
page_type: sample
products:
- office-outlook
- office-onedrive
- office-sp
- office-365
- ms-graph
languages:
- aspx
- csharp
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Office UI Fabric
  - Azure AD
  services:
  - Outlook
  - OneDrive
  - SharePoint
  - Office 365
  createdDate: 1/1/2016 12:00:00 AM
---
# Microsoft Graph – Consultar arquivos pessoais e emails #

### Resumo ###
Este é um aplicativo simples em ASP.net MVC para consultar emails e arquivos pessoais usando o Microsoft Graph, mostrando também consultas dinâmicas das informações com consultas ajax. A amostra também usa o Office UI Fabric para fornecer uma experiência de interface do usuário consistente com controles e apresentação padronizados.

### Aplica-se ao ###
-  Office 365 Multilocatário (MT)

### Pré-requisitos ###
Configuração do aplicativo no Azure AD

### Solução ###
Solução | Autor(es)
---------|----------
Office365Api.Graph.Simples.MailAndFiles | Vesa Juvonen

### Histórico de versão ###
Versão | Data | Comentários
---------| -----| --------
1.0 | 5 de fevereiro de 2016 | Lançamento inicial

### Aviso de isenção de responsabilidade ###
**ESSE CÓDIGO É FORNECIDO *COMO ESTÁ* SEM GARANTIA DE QUALQUER TIPO, SEJA EXPLÍCITA OU IMPLÍCITA, INCLUINDO QUAISQUER GARANTIAS IMPLÍCITAS DE ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA, COMERCIABILIDADE OU NÃO VIOLAÇÃO.**

----------

# Introdução #
Esta amostra é a demonstração da conectividade simplista do Microsoft Graph para mostrar emails e arquivos de um usuário específico. A interface do usuário atualizará automaticamente as diferentes partes da interface do usuário, se houver novos itens chegando na caixa de entrada do email ou adicionados ao site do OneDrive for Business do usuário.

![Interface do Usuário do Aplicativo](http://i.imgur.com/Rt4d8Py.png)

# Configuração do Active Directory do Azure #
Antes que este exemplo possa ser executado, você precisará registrar o aplicativo no Azure AD e fornecer as permissões necessárias para que as consultas do Graph funcionem. Criaremos uma entrada do aplicativo no Azure Active Directory e configuraremos as permissões necessárias.

- Abra a interface do usuário do Portal do Azure e vá para as Interfaces do Usuário do Active Directory - no momento da redação, isso está disponível apenas nas Interfaces do Usuário do portal antigo.
- Migrar para a seleção **aplicativos**
- Clique em **Adicionar** para iniciar a criação de um novo aplicativo
- Clique em **Adicionar aplicativo que minha organização está desenvolvendo**

![O que você deseja fazer na Interface do Usuário no Azure AD](http://i.imgur.com/dNtLtnl.png)

- Forneça um **nome** ao seu aplicativo e selecione **Aplicativo Web e API da Web** como o tipo

![Adicionar Interface do Usuário do aplicativo](http://i.imgur.com/BrxalG7.png)

- Atualizar as propriedades do aplicativo da seguinte forma para depuração
	- **URL ** – https://localhost:44301/
	- **URL do ID do aplicativo** - URI válido como http://pnpemailfiles.contoso.local - este é apenas um identificador, portanto, não precisa ser uma URL válida real

![Detalhes da Interface do Usuário do Aplicativo](http://i.imgur.com/1IaNxLm.png)

- Mover para **configurar** a página e seção ao redor das teclas
- Selecione 1 ou 2 anos de duração para o segredo gerado

![Configuração do ciclo de vida do segredo](http://i.imgur.com/7kX396J.png)

- Clique em **Salvar** e copie o segredo gerado para uso futuro da página - observe que o segredo está visível APENAS durante esse período, portanto, você precisará protegê-lo em outro local.

![Segredo do Cliente](http://i.imgur.com/5vnkkTA.png)

- Role para baixo para a configuração de permissão

![Permissões para outros aplicativos](http://i.imgur.com/tF4R75w.png)

- Selecione Office 365 Exchange Online e Office 365 SharePoint Online como os aplicativos aos quais você deseja atribuir permissões

![Atribuição de permissão](http://i.imgur.com/XGOba3Y.png)

- Conceder permissão "**Ler email do usuário**" em permissões do Exchange Online

![Seleção de permissões necessárias para o Exchange](http://i.imgur.com/CyH9gg2.png)

- Conceder permissão "**Ler arquivos do usuário**" nas permissões do SharePoint Online

![Seleção de permissões necessárias para o SharePoint](http://i.imgur.com/NSZiHsh.png)

- Clique em **Salvar** 

Agora você concluiu a configuração necessária na parte do Azure Active Directory. Observe que você ainda precisará configurar a ID e o segredo do cliente no arquivo web.config no projeto. Atualize as chaves de ID do cliente e ClientSecret corretamente.

![Configuração do web.config](http://i.imgur.com/pihBvR5.png)

# Executar a solução #
Sempre que você configurou o lado do Azure AD e atualizou o web.config com base em seus valores ambientais, você pode executar a amostra corretamente.

- Pressione F5 no Visual Studio
- Clique em **Conectar-se ao Office 365** ou **Entrar** na barra do pacote, que mostrará a interface do usuário concentrada do AAD para entrar no Azure AD certo

![Interface do Usuário do Aplicativo](http://i.imgur.com/YMCrG4O.png)

- Entre com as credenciais corretas do Azure Active Directory no aplicativo

![Entrar no Azure AD - IU de consentimento](http://i.imgur.com/gNz5Wgz.png)

- Você verá a Interface do Usuário do aplicativo

![Interface do Usuário do aplicativo com seus dados pessoais](http://i.imgur.com/Rt4d8Py.png)


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.Simple.MailAndFiles" />