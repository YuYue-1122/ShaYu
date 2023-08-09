using System;
using System.Collections.Generic;
using System.Text;
using YiSha.Util.WeChat.Model;

namespace YiSha.Util.WeChat
{
    public static class WeChatPayHelper
    {
        /// <summary>
        /// 统一下单
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        /// <param name="mchId">商户号 </param>
        /// <param name="mchKey">商户Key</param>
        /// <param name="body">支付说明</param>
        /// <param name="out_trade_no">订单号：我们平台的唯一标识，微信回调的时候会返回</param>
        /// <param name="amount">支付金额</param>
        /// <param name="notifyUrl">回调Url</param>
        /// <param name="trade_type">JSAPI -JSAPI支付/NATIVE -Native支付/APP -APP支付</param>
        /// <param name="product_id">产品ID</param>
        /// <param name="openid">用户openid</param>
        public static WxPayData Unifiedorder(string appId, string appSecret, string mchId, string mchKey, string body, string out_trade_no, decimal amount, string notifyUrl, string trade_type, string product_id, string openid)
        {
            //统一下单
            Model.WxPayData data = new Model.WxPayData();
            data.SetValue("appid", appId);//WxAPPID
            data.SetValue("mch_id", mchId);//
            data.SetValue("nonce_str", Util.SecurityHelper.GetGuid());//随机字符串
            data.SetValue("body", body);
            data.SetValue("out_trade_no", out_trade_no);
            data.SetValue("total_fee", (int)(amount * 100));
            data.SetValue("spbill_create_ip", Util.SecurityHelper.GetHostAddress());//终端ip	 
            data.SetValue("notify_url", notifyUrl);//异步通知url
            data.SetValue("trade_type", trade_type);
            data.SetValue("product_id", product_id);
            data.SetValue("openid", openid);
            data.SetValue("sign", data.MakeSign(mchKey));//签名
            ////关联参数
            if (trade_type == "JSAPI" && string.IsNullOrEmpty(openid))
            {
                throw new WxPayException("统一支付接口中，缺少必填参数openid！trade_type为JSAPI时，openid为必填参数！");
            }
            if (trade_type == "NATIVE" && !string.IsNullOrEmpty(product_id))
            {
                throw new WxPayException("统一支付接口中，缺少必填参数product_id！trade_type为NATIVE时，product_id为必填参数！");
            }

            //异步通知url未设置，则使用配置文件中的url
            if (string.IsNullOrEmpty(notifyUrl))
            {
                throw new WxPayException("未设置通知Url");
            }
            string xml = data.ToXml();

            string response = YiSha.Util.HttpHelper.GetHtmlString(WeChatApi.UnifiedorderApiUrl, xml, null, Encoding.UTF8, 2000,false, "text/xml");

            LogHelper.Info("统一下单：response" + response);
            WxPayData result = new WxPayData();
            result.FromXml(response, "");
            return result;
        }
        /// <summary>
        /// 微信提现
        /// </summary>
        /// <param name="appId">商户账号appid</param>
        /// <param name="checkName">校验用户姓名选项</param>
        /// <param name="mchId">商户号</param>
        /// <param name="mchKey">签名</param>
        /// <param name="desc">企业付款备注</param>
        /// <param name="partnerTradeNo">商户订单号</param>
        /// <param name="amount">金额</param>
        /// <param name="reUserName">收款用户姓名</param>
        /// <param name="openid">用户openid</param>
        /// <returns></returns>
        public static WxPayData Transfers(string appId, string checkName, string mchId, string mchKey, string desc, string partnerTradeNo, decimal amount, string reUserName, string openid)
        {
            //微信提现
            Model.WxPayData data = new Model.WxPayData();
            data.SetValue("mch_appid", appId);//商户账号appid
            data.SetValue("mchid", mchId);//商户号 
            data.SetValue("nonce_str", (Util.SecurityHelper.GetGuid()));//随机字符串
            data.SetValue("partner_trade_no", partnerTradeNo);//商户订单号 
            data.SetValue("openid", openid);///用户openid 
            data.SetValue("check_name", checkName);//校验用户姓名选项
            data.SetValue("re_user_name", reUserName);//收款用户姓名 
            data.SetValue("amount", (int)(amount * 100));//金额
            data.SetValue("desc", desc);//企业付款备注
            data.SetValue("spbill_create_ip", Util.SecurityHelper.GetHostAddress());//Ip地址 
            data.SetValue("sign", data.MakeSign(mchKey));//签名 

            string xml = data.ToXml();

            string response = YiSha.Util.HttpHelper.GetHtmlString(WeChatApi.TransfersApiUrl, xml, null, Encoding.UTF8, 2000,true, "text/xml");

            LogHelper.Info("微信提现：response" + response);
            WxPayData result = new WxPayData();
            result.FromXml(response, "");
            return result;
        }
        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="mchId">商户号</param>
        /// <param name="mchKey">商户APIkey</param>
        /// <param name="transaction_id">支付时微信回传的订单哈</param>
        /// <param name="out_trade_no">商户订单号</param>
        /// <param name="out_refund_no">退款单号</param>
        /// <param name="totalAmount">订单总金额</param>
        /// <param name="refundAmount">退款金额</param>
        /// <param name="notifyUrl">回调地址</param>
        /// <param name="refund_desc">退款原因</param>
        /// <returns></returns>
        public static WxPayData Refund(string appId, string mchId, string mchKey, string transaction_id, string out_trade_no, string out_refund_no, decimal totalAmount, decimal refundAmount, string notifyUrl, string refund_desc)
        {
            //统一下单
            Model.WxPayData data = new Model.WxPayData();
            data.SetValue("appid", appId);//WxAPPID
            data.SetValue("mch_id", mchId);//
            data.SetValue("nonce_str", Util.SecurityHelper.GetGuid());//随机字符串
            data.SetValue("sign_type", "MD5");
            if (!string.IsNullOrEmpty(transaction_id))
            {
                data.SetValue("transaction_id", transaction_id);
            }
            if (!string.IsNullOrEmpty(out_trade_no))
            {
                data.SetValue("out_trade_no", out_trade_no);
            }
            data.SetValue("out_refund_no", out_refund_no);
            data.SetValue("total_fee", (int)(totalAmount * 100));
            data.SetValue("refund_fee", (int)(refundAmount * 100));
            data.SetValue("refund_desc", refund_desc);
            //使用未结算资金退款
            data.SetValue("refund_account", "REFUND_SOURCE_UNSETTLED_FUNDS");
            data.SetValue("notify_url", notifyUrl);//异步通知url
            data.SetValue("sign", data.MakeSign(mchKey));//签名
            string xml = data.ToXml();

            string response = YiSha.Util.HttpHelper.GetHtmlString(WeChatApi.RefundApiUrl, xml, null, Encoding.UTF8, 2000, true, "text/xml");

            WxPayData result = new WxPayData();
            result.FromXml(response, "");
            return result;
        }

    }
}
