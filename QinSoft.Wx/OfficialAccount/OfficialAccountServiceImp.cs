using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QinSoft.Wx.Common;
using QinSoft.Wx.OfficialAccount.Model.AccessToken;
using QinSoft.Wx.OfficialAccount.Model.CustomerService;

namespace QinSoft.Wx.OfficialAccount
{
    /// <summary>
    /// 公众号服务实现
    /// </summary>
    public class OfficialAccountServiceImp : OfficialAccountService
    {
        private OfficialAccountConfig officialAccountConfig;

        private Dictionary<string, string> urlDictionary;

        public OfficialAccountServiceImp(OfficialAccountConfig officialAccountConfig)
        {
            if (officialAccountConfig == null) throw new ArgumentNullException("officialAccountConfig");
            this.officialAccountConfig = officialAccountConfig;
            this.urlDictionary = new Dictionary<string, string>() {
                { "GetAccessToken","https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}"},
                { "AddCustomerService","https://api.weixin.qq.com/customservice/kfaccount/add?access_token={0}"},
                { "UpdateCustomerService","https://api.weixin.qq.com/customservice/kfaccount/update?access_token={0}"},
                { "DeleteCustomerService","https://api.weixin.qq.com/customservice/kfaccount/del?access_token={0}"},
                { "GetCustomerServiceList","https://api.weixin.qq.com/cgi-bin/customservice/getkflist?access_token={0}"},
                { "SendCustomerServiceMessage","https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}"},
                { "TypingCustomerService","https://api.weixin.qq.com/cgi-bin/message/custom/typing?access_token={0}"}
            };
        }

        public override string CalculateJoinSignature(long timestamp, string nonce)
        {
            List<string> data = new List<string>();
            data.Add(timestamp.ToString());
            data.Add(nonce);
            data.Add(this.officialAccountConfig.Token);
            data.Sort();
            string joinStr = string.Join("", data);
            return joinStr.SHA1();
        }

        public override string GetAccessToken()
        {
            AccessTokenResponse response = RetryTools.Retry<AccessTokenResponse>(() =>
            {
                return HttpTools.Get<AccessTokenResponse>(string.Format(urlDictionary["GetAccessToken"], this.officialAccountConfig.AppId, this.officialAccountConfig.AppSecret), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            else return response.AccessToken;
        }

        #region 客服

        public override void AddCustomerService(string accessToken, CustomerServiceActionRequest customerService)
        {
            CustomerServiceActionResponse response = RetryTools.Retry<CustomerServiceActionResponse>(() =>
            {
                return HttpTools.Post<CustomerServiceActionResponse>(string.Format(urlDictionary["AddCustomerService"], accessToken), null, null, customerService);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override void UpdateCustomerService(string accessToken, CustomerServiceActionRequest customerService)
        {
            CustomerServiceActionResponse response = RetryTools.Retry<CustomerServiceActionResponse>(() =>
            {
                return HttpTools.Post<CustomerServiceActionResponse>(string.Format(urlDictionary["UpdateCustomerService"], accessToken), null, null, customerService);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override void DeleteCustomerService(string accessToken, CustomerServiceActionRequest customerService)
        {
            CustomerServiceActionResponse response = RetryTools.Retry<CustomerServiceActionResponse>(() =>
            {
                return HttpTools.Post<CustomerServiceActionResponse>(string.Format(urlDictionary["DeleteCustomerService"], accessToken), null, null, customerService);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override CustomerServiceListItem[] GetCustomerServiceList(string accessToken)
        {
            CustomerServiceListResponse response = RetryTools.Retry<CustomerServiceListResponse>(() =>
            {
                return HttpTools.Get<CustomerServiceListResponse>(string.Format(urlDictionary["GetCustomerServiceList"], accessToken), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response.CustomerServiceList;
        }

        public override void SendCustomerServiceMessage(string accessToken, CustomerServiceMsgBase message)
        {
            CustomerServiceMsgResponse response = RetryTools.Retry<CustomerServiceMsgResponse>(() =>
            {
                return HttpTools.Post<CustomerServiceMsgResponse>(string.Format(urlDictionary["SendCustomerServiceMessage"], accessToken), null, null, message);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override void TypingCustomerService(string accessToken, TypingCustomerServiceRequest action)
        {
            TypingCustomerServiceResponse response = RetryTools.Retry<TypingCustomerServiceResponse>(() =>
            {
                return HttpTools.Post<TypingCustomerServiceResponse>(string.Format(urlDictionary["TypingCustomerService"], accessToken), null, null, action);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        #endregion
    }
}
