
namespace Tsubaki.Configuration
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RouteAttribute : Attribute
    {
        public RouteAttribute(string file)
        {
            if (string.IsNullOrWhiteSpace(file))
                file = null;

            this.File = file;
        }

        internal string File { get; }
    }


}
