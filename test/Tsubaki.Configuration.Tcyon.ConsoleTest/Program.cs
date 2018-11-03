// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.X
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Text.RegularExpressions;
    
    using System.Reflection;
    using System.IO;
    using System.Runtime.Serialization;
    using System.ComponentModel;

    internal class Program
    { 
        private static void Main(string[] args)
        {
            try
            {
                var entity = YourClass.Load();
                if (entity.Text is string s)
                {
                    Console.WriteLine(s);
                    Console.WriteLine(entity.IgnoreMe);
                    entity.Text = null;
                }
                else
                {
                    Console.WriteLine(entity.IgnoreMe);
                    entity.Text = "反序列化成功";
                }
                entity.IgnoreMe = "Hello";
                entity.Save();
            }
            finally
            {
            }
            Console.ReadKey();
        }

        [Serializable]
        public class YourClass : SelfDisciplined<YourClass>
        {
            public YourClass()
            {

            }

            private YourClass(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }

            [Ignore]
            public string IgnoreMe { get; internal set; }
            public object Text { get; internal set; }
        }
    }
}