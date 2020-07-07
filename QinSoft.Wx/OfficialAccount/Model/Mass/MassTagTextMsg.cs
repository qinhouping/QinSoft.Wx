using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassTagTextMsg : MassTagMsgBase
    {
        [JsonProperty("text")]
        public MassTagTextMsgContent Text { get; set; }

        public MassTagTextMsg()
        {
            this.MsgType = "text";
        }
    }

    public class MassTagTextMsgContent
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
