using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QinSoft.Wx.OfficialAccount.Model.ReplyMsg
{
    public class ReplyTextMsg : ReplyMsgBase
    {
        public string Content { get; set; }

        public ReplyTextMsg()
        {
            this.MsgType = "text";
        }
    }
}
