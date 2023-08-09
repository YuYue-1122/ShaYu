using System;
using System.Collections.Generic;
using System.Text;

namespace YiSha.Model.Result.WeChat
{
    public class AccessTokenModel
    {
        public string access_token { get; set; }

        public string expires_in { get; set; }

        public string errcode { get; set; }
    }
}
