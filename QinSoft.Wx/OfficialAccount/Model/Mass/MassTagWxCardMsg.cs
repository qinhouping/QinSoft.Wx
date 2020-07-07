using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassTagWxCardMsg : MassTagMsgBase
    {
        [JsonProperty("wxcard")]
        public MassTagWxCardMsgContent WxCard { get; set; }

        public MassTagWxCardMsg()
        {
            this.MsgType = "wxcard";
        }
    }

    public class MassTagWxCardMsgContent
    {
        [JsonProperty("card_id")]
        public string CardId { get; set; }
    }
}
