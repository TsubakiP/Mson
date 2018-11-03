// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    using System;

    public sealed class DateTimeFx : ResourceFx<DateTime>
    {
        protected override string ResourcePattern => "time";

        protected override bool TryGenerate(DateTime feed, out string value)
        {
            value = this.ToBase64(feed);
            return true;
        }

        protected override bool TryParse(string feed, out DateTime result)
        {
            return this.FromBase64(feed, out result);
        }

        private bool FromBase64(string base64, out DateTime time)
        {
            time = default;
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
            var ticks = BitConverter.ToInt64(bytes, 0);
            if (ticks > 7767064994427387903)
                return false;

            time = DateTime.FromBinary(ticks);
            return true;
        }

        private string ToBase64(DateTime time)
        {
            var bytes = BitConverter.GetBytes(time.Ticks);
            var base64 = Convert.ToBase64String(bytes);
            return base64;
        }

    }
}