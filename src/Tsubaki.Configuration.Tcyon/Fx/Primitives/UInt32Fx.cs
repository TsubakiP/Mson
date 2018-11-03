// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    public sealed class UInt32Fx : IntegralFx<uint>
    {
        protected override string SuffixPattern => "u";
        protected override bool TryParse(string feed, out uint result) => uint.TryParse(feed, out result);

        protected override bool TryGenerate(uint feed, out string value)
        {
            value = feed.ToString();
            return true;
        }
    }
}