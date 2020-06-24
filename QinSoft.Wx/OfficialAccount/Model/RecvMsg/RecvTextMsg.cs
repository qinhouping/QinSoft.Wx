using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QinSoft.Wx.OfficialAccount.Model.RecvMsg
{
    public class RecvTextMsg : RecvMsgBase
    {
        public string Content { get; set; }

        [XmlElement(ElementName = "bizmsgmenuid")]
        public string BizMsgMenuId { get; set; }
    }
}
