using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.RecvMsg.RecvEvent
{
    public class RecvLocationEventMsg : RecvEventMsgBase
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Precision { get; set; }
    }
}
