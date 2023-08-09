using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace YiSha.Enum
{
    public enum ArticleCodeEnum
    {
        [Description("平台简介")]
        PlatformInfo = 1,
        [Description("新手指引")]
        NoviceGuide = 2,
        [Description("咨询协议")]
        Agreement = 3
    }
}
