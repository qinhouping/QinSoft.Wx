using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.CustomerService
{
    public class CustomerServiceImageMsg : CustomerServiceMsgBase
    {
        [JsonProperty("image")]
        public CustomerServiceImageMsgContent Image { get; set; }

        public CustomerServiceImageMsg()
        {
            this.MsgType = "image";
        }
    }

    public class CustomerServiceImageMsgContent
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }
    }
}
