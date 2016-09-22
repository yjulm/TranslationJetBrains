using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TranslationJetBrains
{
    public class Encrypt
    {
        /// <summary>
        /// DES 解密
        /// </summary>
        /// <param name="_str">待解密的 Base64 形式字符串</param>
        /// <param name="_key">密钥</param>
        /// <returns>解密后字符串</returns>
        public static string DESDecrypt(string _str, string _key)
        {
            using (DES des = DES.Create())
            {
                byte[] bt = Convert.FromBase64String(_str);
                byte[] KI = Encoding.UTF8.GetBytes(MD5Encrypt(_key).Substring(0, 8));
                des.Key = KI;
                des.IV = KI;

                using (MemoryStream ms = new MemoryStream())
                {
                    CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
                    cs.Write(bt, 0, bt.Length);
                    cs.FlushFinalBlock();

                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// DES 加密
        /// </summary>
        /// <param name="_str">待加密字符串</param>
        /// <param name="_key">密钥</param>
        /// <returns>加密后 Base64形式字符串</returns>
        public static string DESEncrypt(string _str, string _key)
        {
            using (DES des = DES.Create())
            {
                byte[] bt = Encoding.UTF8.GetBytes(_str);
                byte[] KI = Encoding.UTF8.GetBytes(MD5Encrypt(_key).Substring(0, 8));
                des.Key = KI;
                des.IV = KI;

                using (MemoryStream ms = new MemoryStream())
                {
                    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
                    cs.Write(bt, 0, bt.Length);
                    cs.FlushFinalBlock();

                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        /// <summary>
        /// MD5 加密
        /// </summary>
        /// <param name="_str"></param>
        /// <returns></returns>
        public static string MD5Encrypt(string _str)
        {
            using (MD5 md = MD5.Create())
            {
                byte[] bt = md.ComputeHash(Encoding.UTF8.GetBytes(_str));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bt.Length; i++)
                {
                    sb.Append(bt[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// SHA512 加密
        /// </summary>
        /// <param name="_str"></param>
        /// <returns></returns>
        public static string SHA512Encrypt(string _str)
        {
            using (SHA512 sha = SHA512.Create())
            {
                byte[] bt = sha.ComputeHash(Encoding.UTF8.GetBytes(_str));
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bt.Length; i++)
                {
                    sb.Append(bt[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}