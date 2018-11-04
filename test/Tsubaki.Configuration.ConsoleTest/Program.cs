// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.X
{
    using System;

    using Tsubaki.Configuration.Attributes;

    internal class P
    {
        [Route("v.yml")]
        public class Template : SelfDisciplined<Template>
        {
            public string Value { get; set; }
        }

        private static void Main(string[] args)
        {
            var temp = Template.Load();
            Console.WriteLine(temp.Value = "SSSSSSSS");
            temp.Save();

            Console.ReadKey();
            return;
        }
    }
}