using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount
{
    public class OfficialAccountException : Exception
    {
        public int ErrCode { get; private set; }

        public string ErrMsg { get; private set; }

        public OfficialAccountException(int errCode, string errMsg) : base(string.Format("OfficialAccount ErrCode:{0} ErrMsg:{1}", errCode, errMsg))
        {
            this.ErrCode = errCode;
            this.ErrMsg = ErrMsg;
        }
    }
}
