// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Internal
{
    using System;
    using System.Text;

    internal sealed class StringParser : FieldParser<string>
    {
        protected override string SerializationFormat => "'{0}'";

        protected override string BuildSerializeString(string value)
        {
            return base.BuildSerializeString(value.Replace("'", "''"));
        }

        protected override bool FindValueBegin(string tcyon, ref int current, ref StringBuilder sb)
        {// find value start (0-9)
            for (; current < tcyon.Length; current++)
            {
                if (this.IsWhiteSpace(tcyon[current]))
                    continue;

                if (tcyon[current] == '\'')
                {
                    current++;
                    return true;
                }
                else
                    break;
            }
            return false;
        }

        protected override bool FindValueEnd(string tcyon, ref int current, StringBuilder sb, out string result)
        {
            // find value end (0-9)
            result = default;
            for (; current < tcyon.Length; current++)
            {
                if (this.MatchValueEndToken(tcyon[current]))
                {
                    if (tcyon.Length > current + 1 && tcyon[current + 1] == '\'')
                    {
                        sb.Append('\'');
                        current++;
                        continue;
                    }

                    current++;
                    result = sb.ToString();
                    return true;
                }
                else
                    sb.Append(tcyon[current]);
            }
            return false;
        }

        protected override bool MatchValueEndToken(char c) => c == '\'';

        protected override bool TryParse(string str, out string value)
        {
            throw new NotImplementedException();
        }
    }
}