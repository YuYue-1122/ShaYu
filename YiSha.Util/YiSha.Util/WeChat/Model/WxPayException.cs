using System;
using System.Collections.Generic;
using System.Text;

namespace YiSha.Util.WeChat.Model
{
    /// <summary>
    /// WxPayException 的摘要说明
    /// </summary>
    public class WxPayException : Exception
    {
        public WxPayException(string msg) : base(msg)
        {

        }
    }
}
