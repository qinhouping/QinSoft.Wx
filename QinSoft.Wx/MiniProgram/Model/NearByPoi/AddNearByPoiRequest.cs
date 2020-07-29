using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.NearByPoi
{
    public class AddNearByPoiRequest
    {
        [JsonProperty("is_comm_nearby")]
        public string IsCommNearBy { get; set; } = "1";

        [JsonProperty("pic_list")]
        public string PicList { get; set; }

        [JsonProperty("service_infos")]
        public string ServiceInfos { get; set; }

        [JsonProperty("kf_info")]
        public string KFInfo { get; set; }

        [JsonProperty("hour")]
        public string Hour { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("poi_id")]
        public string PoiId { get; set; }

        [JsonProperty("company_name")]
        public string CompanyName { get; set; }

        [JsonProperty("contract_phone")]
        public string ContractPhone { get; set; }

        [JsonProperty("credential")]
        public string Credential { get; set; }

        [JsonProperty("qualification_list")]
        public string QualificationList { get; set; }

        [JsonProperty("map_poi_id")]
        public string MapPoiId { get; set; }
    }
}
