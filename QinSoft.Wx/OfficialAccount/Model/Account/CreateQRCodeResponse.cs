using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.Account
{
    public class CreateQRCodeResponse
    {
        [JsonProperty("ticket")]
        public string Ticket { get; set; }

        [JsonProperty("expire_seconds")]
        public int ExpireSeconds { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
