// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public sealed class StringFx : Fx<string>
    {
        protected override string ValuePattern => ".*";
        protected override string SuffixPattern => "'";
        protected override string PrefixPattern => @"'";
        protected override bool TryParse(string feed, out string result) => throw new NotImplementedException();
        public override IEnumerable<(string fieldName, string value)> Fetch(string feed)
        {
            foreach (Match match in this.InternalRegex.Value.Matches(feed))
            {
                yield return (match.Groups["Name"].Value, match.Groups["Value"].Value);
            }
        }

        protected override bool TryGenerate(string feed, out string value)
        {
            value = feed;
            return true;
        }
    }

}