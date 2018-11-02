// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Internal
{
    internal sealed class SByteParser : FieldParser<sbyte>
    {
        protected override string SerializationFormat => "{0}B";

        protected override bool MatchValueEndToken(char c) => c == 'B';

        protected override bool TryParse(string str, out sbyte value) => sbyte.TryParse(str, out value);
    }
}