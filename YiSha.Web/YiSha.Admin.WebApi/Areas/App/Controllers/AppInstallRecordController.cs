using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YiSha.Business.App;
using YiSha.Cache.Factory;
using YiSha.Entity.App;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Web.Code;

namespace YiSha.Admin.WebApi.Areas.App.Controllers
{
    /// <summary>
    /// 安装记录
    /// </summary>
    [Route("api/App/[controller]")]
    [ApiController]
    public class AppInstallRecordController : ControllerBase
    {
        private AppInstallRecordBLL appInstallRecordBLL = new AppInstallRecordBLL();

        #region 添加安装记录
        /// <summary>
        /// 添加安装记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<TData<string>> InstallApp([FromBody]AppInstallRecordEntity entity)
        {
            TData<string> obj = new TData<string>();
            OperatorInfo userModel =await Operator.Instance.Current(entity.Token);
            if (userModel == null)
            {
                obj.Message = "登录超时";
                obj.Tag = (int)Enum.TagEnum.LoginExpire;
                return obj;
            }
            if (entity == null||string.IsNullOrEmpty(entity.IMEI) || string.IsNullOrEmpty(entity.AppName) || string.IsNullOrEmpty(entity.AppApkName))
            {
                obj.Message = "参数不正确";
                return obj;
            }
            entity.UserId = userModel.UserId;
            obj = await appInstallRecordBLL.SaveForm(entity);
            return obj;
        }
        #endregion
    }
}
