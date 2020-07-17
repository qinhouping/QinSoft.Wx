using QinSoft.Wx.Common;
using QinSoft.Wx.MiniProgram;
using QinSoft.Wx.MiniProgram.Model.Auth;
using QinSoft.Wx.MiniProgram.Model.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace QinSoft.Wx.Web.Controllers
{
    public class MiniProgramController : Controller
    {
        private MiniProgramService miniProgramService;

        public MiniProgramController()
        {
            this.miniProgramService = new MiniProgramServiceImp(new MiniProgramConfig()
            {
                AppId = "wx2059b6974af30819",
                AppSecret = "c4e05269dba64bcd9365575c10f2c2c1"
            });
        }

        [HttpGet]
        public ActionResult GetJsCode2Session(string jsCode)
        {
            GetAccessTokenResponse accessTokenResponse = this.miniProgramService.GetAccessToken();
            GetJsCode2SessionResponse getJsCode2SessionResponse = this.miniProgramService.GetJsCode2Session(jsCode);
            SendCustomerServiceMessageResponse sendCustomerServiceMessageResponse = this.miniProgramService.SendCustomerServiceMessage(accessTokenResponse.AccessToken, new CustomerServiceTextMsg() { ToUser = getJsCode2SessionResponse.OpenId, Text = new CustomerServiceTextMsgContent() { Content = "hello world" } });
            return Content(sendCustomerServiceMessageResponse.ToJson());
        }
    }
}
