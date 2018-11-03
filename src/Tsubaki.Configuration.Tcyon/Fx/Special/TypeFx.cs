// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.Fx
{
    using System;
    using System.Text;

    public sealed class TypeFx : ResourceFx<Type>
    {
        protected override string ResourcePattern => "type";
        protected override bool TryParse(string feed, out Type result)
        {
            result = default;
            if (!this.UseBase64)
            {
                if (string.IsNullOrWhiteSpace(feed))
                    return false;
                if (Type.GetType(feed, false) is Type t)
                {
                    result = t;
                    return true;
                }
            }
            return this.FromBase64(feed, out result);
        }
        protected override bool TryGenerate(Type feed, out string value)
        {
            value = this.UseBase64 ? this.ToBase64(feed) : feed.AssemblyQualifiedName;
            return true;
        }

        public bool UseBase64 { get; set; }
        
        private string ToBase64(Type t)
        {
            var bytes = Encoding.UTF8.GetBytes(t.AssemblyQualifiedName);
            var base64 = Convert.ToBase64String(bytes);
            return base64;
        }
        private bool FromBase64(string base64, out Type result)
        {
            result = default;
            if (string.IsNullOrWhiteSpace(base64))
                return false;
            
            try
            {
                var bytes = new byte[0];
                bytes = Convert.FromBase64String(base64);
                base64 = Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                return false;
            }

            if (Type.GetType(base64, false) is Type t)
            {
                result = t;
                return true;
            }

            return false;
        }
        
    }
}