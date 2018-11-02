// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.Tcyon
{
    using System;
    using System.Collections.Generic;

    using Tsubaki.Configuration.Tcyon.Internal;

    public sealed class Interpreter
    {
        private readonly static object s_locker = new object();

        private static volatile Interpreter s_instance;

        private readonly Dictionary<Type, IParserGlue> _dict;

        public static Interpreter Instance
        {
            get
            {
                lock (s_locker)
                {
                    if (s_instance == null)
                    {
                        lock (s_locker)
                        {
                            s_instance = new Interpreter();
                        }
                    }
                    return s_instance;
                }
            }
        }

        private Interpreter()
        {
            this._dict = new Dictionary<Type, IParserGlue>
            {
                [typeof(byte)] = new ByteParser(),
                [typeof(sbyte)] = new SByteParser(),
                [typeof(bool)] = new BooleanParser(),
                [typeof(short)] = new Int16Parser(),
                [typeof(ushort)] = new UInt16Parser(),
                [typeof(int)] = new Int32Parser(),
                [typeof(uint)] = new UInt32Parser(),
                [typeof(long)] = new Int64Parser(),
                [typeof(ulong)] = new UInt64Parser(),
                [typeof(double)] = new DoubleParser(),
                [typeof(float)] = new FloatParser(),
                [typeof(decimal)] = new DecimalParser(),
                [typeof(string)] = new StringParser(),
            };
        }

        public bool TryGet<T>(out IFieldParser<T> parser)
        {
            parser = default;
            if (this._dict.TryGetValue(typeof(T), out var p))
            {
                parser = (IFieldParser<T>)p;
                return true;
            }
            return false;
        }
    }
}