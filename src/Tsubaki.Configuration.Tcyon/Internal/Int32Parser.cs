// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Internal
{
    using System.Text;

    internal sealed class Int32Parser : FieldParser<int>
    {
        protected override string SerializationFormat => "{0}";

        protected override bool FindValueEnd(string tcyon, ref int current, StringBuilder sb, out int result)
        {
            // find value end (0-9)
            result = default;
            for (; current < tcyon.Length; current++)
            {
                if (char.IsDigit(tcyon[current]))
                {
                    sb.Append(tcyon[current]);
                    continue;
                }
                else
                {
                    break;
                }
            }

            var tmp = sb.ToString();
            if (this.TryParse(tmp, out result))
            {
                return true;
            }

            return false;
        }

        protected override bool MatchValueEndToken(char c) => !char.IsDigit(c);

        protected override bool TryParse(string str, out int value) => int.TryParse(str, out value);
    }
}