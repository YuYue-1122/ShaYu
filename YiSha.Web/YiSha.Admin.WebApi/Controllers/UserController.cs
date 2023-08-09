using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YiSha.Business.App;
using YiSha.Business.OrganizationManage;
using YiSha.Cache.Factory;
using YiSha.Entity.OrganizationManage;
using YiSha.Enum;
using YiSha.Model.Param.SystemManage;
using YiSha.Model.Result.SystemManage;
using YiSha.Util;
using YiSha.Util.Model;
using YiSha.Web.Code;

namespace YiSha.Admin.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [AuthorizeFilter]
    public class UserController : ControllerBase
    {
        private UserBLL userBLL = new UserBLL();
        private AppInstallRecordBLL appInstallRecordBLL = new AppInstallRecordBLL();

        #region 获取数据  
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="token">登录凭证</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<TData<OperatorInfo>> GetUserInfo([FromQuery] string token)
        {
            TData<OperatorInfo> obj = new TData<OperatorInfo>();
            OperatorInfo user = CacheFactory.Cache.GetCache<OperatorInfo>(token);
            if (user == null)
            {
                obj.Tag = (int)TagEnum.LoginExpire;
                obj.Message = "登录超时";
                return obj;
            }

            obj.Data = user;
            obj.Tag = 1;
            obj.Message = "SUCCESS";
            return obj;
        }
        #endregion

        #region 提交数据
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="param">登录参数</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<TData<OperatorInfo>> Login([FromBody] LoginParam param)
        {
            TData<OperatorInfo> obj = new TData<OperatorInfo>();
            TData<UserEntity> userObj = await userBLL.CheckLogin(param.UserName, param.Password, (int)PlatformEnum.WebApi);
            if (userObj.Tag == 1)
            {
                await new UserBLL().UpdateUser(userObj.Data);
                await Operator.Instance.AddCurrent(userObj.Data.ApiToken);
                obj.Data = await Operator.Instance.Current(userObj.Data.ApiToken);
            }
            obj.Tag = userObj.Tag;
            obj.Message = userObj.Message;
            return obj;
        }

        /// <summary>
        /// 用户退出登录
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost]
        public TData LoginOff([FromQuery] string token)
        {
            var obj = new TData();
            try
            {
                Operator.Instance.RemoveCurrent(token);
                obj.Tag = 1;
                obj.Message = "SUCCESS";
            }
            catch (Exception ex)
            {
                obj.Message = "ERROR";
            }
            return obj;
        }
        #endregion

        #region 获取用户收益
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="token">登录凭证</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<TData<object>> GetUserProfit([FromQuery] string token)
        {
            TData<object> obj = new TData<object>();
            OperatorInfo user = CacheFactory.Cache.GetCache<OperatorInfo>(token);
            if (user == null)
            {
                obj.Tag = (int)TagEnum.LoginExpire;
                obj.Message = "登录超时";
                return obj;
            }
            obj = await appInstallRecordBLL.GetUserProfitList((long)user.UserId);
            return obj;
        }
        #endregion

        #region 获取店员二维码
        [HttpGet]
        public async Task<TData<string>> GetUserQrCode([FromQuery] string token)
        {

            TData<string> obj = new TData<string>();
            OperatorInfo user = CacheFactory.Cache.GetCache<OperatorInfo>(token);
            if (user == null)
            {
                obj.Tag = (int)TagEnum.LoginExpire;
                obj.Message = "登录超时";
                return obj;
            }
            string url = GlobalContext.SystemConfig.ApiSite + "/app-release.apk.1?username=" + user.UserName + "&password=" + user.ClearTextPassword;
            string codeUrl = GlobalContext.SystemConfig.ApiSite + "/User/GetPTQRCode?url=" + HttpUtility.UrlEncode(url);
            obj.Data = codeUrl;
            return obj;
        }
        [HttpGet]
        public IActionResult GetPTQRCode(string url, int pixel = 8)
        {
            url = HttpUtility.UrlDecode(url);
            Response.ContentType = "image/jpeg";

            var bitmap = QrCoderHelper.GetPTQRCode(url, pixel);
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);
            return File(ms.ToArray(), "image/png");
        }
        #endregion
    }
}