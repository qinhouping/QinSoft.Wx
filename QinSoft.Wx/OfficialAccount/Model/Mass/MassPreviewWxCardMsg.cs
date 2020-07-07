using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassPreviewWxCardMsg : MassPreviewMsgBase
    {
        [JsonProperty("wxcard")]
        public MassPreviewWxCardMsgContent WxCard { get; set; }

        public MassPreviewWxCardMsg()
        {
            this.MsgType = "wxcard";
        }
    }

    public class MassPreviewWxCardMsgContent
    {
        [JsonProperty("card_id")]
        public string CardId { get; set; }

        [JsonProperty("card_ext")]
        public MassPreviewWxCardMsgContentExt CardExt { get; set; }
    }

    public class MassPreviewWxCardMsgContentExt
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("openid")]
        public string OpenId { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
}
