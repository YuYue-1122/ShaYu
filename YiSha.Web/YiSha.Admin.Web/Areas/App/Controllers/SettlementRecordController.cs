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
    /// 日 期：2021-07-13 14:07
    /// 描 述：结算记录控制器类
    /// </summary>
    [Area("App")]
    public class SettlementRecordController :  BaseController
    {
        private SettlementRecordBLL settlementRecordBLL = new SettlementRecordBLL();

        #region 视图功能
        [AuthorizeFilter("app:settlementrecord:view")]
        public ActionResult SettlementRecordIndex()
        {
            return View();
        }

        public ActionResult SettlementRecordForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:settlementrecord:search")]
        public async Task<ActionResult> GetListJson(SettlementRecordListParam param)
        {
            TData<List<SettlementRecordEntity>> obj = await settlementRecordBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:settlementrecord:search")]
        public async Task<ActionResult> GetPageListJson(SettlementRecordListParam param, Pagination pagination)
        {
            TData<List<SettlementRecordEntity>> obj = await settlementRecordBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(int id)
        {
            TData<SettlementRecordEntity> obj = await settlementRecordBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:settlementrecord:add,app:settlementrecord:edit")]
        public async Task<ActionResult> SaveFormJson(SettlementRecordEntity entity)
        {
            TData<string> obj = await settlementRecordBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:settlementrecord:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await settlementRecordBLL.DeleteForm(ids);
            return Json(obj);
        }
        /// <summary>
        /// 计算佣金
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Calculation(int id)
        {
            TData<string> obj = await settlementRecordBLL.Calculation(id);
            return Json(obj);
        }
        
        #endregion
    }
}
