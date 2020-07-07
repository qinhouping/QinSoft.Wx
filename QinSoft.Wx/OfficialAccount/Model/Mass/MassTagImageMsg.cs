using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Mass
{
    public class MassTagImageMsg : MassTagMsgBase
    {
        [JsonProperty("images")]
        public MassTagImageMsgContent Images { get; set; }
        public MassTagImageMsg()
        {
            this.MsgType = "image";
        }
    }

    public class MassTagImageMsgContent
    {
        [JsonProperty("media_ids")]
        public string[] MediaIds { get; set; }

        [JsonProperty("recommend")]
        public string Recommend { get; set; }


        [JsonProperty("need_open_comment")]
        public int NeedOpenComment { get; set; }

        [JsonProperty("only_fans_can_comment")]
        public int OnlyFansCanComment { get; set; }
    }
}
