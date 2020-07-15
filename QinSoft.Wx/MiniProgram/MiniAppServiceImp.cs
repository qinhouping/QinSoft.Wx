using QinSoft.Wx.Common;
using QinSoft.Wx.MiniProgram.Model.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.MiniProgram
{
    public class MiniProgramServiceImp : MiniProgramService
    {
        private MiniProgramConfig MiniProgramConfig;
        private Dictionary<string, string> urlDictionary;

        public MiniProgramServiceImp(MiniProgramConfig MiniProgramConfig)
        {
            this.MiniProgramConfig = MiniProgramConfig;
            this.urlDictionary = new Dictionary<string, string>()
            {
                { "GetJsCode2Session","https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type={3}" },
                { "GetPaidUnionId","https://api.weixin.qq.com/wxa/getpaidunionid?access_token={0}&openid={1}&{2}" },
                { "GetAccessToken","https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}" }
            };
        }

        #region 登录
        public override GetJsCode2SessionResponse GetJsCode2Session(string jsCode)
        {
            return RetryTools.Retry<GetJsCode2SessionResponse>(() =>
            {
                return HttpTools.Get<GetJsCode2SessionResponse>(string.Format(urlDictionary["GetJsCode2Session"], this.MiniProgramConfig.AppId, this.MiniProgramConfig.AppSecret, jsCode, "authorization_code"), null, null);
            });
        }
        #endregion

        #region 用户信息
        public override GetPaidUnionIdResponse GetPaidUnionId(string accessToken, string openId, string transactionId)
        {
            return RetryTools.Retry<GetPaidUnionIdResponse>(() =>
            {
                return HttpTools.Get<GetPaidUnionIdResponse>(string.Format(urlDictionary["GetPaidUnionId"], accessToken, openId, string.Format("transaction_id={0}", transactionId)), null, null);
            });
        }

        public override GetPaidUnionIdResponse GetPaidUnionId(string accessToken, string openId, string outTradeNo, string mchId)
        {
            return RetryTools.Retry<GetPaidUnionIdResponse>(() =>
            {
                return HttpTools.Get<GetPaidUnionIdResponse>(string.Format(urlDictionary["GetPaidUnionId"], accessToken, openId, string.Format("out_trade_no={0}&mch_id={1}", outTradeNo, mchId)), null, null);
            });
        }
        #endregion

        #region 接口凭证
        public override GetAccessTokenResponse GetAccessToken()
        {
            return RetryTools.Retry<GetAccessTokenResponse>(() =>
            {
                return HttpTools.Get<GetAccessTokenResponse>(string.Format(urlDictionary["GetAccessToken"], "client_credential", this.MiniProgramConfig.AppId, this.MiniProgramConfig.AppSecret), null, null);
            });
        }
        #endregion
    }
}
