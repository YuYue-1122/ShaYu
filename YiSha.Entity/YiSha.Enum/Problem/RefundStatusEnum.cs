using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace YiSha.Enum.Problem
{
    public enum RefundStatusEnum
    {
        [Description("已申请待审核")]
        ApplyRefund = 1,
        [Description("审核通过等待退款")]
        ApplySuccess = 2,
        [Description("退款成功")]
        Success = 3,
        [Description("驳回")]
        Fail = 4,
    }
}
