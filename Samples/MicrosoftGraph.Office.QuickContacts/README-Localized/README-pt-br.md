---
page_type: sample
products:
- office-outlook
- office-365
- office-sp
- ms-graph
languages:
- javascript
- nodejs
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
  services:
  - Outlook
  - Office 365
  - SharePoint
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Mobile
---
# Microsoft Graph - contatos rápidos

### Resumo

Este exemplo mostra como usar o Microsoft Graph para localizar contatos rapidamente em dispositivos móveis.

![Captura de tela](assets/search-results.png)

### Aplicável a

- Office 365 Multilocatário (MT)

### Pré-requisitos

- Locatário do Office 365
- Configuração de aplicativos no Azure Active Directory (AAD)
    - Permissões
        - Office 365 SharePoint Online
            - Executar consultas de pesquisa como usuário
        - Microsoft Graph
            - Ler listas de pessoas relevantes dos usuários (visualização)
            - Acessar o diretório como o usuário conectado
            - Ler os perfis básicos de todos usuários
        - Microsoft Azure Active Directory
            - Entrar e ler o perfil do usuário
    - Fluxo do OAuth implícito habilitado
    
### Solução

Solução|Autor(s)
--------|---------
MicrosoftGraph.Office.QuickContacts|Waldek Mastykarz (MVP, Rencore, @waldekm), Stefan Bauer (n8d, @StfBauer)

### Histórico de versão

Versão|Data|Comentários
-------|----|--------
1.0 |24 de março de 2016|Versão inicial

### Isenção de responsabilidade
**ESSE CÓDIGO É FORNECIDO *NAS CIRCUNTÂNCIAS ATUAIS*SEM GARANTIA DE QUALQUER TIPO, SEJA EXPLÍCITA OU IMPLÍCITA, INCLUINDO QUAISQUER GARANTIAS IMPLÍCITAS DE ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA, COMERCIABILIDADE OU NÃO VIOLAÇÃO.**

---

## Contatos rápidos do Outlook

Este é um aplicativo de exemplo que ilustra como você pode aproveitar o Microsoft Graph para localizar rapidamente contatos relevantes usando seu telefone celular.

![Contatos encontrados mostrados no aplicativo contatos rápidos do Office](assets/search-results.png)

Usando a nova API de pessoas, o aplicativo permite que você encontre contatos, incluindo suas informações de contato.

![Exibição de ações rápidas em um contato](assets/quick-actions.png)

Como a nova API de pessoas usa a pesquisa fonética, não importa o nome da pessoa que você está procurando corretamente.

![Resultados da pesquisa para o nome do contato digitado incorretamente](assets/typo.png)

Ao tocar em um contato, você pode obter acesso a outras informações e, se o contato for da sua organização, obterá um link direto para seus emails.

![Cartão de visita aberto no aplicativo](assets/person-card.png)

## Pré-requisitos

Para que você possa iniciar esse aplicativo, há algumas etapas de configuração que você precisa concluir.

### ID do Aplicativo do Azure AD:

Esse aplicativo usa o Microsoft Graph para pesquisar por contatos relevantes. Para que ele possa acessar o Microsoft Graph, é necessário ter um aplicativo do Azure Active Directory correspondente configurado no Azure Active Directory. Veja a seguir as etapas para criar e configurar corretamente o aplicativo no AAD. 

- Crie aplicativo novo da Web no Active Directory do Azure.
- Defina o **URL de Logon** para `https://localhost:8443`
- Copie a **ID de cliente **, precisamos ainda mais para configurar o aplicativo
- no **URL de resposta** adicionar `https://localhost:8443`. Caso pretenda testar o aplicativo em seu dispositivo móvel, você também precisará adicionar o **URL de** externo exibida pela browserify depois de iniciar o aplicativo usando `$ gulp serve`
- conceda ao aplicativo as seguintes permissões:
    - Office 365 SharePoint Online
        - Executar consultas de pesquisa como usuário
    - Microsoft Graph
        - Ler listas de pessoas relevantes dos usuários (visualização)
        - Acessar o diretório como o usuário conectado
        - Ler os perfis básicos de todos usuários
    - Microsoft Azure Active Directory
        - Entrar e ler o perfil do usuário
- habilitar o fluxo implícito OAuth

### Configure o aplicativo

Para que o aplicativo possa ser iniciado, ele precisa estar vinculado ao aplicativo recém-criado do Azure Active Directory e a um locatário do SharePoint. As duas configurações podem ser configuradas no arquivo `app/app.config.js`.

- clonar este repositório
- como o valor da constante **appId** definir o de **ID do cliente** copiado anteriormente do aplicativo AAD recém-criado
- como o valor da constante **sharePointUrl** defina a URL do seu locatário do SharePoint sem a barra à direita, ou seja, `https://contoso.sharepoint.com`

## Executar o aplicativo

Execute as etapas a seguir para iniciar o aplicativo:

- na linha de comando, execute
```
$ npm i && bower i
```
- na linha de comando, execute
```
$ gulp serve
```
para iniciar o aplicativo

![Aplicativo iniciado no navegador](assets/app.png) 

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office.QuickContacts" />