using GoogleTranslateToken;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace TranslationJetBrains
{
    /// <summary>
    /// 本类主要用来进行发起翻译请求，
    /// 以及对服务器的返回结果做处理
    /// </summary>
    public class Client
    {
        /// <summary>
<<<<<<< HEAD
        /// 最新的翻译服务  APPID 与 KEY 需要自己申请
=======
        /// 最新的翻译服务
>>>>>>> cb77de2cffca8fc5282ea4ccd87961a8005d381b
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string TranslateFromNewService(string str)
        {
            string salt = new Random().Next(10000, 100000).ToString();
<<<<<<< HEAD
            string sign = Encrypt.MD5Encrypt(string.Format("{0}{1}{2}{3}", "APPID", str, salt, "KEY")).ToLower();
            string url = string.Format("http://api.fanyi.baidu.com/api/trans/vip/translate?q={0}&from=en&to=zh&appid={1}&salt={2}&sign={3}", HttpUtility.UrlEncode(str, Encoding.UTF8), "APPID", salt, sign);
=======
            string sign = Encrypt.MD5Encrypt(string.Format("{0}{1}{2}{3}", "20160623000023862", str, salt, "zBk6_inCQHi2931gn29p")).ToLower();
            string url = string.Format("http://api.fanyi.baidu.com/api/trans/vip/translate?q={0}&from=en&to=zh&appid=20160623000023862&salt={1}&sign={2}", HttpUtility.UrlEncode(str, Encoding.UTF8), salt, sign);
>>>>>>> cb77de2cffca8fc5282ea4ccd87961a8005d381b

            WebRequest req = WebRequest.Create(url);
            WebResponse res = req.GetResponse();
            using (Stream st = res.GetResponseStream())
            {
                StreamReader sr = new StreamReader(st);
                return sr.ReadToEnd().Trim();
            }
        }

        /// <summary>
        /// 谷歌翻译服务
        /// </summary>
        /// <param name="str">待翻译字符串</param>
        /// <param name="TKK">TKK值</param>
        /// <returns>直接返回结果，不必再解析</returns>
        public string TranslateFromGoogleService(string str, string TKK)
        {
            if (str.IsNullOrEmptyOrSpace() || TKK.IsNullOrEmptyOrSpace()) return null;
            Token token = new Token();

            /// client 固定参数
            /// sl 选择语言
            /// tl 目标语言
            /// ie 输入编码
            /// oe 输出编码
            /// dt 固定参数
            /// tk Token值
            /// q  翻译字符，需要urlencode

            string url = "https://203.208.39.255:443/translate_a/single?client=t&sl=en&tl=zh-CN&ie=UTF-8&oe=UTF-8&dt=t";
            url += string.Format("&tk={0}&q={1}", token.GetToken(str, TKK), HttpUtility.UrlEncode(str, Encoding.UTF8));

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Host = "translate.google.cn";
            WebResponse res = req.GetResponse();
            using (Stream st = res.GetResponseStream())
            {
                StreamReader sr = new StreamReader(st);
                string data = sr.ReadToEnd().Trim();   // [[["标题","title",,,2]],,"en"]
                if (!data.IsNullOrEmptyOrSpace() && data.Length > 5)
                {
                    data = data.Substring(4, data.IndexOf("\",\"") - 4);
                    return data;
                }
                else return null;
            }
        }
    }
}