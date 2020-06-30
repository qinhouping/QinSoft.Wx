using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Media
{
    public class AddNewsMaterialRequest
    {
        [JsonProperty("articles")]
        public NewsMaterialArticle[] Articles { get; set; }
    }
}
