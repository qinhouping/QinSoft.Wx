using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.CustomerService
{
    public class CustomerServiceTextMsg : CustomerServiceMsgBase
    {
        [JsonProperty("text")]
        public CustomerServiceTextMsgContent Text { get; set; }

        public CustomerServiceTextMsg()
        {
            this.MsgType = "text";
        }
    }

    public class CustomerServiceTextMsgContent
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
