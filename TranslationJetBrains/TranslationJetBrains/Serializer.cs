using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace TranslationJetBrains
{
    public sealed class Serializer
    {
        private Serializer()
        {
        }

        //////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 将继承自Serializer.Person的对象序列化为JSON字符串
        /// </summary>
        /// <typeparam name="T">继承自Serializer.Person的数据协定类</typeparam>
        /// <param name="_per">待反序列化的Person对象</param>
        /// <returns>JSON字符串</returns>
        public static string GetJsonStr<T>(T _per) where T : Person      //利用泛型，动态的改变参数类型，不再局限为Person类
        {
            var mstr = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(T));
            ser.WriteObject(mstr, _per);
            mstr.Position = 0;

            var sr = new StreamReader(mstr, Encoding.UTF8);
            return sr.ReadToEnd();
        }

        /// <summary>
        /// 将JSON字符串写入内存流
        /// </summary>
        /// <param name="_str">JSON字符串</param>
        /// <returns>MemoryStream对象</returns>
        public static MemoryStream GetMemoryStream(string _str)
        {
            Byte[] bt = Encoding.UTF8.GetBytes(_str);

            var mstr = new MemoryStream();
            mstr.Write(bt, 0, bt.Length);
            mstr.Position = 0;      //将流位置复原，不然后面读取操作时在流的末尾会读取不到数据

            return mstr;
        }

        /// <summary>
        /// 将JSON字符串反序列化为继承自Serializer.Person的对象
        /// </summary>
        /// <typeparam name="T">继承自Serializer.Person的数据协定类</typeparam>
        /// <param name="_str">待序列化的JSON字符串</param>
        /// <returns>继承自Serializer.Person的对象</returns>
        public static T GetPerson<T>(string _str) where T : Person      //同样利用泛型，动态的指定目标类，不再局限于Person类
        {
            Byte[] bt = Encoding.UTF8.GetBytes(_str);

            var mstr = new MemoryStream();
            mstr.Write(bt, 0, bt.Length);
            mstr.Position = 0;

            var ser = new DataContractJsonSerializer(typeof(T));
            return (T)ser.ReadObject(mstr);
        }

        /// <summary>
        /// 空的数据协定类,此类必须被继承其他方法才有效
        /// </summary>
        [DataContract]
        public class Person { }

        //////////////////////////////////////////////////////////////////////////////////////
    }
}