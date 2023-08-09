using System;
using System.Collections.Generic;
using System.Text;

namespace YiSha.Business.WeChat.Model
{
    public static class WeChatApiUrl
    {
        /// <summary>
        /// 全局Token 
        /// </summary>
        public const string ClientAccessTokenApiUrl = "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}";

        /// <summary>
        /// 统一服务消息 
        /// </summary>
        public const string UniformSendApiUrl = "https://api.weixin.qq.com/cgi-bin/message/wxopen/template/uniform_send?access_token={0}";
        /// <summary>
        /// 客服消息
        /// </summary>
        public const string CustomerServiceMessageApiUrl = "https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}";
        /// <summary>
        /// 订阅消息
        /// </summary>
        public const string SubscribeMessageApiUrl = "https://api.weixin.qq.com/cgi-bin/message/subscribe/send?access_token={0}";
    }
}
