using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace YiSha.Util.WeChat
{
    /// <summary>  
    /// 处理微信小程序用户数据的签名验证和解密  
    /// </summary>  
    public class WeChatAppDecrypt
    {
        private string appId;
        private string appSecret;
        /// <summary>  
        /// 构造函数  
        /// </summary>  
        /// <param name="appId">应用程序的AppId</param>  
        /// <param name="appSecret">应用程序的AppSecret</param>  
        public WeChatAppDecrypt(string appId, string appSecret)
        {
            this.appId = appId;
            this.appSecret = appSecret;
        }
        /// <summary>  
        /// 获取OpenId和SessionKey的Json数据包  
        /// </summary>  
        /// <param name="code">客户端发来的code</param>  
        /// <returns>Json数据包</returns>  
        private string GetOpenIdAndSessionKeyString(string code)
        {
            string temp = "https://api.weixin.qq.com/sns/jscode2session?" +
                "appid=" + appId
                + "&secret=" + appSecret
                + "&js_code=" + code
                + "&grant_type=authorization_code";

            return GetResponse(temp);

        }
        /// <summary>  
        /// GET请求  
        /// </summary>  
        /// <param name="url"></param>  
        /// <returns></returns>  
        public string GetResponse(string url)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        /// <summary>  
        /// 反序列化包含OpenId和SessionKey的Json数据包  
        /// </summary>  
        /// <param name="code">微信获取到的Code</param>  
        /// <returns>包含OpenId和SessionKey的类</returns>  
        public OpenIdAndSessionKey DecodeOpenIdAndSessionKey(string code)
        {
            OpenIdAndSessionKey oiask = JsonConvert.DeserializeObject<OpenIdAndSessionKey>(GetOpenIdAndSessionKeyString(code));
            if (!String.IsNullOrEmpty(oiask.errcode))
                return null;
            return oiask;
        }

        /// <summary>  
        /// 根据微信小程序平台提供的解密算法解密数据  
        /// </summary>  
        /// <param name="encryptedData">加密数据</param>  
        /// <param name="iv">初始向量</param>  
        /// <param name="sessionKey">从服务端获取的SessionKey</param>  
        /// <returns></returns>  
        public WechatUserInfo Decrypt(string encryptedData, string iv, string sessionKey)
        {
            WechatUserInfo userInfo;
            //创建解密器生成工具实例  
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            //设置解密器参数  
            aes.Mode = CipherMode.CBC;
            aes.BlockSize = 128;
            aes.Padding = PaddingMode.PKCS7;
            //格式化待处理字符串  
            byte[] byte_encryptedData = Convert.FromBase64String(encryptedData);
            byte[] byte_iv = Convert.FromBase64String(iv);
            byte[] byte_sessionKey = Convert.FromBase64String(sessionKey);

            aes.IV = byte_iv;
            aes.Key = byte_sessionKey;
            //根据设置好的数据生成解密器实例  
            ICryptoTransform transform = aes.CreateDecryptor();

            //解密  
            byte[] final = transform.TransformFinalBlock(byte_encryptedData, 0, byte_encryptedData.Length);

            //生成结果  
            string result = Encoding.UTF8.GetString(final);

            //反序列化结果，生成用户信息实例  
            userInfo = JsonConvert.DeserializeObject<WechatUserInfo>(result);

            return userInfo;

        }
    }
    /// <summary>  
    /// 微信小程序从服务端获取的OpenId和SessionKey信息结构  
    /// </summary>  
    public class OpenIdAndSessionKey
    {
        public string openid { get; set; }
        public string session_key { get; set; }
        public string errcode { get; set; }
        public string errmsg { get; set; }
    }
    /// <summary>  
    /// 微信小程序用户信息结构  
    /// </summary>  
    public class WechatUserInfo
    {
        public string openId { get; set; }
        public string nickName { get; set; }
        public string gender { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string avatarUrl { get; set; }
        public string unionId { get; set; }
        public Watermark watermark { get; set; }


        public string phoneNumber { get; set; }

        public string purePhoneNumber { get; set; }

        public string countryCode { get; set; }

        public class Watermark
        {
            public string appid { get; set; }
            public string timestamp { get; set; }
        }
    }
}
