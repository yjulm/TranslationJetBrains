using System;

namespace TranslationJetBrains
{
    public static class Extension
    {
        /// <summary>
        /// 判断该元素是否是空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNullOrEmptyOrSpace(this object obj)
        {
            if (obj == null || obj is DBNull) return true;
            if (obj.ToString().Trim() == "") return true;
            return false;
        }

        /// <summary>
        /// 将字符转到unicode编码状态
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ConvertToUnicode(this string str)
        {
            string unicode = null;
            if (!str.IsNullOrEmptyOrSpace())
            {
                for (int i = 0; i < str.Length; i++)
                {
                    //string s = ((int)str[i]).ToString("x");     // 10 -> 16      进制转换
                    string s = Convert.ToString(str[i], 16);
                    if (s.Length == 2) s = "00" + s;        //长度不够就补位
                    if (s.Length == 3) s = "0" + s;
                    unicode += @"\u" + s;
                }
            }
            return unicode;
        }
    }
}