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
- javascript
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
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
  - REST API
  createdDate: 1/1/2016 12:00:00 AM
  scenarios:
  - Mobile
---
# Exemplo usando o Microsoft Graph com Plug-in do Apache Cordova e ADAL Cordova  #

### Visão Geral ###
Este exemplo demonstra como usar a API do Microsoft Graph para recuperar dados do Office 365 usando a API REST e OData.
O exemplo é intencionalmente simples e não usa estruturas SPA, biblioteca de associação de dados, jQuery etc.
Ele não tem o objetivo de demonstrar um aplicativo móvel com recursos completos.
É possível focar várias plataformas do Windows,
bem como Android e iOS,
usando o mesmo código JavaScript.

O token de acesso é obtido usando o plug-in ADAL do Cordova.
Esse é um dos principais plug-ins do Visual Studio e está disponível no editor config.xml.
Essa é uma alternativa ao assistente para Adicionar Serviço Conectado que gera vários arquivos de JavaScript,
incluindo uma biblioteca (o365auth.js) que pode ser usada para obter tokens usando um navegador no aplicativo para gerenciar o redirecionamento do usuário para o ponto de extremidade de autorização.
Em vez disso, o plug-in ADAL
do Cordova usa as bibliotecas do ADAL nativo
para cada plataforma e pode aproveitar os recursos nativos,
como o cache de tokens e os navegadores aprimorados.

### Aplicável a ###
-  Office 365 Multilocatário (MT)
-  Microsoft Graph

### Pré-requisitos ###
- Ferramentas do Visual Studio para Apache Cordova (opção de configuração do VS-TACO)
- Plug-in ADAL do Cordova (Cordova-plug-in-MS-Adal)

### Solução ###
Solução | Autor (s)
---------|----------
celular. MicrosoftGraphCordova | Bill Ayers (@SPDoctor, spdoctor.com, flosim.com)

### Histórico de versão ###
Versão | Data | Comentários
---------| -----| --------
1.0 | 15 de março de 2016 | Lançamento inicial

### Aviso de isenção de responsabilidade ###
**ESSE CÓDIGO É FORNECIDO *NAS CIRCUNTÂNCIAS ATUAIS*SEM GARANTIA DE QUALQUER TIPO, SEJA EXPLÍCITA OU IMPLÍCITA, INCLUINDO QUAISQUER GARANTIAS IMPLÍCITAS DE ADEQUAÇÃO A UMA FINALIDADE ESPECÍFICA, COMERCIABILIDADE OU NÃO VIOLAÇÃO.**


----------

### Execução do Exemplo ###

Quando o exemplo for executado, você poderá clicar no botão "Carregar Dados".
Se essa for a primeira vez que você o executa, você será instruído a autorizar o aplicativo.
Esta é a mensagem de logon conhecida do Office 365. Como estamos usando o Microsoft Graph,
também é possível usar uma "conta da Microsoft"
(por exemplo, live.com ou uma conta do Hotmail). 

Se você inseriu o nome do locatário do Office 365,
ele funcionará nessa conta. Se você deixar o locatário em branco,
o ponto de extremidade "comum" será usado e o locatário real usado será determinado a partir das
credenciais de usuário usadas para autenticação com o ponto de extremidade de autorização.

Você pode inserir uma consulta válida na caixa de entrada (embora nem todas sejam analisadas sem modificação de código).
Como alternativa, você pode selecionar a partir da caixa suspensa
e selecionar uma consulta criada anteriormente.

![Executando o no Windows 10](MicrosoftGraphCordova.png)

Depois de obter um token, ele será analisado e exibido apenas para fins de demonstração.
O token não é criptografado (por isso, a necessidade de segurança da camada de transporte, como SSL),
mas deve ser tratado como opaco. Ou seja, não escreva um código que se baseie nas informações contidas no token.
Ao invés disso use as APIs.

Usando o token de acesso, a solicitação REST é feita à API do Microsoft Graph e os dados são exibidos.
Você pode observar um atraso entre o token sendo recebido e os dados que retornam do ponto de extremidade do REST.
Observe que a biblioteca ADAL também pode ser usada para obter tokens para os pontos de extremidade do Office 365,
mas, no código de exemplo,
o escopo foi definido como Microsoft Graph.

Você pode ver que o token de acesso tem uma duração de cerca de uma hora.
Você pode continuar a fazer mais solicitações usando o token até que ele expire sem avisos posteriores.
Isso funcionará, mesmo que você feche o aplicativo e o inicie novamente porque o token é armazenado em cache.
Após uma hora, o token vai expirar e o token de atualização será usado para obter um novo token de acesso.
Isso também resultará em um novo token de atualização, e esse processo poderá ser repetido por vários meses,
desde que o token de atualização,
que também é armazenado em cache, não expire.

Se você clicar no botão "limpar cache", o cache de token será apagado.
Na próxima vez que você clicar em carregar dados, receberá um aviso de autorização. 

### Nos bastidores. ###

Todo o gerenciamento do cache (que é dependente de plataformas),
a negociação de tokens de acesso expirados e o uso do token de atualização,
é manipulado pelas bibliotecas do ADAL. Basta obter um contexto de autenticação e acompanhar o padrão atual recomendado,
que é chamar acquireTokenSilentAsync primeiro. Se não for possível obter um token silenciosamente (ou seja, no cache ou usando um token de atualização),
o retorno de chamada "falha"e,
em seguida, invoca a acquireTokenAsync,
que tem o comportamento do pedido definido como "sempre".

```javascript

    context.acquireTokenSilentAsync(resourceUrl, appId).then(success, function () {
      context.acquireTokenAsync(resourceUrl, appId, redirectUrl).then(success, fail);
    });

```

Embora a documentação atual e algumas das bibliotecas de ADAL tenham acquireTokenAsync com o comportamento de solicitação definido como "automático",
o que significa que o usuário só solicite o design do plug-in do Cordova,
isso significa que o acquireTokenAsync sempre avisará. 

Observação: Compreendo que o restante das bibliotecas de ADAL adotará esse padrão daqui em diante. 


<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Cordova.Mobile" />