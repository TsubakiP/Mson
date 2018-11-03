
namespace Tsubaki.Configuration
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;


    public abstract class SelfDisciplined<T> : IDisposable, ISerializable where T : class, new()
    {
        protected SelfDisciplined()
        {

        }
        public static T Load(bool createWithoutThrown = true)
        {
            var type = typeof(T);
            var file = type.GetCustomAttribute<RouteAttribute>() is RouteAttribute cf ? cf.File ?? type.Name : type.Name;
            var f = new FileInfo(file);
            var result = default(T);
            using (var fs = f.Open(FileMode.OpenOrCreate))
            {
                try
                {
                    var bf = new BinaryFormatter();
                    var obj = bf.Deserialize(fs);
                    result = (T)obj;
                }
                catch (SerializationException se)
                {
                    Debug.WriteLine(se.Message);
                    result = createWithoutThrown ? new T() : throw se;
                }
                finally
                {
                    fs.Dispose();
                }
            }
            return result;
        }

        public void Save()
        {
            var type = this.GetType();
            var file = type.GetCustomAttribute<RouteAttribute>() is RouteAttribute cf ? cf.File ?? type.Name : type.Name;
            var f = new FileInfo(file);
            using (var fs = f.Open(FileMode.OpenOrCreate))
            {
                try
                {
                    var bf = new BinaryFormatter();
                    bf.Serialize(fs, this);
                }
                catch (SerializationException se)
                {
                    Debug.WriteLine(se.Message);
                }
                finally
                {
                    fs.Dispose();
                }
            }
        }

        void IDisposable.Dispose() => this.Save();

        [EditorBrowsable(EditorBrowsableState.Never)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            var props = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for (int index = 0; index < props.Length; index++)
            {
                var current = props[index];
                if (current.SetMethod is null)
                    throw new NotSupportedException();
                else if (current.GetCustomAttribute<IgnoreAttribute>() is null)
                {
                    info.AddValue(current.Name, current.GetValue(this));
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected SelfDisciplined(SerializationInfo info, StreamingContext context)
        {
            var props = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for (int index = 0; index < props.Length; index++)
            {
                var current = props[index];
                if (current.SetMethod is null)
                    throw new NotSupportedException();
                else if (current.GetCustomAttribute<IgnoreAttribute>() is null)
                {
                    current.SetValue(this, info.GetValue(current.Name, current.PropertyType));
                }
            }
        }
    }


}
