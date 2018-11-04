# Overview  
[![Build status](https://ci.appveyor.com/api/projects/status/pgo86fa8u8px10lb/branch/master?svg=true)](https://ci.appveyor.com/project/0x0001F36D/tsubaki-configuration/branch/master)
<br>Provides object selfing de/serializable ability.

# How to
At first, implement your class like this.
```csharp
public class YourClass : SelfDisciplined<YourClass>
{
    public string YourProperty { get; set; }
}
```
Then try this and run it twice!
```csharp
var obj = YourClass.Load();
if (entity.YourProperty is string s)
{
    Debug.WriteLine(s);
    entity.YourProperty = null;
}
else
{
    entity.YourProperty = "Success";
}
obj.Save();
```
Maybe this is what you want!