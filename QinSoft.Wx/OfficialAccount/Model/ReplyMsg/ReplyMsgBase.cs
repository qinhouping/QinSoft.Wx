using QinSoft.Wx.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QinSoft.Wx.OfficialAccount.Model.ReplyMsg
{
    public class ReplyMsgBase
    {
        public string ToUserName { get; set; }

        public string FromUserName { get; set; }

        public long CreateTime { get; set; }

        public string MsgType { get; set; }

        public ReplyMsgBase()
        {
            this.CreateTime = DateTime.Now.ToTimeStamp();
        }
    }
}
