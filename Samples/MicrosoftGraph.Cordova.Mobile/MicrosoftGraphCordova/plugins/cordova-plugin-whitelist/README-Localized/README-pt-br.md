<!--
# license: Licensed to the Apache Software Foundation (ASF) under one
#         or more contributor license agreements.  See the NOTICE file
#         distributed with this work for additional information
#         regarding copyright ownership.  The ASF licenses this file
#         to you under the Apache License, Version 2.0 (the
#         "License"); you may not use this file except in compliance
#         with the License.  You may obtain a copy of the License at
#
#           http://www.apache.org/licenses/LICENSE-2.0
#
#         Unless required by applicable law or agreed to in writing,
#         software distributed under the License is distributed on an
#         "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
#         KIND, either express or implied.  See the License for the
#         specific language governing permissions and limitations
#         under the License.
-->

# lista-de-permissões-do-plug-in-cordova

Este plug-in implementa uma política de lista de permissões para navegar pelo aplicativo WebView no Cordova 4.0

:aviso: Relatar problemas no [Rastreador de problemas do Apache Cordova](https://issues.apache.org/jira/issues/?jql=project%20%3D%20CB%20AND%20status%20in%20%28Open%2C%20%22In%20Progress%22%2C%20Reopened%29%20AND%20resolution%20%3D%20Unresolved%20AND%20component%20%3D%20%22Plugin%20Whitelist%22%20ORDER%20BY%20priority%20DESC%2C%20summary%20ASC%2C%20updatedDate%20DESC)


## Plataformas compatíveis com o Cordova

* Android 4.0.0 ou posterior

## Lista de permissões de navegação
Controla quais URLs o próprio WebView pode acessar.
Aplica-se somente a navegação de nível superior.

Quirks: no Android ele também se aplica ao iFrames para esquemas não http(s).

Por padrão, são permitidos navegações apenas para URLs `file://`. Para permitir outras URLs, você deve adicionar as marcas `<allow-navigation>` ao `config.xml`:

    <!-- Permitir links para example.com –>
    <permitir-navegação href="http://example.com/*" />

    <!-- Curingas são permitidos para o protocolo, como um prefixo
         ao host ou como um sufixo ao caminho -->
    <permitir-navegação href="*://*.example.com/*" />

    <!-- Um curinga pode ser usado para listar toda a rede,
         sobre HTTP e HTTPS.
         *NÃO RECOMENDADO* -->
    <permitir-navegação href="*" />

    <!-- A acima é equivalente a essas três declarações -->
    <permitir-navegação href="http://*/*" />
    <permitir-navegação href="https://*/*" />
    <permitir-navegação href="data:*" />

## Lista de desbloqueio de intenções
Controla quais URLs o aplicativo tem permissão para abrir no sistema.
Por padrão, não são permitidas URLs externas.

No Android, isso equivale a enviar uma intenção de tipo NAVEGÁVEL.

Esta lista de permissões não se aplica aos plug-ins, somente hiperlinks e chamadas para `window.open()`.

Em`config.xml`, adicione as marcas `<allow-intent>` assim:

    <!-- Permitir que os links de páginas da Web sejam abertos em um navegador -->
    <permitir-intenção href="http://*/*" />
    <permitir-intenção href="https://*/*" />

    <!-- Permitir que os links example.com sejam abertos em um navegador -->
    <permitir-intenção href="http://example.com/*" />

    <!-- Curingas são permitidos para o protocolo, como um prefixo
         ao host ou como um sufixo ao caminho -->
    <permitir-intenção href="*://*.example.com/*" />

    <!-- Permitir que links SMS abram o aplicativo de mensagens -->
    <permitir-intenção href="SMS:*" />

    <!-- Permitir que tel: links abram o discador -->
    <permitir-intenção href="tel:*" />

    <!-- Permitir geo: links para abrir mapas –>
    <permitir-intenção href="geo:*" />

    <!-- Permitir que todas as URLs não reconhecidas abram aplicativos instalados
         *NÃO RECOMENDADO* -->
    <permitir-intenção href="*" />

## Lista de permissões de solicitações de rede
Controla quais solicitações de rede (imagens, XHRs, etc.) podem ser feitas (por meio de ganchos nativos do Cordova).

Observação: Sugerimos que você use uma Política de segurança de conteúdo (veja abaixo), que é mais segura. Esta lista de permissões é histórica para visualizações na web que não oferecem suporte a CSP.

Em`config.xml`, adicione as marcas `<access>` assim:

    <!-- Permitir imagens, xhrs, etc., ao google.com –>
    <acessar origem="http://google.com" />
    <acessar origem="https://google.com" />

    <!-- Acesso ao subdomínio maps.google.com –>
    <acessar origem="http://maps.google.com" />

    <!-- Acesso a todos os subdomínios na google.com –>
    <acessar origem="http://*.google.com" />

    <!-- Habilitar solicitações de conteúdo: URLs -->
    <acessar origem="content:///*" />

    <!-- Não bloquear nenhuma solicitação -->
    <acessar origem="*" />

Sem nenhuma marca `<access>`, só serão permitidas solicitações para URLs `file://`. No entanto, o aplicativo padrão do Cordova inclui `<access origin="*">` por padrão.

Quirk: o Android também permite solicitações para https://ssl.gstatic.com/accessibility/javascript/android/ por padrão, pois isso é necessário para que o Talkback funcione corretamente.

### Política de segurança de conteúdo
Controla quais solicitações de rede (imagens, XHRs, etc.) podem ser feitas (diretamente por meio de visualizações da web).

No Android e iOS, a lista de permissões de solicitação de rede (veja acima) não consegue filtrar todos os tipos de solicitações (por exemplo `<video>` e WebSockets não são bloqueados). Portanto, além da lista de permissões, você deve usar uma marca `<meta>` de [política de segurança de conteúdo](http://content-security-policy.com/) em todas as suas páginas.

No Android, o suporte ao CSP na visualização da web do sistema começa com o KitKat (mas está disponível em todas as versões usando o Crosswalk WebView).

Aqui estão alguns exemplos de declarações de CSP para páginas `.html`:

    <!-- Boa declaração padrão:
        * intervalo: só é necessário no iOS (ao usar UIWebView) e é necessário para o JS->comunicação nativa
        * https://ssl.gstatic.com só é necessário para o Android e é necessário para que o Talkback funcione corretamente
        * Desativar o uso de eval() e scripts embutidos para reduzir o risco de vulnerabilidades do XSS. Para alterar isso:
            * Habilitar o JS embutido: adicionar 'unsafe-inline' ao default-src
            * Habilitar eval(): adicionar 'unsafe-eval' ao default-src
    -->
    <meta http-equiv="Política de segurança de conteúdo" content="default-src 'self' data: gap: https://ssl.gstatic.com; style-src 'self' 'unsafe-inline'; media-src *">

    <!-- Permite tudo, mas somente da mesma origem e foo.com -->
    <meta http-equiv="Política de segurança de conteúdo" conteúdo="default-src 'self' foo.com">

    <!-- Essa política permite tudo (por exemplo, CSS, AJAX, objeto, quadro, mídia etc.), exceto no caso de 
        * CSS apenas dos mesmos estilos embutidos e de origem,
        * scripts apenas dos mesmos estilos embutidos e de origem e eval()
    -->
    <meta http-equiv="Política de segurança de conteúdo" content="default-src *; style-src 'self' 'unsafe-inline'; script-src 'self' 'unsafe-inline' 'unsafe-eval'">

    <!-- Só permite XHRs por meio de HTTPS no mesmo domínio. -->
    <meta http-equiv="Política de segurança de conteúdo" content="default-src 'self' https:">

    <!-- Permitir iframe ao https://cordova.apache.org/ -->
    <meta http-equiv="Política de segurança de conteúdo" conteúdo="default-src 'self'; frame-src 'self' https://cordova.apache.org">
