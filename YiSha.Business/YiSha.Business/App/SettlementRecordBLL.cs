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

namespace YiSha.Business.App
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-07-13 14:07
    /// 描 述：结算记录业务类
    /// </summary>
    public class SettlementRecordBLL
    {
        private SettlementRecordService settlementRecordService = new SettlementRecordService();
        private ProportionSettingService proportionSettingService = new ProportionSettingService();
        #region 获取数据
        public async Task<TData<List<SettlementRecordEntity>>> GetList(SettlementRecordListParam param)
        {
            TData<List<SettlementRecordEntity>> obj = new TData<List<SettlementRecordEntity>>();
            obj.Data = await settlementRecordService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<SettlementRecordEntity>>> GetPageList(SettlementRecordListParam param, Pagination pagination)
        {
            TData<List<SettlementRecordEntity>> obj = new TData<List<SettlementRecordEntity>>();
            obj.Data = await settlementRecordService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<SettlementRecordEntity>> GetEntity(int id)
        {
            TData<SettlementRecordEntity> obj = new TData<SettlementRecordEntity>();
            obj.Data = await settlementRecordService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(SettlementRecordEntity entity)
        {
            TData<string> obj = new TData<string>();
            entity.UnitPrice = Math.Round((decimal)(entity.SettlementAmount / entity.InstallCount), 2);
            if (entity.ActualSettlementAmount > 0)
            {
                entity.ActualUnitPrice = Math.Round((decimal)(entity.ActualSettlementAmount / entity.InstallCount), 2);
            }
            await settlementRecordService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await settlementRecordService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        public async Task<TData<string>> Calculation(int id)
        {
            TData<string> obj = new TData<string>();
            SettlementRecordEntity entity = await settlementRecordService.GetEntity(id);
            if (entity == null)
            {
                obj.Message = "结算记录已被删除";
                return obj;
            }
            //获取佣金比例配置
            ProportionSettingEntity proportionSettingEntity= await proportionSettingService.GetEntity();
            if (proportionSettingEntity == null)
            {
                obj.Message = "未设置佣金比例";
                return obj;
            }
            //计算该日期店员佣金
            entity.UnitPrice = Math.Round((decimal)(entity.SettlementAmount / entity.InstallCount), 2);
            await settlementRecordService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }
        
        #endregion

        #region 私有方法
        #endregion
    }
}
