using QinSoft.Wx.Common;
using QinSoft.Wx.MiniProgram.Model;
using QinSoft.Wx.MiniProgram.Model.Login;
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
                { "GetJsCode2Session","https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type={3}" }
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
    }
}
