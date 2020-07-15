using QinSoft.Wx.MiniProgram;
using QinSoft.Wx.MiniProgram.Model.Login;
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
        public GetJsCode2SessionResponse GetJsCode2Session(string jsCode)
        {
            return miniProgramService.GetJsCode2Session(jsCode);
        }
    }
}
