using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class CustomerServiceVoiceMsg : CustomerServiceMsgBase
    {
        [JsonProperty("voice")]
        public CustomerServiceVoiceMsgContent Voice { get; set; }

        public CustomerServiceVoiceMsg()
        {
            this.MsgType = "Voice";
        }
    }

    public class CustomerServiceVoiceMsgContent
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}
