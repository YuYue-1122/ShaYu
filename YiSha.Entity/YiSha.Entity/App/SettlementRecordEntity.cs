using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.App
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-07-13 14:07
    /// 描 述：结算记录实体类
    /// </summary>
    [Table("T_SettlementRecord")]
    public class SettlementRecordEntity : NewBaseExtensionEntity
    {
        /// <summary>
        /// 结算日期
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? SettlementDate { get; set; }
        /// <summary>
        /// 有效总量
        /// </summary>
        /// <returns></returns>
        public int? InstallCount { get; set; }
        /// <summary>
        /// 预估结算金额
        /// </summary>
        /// <returns></returns>
        public decimal? SettlementAmount { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        /// <returns></returns>
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// 实际结算金额（T+7）
        /// </summary>
        /// <returns></returns>
        public decimal? ActualSettlementAmount { get; set; }
        /// <summary>
        /// 实际单价（T+7之后才有数据）
        /// </summary>
        /// <returns></returns>
        public decimal? ActualUnitPrice { get; set; }
        /// <summary>
        /// 状态：0未结算；1已结算；
        /// </summary>
        public int Status { get; set; }

    }
}
