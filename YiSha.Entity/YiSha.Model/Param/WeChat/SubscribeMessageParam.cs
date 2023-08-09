using System;
using System.Collections.Generic;
using System.Text;

namespace YiSha.Model.Param.WeChat
{
    public class SubscribeMessageParam
    {
        public SubscribeMessageParam()
        {
            thing1 = new ParamValue();
            thing2 = new ParamValue();
        }

        public ParamValue thing1 { get; set; }

        public ParamValue thing2 { get; set; }
    }
    public class ParamValue
    {
        public string value { get; set; }
    }
}
