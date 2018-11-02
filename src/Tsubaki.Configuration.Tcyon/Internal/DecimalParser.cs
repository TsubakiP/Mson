// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Internal
{
    using System.Text;

    internal sealed class DecimalParser : FieldParser<decimal>
    {
        protected override string SerializationFormat => "{0}m";

        protected override bool FindValueEnd(string tcyon, ref int current, StringBuilder sb, out decimal result)
        {
            bool hasDot = false;
            // find value end (0-9)
            result = default;
            for (; current < tcyon.Length; current++)
            {
                if (this.MatchValueEndToken(tcyon[current]))
                {
                    var tmp = sb.ToString();
                    if (this.TryParse(tmp, out result))
                    {
                        return true;
                    }
                    break;
                }
                else if (char.IsDigit(tcyon[current]))
                {
                    sb.Append(tcyon[current]);
                    continue;
                }
                else if (tcyon[current] == '.')
                {
                    if (!hasDot)
                    {
                        sb.Append(tcyon[current]);
                        hasDot = true;
                        continue;
                    }
                    else
                        break;
                }
                else
                    break;
            }
            return false;
        }

        protected override bool MatchValueEndToken(char c) => c == 'm';

        protected override bool TryParse(string str, out decimal value) => decimal.TryParse(str, out value);
    }
}