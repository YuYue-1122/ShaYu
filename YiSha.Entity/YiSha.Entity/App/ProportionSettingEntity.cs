using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;

namespace YiSha.Entity.App
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-07-11 15:31
    /// 描 述：比例配置实体类
    /// </summary>
    [Table("T_ProportionSetting")]
    public class ProportionSettingEntity : NewBaseExtensionEntity
    {
        /// <summary>
        /// 合作伙伴比例
        /// </summary>
        /// <returns></returns>
        public decimal? PartnerProportion { get; set; }
        /// <summary>
        /// 代理商比例
        /// </summary>
        /// <returns></returns>
        public decimal? AgentProportion { get; set; }
        /// <summary>
        /// 店员比例
        /// </summary>
        /// <returns></returns>
        public decimal? ClerkProportion { get; set; }
    }
}
