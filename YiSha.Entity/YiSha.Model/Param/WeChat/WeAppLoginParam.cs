using System;
using System.Collections.Generic;
using System.Text;

namespace YiSha.Model.Param.WeChat
{
    public class WeAppLoginParam
    {
        /// <summary>
        /// 获得的授权code
        /// </summary>
        public string code { get; set; }
        public string encryptedData { get; set; }
        public string iv { get; set; }
        public string rawData { get; set; }
        public string signature { get; set; }
    }
}
