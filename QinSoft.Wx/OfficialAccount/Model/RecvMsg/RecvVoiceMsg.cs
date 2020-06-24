using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.RecvMsg
{
    public class RecvVoiceMsg : RecvMsgBase
    {
        public string MediaId { get; set; }

        public string Format { get; set; }

        public string Recognition { get; set; }
    }
}
