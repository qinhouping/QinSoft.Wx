using QinSoft.Wx.OfficialAccount.Model.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount
{
    /// <summary>
    /// 公众号服务
    /// </summary>
    public abstract class OfficialAccountService
    {
        public abstract string CalculateJoinSignature(long timestamp, string nonce);

        public abstract string GetAccessToken();

        #region 客服

        public abstract void AddCustomerService(string accessToken, CustomerServiceActionRequest customerService);

        public abstract void UpdateCustomerService(string accessToken, CustomerServiceActionRequest customerService);

        public abstract void DeleteCustomerService(string accessToken, CustomerServiceActionRequest customerService);

        public abstract CustomerServiceListItem[] GetCustomerServiceList(string accessToken);

        public abstract void SendCustomerServiceMessage(string accessToken, CustomerServiceMsgBase message);

        public abstract void TypingCustomerService(string accessToken, TypingCustomerServiceRequest action);
        #endregion
    }
}
