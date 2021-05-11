#适用于 iOS 和 OSX 的 Microsoft Azure Active Directory 身份验证库（ADAL）
=====================================

[![构建状态](https://travis-ci.org/MSOpenTech/azure-activedirectory-library-for-ios.png)](https://travis-ci.org/MSOpenTech/azure-activedirectory-library-for-ios)
[![覆盖状态](https://coveralls.io/repos/MSOpenTech/azure-activedirectory-library-for-ios/badge.png?branch=master)](https://coveralls.io/r/MSOpenTech/azure-activedirectory-library-for-ios?branch=master)

ADAL SDK for iOS 让你能够只需几行附加代码，就能添加工作账户支持至应用程序。此 SDK 为应用程序提供了 Microsoft Azure AD 的全部功能，其中包括 OAuth2 的行业标准协议支持、Web API 集成（含用户级同意）和双因素身份验证支持。最重要的是，它是免费开源软件，因此能够在创建这些库时参与开发流程。 

**什么是工作账户？**

工作帐户是一种标识，无论是在企业中还是在大学校园中，都可以使用它来完成工作。任何需要访问工作环境的地方，都将使用工作账户。工作账户可绑定至数据中心中运行的 Active Directory 服务器，或在使用 Office365 时完全驻留在云端。工作账户将让用户知道他们正在存取的重要文件和数据已由 Microsoft 安全提供保障。

## ADAL for iOS 1.0 正式发布！

感谢你的反馈，我们已发布了适用于 ADAL 的 1.0.0 版 iOS [可在此处获取发布版本] (https://github.com/AzureAD/azure-activedirectory-library-for-objc/releases/tag/1.0.1)

## 示例和文档

[我们提供有关 GitHub 的全套示例应用和文档](https://github.com/AzureADSamples)，帮助你开始学习 Azure Identity 系统。这包括适用于 Windows、Windows Phone、iOS、OSX、Android 和 Linux 等本机客户端的教程。我们还提供了有关身份验证流的完整演练，如 OAuth2、OpenID Connect、Graph API 和其他强大功能。 

点击这里访问适用于 iOS 的 Azure Identity 示例：[https://github.com/AzureADSamples/NativeClient-iOS](https://github.com/AzureADSamples/NativeClient-iOS)

## 社区帮助和支持

我们利用“[堆栈溢出](http://stackoverflow.com/)”与社区协作，为 Azure Active Directory 和 SDK 提供支持，包括此支持。强烈建议询问有关堆栈溢出的问题（我们准备就绪！） 另外浏览存在的问题，看看以前是否有人遇到过这样的问题。 

建议使用 "adal" 标记，以便我们可以看到！下面是有关 ADAL 堆栈溢出的最新问题和解答：[http://stackoverflow.com/questions/tagged/adal](http://stackoverflow.com/questions/tagged/adal)

## 参与

所有代码均获得 Apache 2.0 许可证授权，而且我们主动在 GitHub 上进行会审。我们热情欢迎你的投稿和反馈。现在你可复制库并开始参与。 

## 快速入门

1. 克隆存储库至计算机
2. 生成库
3. 添加 ADALiOS 库至项目
4. 将 ADALiOSBundle 中的情节提要添加到项目资源
5. 添加 libADALiOS 至“与库关联”阶段。 


##下载

我们提供了多个选项以方便你在 iOS 项目中使用此库：

###选项 1：源压缩文件

若要下载源代码副本，请单击页面右侧的单击“下载 ZIP”或点击“[这里](https://github.com/AzureAD/azure-activedirectory-library-for-objc/archive/1.0.0.tar.gz)”。

###选项 2：Cocoapods

    pod 'ADALiOS', '~> 1.0.2'

## 用法

### ADAuthenticationContext

API 的起点位于 ADAuthenticationContext.h 标头中。ADAuthenticationContext 是用于获取、缓存和提供访问令牌的主类。

#### 如何从 SDK 快速获取令牌：

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

#### 将令牌添加到 authHeader 以访问 Api：

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

### 诊断

下面是用来诊断问题的信息的主要来源：

+ NSError
+ 日志
+ 网络跟踪

另外请注意，相关性 ID 是在库中进行诊断的关键所在。如果想要在代码中将 ADAL 请求关联到其他操作，可以基于每个请求设置相关性 ID。如果未设置相关性 ID，则 ADAL 将生成一个随机 ID，所有日志消息和网络调用将使用相关性 ID 标记。每发出一个请求，自我生成的 ID 都会更改。

#### NSError

这明显是首次诊断。我们将尝试提供有用的错误消息。如果发现某个错误消息没有作用，请记录相应的问题并告诉我们。请提供设备信息，例如型号和 SDK 号。错误消息返回为 ADAuthenticationResult 的一部分，其中状态设置为 AD_FAILED。

#### 日志

可以将库配置为生成有助于诊断问题的日志消息。ADAL 默认使用 NSLog 记录消息。每一 API 方法调用使用 API 版本装饰，其他每条消息使用相关性 ID 和 UTC 时间戳装饰。此数据对服务器端诊断的外观非常重要。SDK 还公开提供自定义记录器回调的功能，如下所示。
```Objective-C
    [ADLogger setLogCallBack:^(ADAL_LOG_LEVEL logLevel, NSString *message, NSString *additionalInformation, NSInteger errorCode) {
        //HANDLE LOG MESSAGE HERE
    }]
```

##### 日志记录级别
+ No_Log（禁用所有日志）
+ Error（异常。设为默认值）
+ Warn（警告）
+ Info（信息用途）
+ Verbose（更多详细信息）

可按如下所述设置日志级别：
```Objective-C
[ADLogger setLevel:ADAL_LOG_LEVEL_INFO]
 ```
 
#### 网络跟踪

可以使用各种工具来捕获 ADAL 生成的 HTTP 流量。如果熟悉 OAuth 协议或者需要向 Microsoft 或其他支持渠道提供诊断信息，这会十分有用。

Charles 是 OSX 系统中最方便的 HTTP 跟踪工具。可以使用以下链接设置该工具以正确记录 ADAL 网络流量。为了有用，需配置 Charles 来记录未加密的 SSL 流量。注意：以这种方式生成的跟踪可能包含高特权信息，例如访问令牌、用户名和密码。如果使用的是生产帐户，请不要与第三方共享这些跟踪。如果需要向某人提供跟踪以便获得支持，请使用一个临时帐户再现问题，临时帐户包含你不介意共享的用户名和密码。

+ [为 iOS 模拟器或设备设置 SSL](http://www.charlesproxy.com/documentation/faqs/ssl-connections-from-within-iphone-applications/)



##常见问题

**使用 ADAL 库的应用会因下列异常而崩溃：**<br/> \*\** 由于未捕获到异常 'NSInvalidArgumentException' 导致终止应用，原因： '+[NSString isStringNilOrBlank:]: 无法识别的选择程序已发送至类 0x13dc800'<br/>
**解决方案：**确保添加 -ObjC 标记至“其他链接器标记”应用构建设置。更多详情，请参阅 Apple 公司的静态库使用文档：<br/> https://developer.apple.com/library/ios/technotes/iOSStaticLibraries/Articles/configuration.html#//apple_ref/doc/uid/TP40012554-CH3-SW1.

## 许可证

版权所有 (c) Microsoft Open Technologies, Inc.保留所有权利。获得Apache 许可证，版本 2.0授权（“许可证”）； 
