using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Media
{
    public class UploadMaterialRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("introduction")]
        public string Introduction { get; set; }
    }
}
