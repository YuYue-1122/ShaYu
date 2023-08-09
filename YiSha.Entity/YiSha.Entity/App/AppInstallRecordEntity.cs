using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using YiSha.Util;
using System.ComponentModel;

namespace YiSha.Entity.App
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-07-11 15:25
    /// 描 述：安装记录实体类
    /// </summary>
    [Table("T_AppInstallRecord")]
    public class AppInstallRecordEntity : NewBaseExtensionEntity
    {
        /// <summary>
        /// 店员Id
        /// </summary>
        /// <returns></returns>
        public long? UserId { get; set; }
        /// <summary>
        /// App名称
        /// </summary>
        /// <returns></returns>
        public string AppName { get; set; }
        /// <summary>
        /// 包名
        /// </summary>
        /// <returns></returns>
        public string AppApkName { get; set; }
        [Description("IMEI")]
        /// <summary>
        /// 设备IMEI
        /// </summary>
        /// <returns></returns>
        public string IMEI { get; set; }

        [Description("创建日期")]
        /// <summary>
        /// 安装日期
        /// </summary>
        /// <returns></returns>
        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime? InstallDate { get; set; }

        [Description("合作伙伴预估收益")]
        /// <summary>
        /// 合作伙伴收益
        /// </summary>
        /// <returns></returns>
        public decimal? PartnerProfit { get; set; }
        [Description("代理商预估收益")]
        /// <summary>
        /// 代理商收益
        /// </summary>
        /// <returns></returns>
        public decimal? AgentProfit { get; set; }
        [Description("店员预估收益")]
        /// <summary>
        /// 店员收益
        /// </summary>
        /// <returns></returns>
        public decimal? ClerkProfit { get; set; }

        /// <summary>
        /// 广告来源：1鲨鱼宝；2海螺广告。
        /// </summary>
        /// <returns></returns>
        public int? AdvertFrom { get; set; }

        [Description("用户姓名")]
        /// <summary>
        /// 店员姓名
        /// </summary>
        [NotMapped]
        public string RealName { get; set; }

        [Description("用户名")]
        /// <summary>
        /// 用户名
        /// </summary>
        [NotMapped]
        public string UserName { get; set; }

        [Description("门店")]
        /// <summary>
        /// 门店名称
        /// </summary>
        [NotMapped]
        public string StoreName { get; set; }
        [Description("经销商")]
        /// <summary>
        /// 经销商名称
        /// </summary>
        [NotMapped]
        public string AgentName { get; set; }
        [Description("合作伙伴")]
        /// <summary>
        /// 合作伙伴名称
        /// </summary>
        [NotMapped]
        public string PartnerName { get; set; }

        //[Description("IMEI数")]
        ///// <summary>
        ///// IMEI数
        ///// </summary>
        //[NotMapped]
        //public string IMEICount { get; set; }

        [Description("下载安装数")]
        /// <summary>
        /// 安装应用数
        /// </summary>
        [NotMapped]
        public int AppCount { get; set; }

        [NotMapped]
        /// <summary>
        /// 预估单价
        /// </summary>
        public decimal? UnitPrice { get; set; }

        [NotMapped]
        /// <summary>
        /// 实际单价
        /// </summary>
        public decimal? ActualUnitPrice { get; set; }

        [NotMapped]
        /// <summary>
        /// 合作伙伴比例
        /// </summary>
        /// <returns></returns>
        public decimal? PartnerProportion { get; set; }

        [NotMapped]
        /// <summary>
        /// 代理商比例
        /// </summary>
        /// <returns></returns>
        public decimal? AgentProportion { get; set; }

        [NotMapped]
        /// <summary>
        /// 店员比例
        /// </summary>
        /// <returns></returns>
        public decimal? ClerkProportion { get; set; }

        [Description("合作伙伴实际收益")]
        [NotMapped]
        public decimal? PartnerActualProfit { get; set; }

        [Description("代理商实际收益")]
        [NotMapped]
        public decimal? AgentActualProfit { get; set; }

        [Description("店员实际收益")]
        [NotMapped]
        public decimal? ClerkActualProfit { get; set; }

    }
}
