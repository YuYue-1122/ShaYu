using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.App
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-07-13 14:07
    /// 描 述：结算记录实体查询类
    /// </summary>
    public class SettlementRecordListParam
    {
        public DateTime? SettlementDate { get; set; }
    }
}
