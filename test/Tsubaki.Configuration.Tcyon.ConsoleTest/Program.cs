// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon.X
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using Tsubaki.Configuration.Tcyon.Fx;


    internal class Program
    {

        private static void Main(string[] args)
        {
             
            var feed = @"
- A : 12s
- B :456.2m
- C : 777
- D : 
uri:[http://x.com]
- E : true
- F:   ON
- G: Off
- H:  'off'
";
            var fx = new BooleanFx();

            /*var sss = fx.Build(feed, new Uri("http://x.com") ).ToList();

            foreach (var item in sss)
            {
                Console.WriteLine(item);
            }*/

            foreach (var item in fx.Fetch(feed))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
            return;
            
        }
    }
}