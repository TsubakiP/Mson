// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    public sealed class CurrencyFx : DecimalFx<decimal>
    {
        protected override string ValuePattern => base.ValuePattern;

        protected override string SuffixPattern => "m";
        protected override bool TryParse(string feed, out decimal result) => decimal.TryParse(feed, out result);

        protected override bool TryGenerate(decimal feed, out string value)
        {
            value = feed.ToString();
            return true;
        }
    }
}