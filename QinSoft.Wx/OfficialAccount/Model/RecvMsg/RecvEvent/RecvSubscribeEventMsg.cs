using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.RecvMsg.RecvEvent
{
    public class RecvSubscribeEventMsg : RecvEventMsgBase
    {
        public string EventKey { get; set; }

        public string Ticket { get; set; }
    }
}
