using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;
using System.Data;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json.Converters;
using System.Diagnostics;
using System.Xml;

namespace QinSoft.Wx.Common
{
    /// <summary>
    /// 基础拓展类
    /// </summary>
    public static class BaseTools
    {
        /// <summary>
        /// json日期默认格式
        /// </summary>
        public static DateTimeConverterBase DefaultDateTimeConvert = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
        /// <summary>
        /// 拓展方法：序列化对象成json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            if (null == obj)
            {
                return string.Empty;
            }
            else
            {
                try
                {
                    return JsonConvert.SerializeObject(obj, DefaultDateTimeConvert);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// 拓展方法：反序列化json字符串成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return default;
            }
            else
            {
                try
                {
                    return JsonConvert.DeserializeObject<T>(value);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                    return default;
                }
            }
        }

        /// <summary>
        /// 拓展方法：序列化对象成XML
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToXml(this object obj)
        {
            if (obj == null)
                return null;
            try
            {
                XmlSerializer xs = new XmlSerializer(obj.GetType(), new XmlRootAttribute("xml"));
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new XmlQualifiedName[] { new XmlQualifiedName(string.Empty, string.Empty) });
                using (StreamReader sr = new StreamReader(new MemoryStream()))
                {
                    XmlWriterSettings xws = new XmlWriterSettings();
                    xws.OmitXmlDeclaration = true;
                    xws.Encoding = Encoding.UTF8;
                    xws.Indent = true;
                    XmlWriter xwr = XmlWriter.Create(sr.BaseStream, xws);
                    sr.BaseStream.Position = 0;
                    xs.Serialize(xwr, obj, namespaces);
                    sr.BaseStream.Position = 0;
                    return sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return null;
            }
        }

        /// <summary>
        /// 拓展方法反序列化xml字符串成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T FromXml<T>(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return default;
            }
            try
            {
                using (StringReader sr = new StringReader(value))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T), new XmlRootAttribute("xml"));
                    return (T)xs.Deserialize(sr);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                return default;
            }
        }
        public static long ToTimeStamp(this DateTime Date)
        {
            switch (Date.Kind)
            {
                case DateTimeKind.Utc:; break;
                case DateTimeKind.Local: Date = Date.ToUniversalTime(); break;
                case DateTimeKind.Unspecified: DateTime.SpecifyKind(Date, DateTimeKind.Local); break;
            }
            TimeSpan ts = Date - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)ts.TotalMilliseconds;
        }

        public static DateTime ToDateTime(this long TimeStamp)
        {
            DateTime Date = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            TimeSpan Span = new TimeSpan(TimeStamp);
            return Date.Add(Span);
        }
    }
}
