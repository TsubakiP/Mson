// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Internal
{
    internal sealed class Int64Parser : FieldParser<long>
    {
        protected override string SerializationFormat => "{0}l";

        protected override bool MatchValueEndToken(char c) => c == 'l';

        protected override bool TryParse(string str, out long value) => long.TryParse(str, out value);
    }
}