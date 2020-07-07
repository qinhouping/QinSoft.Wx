﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Security;

namespace QinSoft.Wx.Common
{
    public static class HttpTools
    {
        public static string UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/66.0.3359.139 Safari/537.36";
        private static int ContentLength = 0;
        public static string ContentType = "application/x-www-form-urlencoded";
        public static string RequestEncoding = "utf-8";
        public static string ResponseEncoding = "utf-8";
        public static CookieContainer cookieContainer = new CookieContainer();

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        public static string UrlEncode(IDictionary<string, object> data)
        {
            IEnumerable<string> list = from item in data select string.Format("{0}={1}", HttpUtility.UrlEncode(item.Key), HttpUtility.UrlEncode(Convert.ToString(item.Value)));
            return string.Join("&", list);
        }

        public static IDictionary<string, object> UrlDecode(string url)
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            IEnumerable<string> list = url.Split('&');
            foreach (string item in list)
            {
                string[] kv = item.Split('=');
                result[HttpUtility.UrlDecode(kv[0])] = HttpUtility.UrlDecode(kv[1]);
            }
            return result;
        }

        public static WebResponse Get(string url, IDictionary<string, string> Headers, IDictionary<string, string> Cookies)
        {
            return Do(WebMethod.GET, url, Headers, Cookies);
        }

        public static T Get<T>(string url, IDictionary<string, string> Headers, IDictionary<string, string> Cookies)
        {
            return Do<T>(WebMethod.GET, url, Headers, Cookies, null);
        }

        public static WebResponse Post(string url, IDictionary<string, string> Headers, IDictionary<string, string> Cookies, string Data)
        {
            return Do(WebMethod.POST, url, Headers, Cookies, Data);
        }

        public static T Post<T>(string url, IDictionary<string, string> Headers, IDictionary<string, string> Cookies, object Data)
        {
            return Do<T>(WebMethod.POST, url, Headers, Cookies, Data);
        }

        public static WebResponse Delete(string url, IDictionary<string, string> Headers, IDictionary<string, string> Cookies)
        {
            return Do(WebMethod.DELETE, url, Headers, Cookies);
        }

        public static T Delete<T>(string url, IDictionary<string, string> Headers, IDictionary<string, string> Cookies)
        {
            return Do<T>(WebMethod.DELETE, url, Headers, Cookies);
        }

        public static WebResponse Put(string url, IDictionary<string, string> Headers, IDictionary<string, string> Cookies, string Data)
        {
            return Do(WebMethod.PUT, url, Headers, Cookies, Data);
        }

        public static T Put<T>(string url, IDictionary<string, string> Headers, IDictionary<string, string> Cookies, object Data)
        {
            return Do<T>(WebMethod.PUT, url, Headers, Cookies, Data);
        }

        public static WebResponse Options(string url, IDictionary<string, string> Headers, IDictionary<string, string> Cookies, string Data)
        {
            return Do(WebMethod.OPTIONS, url, Headers, Cookies, Data);
        }

        public static T Options<T>(string url, IDictionary<string, string> Headers, IDictionary<string, string> Cookies, object Data)
        {
            return Do<T>(WebMethod.OPTIONS, url, Headers, Cookies, Data);
        }

        private static WebResponse Do(WebMethod method, string url, IDictionary<string, string> Headers = null, IDictionary<string, string> Cookies = null, string data = null, int timeout = 60000)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            //方法
            request.Method = method.ToString();
            //超时
            request.Timeout = timeout;
            //用户标示
            request.UserAgent = UserAgent;
            //内容长度
            request.ContentLength = ContentLength;
            //内容类型
            request.ContentType = ContentType;
            //cookie容器
            request.CookieContainer = cookieContainer;

            if (Headers != null)
            {
                foreach (string key in Headers.Keys)
                {
                    string value = Headers[key];
                    Type type = request.GetType();
                    PropertyInfo info = type.GetProperty(key.Replace("-", ""));
                    if (info != null)
                    {
                        info.SetValue(request, value, null);
                    }
                    else
                    {
                        request.Headers.Add(key, value);
                    }
                }
            }
            if (Cookies != null)
            {
                foreach (String key in Cookies.Keys)
                {
                    string value = Headers[key];
                    request.Headers.Add("Cookie", key + "=" + value);
                }
            }
            if (!string.IsNullOrEmpty(data))
            {
                byte[] bytes = Encoding.GetEncoding(RequestEncoding).GetBytes(data.ToString());
                request.ContentLength = bytes.Length;
                request.GetRequestStream().Write(bytes, 0, bytes.Length);
            }
            return request.GetResponse();
        }

        private static T Do<T>(WebMethod method, string url, IDictionary<string, string> Headers = null, IDictionary<string, string> Cookies = null, object data = null, int timeout = 60000)
        {
            if (Headers == null)
            {
                Headers = new Dictionary<string, string>();
            }
            Headers["Content-Type"] = "application/json";//Json
            HttpWebResponse response = Do(method, url, Headers, Cookies, data.ToJson(), timeout) as HttpWebResponse;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new InvalidOperationException(string.Format("返回状态异常:{0}", response.StatusCode.ToString()));
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(ResponseEncoding));
            string content = reader.ReadToEnd();
            Debug.WriteLine("httptools request:{0} response:{1}", url, content);
            return content.FromJson<T>();
        }

        /// <summary>
        /// 模拟Javascript Ajax请求 （异步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <param name="Success"></param>
        /// <param name="Error"></param>
        public static void RequestAsync<T>(HttpParams param, Action<T> Success, Action<Exception> Error)
        {
            Task.Factory.StartNew(() =>
            {
                RequestSync(param, Success, Error);
            });
        }

        /// <summary>
        /// 模拟Javascript Ajax请求 （同步）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        /// <param name="Success"></param>
        /// <param name="Error"></param>
        public static void RequestSync<T>(HttpParams param, Action<T> Success, Action<Exception> Error)
        {
            try
            {
                T response = Do<T>(param.Method, param.Url, param.Headers, param.Cookies, param.Data, param.Timeout);
                Success.Invoke(response);
            }
            catch (Exception e)
            {
                Error.Invoke(e);
            }
        }

        /// <summary>
        /// 异步文件上传
        /// </summary>
        /// <param name="url">上传路径</param>
        /// <param name="stream">文件流</param>
        /// <param name="name">名称</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="extData">其他数据</param>
        /// <returns>上传结果</returns>
        public static async Task<HttpResponseMessage> UploadAsync(string url, Stream stream, string name, string fileName, IDictionary<string, string> extData = null)
        {
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent(DateTime.Now.Ticks.ToString("X"));
            multipartFormDataContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
            multipartFormDataContent.Add(new StreamContent(stream), string.Format("\"{0}\"", name), string.Format("\"{0}\"", fileName));

            if (extData == null)
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.PostAsync(url, multipartFormDataContent);
                return response;
            }
            else
            {
                foreach (string key in extData.Keys)
                {
                    multipartFormDataContent.Add(new StringContent(extData[key]), string.Format("\"{0}\"", key));
                }
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.PostAsync(url, multipartFormDataContent);
                return response;
            }
        }

        /// <summary>
        /// 异步文件上传
        /// </summary>
        /// <typeparam name="T">结果泛型</typeparam>
        /// <param name="url">上传路径</param>
        /// <param name="stream">文件流</param>
        /// <param name="name">名称</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="extData">其他数据</param>
        /// <returns>上传结果</returns>
        public static async Task<T> UploadAsync<T>(string url, Stream stream, string name, string fileName, IDictionary<string, string> extData = null)
        {
            HttpResponseMessage response = await UploadAsync(url, stream, name, fileName, extData);
            string content = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("httptools request:{0} response:{1}", url, content);
            return content.FromJson<T>();
        }

        /// <summary>
        /// 异步文件下载
        /// </summary>
        /// <param name="url">下载路径</param>
        /// <param name="Headers">请求头部</param>
        /// <param name="Cookies">cookie</param>
        /// <param name="timeout">超时</param>
        /// <returns>文件流</returns>
        public static Task<Stream> DownloadAsync(string url, IDictionary<string, string> Headers = null, IDictionary<string, string> Cookies = null, int timeout = 60000)
        {
            return DownloadAsync(WebMethod.GET, url, Headers, Cookies, null, timeout);
        }

        /// <summary>
        /// 异步文件下载
        /// </summary>
        /// <param name="method">请求方法</param>
        /// <param name="url">下载路径</param>
        /// <param name="Headers">请求头部</param>
        /// <param name="Cookies">cookie</param>
        /// <param name="timeout">超时</param>
        /// <returns>文件流</returns>
        public static Task<Stream> DownloadAsync(WebMethod method, string url, IDictionary<string, string> Headers = null, IDictionary<string, string> Cookies = null, object data = null, int timeout = 60000)
        {
            return Task.Factory.StartNew(() =>
            {
                if (Headers == null)
                {
                    Headers = new Dictionary<string, string>();
                }
                Headers["Content-Type"] = "application/json";//Json
                WebResponse response = Do(method, url, Headers, Cookies, data.ToJson(), timeout);
                return response.GetResponseStream();
            });
        }
    }

    public class HttpParams
    {
        public WebMethod Method { get; set; }
        public string Url { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public IDictionary<string, string> Cookies { get; set; }
        public Object Data { get; set; }
        public int Timeout { get; set; }

        public HttpParams()
        {
            Timeout = 60000;
        }
    }

    public enum WebMethod
    {
        GET,
        POST,
        DELETE,
        PUT,
        OPTIONS
    }
}
