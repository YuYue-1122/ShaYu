using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace YiSha.Enum.Problem
{
    public enum ProblemStatusEnum
    {
        [Description("暂存")]
        Save = 0,
        [Description("待认领")]
        DaiRenLing = 1,
        [Description("待解答")]
        DaiJieDa = 2,
        [Description("待评价")]
        DaiPingJia = 3,
        [Description("评价完成")]
        PingJiaWanCheng = 4,
        [Description("申请退款")]
        ApplyTuiKuan = 5,
        [Description("退款成功")]
        TuiKuanSuccess = 6,
        [Description("交易成功")]
        Success = 7,
        [Description("待支付")]
        DaiZhiFu = 8
    }
}
