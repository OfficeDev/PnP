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
# Office 365 機能用の Microsoft.Graph の汎用サンプル #

### 概要 ###
これは、Office 365 の機能に関する Microsoft Graph の汎用サンプルです。次の領域にわたるさまざまな操作をデモンストレーションします。
- カレンダー
- 連絡先
- ファイ
- 統合グループ
- ユーザー

詳細については、次の PnP Web キャストをご覧ください。このサンプルに関するライブ デモ
- [PnP Web キャスト - PnP Web キャスト - Office 365 開発者向けの Microsoft Graph の概要](https://channel9.msdn.com/blogs/OfficeDevPnP/PnP-Web-Cast-Introduction-to-Microsoft-Graph-for-Office-365-developer)

### 適用対象 ###
-  Office 365 マルチテナント (MT)

### 前提条件 ###
Azure AD でのアプリケーション構成 - クライアント ID とクライアント シークレット

### ソリューション ###
ソリューション |作成者
---------|----------
OfficeDevPnP.MSGraphAPIDemo | Paolo Pialorsi

### バージョン履歴 ###
バージョン | 日付 | コメント
---------| -----| --------
1.0 | 2016 年 2 月 8 日 | 初期リリース

### 免責事項 ###
**このコードは、明示または黙示のいかなる種類の保証なしに*現状のまま*提供されるものであり、特定目的への適合性、商品性、権利侵害の不存在についての暗黙的な保証は一切ありません。**


----------

# セットアップ ガイダンス #
高レベルの構成の詳細は次のとおりです。

- クライアント ID とシークレットを Azure Active Directory に登録する
- アプリケーションに必要なアクセス許可を構成する
- 登録済みアプリの情報に応じて web.config ファイルを構成する 

![web.config のセットアップの詳細](http://i.imgur.com/POSJqD7.png)

<img src="https://telemetry.sharepointpnp.com/pnp/samples/MicrosoftGraph.Office365.Generic" />