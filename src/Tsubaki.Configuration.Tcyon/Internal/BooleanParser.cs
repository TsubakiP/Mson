// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Internal
{
    using System;
    using System.Text;

    internal sealed class BooleanParser : FieldParser<bool>
    {
        private string[] FALSE = { "no", "off", "false", "disable" };
        private string[] TRUE = { "on", "yes", "true", "enable" };
        protected override string SerializationFormat => "{0}";

        protected override bool FindValueBegin(string tcyon, ref int current, ref StringBuilder sb)
            => throw new NotImplementedException();

        protected override bool FindValueEnd(string tcyon, ref int current, StringBuilder sb, out bool result)
            => throw new NotImplementedException();

        protected override bool ProcessValueBlock(string tcyon, ref int current, ref StringBuilder sb, out bool result)
        {
            result = false;

            for (; current < tcyon.Length; current++)
            {
                if (this.IsWhiteSpace(tcyon[current]))
                    continue;

                return char.IsLetter(tcyon[current]) &&
                    (this.Scan(tcyon, ref current, TRUE, true, out result) || this.Scan(tcyon, ref current, FALSE, false, out result));
            }
            return false;
        }

        protected override bool TryParse(string str, out bool value)
            => throw new NotImplementedException();

        private bool Scan(string tcyon, ref int current, string[] entities, bool ifSuccess, out bool result)
        {
            result = !ifSuccess;

            foreach (var f in entities)
            {
                var choice = true;
                for (int i = 0; i < f.Length; i++)
                {
                    var left = char.ToLower(tcyon[current + i]);
                    var right = f[i];
                    if (left != right)
                    {
                        choice = false;
                        break;
                    }
                }
                if (choice)
                {
                    var len = f.Length + current;

                    if (len == tcyon.Length || (len < tcyon.Length && char.IsWhiteSpace(tcyon[len + 1])))
                    {
                        current += f.Length;
                        result = ifSuccess;
                        return true;
                    }
                }
                else
                    continue;
            }
            return false;
        }
    }
}