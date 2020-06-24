using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.ReplyMsg
{
    public class ReplyVideoMsg : ReplyMsgBase
    {
        public ReplyVideoMsgContent Video { get; set; }

        public ReplyVideoMsg()
        {
            this.MsgType = "video";
        }
    }
    public class ReplyVideoMsgContent
    {
        public string MediaId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
