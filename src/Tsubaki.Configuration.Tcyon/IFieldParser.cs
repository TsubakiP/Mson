// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D
namespace Tsubaki.Configuration.Tcyon
{
    public interface IFieldParser<T>
    {
        string Serialize(string fieldName, T value);

        bool TryDeserialize(string tcyon, out (string name, T value) field);
    }
}