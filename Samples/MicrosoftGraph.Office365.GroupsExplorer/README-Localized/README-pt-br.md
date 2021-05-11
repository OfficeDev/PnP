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
  services:
  - Office 365
  - Groups
  - SharePoint
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Connect
---
# API do Office 365 - Explorador de Grupos#

### Resumo ###
O aplicativo web complementar lista todos os grupos existentes no locatário do usuário, juntamente com todas as propriedades.

### Aplicável a ###
-  Office 365 Multilocatário (MT)

### Pré-requisitos ###
Este exemplo requer a versão da API do Office 365 lançada em novembro de 2014. Visite http://msdn.microsoft.com/en-us/office/office365/howto/platform-development-overview para obter mais detalhes.

### Solução ###
Solução | Autor (es
---------|----------
Office365Api. Groups | Paulo Schaeflein (Schaeflein Consulting, @paulschaeflein)

### Histórico de versão ###
Versão | Data | Comentários
---------| -----| --------
1.0 | 8 de fevereiro de 2016 | Versão inicial

### Aviso de isenção de responsabilidade ###
**ESSE CÓDIGO É FORNECIDO *NAS CIRCUNTÂNCIAS ATUAIS*SEM GARANTIA DE QUALQUER TIPO, SEJA EXPLÍCITA OU IMPLÍCITA, INCLUINDO QUAISQUER GARANTIAS IMPLÍCITAS DE ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA, COMERCIABILIDADE OU NÃO VIOLAÇÃO.**


----------

# Explorando a API de grupos do Office 365 #
Esse exemplo é oferecido para auxiliar a revisão das propriedades e relacionamentos de grupos do Office 365.
É possível encontrar mais informações no blog em http://www.schaeflein.net/exploring-the-office-365-groups-api/.



# O exemplo do ASP.NET MVC #
Esta seção descreve o exemplo do ASP.NET MVC incluído na solução atual.

## Prepare o cenário para o exemplo ASP.NET MVC ##
O aplicativo de exemplo ASP.NET MVC usará a nova API do Microsoft Graph para executar a lista de tarefas a seguir:

-  Ler a lista de grupos no diretório do usuário atual
-  Leia as conversas, os eventos e os arquivos em grupos "unificados"
-  Listar os grupos aos quais o usuário atual entrou

Para executar o aplicativo Web, você precisará registrá-lo em seu inquilino de desenvolvimento do Azure AD.
O aplicativo web usa OWIN e OpenId Connect para se autenticar no Azure AD que está coberto por seu inquilino do Office 365.
Você pode encontrar mais detalhes sobre OWIN e OpenId Connect, bem como sobre o cadastro do seu aplicativo no inquilino do Azure AD: http://www.cloudidentity.com/blog/2014/07/28/protecting-an-mvc4-vs2012-project-with-openid-connect-and-azure-ad/ 

Depois de registrar o aplicativo no inquilino do Azure AD, você precisará definir as configurações a seguir no arquivo web.config:

		<adicionar tecla = "ida: ClientId" valor = "[Seu ClientID aqui]" />
		<adicionar tecla = "ida: ClientSecret" valor = "[Seu ClientSecret aqui]" />
		<adicionar tecla="ida:TenantId" valor="[Seu TenantId aqui]" />
		<adicionar tecla="ida:Domain" valor="seu_domain.onmicrosoft.com" />

# Cobertura do exemplo #
O aplicativo é codificado no ponto de extremidade beta da API do Graph. A classe GroupsController especifica a URL para cada chamada:

```
string apiUrl = String.Format("{0}/beta/myorganization/groups/{1}/conversations/{2}/threads", 
                              SettingsHelper.MSGraphResourceId, 
                              id, itemId);
```

A interface do usuário usa o Office UI Fabric (http://dev.office.com/fabric). Há algumas exibições de DisplayTemplate personalizadas que manipulam o estilo necessário da CSS da malha.

## Créditos ##
Os multilocatários com ASP.NET MVC e OpenID Connect são fornecidos graças ao projeto GitHub disponível aqui:
https://github.com/Azure-Samples/active-directory-dotnet-webapp-multitenant-openidconnect

Créditos para https://github.com/dstrockis e https://github.com/vibronet.

O estilo da interface de usuário do Office Fabric foi auxiliado por essa postagem de blog: http://chakkaradeep.com/index.php/using-office-ui-fabric-in-sharepoint-add-ins/

Crédito para https://github.com/chakkaradeep

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.GroupsExplorer" />