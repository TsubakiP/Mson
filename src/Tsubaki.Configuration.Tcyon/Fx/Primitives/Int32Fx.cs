
namespace Tsubaki.Configuration.Tcyon.Fx
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class Int32Fx : IntegralFx<int>
    {
        protected override string SuffixPattern => null;
        protected override bool TryParse(string feed, out int result) => int.TryParse(feed, out result);

        protected override bool TryGenerate(int feed, out string value)
        {
            value = feed.ToString();
            return true;
        }
    }
}
