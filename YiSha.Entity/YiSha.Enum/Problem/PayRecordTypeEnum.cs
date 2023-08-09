using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace YiSha.Enum.Problem
{
    public enum PayRecordTypeEnum
    {
        [Description("问题支付")]
        Problem = 1,

        [Description("退款")]
        Refund = 2,

        [Description("提现")]
        CashOut = 3,

        [Description("专家入驻")]
        EntryExperts = 4,

        [Description("追问支付")]
        AddProblemDetail = 5,

    }

    public enum PayRecordStatusEnum
    {
        [Description("未支付")]
        NotPay = 0,

        [Description("支付成功")]
        Success = 1,

        [Description("支付失败")]
        PayError = 2
    }
}
