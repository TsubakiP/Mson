// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    using System.Collections.Generic;

    public interface ICodex<T>
    {
        IEnumerable<string> Build(string fieldName, T value, params (string fieldName, T value)[] feed);
        IEnumerable<(string fieldName, T value)> Fetch(string feed);
    }

}