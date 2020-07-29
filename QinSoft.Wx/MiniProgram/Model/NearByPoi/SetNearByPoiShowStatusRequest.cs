using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.NearByPoi
{
    public class SetNearByPoiShowStatusRequest
    {
        [JsonProperty("poi_id")]
        public string PoiId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
