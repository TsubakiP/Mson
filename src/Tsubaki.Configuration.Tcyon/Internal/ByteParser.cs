// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Internal
{
    internal sealed class ByteParser : FieldParser<byte>
    {
        protected override string SerializationFormat => "{0}b";

        protected override bool MatchValueEndToken(char c) => c == 'b';

        protected override bool TryParse(string str, out byte value) => byte.TryParse(str, out value);
    }
}