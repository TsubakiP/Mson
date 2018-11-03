// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    public sealed class UInt08Fx : UnsignedIntegralFx<byte>
    {
        protected override string SuffixPattern => "B";
        protected override bool TryParse(string feed, out byte result) => byte.TryParse(feed, out result);

        protected override bool TryGenerate(byte feed, out string value)
        {
            value = feed.ToString();
            return true;
        }
    }
}