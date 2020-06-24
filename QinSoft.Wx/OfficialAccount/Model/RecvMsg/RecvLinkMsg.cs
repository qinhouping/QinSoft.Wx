using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.RecvMsg
{
    public class RecvLinkMsg : RecvMsgBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }
    }
}
