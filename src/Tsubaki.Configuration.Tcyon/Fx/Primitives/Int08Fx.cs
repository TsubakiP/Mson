// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    public sealed class Int08Fx : IntegralFx<sbyte>
    {
        protected override string SuffixPattern => "b";
        protected override bool TryParse(string feed, out sbyte result) => sbyte.TryParse(feed, out result);

        protected override bool TryGenerate(sbyte feed, out string value)
        {
            value = feed.ToString();
            return true;
        }
    }

}