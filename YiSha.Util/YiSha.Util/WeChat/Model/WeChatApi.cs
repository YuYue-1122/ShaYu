using System;
using System.Collections.Generic;
using System.Text;

namespace YiSha.Util.WeChat.Model
{
    /// <summary>
    /// 微信API
    /// </summary>
    public static class WeChatApi
    {
        /// <summary>
        /// 授权API
        /// </summary>
        public const string OauthApiUrl = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope={2}&state={3}&connect_redirect=1#wechat_redirect";

        /// <summary>
        /// 通过授权Code获取access_token
        /// </summary>
        public const string AccessTokenApiUrl = " https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";

        /// <summary>
        /// 获取用户信息
        /// </summary>
        public const string GetUserInfoApiUrl = " https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN";

        /// <summary>
        /// 统一下单
        /// </summary>
        public const string UnifiedorderApiUrl = "https://api.mch.weixin.qq.com/pay/unifiedorder";

        /// <summary>
        /// 微信提现
        /// </summary>
        public const string TransfersApiUrl = "https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers";
        /// <summary>
        /// 退款
        /// </summary>
        public const string RefundApiUrl = "https://api.mch.weixin.qq.com/secapi/pay/refund";
    }
}
