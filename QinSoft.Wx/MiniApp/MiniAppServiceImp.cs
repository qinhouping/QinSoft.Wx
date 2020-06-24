using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.MiniApp
{
    public class MiniAppServiceImp : MiniAppService
    {
        private MiniAppConfig miniAppConfig;
        public MiniAppServiceImp(MiniAppConfig miniAppConfig)
        {
            this.miniAppConfig = miniAppConfig;
        }
    }
}
