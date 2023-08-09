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
using YiSha.Model.Result.App;

namespace YiSha.Service.App
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2021-07-11 15:25
    /// 描 述：安装记录服务类
    /// </summary>
    public class AppInstallRecordService : RepositoryFactory
    {
        #region 获取数据
        public async Task<List<AppInstallRecordEntity>> GetList(AppInstallRecordListParam param)
        {
            string strTable = "T_AppInstallRecord";
            if (!string.IsNullOrEmpty(param.Month))
            {
                strTable += "_" + param.Month;
            }
            StringBuilder strSql = new StringBuilder();

            strSql.Append(@"select UserId,InstallDate,IMEI,AppCount,ISNULL(settlement.UnitPrice,0)UnitPrice,ISNULL(settlement.ActualUnitPrice,0)ActualUnitPrice,u.RealName,u.UserName,store.DepartmentName StoreName,agent.DepartmentName AgentName,par.DepartmentName PartnerName,p.PartnerProportion,p.AgentProportion,p.ClerkProportion  
from(select UserId,InstallDate,IMEI,COUNT(1) AppCount from "+ strTable + 
@" group by UserId,InstallDate,IMEI) i
left join SysUser u on i.UserId=u.Id
left join SysDepartment store on u.DepartmentId=store.Id
left join SysDepartment agent on store.ParentId=agent.Id
left join SysDepartment par on par.Id=agent.ParentId
left join T_ProportionSetting p on 1=1
left join T_SettlementRecord settlement on settlement.SettlementDate=i.InstallDate
where 1=1");
            var parameter = new List<DbParameter>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.RealName))
                {
                    strSql.Append(" and u.RealName=@RealName");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@RealName", param.RealName));
                }
                if (!string.IsNullOrEmpty(param.UserName))
                {
                    strSql.Append(" and u.UserName=@UserName");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@UserName", param.UserName));
                }
                if (!string.IsNullOrEmpty(param.InstallDate))
                {
                    strSql.Append(" and InstallDate>=@InstallDate");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@InstallDate", param.InstallDate));
                }
                if (!string.IsNullOrEmpty(param.InstallEndDate))
                {
                    strSql.Append(" and InstallDate<=@InstallEndDate");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@InstallEndDate", param.InstallEndDate));
                }
                if (param.UserId > 0)
                {
                    strSql.Append(" and i.UserId=@UserId");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@UserId", param.UserId));
                }
                if (!string.IsNullOrEmpty(param.DepartmentIds))
                {
                    strSql.Append(" and  u.DepartmentId in(" + param.DepartmentIds + ")");
                }
            }
            var list = await this.BaseRepository().FindList<AppInstallRecordEntity>(strSql.ToString(), parameter.ToArray());
            return list.ToList();
        }

        public async Task<List<AppInstallRecordEntity>> GetPageList(AppInstallRecordListParam param, Pagination pagination)
        {
            StringBuilder strSql = new StringBuilder();
            //            strSql.Append(@"select UserId,InstallDate,AppCount,(select count(distinct IMEI) from
            //T_AppInstallRecord r where
            //r.InstallDate=i.InstallDate and
            //r.UserId=i.UserId)IMEICount,PartnerProfit,AgentProfit,ClerkProfit,u.RealName,u.UserName from(select UserId,InstallDate,COUNT(1) AppCount,ISNULL(SUM(PartnerProfit),0)PartnerProfit,ISNULL(SUM(AgentProfit),0)AgentProfit,ISNULL(SUM(ClerkProfit),0)ClerkProfit from T_AppInstallRecord 
            //group by UserId,InstallDate) i
            //left join SysUser u on i.UserId=u.Id where 1=1");
            string strTable = "T_AppInstallRecord";
            if (!string.IsNullOrEmpty(param.Month))
            {
                strTable += "_" + param.Month;
            }
            strSql.Append(@"select UserId,InstallDate,IMEI,AppCount,settlement.UnitPrice,settlement.ActualUnitPrice,u.RealName,u.UserName,store.DepartmentName StoreName,agent.DepartmentName AgentName,par.DepartmentName PartnerName,p.PartnerProportion,p.AgentProportion,p.ClerkProportion  
from(select UserId,InstallDate,IMEI,COUNT(1) AppCount from " + strTable + 
@" group by UserId,InstallDate,IMEI) i
left join SysUser u on i.UserId=u.Id
left join SysDepartment store on u.DepartmentId=store.Id
left join SysDepartment agent on store.ParentId=agent.Id
left join SysDepartment par on par.Id=agent.ParentId
left join T_ProportionSetting p on 1=1
left join T_SettlementRecord settlement on settlement.SettlementDate=i.InstallDate
where 1=1");
            var parameter = new List<DbParameter>();
            if (param != null)
            {
                if (!string.IsNullOrEmpty(param.RealName))
                {
                    strSql.Append(" and u.RealName=@RealName");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@RealName", param.RealName));
                }
                if (!string.IsNullOrEmpty(param.UserName))
                {
                    strSql.Append(" and u.UserName=@UserName");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@UserName", param.UserName));
                }
                if (!string.IsNullOrEmpty(param.InstallDate))
                {
                    strSql.Append(" and InstallDate>=@InstallDate");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@InstallDate", param.InstallDate));
                }
                if (!string.IsNullOrEmpty(param.InstallEndDate))
                {
                    strSql.Append(" and InstallDate<=@InstallEndDate");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@InstallEndDate", param.InstallEndDate));
                }
                if (param.UserId > 0)
                {
                    strSql.Append(" and i.UserId=@UserId");
                    parameter.Add(DbParameterExtension.CreateDbParameter("@UserId", param.UserId));
                }
                if (!string.IsNullOrEmpty(param.DepartmentIds))
                {
                    strSql.Append(" and  u.DepartmentId in(" + param.DepartmentIds + ")");
                }
            }
            var list = await this.BaseRepository().FindList<AppInstallRecordEntity>(strSql.ToString(), parameter.ToArray(), pagination);
            return list.ToList();
        }

        public async Task<AppInstallRecordEntity> GetEntity(int id)
        {
            return await this.BaseRepository().FindEntity<AppInstallRecordEntity>(id);
        }
        public async Task<int> GetInstallCount(string datetime)
        {
            StringBuilder strSql = new StringBuilder(" select count(1) from T_AppInstallRecord");

            var parameter = new List<DbParameter>();

            if (!string.IsNullOrEmpty(datetime))
            {
                strSql.AppendFormat("  where InstallDate='{0}'", datetime);
            }
            var obj = await this.BaseRepository().FindObject(strSql.ToString());
            return Convert.ToInt32(obj);
        }

        #endregion

        #region 提交数据
        public async Task SaveForm(AppInstallRecordEntity entity)
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
            await this.BaseRepository().Delete<AppInstallRecordEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<AppInstallRecordEntity, bool>> ListFilter(AppInstallRecordListParam param)
        {
            var expression = LinqExtensions.True<AppInstallRecordEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion

        #region 统计店员收益记录
        public async Task<List<ProfitResult>> GetUserProfitList(long userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select t.*,p.ClerkProportion from(select InstallDate,Count(1)AppCount, ISNULL((select top 1 UnitPrice from  T_SettlementRecord s where s.SettlementDate=InstallDate),0) UnitPrice from T_AppInstallRecord
left join T_ProportionSetting p on 1=1
where UserId=" + userId + @"
 Group By InstallDate) t
left join T_ProportionSetting p on 1=1");
            var list = await this.BaseRepository().FindList<ProfitResult>(strSql.ToString());
            return list.ToList();
        }
        #endregion

        #region MyRegion
        public async Task<AppInstallRecordEntity> GetEntity(DateTime? installDate, string imei, string appApkName)
        {
            return await this.BaseRepository().FindEntity<AppInstallRecordEntity>(m => m.InstallDate == installDate && m.IMEI == imei && m.AppApkName == appApkName);
        }
        #endregion
    }
}
