using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.ReplyMsg
{
    public class ReplyNewsMsg : ReplyMsgBase
    {
        public ReplyNewsMsgContent Articles { get; set; }

        public ReplyNewsMsg()
        {
            this.MsgType = "news";
        }
    }

    public class ReplyNewsMsgContent
    {
        public ReplyNewsMsgContentItem[] Item { get; set; }
    }

    public class ReplyNewsMsgContentItem
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string PicUrl { get; set; }

        public string Url { get; set; }
    }
}
