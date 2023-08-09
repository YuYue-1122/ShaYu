using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YiSha.Util
{
    public class SecurityHelper
    {
        /// <summary>
        /// 用MD5加密字符串，可选择生成16位或者32位的加密字符串
        /// </summary>
        /// <param name="str">待加密的字符串</param>
        /// <param name="bit">位数，一般取值16 或 32</param>
        /// <returns>返回的加密后的字符串</returns>
        public static string MD5Encrypt(string str, int bit = 32)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] hashedDataBytes;
            hashedDataBytes = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sb = new StringBuilder();
            foreach (byte i in hashedDataBytes)
            {
                sb.Append(i.ToString("x2"));
            }
            if (bit == 16)
            {
                return sb.ToString().Substring(8, 16).ToLower();
            }
            else
            {
                return sb.ToString().ToLower();
            }
        }

        public static string GetGuid()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty).ToLower();
        }

        public static bool IsSafeSqlParam(string value)
        {
            return !Regex.IsMatch(value, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        #region 获取客户端IP地址
        /// <summary>
        /// 获取客户端IP地址
        /// </summary>
        /// <returns>若失败则返回默认地址</returns>
        public static string GetHostAddress()
        {
            HttpContextAccessor context = new HttpContextAccessor();
            var ip = context.HttpContext?.Connection.RemoteIpAddress.ToString();
            return ip ?? "127.0.0.1";
        }
        #endregion
    }
}
