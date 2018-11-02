// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Internal
{
    internal sealed class UInt16Parser : FieldParser<ushort>
    {
        protected override string SerializationFormat => "{0}S";

        protected override bool MatchValueEndToken(char c) => c == 'S';

        protected override bool TryParse(string str, out ushort value) => ushort.TryParse(str, out value);
    }
}