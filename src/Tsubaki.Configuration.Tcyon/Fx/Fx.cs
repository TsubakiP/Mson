// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text.RegularExpressions;


    public abstract class Fx<T> : ICodex<T>
    {
        protected virtual string FullPattern { get; }
        protected virtual string OutputFormat { get; }

        protected Lazy<Regex> InternalRegex { get; } 
        protected virtual string KeyValidatePattern => @"\w{1,64}";

        protected virtual string KeyPattern => $@"-\s+(?<Name>{this.KeyValidatePattern})\s*:\s*";


        protected virtual string PrefixPattern => null;

        protected virtual string SuffixPattern => null;

        protected abstract string ValuePattern { get; }


        private string ProcessBackslash(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length <= 1)
                return value;

            return Regex.Replace(value, @"\\(.)", x => x.Groups[1].Value);
        }

        protected virtual RegexOptions Options { get; }

        protected Fx()
        {
            this.FullPattern = this.KeyPattern + this.PrefixPattern + $@"(?<Value>{this.ValuePattern})" + this.SuffixPattern;
            this.OutputFormat = $"- {{0}}: {this.ProcessBackslash(this.PrefixPattern)}{{1}}{this.ProcessBackslash(this.SuffixPattern)}";


            Debug.WriteLine("Full pattern: " + this.FullPattern);
            Debug.WriteLine("Output format: " + this.OutputFormat);
            this.InternalRegex = new Lazy<Regex>(() => new Regex(this.FullPattern, RegexOptions.Multiline | RegexOptions.ExplicitCapture | this.Options));
        }

        protected virtual bool ValidateFieldName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            return Regex.IsMatch(name, this.KeyValidatePattern);
        }


        public virtual IEnumerable<string> Build(string fieldName, T value, params (string fieldName, T value)[] feed)
        {
            if (this.InternalGenerate(fieldName, value, out var s))
            {
                yield return s;
            }

            if (feed is IList<(string, T)> feeds)
                foreach (var (f, v) in feeds)
                {
                    if (this.InternalGenerate(f, v, out s))
                    {
                        yield return s;
                    }
                }
        }

        public virtual IEnumerable<(string fieldName, T value)> Fetch(string feed)
        {
            foreach (Match match in this.InternalRegex.Value.Matches(feed))
            {
                var v = match.Groups["Value"].Value;
                if (this.TryParse(v, out var value))
                {
                    yield return (match.Groups["Name"].Value, value);
                }
            }
        }

        protected abstract bool TryGenerate(T feed, out string value);

        protected abstract bool TryParse(string feed, out T result);



        private bool InternalGenerate(string name, T value, out string callback)
        {
            callback = default;
            var r = this.ValidateFieldName(name) && this.TryGenerate(value, out callback);
            if (r)
                callback = string.Format(this.OutputFormat, name, callback);
            return r;
        }
    }

}