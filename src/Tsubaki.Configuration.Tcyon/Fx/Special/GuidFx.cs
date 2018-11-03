// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    using System;

    public sealed class GuidFx : ResourceFx<Guid>
    {
        protected override string ResourcePattern => "guid";

        protected override bool TryGenerate(Guid feed, out string value)
        {
            value = this.ToBase64(feed);
            return true;
        }

        protected override bool TryParse(string feed, out Guid result)
        {
            return this.FromBase64(feed, out result);
        }


        private string ToBase64(Guid guid)
        {
            var bytes = guid.ToByteArray();
            var base64 = Convert.ToBase64String(bytes);
            return base64;
        }

        private bool FromBase64(string base64, out Guid guid)
        {
            guid = default;
            if (string.IsNullOrWhiteSpace(base64))
                return false;
            var bytes = new byte[0];
            try
            {
                bytes = Convert.FromBase64String(base64);
            }
            catch
            {
                return false;
            }

            if (bytes.Length != 16)
                return false;
            guid = new Guid(bytes);
            return true;
        }
    }
}