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
    /// 日 期：2021-07-13 14:07
    /// 描 述：结算记录服务类
    /// </summary>
    public class SettlementRecordService : RepositoryFactory
    {
        #region 获取数据
        public async Task<List<SettlementRecordEntity>> GetList(SettlementRecordListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<SettlementRecordEntity>> GetPageList(SettlementRecordListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<SettlementRecordEntity> GetEntity(int id)
        {
            return await this.BaseRepository().FindEntity<SettlementRecordEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(SettlementRecordEntity entity)
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
            await this.BaseRepository().Delete<SettlementRecordEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<SettlementRecordEntity, bool>> ListFilter(SettlementRecordListParam param)
        {
            var expression = LinqExtensions.True<SettlementRecordEntity>();
            if (param != null)
            {
                if (param.SettlementDate != null)
                {
                    expression = expression.And(m => m.SettlementDate == param.SettlementDate);
                }
            }
            return expression;
        }
        #endregion
    }
}
