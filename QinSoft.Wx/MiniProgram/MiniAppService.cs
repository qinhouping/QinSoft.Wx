using QinSoft.Wx.MiniProgram.Model.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.MiniProgram
{
    public abstract class MiniProgramService
    {
        #region 登录
        public abstract GetJsCode2SessionResponse GetJsCode2Session(string jsCode);
        #endregion

        #region 用户信息
        public abstract GetPaidUnionIdResponse GetPaidUnionId(string accessToken, string openId, string transactionId);

        public abstract GetPaidUnionIdResponse GetPaidUnionId(string accessToken, string openId, string outTradeNo, string mchId);
        #endregion

        #region 接口凭证
        public abstract GetAccessTokenResponse GetAccessToken();
        #endregion
    }
}
