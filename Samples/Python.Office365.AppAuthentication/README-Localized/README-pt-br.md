---
page_type: sample
products:
- office-sp
- office-365
- ms-graph
languages:
- python
extensions:
  contentType: samples
  technologies:
  - Microsoft Graph
  - Azure AD
  services:
  - SharePoint
  - Office 365
  createdDate: 1/1/2016 12:00:00 AM
---
# Autenticação do aplicativo Flask do Office 365 Python #

### Resumo ###
Este cenário mostra como configurar a autenticação entre um aplicativo em Python (usando a microestrutura Flask) e um site do SharePoint Online do Office 365. O objetivo deste exemplo é mostrar como um usuário pode autenticar e interagir com os dados do site do SharePoint do Office 365.

### Aplicável a ###
- Office 365 Multilocatário (MT)
- Office 365 Dedicado (D)

### Pré-requisitos ###
- Locatário de desenvolvedor do Office 365
- Visual Studio 2015 instalado
- Ferramentas Python do Visual Studio instaladas
- Python 2.7 ou 3.4 instalado
- Flask, solicitações e pacotes Python do PyJWT instalados por pip

### Solução ###
Solução | Author(s) 
---------|---------- 
Python.Office365.AppAuthentication | Velin Georgiev (**OneBit Software**), Radi Atanassov (**OneBit Software**)

### Histórico de versão ###
Versão | Data | Comentários 
---------| -----| -------- 
1.0 | 9 de fevereiro de 2016 | Versão inicial (Velin Georgiev)

### Aviso de isenção de responsabilidade ###
**ESSE CÓDIGO É FORNECIDO *NAS CIRCUNTÂNCIAS ATUAIS* SEM GARANTIA DE QUALQUER TIPO, SEJA EXPRESSA OU IMPLÍCITA, INCLUINDO QUAISQUER GARANTIAS IMPLÍCITAS DE ADEQUAÇÃO À UMA FINALIDADE ESPECÍFICA, COMERCIABILIDADE OU NÃO VIOLAÇÃO.**

----------

# Exemplo de Autenticação do Aplicativo Python Flask do Office 365 #
Esta seção descreve o exemplo de autenticação do Aplicativo Python Flask do Office 365 na solução atual.

# Prepare o cenário para o exemplo de Autenticação do Aplicativo Python Flask do Office 365 #
O aplicativo Python Flask do Office 365 irá:

- Usar pontos de extremidade de autorização do Azure AD para executar autenticação
- Usar a API do SharePoint do Office 365 para mostrar o título do usuário autenticado

Para que essas tarefas sejam bem-sucedidas, você precisa fazer configurações adicionais abaixo. 

- Crie uma conta de avaliação do Azure com a conta do Office 365 para que o aplicativo possa ser registrado ou você possa registrá-lo no PowerShell. Um bom tutorial pode ser encontrado neste link https://github.com/OfficeDev/PnP/blob/497b0af411a75b5b6edf55e59e48c60f8b87c7b9/Samples/AzureAD.GroupMembership/readme.md.
- Registre o aplicativo no portal do Azure e atribua http://localhost:5555 à URL de entrada e URL de resposta
- Crie um segredo do cliente
- Conceda a seguinte permissão para o aplicativo Python Flask: Office 365 SharePoint Online > Permissões Delegadas > Ler Perfis de usuário

![Configuração de permissão do portal do Azure](https://lh3.googleusercontent.com/-LxhYrbik6LQ/VrnZD-0Uf0I/AAAAAAAACaQ/jsUjHDQlmd4/s732-Ic42/office365-python-app2.PNG)

- Copie o segredo do cliente e a ID do cliente do portal do Azure e substitua-os no arquivo de configuração Python Flask
- Atribua uma URL para o site do SharePoint que você vai acessar para a variável de configuração do RECURSO.

![Detalhes do aplicativo no arquivo de configuração](https://lh3.googleusercontent.com/-ETtW5MBuOcA/VrnZDQBAxQI/AAAAAAAACaY/ppp4My1JTlE/s616-Ic42/office365-python-app-config.PNG)

- Abra o arquivo de exemplo no Visual Studio 2015
- Vá para Projeto > Propriedades > Debug e atribua 5555 para o número da porta

![Alterar a porta na opção debug](https://lh3.googleusercontent.com/-M3upxeCKBN0/VrnZDSHnDoI/AAAAAAAACaA/BF4CTeKlUMs/s426-Ic42/office365-python-app-vs-config.PNG)

- Acesse ambientes Python > seu ambiente de Python ativo > execute "instalar a partir dos requirementos.txt". Isso garante que todos os pacotes necessários do Python sejam instalados.

![Seleção da opção de menu](https://lh3.googleusercontent.com/-At6Smrxg9DQ/VrnZD6KMvfI/AAAAAAAACaM/gcgJUATPigE/s479-Ic42/office365-python-packages.png)

## Execute o exemplo do aplicativo Python Flask do Office 365 ##
Ao executar o exemplo, você verá o título e a URL de login.

![Interface do Usuário do Suplemento](https://lh3.googleusercontent.com/-GDdAcmYylZE/VrnZD8sVGwI/AAAAAAAACaI/1gB0jvULLBo/s438-Ic42/office365-python-app.PNG)


Depois de clicar no link de entrada, a API do Office 365 passará pelo handshake de autenticação, e a tela do Python Flask será recarregada com o título do usuário registrado e o token de acesso exibidos:

![Entrando na Interface do Usuário](https://lh3.googleusercontent.com/-44rsAE2uGFQ/VrnZDdJAseI/AAAAAAAACaE/70N8UX8ErIk/s569-Ic42/office365-python-app-result.PNG)

<img src="https://telemetry.sharepointpnp.com/pnp/samples/Provisioning.Office365.AppAuthentication" />