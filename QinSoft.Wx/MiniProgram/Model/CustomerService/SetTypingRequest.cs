using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.CustomerService
{
    public class SetTypingRequest
    {
        [JsonProperty("touser")]
        public string ToUser { get; set; }

        [JsonProperty("command")]
        public string Command { get; set; }
    }
}
