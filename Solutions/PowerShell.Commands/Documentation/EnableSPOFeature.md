#Enable-SPOFeature
*Topic automatically generated on: 2015-04-29*

Enables a feature
##Syntax
```powershell
Enable-SPOFeature [-Force [<SwitchParameter>]] [-Scope <FeatureScope>] [-Sandboxed [<SwitchParameter>]] -Identity <GuidPipeBind>```
&nbsp;

##Parameters
Parameter|Type|Required|Description
---------|----|--------|-----------
Force|SwitchParameter|False|Forcibly enable the feature.
Identity|GuidPipeBind|True|The id of the feature to enable.
Sandboxed|SwitchParameter|False|Specify this parameter if the feature you're trying to active is part of a sandboxed solution.
Scope|FeatureScope|False|
##Examples

###Example 1
    PS:> Enable-SPOFeature -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe


###Example 2
    PS:> Enable-SPOFeature -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe -Force


###Example 3
    PS:> Enable-SPOFeature -Identity 99a00f6e-fb81-4dc7-8eac-e09c6f9132fe -Scope Web

<!-- Ref: 6035DEC5BC5D3A509F117F1BF8827FF6 -->