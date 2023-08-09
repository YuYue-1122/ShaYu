using System;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using YiSha.Util;
using YiSha.Util.Extension;
using YiSha.Util.Model;
using YiSha.Data;
using YiSha.Data.Repository;
using YiSha.Entity.App;
using YiSha.Model.Param.App;

namespace YiSha.Service.App
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-07-11 15:31
    /// 描 述：比例配置服务类
    /// </summary>
    public class ProportionSettingService :  RepositoryFactory
    {
        #region 获取数据
        public async Task<List<ProportionSettingEntity>> GetList(ProportionSettingListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<ProportionSettingEntity>> GetPageList(ProportionSettingListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list= await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<ProportionSettingEntity> GetEntity(int id)
        {
            return await this.BaseRepository().FindEntity<ProportionSettingEntity>(id);
        }

        public async Task<ProportionSettingEntity> GetEntity()
        {
            return (await this.BaseRepository().FindTopListOrderBy<ProportionSettingEntity>(null,m=>m.Id,1,"desc")).ToList().FirstOrDefault();
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(ProportionSettingEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                await entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {
                await entity.Modify();
                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<ProportionSettingEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<ProportionSettingEntity, bool>> ListFilter(ProportionSettingListParam param)
        {
            var expression = LinqExtensions.True<ProportionSettingEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
