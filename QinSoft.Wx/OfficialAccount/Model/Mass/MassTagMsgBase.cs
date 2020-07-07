using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassTagMsgBase : MassMsgBase
    {
        [JsonProperty("filter")]
        public MassTagMsgFilter Filter { get; set; }


        [JsonProperty("send_ignore_reprint ")]
        public int SendIgnoreReprint { get; set; }

        [JsonProperty("clientmsgid")]
        public string ClientMsgId { get; set; }
    }

    public class MassTagMsgFilter
    {
        [JsonProperty("is_to_all")]
        public bool IsToAll { get; set; }

        [JsonProperty("tag_id")]
        public int TagId { get; set; }
    }
}
