// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    public sealed class UInt16Fx : UnsignedIntegralFx<ushort>
    {
        protected override string SuffixPattern => "S";
        protected override bool TryParse(string feed, out ushort result) => ushort.TryParse(feed, out result);

        protected override bool TryGenerate(ushort feed, out string value)
        {
            value = feed.ToString();
            return true;
        }
    }
}