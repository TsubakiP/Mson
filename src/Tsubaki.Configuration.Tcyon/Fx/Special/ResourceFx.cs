// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

using System.Drawing;

namespace Tsubaki.Configuration.Tcyon.Fx
{
    public abstract class ResourceFx<T> : Fx<T>
    {
        protected override string ValuePattern => @"[^\]]+";
        protected override string SuffixPattern => @"\]";
        protected override string PrefixPattern => $@"{this.ResourcePattern}:\[";
        
        protected abstract string ResourcePattern { get; }
    }

}