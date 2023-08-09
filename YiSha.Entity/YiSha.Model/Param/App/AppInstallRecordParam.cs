using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using YiSha.Util;

namespace YiSha.Model.Param.App
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-07-11 15:25
    /// 描 述：安装记录实体查询类
    /// </summary>
    public class AppInstallRecordListParam
    {
        public string RealName { get; set; }
        public string UserName { get; set; }
        public string InstallDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public string InstallEndDate { get; set; }
        public string DepartmentIds { get; set; }
        public long? UserId { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public string Role { get; set; }
        public string Month { get; set; }
    }
}
