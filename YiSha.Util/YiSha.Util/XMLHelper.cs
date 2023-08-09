using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace YiSha.Util
{
    public static class XMLHelper
    {
        #region 将XML转换成实体对象
        /// <summary>
        /// 将XML转换成实体对象
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="strXML">XML</param>
        public static T DESerializer<T>(string strXML) where T : class
        {
            try
            {
                using (StringReader sr = new StringReader(strXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("将XML转换成实体对象异常", ex);
            }

        } 
        #endregion
    }
}
