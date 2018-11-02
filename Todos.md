# Overview

Tsubaki-Config Syntax for Object Notation

# Types
## Fields
| Type | Symbol/Syntax | Example | Details |
| ---- |:---:| --- | --- |
|<ul><li>[x] byte</li></ul> | b | - Field : 30b |
|<ul><li>[x] sbyte</li></ul> | B | - Field : 30B |
|<ul><li>[x] bool </li></ul> | (auto) | - Field : on <br> - Field : false | True : **_on_**, **_enable_**, **_yes_**, **_true_**<br>False : **_off_**, **_disable_**, **_no_**, **_false_** 
|<ul><li>[x] short </li></ul>| s | - Field : 30s |
|<ul><li>[x] ushort </li></ul>| S | - Field : 30S |
|<ul><li>[x] int </li></ul>|  (auto) | - Field : 30 |
|<ul><li>[x] uint</li></ul> | u | - Field : 30u |
|<ul><li>[x] long </li></ul>| l | - Field : 30l |
|<ul><li>[x] ulong</li></ul> | L | - Field : 30L |
|<ul><li>[x] double</li></ul> | F | - Field : 30.0F |
|<ul><li>[x] float </li></ul>| f | - Field : 30.0f |
|<ul><li>[x] decimal</li></ul> | m | - Field : 30m  |
|<ul><li>[x] string </li></ul>| '&nbsp;&nbsp;&nbsp;&nbsp;' | - Field : 'Hello, My son!'  |
|<ul><li>[ ] Uri</li></ul> | \[name](url-string)<br>url:[url-string] | - \[X.COM](http:\/\/x.com)<br>- Field : url:(http:\/\/x.com) | Seems like: - [X.COM](http://x.com)<br> you can also use 'link' to replace 'url'.|

※ *_Not supported_* **_'Character'_** *_type, If you wanna use then just implement it by yourself!_*
## Arrays
| Type | Syntax |
| ---- |:--------- |
|<ul><li>[ ] List</li></ul> | - Name: <br>&nbsp;&nbsp;&nbsp;&nbsp;- 'Tony'<br>&nbsp;&nbsp;&nbsp;&nbsp;- 'Emily'<br>&nbsp;&nbsp;&nbsp;&nbsp;- 'Lisa'<br> |
|<ul><li>[ ] List</li></ul> | - Name: [ 'Tony', 'Emily', 'Lisa' ] |
|<ul><li>[ ] List</li></ul> | - Values: [ 30m, 'Emily', '%' ] |
|<ul><li>[ ] Tuple</li></ul> | - Name: ( 'Tony', 'Emily', 'Lisa' ) |
|<ul><li>[ ] Tuple </li></ul>| - Values: ( Value: 30m, Name: 'Emily', Symbol: '%' ) |
|<ul><li>[ ] Dictionary</li></ul> | - Characters: <br>&nbsp;&nbsp;&nbsp;&nbsp;- A: 12<br>&nbsp;&nbsp;&nbsp;&nbsp;- B: 30L<br>&nbsp;&nbsp;&nbsp;&nbsp;- C: NO<br> |
|<ul><li>[ ] Dictionary</li></ul> | - Dict: { Value: 30m, Name: 'Emily', Symbol: '%' } |

## Ultra
| Type | Syntax | Sample |
| ---- |:--------- | --- |
|<ul><li>[ ] DateTime </li></ul>| time:[iso-8601]<br>time:[base64-string] | - Time : time:[12/31/9999 23:59:59]<br>- Time : time:[/z839HUoyms=] | ISO-8601 / RFC-1123
|<ul><li>[ ] Guid </li></ul>| guid:[base64-string] | - Guid : guid:[8+7/638hzUm13v8HAtwNtw==] |
|<ul><li>[ ] Image </li></ul>| image:format[base64-string] | - Image : image:png[tlzUd0c5GsLj3l2tVNl1mb...etc] |
|<ul><li>[ ] Delegate</li></ul> | lambda:[base64-string] | - Delegate : lambda:[mbjUs5c23ltdlzVtL1GlN0...etc] |
|<ul><li>[ ] Type </li></ul>| type:[base64-string] | - Type : type:[U3lzdGVtLlN0cms2tlbj15...etc] |
|<ul><li>[ ] Custom </li></ul>| yourName:[your-format] | - Example: [!@#$%^&*]


