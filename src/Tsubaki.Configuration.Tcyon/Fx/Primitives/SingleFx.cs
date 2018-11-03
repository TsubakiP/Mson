// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D



namespace Tsubaki.Configuration.Tcyon.Fx
{
    public sealed class SingleFx : DecimalFx<float>
    {
        protected override string ValuePattern => base.ValuePattern;

        protected override string SuffixPattern => "f";
        protected override bool TryParse(string feed, out float result) => float.TryParse(feed, out result);

        protected override bool TryGenerate(float feed, out string value)
        {
            value = feed.ToString();
            return true;
        }
    }
}