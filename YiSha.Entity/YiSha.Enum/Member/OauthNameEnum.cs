using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace YiSha.Enum.Member
{
    /// <summary>
    /// 授权平台
    /// </summary>
    public enum OauthNameEnum
    {
        [Description("公众号")]
        WeChat,
        [Description("小程序")]
        WeApp,
    }
}
