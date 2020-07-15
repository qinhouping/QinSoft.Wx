using QinSoft.Wx.MiniProgram.Model.Login;
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
    }
}
