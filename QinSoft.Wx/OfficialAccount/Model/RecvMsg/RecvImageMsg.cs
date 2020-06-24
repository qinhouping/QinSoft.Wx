using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.RecvMsg
{
    public class RecvImageMsg : RecvMsgBase
    {
        public string PicUrl { get; set; }

        public string MediaId { get; set; }
    }
}
