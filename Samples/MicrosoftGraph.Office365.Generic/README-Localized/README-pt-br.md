---
page_type: sample
products:
- office-365
- office-outlook
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
  services:
  - Office 365
  - Outlook
  - SharePoint
  - Users
  - Groups
  createdDate: 1/1/2016 12:00:00 AM
---
# Amostra genérica de recursos do Microsoft.Graph para Office 365 #

### Resumo ###
Este é uma amostra genérica do Microsoft Graph em torno dos recursos do Office 365. Ele demonstra diferentes operações abrangendo as seguintes áreas.
- Calendário
- Contatos
- Arquivos
- Grupos unificados
- Usuários

Confira o seguinte Webcast de PnP, para obter mais detalhes e demonstração ao vivo em torno deste exemplo
-[Webcast de PnP - Webcas de Pnp -Introdução ao Microsoft Graph para desenvolvedor do Office 365](https://channel9.msdn.com/blogs/OfficeDevPnP/PnP-Web-Cast-Introduction-to-Microsoft-Graph-for-Office-365-developer)

### Aplica-se ao ###
-  Office 365 Multilocatário (MT)

### Pré-requisitos ###
Configuração de aplicativo no Azure AD - ID do Cliente e Segredo do Cliente 

### Solução ###
Solução | Autor(s)
---------|----------
OfficeDevPnP.MSGraphAPIDemo | Paolo Pialorsi

### Histórico de versão ###
Versão | Data | Comentários
---------| -----| --------
1.0 | 8 de fevereiro de 2016 | Versão inicial

### Aviso de isenção de responsabilidade ###
**ESSE CÓDIGO É FORNECIDO *NAS CIRCUNTÂNCIAS ATUAIS*SEM GARANTIA DE QUALQUER TIPO, SEJA EXPLÍCITA OU IMPLÍCITA, INCLUINDO QUAISQUER GARANTIAS IMPLÍCITAS DE ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA, COMERCIABILIDADE OU NÃO VIOLAÇÃO.**


----------

# Orientações de configuração #
Detalhes da configuração de alto nível, da seguinte forma:

- Registre a ID e o segredo do cliente no Azure Active Directory
- Configure as permissões necessárias para o aplicativo
- Configure o arquivo web.config de acordo coma as informações do aplicativo registrado 

![Detalhes da configuração no web.config](http://i.imgur.com/POSJqD7.png)

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.Generic" />