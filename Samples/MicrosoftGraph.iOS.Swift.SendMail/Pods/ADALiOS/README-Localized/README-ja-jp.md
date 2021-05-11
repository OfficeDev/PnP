#iOS および OSX 用 Azure Active Directory 認証ライブラリ (ADAL)
=====================================

[![ビルドの状態](https://travis-ci.org/MSOpenTech/azure-activedirectory-library-for-ios.png)](https://travis-ci.org/MSOpenTech/azure-activedirectory-library-for-ios)
[![カバレッジの状態](https://coveralls.io/repos/MSOpenTech/azure-activedirectory-library-for-ios/badge.png?branch=master)](https://coveralls.io/r/MSOpenTech/azure-activedirectory-library-for-ios?branch=master)

iOS 用 ADAL SDK を使用すると、数行のコードを追加するだけで、業務用アカウントのサポートをアプリケーションに追加することができます。この SDK により、OAuth2 の業界標準プロトコル サポート、Web API とユーザー レベル承認の統合、2 要素認証サポートなどの Microsoft Azure AD の完全な機能がアプリケーションに与えられます。さらに、これは FOSS (フリー オープン ソース ソフトウェア) であるため、Microsoft がこれらのライブラリを構築する際に、皆様に開発プロセスにご参加いただけます。 

**業務用アカウントとは**

業務用アカウントとは、企業、大学組織を問わず、ユーザーが作業を行うために使用する ID です。職場のファイルにアクセスする必要があるときは、どこからアクセスするかに関わらず、業務用アカウントを使用します。業務用アカウントは、データセンターで実行されている Active Directory サーバーに関連付けることも、Office 365 を使用する場合などは、完全にクラウド内に存在させることもできます。ユーザーは業務用アカウントを使用することで、アクセスしている重要なドキュメントやデータは、Microsoft のセキュリティにより保護されていることを確認できます。

## iOS 1.0 用 ADAL がリリースされました

皆様からのフィードバックに基づき、iOS 用 ADAL のバージョン 1.0.0 をリリースしました。リリースはこちら (https://github.com/AzureAD/azure-activedirectory-library-for-objc/releases/tag/1.0.1) から入手できます。

## サンプルとドキュメント

[Microsoft では多数のサンプル アプリケーションとドキュメントを GitHub で提供しており](https://github.com/AzureADSamples)、これらは Azure ID システムの理解を深めるためにお役立ていただけます。Windows、Windows Phone、iOS、OSX、Android、Linux などのネイティブ クライアント用のチュートリアルがあります。OAuth2、OpenID Connect、Graph API を含む優れた認証フローの機能向けの詳細なチュートリアルも提供しています。 

iOS 用の Azure ID サンプルをご覧ください ([https://github.com/AzureADSamples/NativeClient-iOS](https://github.com/AzureADSamples/NativeClient-iOS))。

## コミュニティでのヘルプとサポート

Azure Active Directory およびその (この SDK も含む) SDKのサポートに関して、Microsoft では[スタック オーバーフロー](http://stackoverflow.com/)を活用してコミュニティと連携しています。ご質問がある場合は、スタック オーバーフローで質問することを強くお勧めします (多くの担当者が参加しています)。 また、既存の質問を参照して、以前に同じ質問があったかどうかを確認できます。 

担当者の目につきやすいよう、"adal タグを使用することをお勧めします。ADAL のスタック オーバーフローでの最新の Q&A は、こちら ([http://stackoverflow.com/questions/tagged/adal](http://stackoverflow.com/questions/tagged/adal)) で確認できます。

## 投稿

すべてのコードは Apache 2.0 ライセンスによってライセンスされており、コードは GitHub で活発にトリアージされています。Microsoft では、投稿とフィードバックを積極的に募集しています。開発したレポジトリを複製することで、今すぐ投稿を行えます。 

## クイック スタート

1. リポジトリをコンピューターに複製する
2. ライブラリを構築する
3. ADALiOS ライブラリをプロジェクトに追加する
4. ADALiOSBundle からのストーリーボードをプロジェクト リソースに追加する
5. libADALiOS を “Link With Libraries” フェーズに追加する 


##ダウンロード

このライブラリを iOS プロジェクトで簡単に使用できるよう、複数のオプションが用意されています。

###オプション 1:ソース Zip

ソース コードのコピーをダウンロードするには、ページの右側にある [ZIP のダウンロード] をクリックするか、[こちら](https://github.com/AzureAD/azure-activedirectory-library-for-objc/archive/1.0.0.tar.gz)をクリックします。

###オプション 2:Cocoapods

    pod 'ADALiOS', '~> 1.0.2'

## 使用方法

### ADAuthenticationContext

API の開始点は ADAuthenticationContext.h ヘッダー内にあります。ADAuthenticationContext は、アクセス トークンの取得、キャッシュ、および供給に使用されるメインのクラスです。

#### SDK からトークンをすばやく取得する方法:

```Objective-C
	ADAuthenticationContext* authContext;
	NSString* authority;
	NSString* redirectUriString;
	NSString* resourceId;
	NSString* clientId;

+(void) getToken : (BOOL) clearCache completionHandler:(void (^) (NSString*))completionBlock;
{
    ADAuthenticationError *error;
    authContext = [ADAuthenticationContext authenticationContextWithAuthority:authority
                                                                        error:&error];
    
    NSURL *redirectUri = [NSURL URLWithString:redirectUriString];
    
    if(clearCache){
        [authContext.tokenCacheStore removeAll];
    }
    
    [authContext acquireTokenWithResource:resourceId
                                 clientId:clientId
                              redirectUri:redirectUri
                          completionBlock:^(ADAuthenticationResult *result) {
        if (AD_SUCCEEDED != result.status){
            // display error on the screen
            [self showError:result.error.errorDetails];
        }
        else{
            completionBlock(result.accessToken);
        }
    }];
}
```

#### トークンを authHeader に追加して API にアクセスする:

```Objective-C

	+(NSArray*) getTodoList:(id)delegate
	{
    __block NSMutableArray *scenarioList = nil;
    
    [self getToken:YES completionHandler:^(NSString* accessToken){
    
    NSURL *todoRestApiURL = [[NSURL alloc]initWithString:todoRestApiUrlString];
            
    NSMutableURLRequest *request = [[NSMutableURLRequest alloc]initWithURL:todoRestApiURL];
            
    NSString *authHeader = [NSString stringWithFormat:@"Bearer %@", accessToken];
            
    [request addValue:authHeader forHTTPHeaderField:@"Authorization"];
            
    NSOperationQueue *queue = [[NSOperationQueue alloc]init];
            
    [NSURLConnection sendAsynchronousRequest:request queue:queue completionHandler:^(NSURLResponse *response, NSData *data, NSError *error) {
                
            if (error == nil){
                    
            NSArray *scenarios = [NSJSONSerialization JSONObjectWithData:data options:0 error:nil];
                
            todoList = [[NSMutableArray alloc]init];
                    
            //each object is a key value pair
            NSDictionary *keyVauePairs;
                    
            for(int i =0; i < todo.count; i++)
            {
                keyVauePairs = [todo objectAtIndex:i];
                        
                Task *s = [[Task alloc]init];
                        
                s.id = (NSInteger)[keyVauePairs objectForKey:@"TaskId"];
                s.description = [keyVauePairs objectForKey:@"TaskDescr"];
                
                [todoList addObject:s];
                
             }
                
            }
        
        [delegate updateTodoList:TodoList];
        
        }];
        
    }];
    return nil; } 
```

### 診断

次に示すのは、問題を診断するための主要な情報ソースです。

+ NSError
+ ログ
+ ネットワーク トレース

ライブラリでの診断では、関連付け ID が中心的な役割を持つことにも注意してください。ADAL 要求をコード内の他の操作と関連付けたい場合は、関連付け ID は要求ごとに設定できます。関連付け ID を設定しない場合、ADAL はランダムな関連付け ID を生成し、すべてのログ メッセージとネットワーク呼び出しにこの関連付け ID がスタンプされます。自己生成 ID は、要求ごとに変更されます。

#### NSError

当然ながら、診断の出発点はここです。Microsoft では、役立つエラー メッセージを提供できるよう取り組んでいます。役に立たないエラー メッセージがあった場合は、問題を報告してください。モデルや SDK 番号など、デバイス情報も提供してください。エラー メッセージは、状態が AD_FAILED と設定された、ADAuthenticationResult の一部として返されます。

#### ログ

ライブラリは、問題の診断に役立てることができるログ メッセージを生成するように構成できます。ADAL は既定で、NSLog を使用してメッセージをログに記録します。各 API メソッド呼び出しは API バージョンで修飾され、メッセージは 1 つおきに関連付け ID と UTC タイムスタンプで修飾されます。このデータは、サーバー側の診断を確認する上で重要です。次に示すように、SDK はカスタム Logger コールバックを提供する機能も公開します。
```Objective-C
    [ADLogger setLogCallBack:^(ADAL_LOG_LEVEL logLevel, NSString *message, NSString *additionalInformation, NSInteger errorCode) {
        //HANDLE LOG MESSAGE HERE
    }]
```

##### ログ レベル
+ No_Log(すべてのログ記録を無効)
+ Error(例外。既定として設定)
+ Warn(警告)
+ Info(情報提供目的)
+ Verbose(詳細情報)

ログ レベルは、次のように設定します。
```Objective-C
[ADLogger setLevel:ADAL_LOG_LEVEL_INFO]
 ```
 
#### ネットワーク トレース

さまざまなツールを使用して、ADAL が生成する HTTP トラフィックをキャプチャすることができます。これは、OAuth プロトコルを使い慣れている場合、または Microsoft や他のサポート チャネルに診断情報を提供する必要がある場合に、最も役立ちます。

Charles は、OSX での最も簡単な HTTP トレース ツールです。ADAL ネットワーク トラフィックを正しく記録できるよう、次のリンク先にある情報を用いて設定してください。有効に使用するには、暗号化されていない SSL トラフィックを記録するように Charles を構成する必要があります。注:この方法で生成されたトレースには、アクセス トークン、ユーザー名、パスワードなどの、非常に機密性の高い情報が含まれている可能性があります。運用環境のアカウントを使用している場合は、それらのトレースを第三者と共有することがないようにしてください。サポートを受けるためにトレースを他者に提供する必要がある場合は、共有しても問題がないユーザー名とパスワードを使う一時的なアカウントを使用して問題を再現します。

+ [iOS 用 SSL シミュレータまたはデバイスを設定する](http://www.charlesproxy.com/documentation/faqs/ssl-connections-from-within-iphone-applications/)



##一般的な問題

**ADAL ライブラリを使用するとアプリケーションが次の例外でクラッシュする**<br/> \*\** Terminating app due to uncaught exception 'NSInvalidArgumentException', reason: '+[NSString isStringNilOrBlank:]: unrecognized selector sent to class 0x13dc800'<br/>
**解決方法:**-ObjC フラグをアプリケーションの "Other Linker Flags" ビルド設定に必ず追加します。詳細については、静的ライブラリの使用に関する Apple のドキュメントを参照してください:<br/> https://developer.apple.com/library/ios/technotes/iOSStaticLibraries/Articles/configuration.html#//apple_ref/doc/uid/TP40012554-CH3-SW1

## ライセンス

Copyright (c) Microsoft Open Technologies, Inc.All rights reserved.Licensed under the Apache License, Version 2.0 (the "License"); 
