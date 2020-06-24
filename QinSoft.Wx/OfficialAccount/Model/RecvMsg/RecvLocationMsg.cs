using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.RecvMsg
{
    public class RecvLocationMsg : RecvMsgBase
    {
        public double Location_X { get; set; }

        public double Location_Y { get; set; }

        public int Scale { get; set; }

        public string Label { get; set; }
    }
}
