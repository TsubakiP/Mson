// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    public sealed class Int16Fx : IntegralFx<short>
    {
        protected override string SuffixPattern => "s";
        protected override bool TryParse(string feed, out short result) => short.TryParse(feed, out result);

        protected override bool TryGenerate(short feed, out string value)
        {
            value = feed.ToString();
            return true;
        }
    }
}