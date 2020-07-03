using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Statistics
{
    public class GetUserShareRequest
    {
        [JsonProperty("begin_date")]
        public string BeginDate { get; set; }

        [JsonProperty("end_date")]
        public string EndDate { get; set; }
    }
}
