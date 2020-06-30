using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Media
{
    public class UpdateNewsMaterialRequest
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("articles")]
        public NewsMaterialArticle Article { get; set; }
    }
}
