// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Internal
{
    using System;
    using System.Text;

    internal abstract class FieldParser<T> : IFieldParser<T>, IParserGlue
    {
        protected abstract string SerializationFormat { get; }

        protected FieldParser()
        {
        }

        public virtual string Serialize(string fieldName, T value)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentException("The argument can't be null or empty.", nameof(fieldName));

            var tcyon = $"- {fieldName}: {this.BuildSerializeString(value)}";

            return tcyon;
        }

        public virtual bool TryDeserialize(string tcyon, out (string name, T value) field)
        {
            if (this.FindFieldBeginToken(tcyon, out var current, out var startIndex) &&
                this.ProcessKeyBlock(tcyon, ref current, out var sb, 64, out var key) &&
                this.ProcessValueBlock(tcyon, ref current, ref sb, out var result))
            // &&this.FindFieldEndToken(tcyon, current, out var endIndex))
            {
                field = (key, result);
                return true;
            }
            field = (null, default);
            return false;
        }

        protected virtual string BuildSerializeString(T value)
        {
            return string.Format(this.SerializationFormat, value);
        }

        protected virtual bool FindFieldBeginToken(string tcyon, out int current, out int startIndex)
        {
            current = 0;
            startIndex = -1;
            // find token '-'
            for (; current < tcyon.Length; current++)
            {
                if (this.IsWhiteSpace(tcyon[current]))
                    continue;
                if (this.MatchNameToken(tcyon[current]))
                {
                    startIndex = current;
                    current++;
                    return true;
                }
            }
            return false;
        }

        /*
        protected virtual bool FindFieldEndToken(string tcyon, int current, out int endIndex)
        {
            if (current == tcyon.Length)
            {
                endIndex = current - 1;
                return true;
            }

            for (; current < tcyon.Length; current++)
            {
                if (this.IsWhiteSpace(tcyon[current]))
                    continue;
                if (tcyon[current] == '\0')
                {
                    endIndex = current - 1;
                    return true;
                }
                else if (tcyon[current] == '\r' && tcyon[current + 1] == '\n')
                {
                    endIndex = current + 1;
                    return true;
                }
            }
            endIndex = -1;
            return false;
        }*/

        protected virtual bool FindKeyBegin(string tcyon, ref int current, out StringBuilder sb, int bufferSize)
        {
            sb = new StringBuilder(bufferSize);
            for (; current < tcyon.Length; current++)
            {
                if (this.IsWhiteSpace(tcyon[current]))
                    continue;
                // the first position should be the letter
                if (char.IsLetter(tcyon[current]))
                {
                    sb.Append(tcyon[current++]);
                    return true;
                }
                else
                    break;
            }
            return false;
        }

        protected virtual bool FindKeyEnd(string tcyon, ref int current, ref StringBuilder sb, out string key)
        {
            // find key end
            key = default;
            for (; current < tcyon.Length; current++)
            {
                if (tcyon[current] == ':')
                {
                    key = sb.ToString();
                    sb.Clear();
                    current++;
                    return true;
                }

                if (char.IsLetterOrDigit(tcyon[current]))
                {
                    sb.Append(tcyon[current]);
                }
                else if (this.IsWhiteSpace(tcyon[current]))
                    continue;
                else
                    break;
            }
            return false;
        }

        protected virtual bool FindValueBegin(string tcyon, ref int current, ref StringBuilder sb)
        {
            // find value start (0-9)
            for (; current < tcyon.Length; current++)
            {
                if (this.IsWhiteSpace(tcyon[current]))
                    continue;

                if (char.IsDigit(tcyon[current]) || tcyon[current] == '-')
                {
                    sb.Append(tcyon[current++]);
                    return true;
                }
                else
                    break;
            }
            return false;
        }

        protected virtual bool FindValueEnd(string tcyon, ref int current, StringBuilder sb, out T result)
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

                if (this.MatchValueEndToken(tcyon[current]))
                {
                    var tmp = sb.ToString();
                    if (this.TryParse(tmp, out result))
                    {
                        current++;
                        return true;
                    }
                    break;
                }
                else
                    break;
            }
            return false;
        }

        protected bool IsWhiteSpace(char c)
        {
            return c == '\t' || c == ' ';
        }

        protected virtual bool MatchNameToken(char c)
        {
            return c == '-';
        }

        protected virtual bool MatchValueEndToken(char c)
        {
            return false;
        }

        protected virtual bool ProcessKeyBlock(string tcyon, ref int current, out StringBuilder sb, int bufferSize, out string key)
        {
            key = null;
            return this.FindKeyBegin(tcyon, ref current, out sb, bufferSize) &&         // find key start
                   this.FindKeyEnd(tcyon, ref current, ref sb, out key);                // find key end
        }

        protected virtual bool ProcessValueBlock(string tcyon, ref int current, ref StringBuilder sb, out T result)
        {
            result = default;
            return this.FindValueBegin(tcyon, ref current, ref sb) &&                   // find value start
                   this.FindValueEnd(tcyon, ref current, sb, out result);            // find value end
        }

        protected abstract bool TryParse(string str, out T value);
    }
}