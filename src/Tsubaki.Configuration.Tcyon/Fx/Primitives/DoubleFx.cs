// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    public sealed class DoubleFx : DecimalFx<double>
    {
        protected override string ValuePattern => base.ValuePattern;

        protected override string SuffixPattern => "F";
        protected override bool TryParse(string feed, out double result) => double.TryParse(feed, out result);

        protected override bool TryGenerate(double feed, out string value)
        {
            value = feed.ToString();
            return true;
        }
    }
}