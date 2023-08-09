using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using YiSha.Business.WeChat.Model;
using YiSha.Cache.Factory;
using YiSha.Model.Result.WeChat;
using YiSha.Util;

namespace YiSha.Business.WeChat
{
    public class WeChatHelper
    {
        #region 获取全局AccessToken
        /// <summary>
        /// 获取该商会公众号的AccessToken
        /// </summary>
        /// <param name="tenantId">商会ID</param>
        /// <param name="appId">appId</param>
        /// <param name="appSecret">appSecret</param>
        /// <returns></returns>
        public static string GetAccessToken(string appId, string appSecret)
        {
            //string access_token = "46_6ngkP3tg6ZwWqcLFFPhVR8zdAo4vSxV2zoZRKSKRYB4ABEYVEc3D07FmKLUyUPfYu_Md-5bUoPGByqpIz3Up83M2e7nXHdNqUSMHl4nmunjWyF8-ws2VJUzTzRnhhn5-80LE4ieJ5hVnanoRSAZcAGAEML";
            string access_token = CacheFactory.Cache.GetCache<string>("AccessToken");
            if (!string.IsNullOrEmpty(access_token))
            {
                return access_token;
            }
            //获取access_token
            string url = string.Format(WeChatApiUrl.ClientAccessTokenApiUrl, appId, appSecret);
            string result = HttpHelper.HttpGet(url);

            LogHelper.Info("access_token35--" + result);
            AccessTokenModel accessTokenModel = JsonHelper.ToObject<AccessTokenModel>(result);
            if (!string.IsNullOrEmpty(accessTokenModel.errcode))
            {
                return null;
            }
            access_token = accessTokenModel.access_token;
            CacheFactory.Cache.SetCache("AccessToken", access_token, DateTime.Now.AddSeconds(6900));
            return access_token;
        }
        #endregion

        #region 发送统一服务消息
        /// <summary>
        /// 发送统一服务消息
        /// </summary>
        /// <param name="appId">appId</param>
        /// <param name="appSecret">appSecret</param>
        /// <param name="data">发送用户消息内容等</param>
        /// <returns></returns>
        public static string UniformSend(string appId, string appSecret, string data)
        {
            string access_token = GetAccessToken(appId, appSecret);
            if (string.IsNullOrEmpty(access_token))
            {
                return "accesstoken获取失败";
            }
            string url = string.Format(WeChatApiUrl.UniformSendApiUrl, access_token);

            string result = HttpHelper.HttpPost(url, data);
            JObject jobject = JsonHelper.ToJObject(result);
            if (jobject["errcode"].ToString() == "0")
            {
                return "1";
            }
            LogHelper.Info("UniformSend--" + jobject["errmsg"]);
            return jobject["errmsg"].ToString();
        }
        #endregion

        #region 发送客服消息
        /// <summary>
        /// 发送客服消息
        /// </summary>
        /// <param name="appId">appId</param>
        /// <param name="appSecret">appSecret</param>
        /// <param name="data">发送用户消息内容等</param>
        /// <returns></returns>
        public static string CustomerServiceMessageSend(string appId, string appSecret, string data)
        {
            string access_token = GetAccessToken(appId, appSecret);
            if (string.IsNullOrEmpty(access_token))
            {
                return "accesstoken获取失败";
            }
            string url = string.Format(WeChatApiUrl.CustomerServiceMessageApiUrl, access_token);

            string result = HttpHelper.HttpPost(url, data);
            JObject jobject = JsonHelper.ToJObject(result);
            if (jobject["errcode"].ToString() == "0")
            {
                return "1";
            }
            LogHelper.Info("UniformSend--" + jobject["errmsg"]);
            return jobject["errmsg"].ToString();
        }
        #endregion

        #region 发送订阅消息
        /// <summary>
        /// 发送订阅消息
        /// </summary>
        /// <param name="appId">appId</param>
        /// <param name="appSecret">appSecret</param>
        /// <param name="data">发送用户消息内容等</param>
        /// <returns></returns>
        public static string SubscribeMessageSend(string appId, string appSecret, string data)
        {
            string access_token = GetAccessToken(appId, appSecret);
            if (string.IsNullOrEmpty(access_token))
            {
                return "accesstoken获取失败";
            }
            string url = string.Format(WeChatApiUrl.SubscribeMessageApiUrl, access_token);

            string result = HttpHelper.HttpPost(url, data);
            JObject jobject = JsonHelper.ToJObject(result);
            if (jobject["errcode"].ToString() == "0")
            {
                return "1";
            }
            LogHelper.Info("SubscribeMessageSend--" + jobject["errmsg"]);
            return jobject["errmsg"].ToString();
        }
        #endregion
    }
}
