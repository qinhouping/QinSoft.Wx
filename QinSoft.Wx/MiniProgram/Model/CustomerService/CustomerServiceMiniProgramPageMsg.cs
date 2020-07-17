using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.CustomerService
{
    public class CustomerServiceMiniProgramPageMsg : CustomerServiceMsgBase
    {
        [JsonProperty("Miniprogrampage")]
        public CustomerServiceMiniProgramPageMsgContent MiniProgramPage { get; set; }

        public CustomerServiceMiniProgramPageMsg()
        {
            this.MsgType = "miniprogrampage ";
        }
    }

    public class CustomerServiceMiniProgramPageMsgContent
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("pagepath")]
        public string PagePath { get; set; }

        [JsonProperty("thumb_media_id")]
        public string ThumbMediaId { get; set; }
    }
}
