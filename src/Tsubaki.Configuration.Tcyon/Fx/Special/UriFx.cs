// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    using System;

    public sealed class UriFx : ResourceFx<Uri>
    {
        protected override string ResourcePattern => "uri";
        protected override bool TryParse(string feed, out System.Uri result) => System.Uri.TryCreate(feed, UriKind.RelativeOrAbsolute, out result);
        protected override bool TryGenerate(Uri feed, out string value)
        {
            value = feed.ToString();
            return true;
        }
    }
}