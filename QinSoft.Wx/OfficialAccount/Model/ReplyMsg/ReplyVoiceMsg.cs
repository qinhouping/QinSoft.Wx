using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.ReplyMsg
{
    public class ReplyVoiceMsg : ReplyMsgBase
    {
        public ReplyVoiceMsgContent Voice { get; set; }

        public ReplyVoiceMsg()
        {
            this.MsgType = "voice";
        }
    }

    public class ReplyVoiceMsgContent
    {
        public string MediaId { get; set; }
    }
}
