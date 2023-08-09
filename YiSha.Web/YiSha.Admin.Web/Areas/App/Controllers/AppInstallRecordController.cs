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
using YiSha.Business.OrganizationManage;

namespace YiSha.Admin.Web.Areas.App.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-07-11 15:25
    /// 描 述：安装记录控制器类
    /// </summary>
    [Area("App")]
    public class AppInstallRecordController : BaseController
    {
        private AppInstallRecordBLL appInstallRecordBLL = new AppInstallRecordBLL();
        private DepartmentBLL departmentBLL = new DepartmentBLL();

        #region 视图功能
        [AuthorizeFilter("app:appinstallrecord:view")]
        public ActionResult AppInstallRecordIndex()
        {
            return View();
        }
        /// <summary>
        /// 合作伙伴查看页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AppInstallRecordPartnerIndex()
        {
            return View();
        }
        /// <summary>
        /// 经销商查看页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AppInstallRecordAgentIndex()
        {
            return View();
        }
        /// <summary>
        /// 店员查看页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AppInstallRecordStoreIndex()
        {
            return View();
        }
        public ActionResult AppInstallRecordForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("app:appinstallrecord:search")]
        public async Task<ActionResult> GetListJson(AppInstallRecordListParam param)
        {
            TData<List<AppInstallRecordEntity>> obj = await appInstallRecordBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("app:appinstallrecord:search")]
        public async Task<ActionResult> GetPageListJson(AppInstallRecordListParam param, Pagination pagination)
        {
            if (!string.IsNullOrEmpty(param.Role))
            {
                switch (param.Role)
                {
                    case "Partner":
                        param.DepartmentIds = (await departmentBLL.GetChildIds((long)user.DepartmentId)).Data;
                        break;
                    case "Agent":
                        param.DepartmentIds = (await departmentBLL.GetChildIds((long)user.DepartmentId)).Data;
                        break;
                    case "Store":
                        param.UserId = user.UserId;
                        break;
                }
            }
            TData<List<AppInstallRecordEntity>> obj = await appInstallRecordBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(int id)
        {
            TData<AppInstallRecordEntity> obj = await appInstallRecordBLL.GetEntity(id);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetInstallCount(string installDate)
        {
            TData<int> obj = await appInstallRecordBLL.GetInstallCount(installDate);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("app:appinstallrecord:add,app:appinstallrecord:edit")]
        public async Task<ActionResult> SaveFormJson(AppInstallRecordEntity entity)
        {
            TData<string> obj = await appInstallRecordBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("app:appinstallrecord:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await appInstallRecordBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion

        #region 导出数据

        #region 管理员导出
        [HttpPost]
        public async Task<IActionResult> ExportAllJson(AppInstallRecordListParam param)
        {
            TData<string> obj = new TData<string>();
            TData<List<AppInstallRecordEntity>> recordObj = await appInstallRecordBLL.GetList(param);
            if (recordObj.Tag == 1)
            {
                foreach (var item in recordObj.Data)
                {
                    item.ClerkProfit = Math.Round((decimal)(item.UnitPrice * item.AppCount * item.ClerkProportion), 2);
                    item.AgentProfit = Math.Round((decimal)(item.UnitPrice * item.AppCount * item.AgentProportion), 2);
                    item.PartnerProfit = Math.Round((decimal)(item.UnitPrice * item.AppCount * item.PartnerProportion), 2);
                    item.ClerkActualProfit = Math.Round((decimal)(item.ActualUnitPrice * item.AppCount * item.ClerkProportion), 2);
                    item.AgentActualProfit = Math.Round((decimal)(item.ActualUnitPrice * item.AppCount * item.AgentProportion), 2);
                    item.PartnerActualProfit = Math.Round((decimal)(item.ActualUnitPrice * item.AppCount * item.PartnerProportion), 2);
                }
                string file = new ExcelHelper<AppInstallRecordEntity>().ExportToExcel(param.InstallDate + "安装数据.xls",
                                                                          "安装数据",
                                                                          recordObj.Data,
                                                                          new string[] { "InstallDate", "RealName", "UserName", "StoreName", "IMEI", "AppCount"
                                                                          , "ClerkProfit", "ClerkActualProfit", "AgentProfit", "AgentActualProfit", "PartnerProfit", "PartnerActualProfit"
                                                                          , "PartnerName", "AgentName" });
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }
        #endregion

        #region 合作伙伴导出
        [HttpPost]
        public async Task<IActionResult> ExportPartnerJson(AppInstallRecordListParam param)
        {
            TData<string> obj = new TData<string>();
            param.DepartmentIds = (await departmentBLL.GetChildIds((long)user.DepartmentId)).Data;
            TData<List<AppInstallRecordEntity>> recordObj = await appInstallRecordBLL.GetList(param);
            if (recordObj.Tag == 1)
            {
                foreach (var item in recordObj.Data)
                {
                    item.ClerkProfit = Math.Round((decimal)(item.UnitPrice * item.AppCount * item.ClerkProportion), 2);
                    item.AgentProfit = Math.Round((decimal)(item.UnitPrice * item.AppCount * item.AgentProportion), 2);
                    item.PartnerProfit = Math.Round((decimal)(item.UnitPrice * item.AppCount * item.PartnerProportion), 2);
                    item.ClerkActualProfit = Math.Round((decimal)(item.ActualUnitPrice * item.AppCount * item.ClerkProportion), 2);
                    item.AgentActualProfit = Math.Round((decimal)(item.ActualUnitPrice * item.AppCount * item.AgentProportion), 2);
                    item.PartnerActualProfit = Math.Round((decimal)(item.ActualUnitPrice * item.AppCount * item.PartnerProportion), 2);
                }
                string file = new ExcelHelper<AppInstallRecordEntity>().ExportToExcel(param.InstallDate + "安装数据.xls",
                                                                          "安装数据",
                                                                          recordObj.Data,
                                                                          new string[] { "InstallDate", "RealName", "UserName", "StoreName", "IMEI"
                                                                          , "ClerkProfit", "ClerkActualProfit", "AgentProfit", "AgentActualProfit", "PartnerProfit", "PartnerActualProfit"
                                                                          , "PartnerName", "AgentName" });
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }
        #endregion

        #region 经销商导出
        [HttpPost]
        public async Task<IActionResult> ExportAgentJson(AppInstallRecordListParam param)
        {
            TData<string> obj = new TData<string>();

            param.DepartmentIds = (await departmentBLL.GetChildIds((long)user.DepartmentId)).Data;
            TData<List<AppInstallRecordEntity>> recordObj = await appInstallRecordBLL.GetList(param);
            if (recordObj.Tag == 1)
            {
                foreach (var item in recordObj.Data)
                {
                    item.ClerkProfit = Math.Round((decimal)(item.UnitPrice * item.AppCount * item.ClerkProportion), 2);
                    item.AgentProfit = Math.Round((decimal)(item.UnitPrice * item.AppCount * item.AgentProportion), 2);
                    item.ClerkActualProfit = Math.Round((decimal)(item.ActualUnitPrice * item.AppCount * item.ClerkProportion), 2);
                    item.AgentActualProfit = Math.Round((decimal)(item.ActualUnitPrice * item.AppCount * item.AgentProportion), 2);
                }
                string file = new ExcelHelper<AppInstallRecordEntity>().ExportToExcel(param.InstallDate + "安装数据.xls",
                                                                          "安装数据",
                                                                          recordObj.Data,
                                                                          new string[] { "InstallDate", "RealName", "UserName", "StoreName", "IMEI"
                                                                          , "ClerkProfit", "ClerkActualProfit", "AgentProfit", "AgentActualProfit", "AgentName" });
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }
        #endregion

        #region 店员导出
        [HttpPost]
        public async Task<IActionResult> ExportStoreJson(AppInstallRecordListParam param)
        {
            TData<string> obj = new TData<string>();

            param.UserId = user.UserId;
            TData<List<AppInstallRecordEntity>> recordObj = await appInstallRecordBLL.GetList(param);
            if (recordObj.Tag == 1)
            {
                foreach (var item in recordObj.Data)
                {
                    item.ClerkProfit = Math.Round((decimal)(item.UnitPrice * item.AppCount * item.ClerkProportion), 2);
                    item.ClerkActualProfit = Math.Round((decimal)(item.ActualUnitPrice * item.AppCount * item.ClerkProportion), 2);
                }
                string file = new ExcelHelper<AppInstallRecordEntity>().ExportToExcel(param.InstallDate + "安装数据.xls",
                                                                          "安装数据",
                                                                          recordObj.Data,
                                                                          new string[] { "InstallDate", "RealName", "UserName", "StoreName", "IMEI"
                                                                          , "ClerkProfit", "ClerkActualProfit"});
                obj.Data = file;
                obj.Tag = 1;
            }
            return Json(obj);
        }
        #endregion

        #endregion
    }
}
