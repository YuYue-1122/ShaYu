using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace YiSha.Enum.Problem
{
    public enum BillTypeEnum
    {
        [Description("消费")]
        XiaoFei = 1,
        [Description("收入")]
        ShouRu = 2,
        [Description("提现")]
        TiXian = 3,
        [Description("退款")]
        TuiKuan = 4,
    }
}
