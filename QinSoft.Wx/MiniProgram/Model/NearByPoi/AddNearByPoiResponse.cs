using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.NearByPoi
{
    public class AddNearByPoiResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("data")]
        public AddNearByPoiData Data { get; set; }
    }

    public class AddNearByPoiData
    {
        [JsonProperty("audit_id")]
        public string AuditId { get; set; }

        [JsonProperty("poi_id")]
        public string PoiId { get; set; }

        [JsonProperty("related_credential")]
        public string RelatedCredential { get; set; }
    }
}
