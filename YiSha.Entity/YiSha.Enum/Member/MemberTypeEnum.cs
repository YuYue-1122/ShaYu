using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace YiSha.Enum.Member
{
    public enum MemberTypeEnum
    {
        [Description("会员")]
        Member = 1,

        [Description("专家")]
        Expert = 2
    }
}
