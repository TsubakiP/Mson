// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    public abstract class IntegralFx<T> : Fx<T> where T : struct
    {
        protected override string ValuePattern => @"-?\d+";
    }
}