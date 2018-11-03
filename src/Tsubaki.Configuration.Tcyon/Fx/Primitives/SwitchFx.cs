// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D


using System.Text.RegularExpressions;

namespace Tsubaki.Configuration.Tcyon.Fx
{
    public sealed class SwitchFx : UnsignedIntegralFx<bool>
    {
        public const string ON = "on";
        public const string OFF = "off";

        protected override RegexOptions Options => RegexOptions.IgnoreCase;

        protected override string ValuePattern => $"({ON}|{OFF})";

        protected override bool TryParse(string feed, out bool result)
        {

            if(string.Equals(feed, ON, System.StringComparison.CurrentCultureIgnoreCase))
            {
                result = true;
                return true;
            }

            if (string.Equals(feed, OFF, System.StringComparison.CurrentCultureIgnoreCase))
            {
                result = false;
                return true;
            }

            result = false;
            return false;
        }
        protected override bool TryGenerate(bool feed, out string value)
        {
            value = feed ? ON : OFF;
            return true;
        }
    }
}