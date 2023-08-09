using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Entity;
using YiSha.Model;
using YiSha.Admin.Web.Controllers;
using YiSha.Entity.App;
using YiSha.Business.App;
using YiSha.Model.Param.App;

namespace YiSha.Admin.Web.Areas.App.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-07-11 15:31
    /// 描 述：比例配置控制器类
    /// </summary>
    [Area("App")]
    public class ProportionSettingController :  BaseController
    {
        private ProportionSettingBLL proportionSettingBLL = new ProportionSettingBLL();

        #region 视图功能
        [AuthorizeFilter("app:proportionsetting:view")]
        public ActionResult ProportionSettingIndex()
        {
            return View();
        }

        public ActionResult ProportionSettingForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:proportionsetting:search")]
        public async Task<ActionResult> GetListJson(ProportionSettingListParam param)
        {
            TData<List<ProportionSettingEntity>> obj = await proportionSettingBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:proportionsetting:search")]
        public async Task<ActionResult> GetPageListJson(ProportionSettingListParam param, Pagination pagination)
        {
            TData<List<ProportionSettingEntity>> obj = await proportionSettingBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(int id)
        {
            TData<ProportionSettingEntity> obj = await proportionSettingBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:proportionsetting:add,app:proportionsetting:edit")]
        public async Task<ActionResult> SaveFormJson(ProportionSettingEntity entity)
        {
            TData<string> obj = await proportionSettingBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:proportionsetting:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await proportionSettingBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
