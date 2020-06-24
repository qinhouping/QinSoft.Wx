using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.ReplyMsg
{
    public class ReplyMuiscMsg : ReplyMsgBase
    {
        public ReplyMusicMsgContent Music { get; set; }

        public ReplyMuiscMsg()
        {
            this.MsgType = "music";
        }
    }

    public class ReplyMusicMsgContent
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string MusicUrl { get; set; }

        public string HQMusicUrl { get; set; }

        public string ThumbMediaId { get; set; }
    }
}
