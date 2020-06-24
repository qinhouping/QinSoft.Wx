using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.RecvMsg
{
    public class RecvShortVideoMsg : RecvMsgBase
    {
        public string MediaId { get; set; }

        public string ThumbMediaId { get; set; }
    }
}
