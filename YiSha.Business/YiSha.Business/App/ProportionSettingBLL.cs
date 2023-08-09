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
    /// 日 期：2021-07-11 15:31
    /// 描 述：比例配置业务类
    /// </summary>
    public class ProportionSettingBLL
    {
        private ProportionSettingService proportionSettingService = new ProportionSettingService();

        #region 获取数据
        public async Task<TData<List<ProportionSettingEntity>>> GetList(ProportionSettingListParam param)
        {
            TData<List<ProportionSettingEntity>> obj = new TData<List<ProportionSettingEntity>>();
            obj.Data = await proportionSettingService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<ProportionSettingEntity>>> GetPageList(ProportionSettingListParam param, Pagination pagination)
        {
            TData<List<ProportionSettingEntity>> obj = new TData<List<ProportionSettingEntity>>();
            obj.Data = await proportionSettingService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<ProportionSettingEntity>> GetEntity(int id)
        {
            TData<ProportionSettingEntity> obj = new TData<ProportionSettingEntity>();
            obj.Data = await proportionSettingService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(ProportionSettingEntity entity)
        {
            TData<string> obj = new TData<string>();
            await proportionSettingService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await proportionSettingService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
