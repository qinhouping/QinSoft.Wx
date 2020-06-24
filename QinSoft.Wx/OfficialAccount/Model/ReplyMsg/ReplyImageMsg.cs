using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.ReplyMsg
{
    public class ReplyImageMsg : ReplyMsgBase
    {
        public ReplyImageMsgContent Image { get; set; }

        public ReplyImageMsg()
        {
            this.MsgType = "image";
        }
    }

    public class ReplyImageMsgContent
    {
        public string MediaId { get; set; }
    }
}
