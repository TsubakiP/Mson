// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Internal
{
    internal sealed class UInt32Parser : FieldParser<uint>
    {
        protected override string SerializationFormat => "{0}u";

        protected override bool MatchValueEndToken(char c) => c == 'u';

        protected override bool TryParse(string str, out uint value) => uint.TryParse(str, out value);
    }
}