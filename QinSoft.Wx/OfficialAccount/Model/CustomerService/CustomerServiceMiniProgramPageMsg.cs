using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QinSoft.Wx.OfficialAccount.Model.CustomerService
{
    public class CustomerServiceMiniProgramPageMsg : CustomerServiceMsgBase
    {
        [JsonProperty("miniprogrampage")]
        public CustomerServiceMiniProgramPageMsgContent MiniProgramPage { get; set; }

        public CustomerServiceMiniProgramPageMsg()
        {
            this.MsgType = "miniprogrampage";
        }
    }

    public class CustomerServiceMiniProgramPageMsgContent
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("appid")]
        public string AppId { get; set; }

        [JsonProperty("pagepath")]
        public string PagePath { get; set; }

        [JsonProperty("thumb_media_id")]
        public string ThumbMediaId { get; set; }
    }
}
