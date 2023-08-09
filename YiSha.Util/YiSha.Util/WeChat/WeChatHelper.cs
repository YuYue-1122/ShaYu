using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using YiSha.Util.WeChat.Model;

namespace YiSha.Util.WeChat
{
    /// <summary>
    /// 微信帮助类
    /// </summary>
    public static class WeChatHelper
    {
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="code">微信返回的Code</param>
        /// <param name="appId">AppId</param>
        /// <param name="appSecret">AppSecret</param>
        /// <returns></returns>
        public static AccessTokenResult GetAccessToken(string code, string appId, string appSecret)
        {
            string url = string.Format(WeChatApi.AccessTokenApiUrl, appId, appSecret, code);
            string result = HttpHelper.HttpGet(url);
            JObject jobject = JsonHelper.ToJObject(result);
            AccessTokenResult obj = null;
            if (jobject.ContainsKey("errcode"))
            {
                LogHelper.Info("GetAccessToken--" + jobject["errmsg"]);
                return obj;
            }
            obj = JsonHelper.ToObject<AccessTokenResult>(result);
            return obj;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="access_token">access_token</param>
        /// <param name="openId">用户唯一标识</param>
        /// <returns></returns>
        public static UserInfoResult GetUserInfo(string access_token, string openId)
        {
            string url = string.Format(WeChatApi.GetUserInfoApiUrl, access_token, openId);
            string result = HttpHelper.HttpGet(url);
            JObject jobject = JsonHelper.ToJObject(result);
            UserInfoResult obj = null;
            if (jobject.ContainsKey("errcode"))
            {
                LogHelper.Info("GetUserInfo--" + jobject["errmsg"]);
                return obj;
            }
            obj = JsonHelper.ToObject<UserInfoResult>(result);
            return obj;
        }
    }
}
