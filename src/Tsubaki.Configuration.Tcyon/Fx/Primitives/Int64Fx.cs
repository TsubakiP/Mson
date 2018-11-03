// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    public sealed class Int64Fx : IntegralFx<long>
    {
        protected override string SuffixPattern => "l";
        protected override bool TryParse(string feed, out long result) => long.TryParse(feed, out result);

        protected override bool TryGenerate(long feed, out string value)
        {
            value = feed.ToString();
            return true;
        }
    }
}