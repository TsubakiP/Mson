// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    using System.Text.RegularExpressions;

    public enum BooleanKinds
    {
        Normal,     // true     :   false
        Mode,       // enable   :   disable
        Switch,     // on       :   off
    }

    public sealed class BooleanFx : UnsignedIntegralFx<bool>
    {
        private const string False = "false", Off = "off", Disable = "disable";
        private const string True = "true", On = "on", Enable = "enable";
        public BooleanKinds BooleanKind { get; set; }
        protected override RegexOptions Options => RegexOptions.IgnoreCase;

        protected override string ValuePattern => $"({False}|{Off}|{Disable}|{True}|{On}|{Enable})";

        protected override bool TryGenerate(bool feed, out string value)
        {
            value = default;
            switch (this.BooleanKind)
            {
                case BooleanKinds.Normal:
                    value = feed ? True : False;
                    break;

                case BooleanKinds.Mode:
                    value = feed ? Enable : Disable;
                    break;

                case BooleanKinds.Switch:
                    value = feed ? On : Off;
                    break;
            }

            return true;
        }

        protected override bool TryParse(string feed, out bool result)
        {
            feed = feed.ToLower();
            result = false;
            if (result = feed == True)
                this.BooleanKind = BooleanKinds.Normal;
            else if (feed == False)
                this.BooleanKind = BooleanKinds.Normal;

            else if (result = feed == On)
                this.BooleanKind = BooleanKinds.Switch;
            else if (feed == Off)
                this.BooleanKind = BooleanKinds.Switch;

            else if (result = feed == Enable)
                this.BooleanKind = BooleanKinds.Mode;
            else if (feed == Disable)
                this.BooleanKind = BooleanKinds.Mode;


            return true;
        }
    }
    
}