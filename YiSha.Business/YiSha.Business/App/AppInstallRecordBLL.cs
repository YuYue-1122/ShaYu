using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Entity.App;
using YiSha.Model.Param.App;
using YiSha.Service.App;
using YiSha.Model.Result.App;
using YiSha.Cache.Factory;

namespace YiSha.Business.App
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-07-11 15:25
    /// 描 述：安装记录业务类
    /// </summary>
    public class AppInstallRecordBLL
    {
        private AppInstallRecordService appInstallRecordService = new AppInstallRecordService();

        #region 获取数据
        public async Task<TData<List<AppInstallRecordEntity>>> GetList(AppInstallRecordListParam param)
        {
            TData<List<AppInstallRecordEntity>> obj = new TData<List<AppInstallRecordEntity>>();
            obj.Data = await appInstallRecordService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<AppInstallRecordEntity>>> GetPageList(AppInstallRecordListParam param, Pagination pagination)
        {
            TData<List<AppInstallRecordEntity>> obj = new TData<List<AppInstallRecordEntity>>();
            obj.Data = await appInstallRecordService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<AppInstallRecordEntity>> GetEntity(int id)
        {
            TData<AppInstallRecordEntity> obj = new TData<AppInstallRecordEntity>();
            obj.Data = await appInstallRecordService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        public async Task<TData<int>> GetInstallCount(string dateTime)
        {
            TData<int> obj = new TData<int>();
            obj.Data = await appInstallRecordService.GetInstallCount(dateTime);
            obj.Tag = 1;
            return obj;
        }

        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(AppInstallRecordEntity entity)
        {
            TData<string> obj = new TData<string>();
            entity.InstallDate = DateTime.Now.Date;

            //存入redis
            string imeiKey = Convert.ToDateTime(entity.InstallDate).ToString("yyyyMMdd") + "_" + entity.IMEI + "_" + entity.AppApkName;
            if (string.IsNullOrEmpty(CacheFactory.Cache.GetCache<string>(imeiKey)))
            {
                CacheFactory.Cache.SetCache(imeiKey, "1", DateTime.Now.AddDays(1));
                await appInstallRecordService.SaveForm(entity);
                obj.Data = entity.Id.ParseToString();
                ////判断该日期 该设备是否安装过
                //if (await appInstallRecordService.GetEntity(entity.InstallDate, entity.IMEI, entity.AppApkName) == null)
                //{
                //    await appInstallRecordService.SaveForm(entity);
                //    obj.Data = entity.Id.ParseToString();
                //}

            }
            else
            {
                obj.Message = "安装记录重复调用";
                LogHelper.Info("安装记录重复调用");
            }
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await appInstallRecordService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion

        #region 获取店员收益记录

        public async Task<TData<object>> GetUserProfitList(long userId)
        {
            TData<object> obj = new TData<object>();
            List<ProfitResult> list = await appInstallRecordService.GetUserProfitList(userId);
            //店员比例
            foreach (var item in list)
            {
                item.InstallDate = Convert.ToDateTime(item.InstallDate).ToString("yyyy-MM-dd");
                item.Profit = Math.Round(item.AppCount * item.UnitPrice * item.ClerkProportion, 2).ToString();
            }
            //总收益金额
            decimal totalProfit = list.Sum(m => m.AppCount * (decimal)m.UnitPrice);
            obj.Data = new { TotalProfit = Math.Round(totalProfit, 2).ToString(), DataList = list };
            obj.Total = list.Count;
            obj.Tag = 1;
            return obj;
        }
        #endregion
    }
}
