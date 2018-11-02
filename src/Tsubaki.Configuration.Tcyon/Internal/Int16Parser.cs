// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Internal
{
    internal sealed class Int16Parser : FieldParser<short>
    {
        protected override string SerializationFormat => "{0}s";

        protected override bool MatchValueEndToken(char c) => c == 's';

        protected override bool TryParse(string str, out short value) => short.TryParse(str, out value);
    }
}