using System.Threading.Tasks;

namespace TranslationJetBrains
{
    internal enum translateType
    {
        Baidu,
        Google
    }

    internal static class Translation
    {
        private static string TKK { get; set; }

        /// <summary>
        /// 百度翻译异步方法,
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static async Task<string> BaiduTranslateAsync(string line)
        {
            string jsonStr = await Task.Run(() =>       //等待翻译请求的结果
            {
                return new Client().TranslateFromNewService(line);
            });

            if (jsonStr.IndexOf("trans_result") > 0)        //翻译正确有返回结果
            {
                ApiStoreRetData data = Serializer.GetPerson<ApiStoreRetData>(jsonStr);
                string str = data.trans_result[0].dst;

                return str.ConvertToUnicode();
            }
            else return line;       //没有结果就是翻译出错，则直接返回原字符串
        }

        /// <summary>
        /// 谷歌翻译异步方法
        /// </summary>
        /// <param name="line"></param>
        /// <param name="tkk"></param>
        /// <returns></returns>
        private static async Task<string> GoogleTranslateAsync(string line)
        {
            if (TKK.IsNullOrEmptyOrSpace())
            {
                TKK = new GoogleTranslateToken.TKK().GetTKK();
            }

            string retStr = await Task.Run(() =>
            {
                return new Client().TranslateFromGoogleService(line, TKK);
            });

            if (retStr.IsNullOrEmptyOrSpace()) return line;

            return retStr.ConvertToUnicode();
        }

        /// <summary>
        /// 开始翻译方法
        /// </summary>
        /// <param name="line">待翻译字符串</param>
        /// <param name="type">使用的翻译服务</param>
        /// <returns></returns>
        internal static async Task<string> BeginTranslationAsync(string line, translateType type)
        {
            try
            {
                switch (type)
                {
                    case translateType.Baidu:
                        return await BaiduTranslateAsync(line);

                    case translateType.Google:
                        return await GoogleTranslateAsync(line);

                    default:
                        return await BaiduTranslateAsync(line);
                }
            }
            catch (System.Net.WebException ex)
            {
                throw new System.Net.WebException(ex.Message);
            }
        }
    }
}