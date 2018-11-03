// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    public sealed class UInt64Fx : UnsignedIntegralFx<ulong>
    {
        protected override string SuffixPattern => "L";
        protected override bool TryParse(string feed, out ulong result) => ulong.TryParse(feed, out result);

        protected override bool TryGenerate(ulong feed, out string value)
        {
            value = feed.ToString();
            return true;
        }
    }

}