using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.RecvMsg.RecvEvent
{
    public class RecvPoiCheckNotifyEventMsg : RecvEventMsgBase
    {
        public string UniqId { get; set; }

        public string PoiId { get; set; }

        public string Result { get; set; }

        public string msg { get; set; }
    }
}
