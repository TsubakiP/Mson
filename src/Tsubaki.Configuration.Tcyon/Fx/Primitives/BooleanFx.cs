// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D


namespace Tsubaki.Configuration.Tcyon.Fx
{
    using System.Text.RegularExpressions;

    public sealed class BooleanFx : UnsignedIntegralFx<bool>
    {
        protected override RegexOptions Options => RegexOptions.IgnoreCase;

        protected override string ValuePattern => $"({true}|{false})";
        
        protected override bool TryParse(string feed, out bool result) => bool.TryParse(feed, out result);

        protected override bool TryGenerate(bool feed, out string value)
        {
            value = feed.ToString();
            return true;
        }
    }
}