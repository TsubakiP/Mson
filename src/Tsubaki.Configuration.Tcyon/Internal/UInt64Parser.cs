// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Internal
{
    internal sealed class UInt64Parser : FieldParser<ulong>
    {
        protected override string SerializationFormat => "{0}L";

        protected override bool MatchValueEndToken(char c) => c == 'L';

        protected override bool TryParse(string str, out ulong value) => ulong.TryParse(str, out value);
    }
}