# Overview
Provides object selfing de/serializable ability.

# How to
At first, implement your class like this.
```csharp
[Serializable]
public class YourClass : SelfDisciplined<YourClass>
{
    // Required!!!
    public YourClass()
    {
    }

    // Required!!!
    private YourClass(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public string YourProperty { get; set; }

    [Ignore]
    public string IgnoreMe { get; set; }
}
```
Then try this and run it twice!
```csharp
var obj = YourClass.Load();
Debug.WriteLine(obj.IgnoreMe);
if (entity.Text is string s)
{
    Debug.WriteLine(s);
    entity.Text = null;
}
else
{
    entity.Text = "Success";
}
obj.IgnoreMe = "Hello"; // This property will be ignore.
obj.Save();
```
Maybe this is what you want!