using Newtonsoft.Json;
using QinSoft.Wx.Common;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.NearByPoi
{
    public class GetNearByPoiListResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("data")]

        public GetNearByPoiListData Data { get; set; }
    }

    public class GetNearByPoiListData
    {
        [JsonProperty("left_apply_num")]
        public int LeftApplyNum { get; set; }

        [JsonProperty("max_apply_num")]
        public int MaxApplyNum { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        public GetNearByPoiListDataDetail DetailData
        {
            get
            {
                return Data.FromJson<GetNearByPoiListDataDetail>();
            }
            set
            {
                Data = value.ToJson();
            }
        }

        public class GetNearByPoiListDataDetail
        {
            [JsonProperty("poi_list")]
            public GetNearByPoiListItem[] PoiList { get; set; }
        }

        public class GetNearByPoiListItem
        {
            [JsonProperty("poi_id")]
            public string PoiId { get; set; }

            [JsonProperty("qualification_address")]
            public string QualificationAddress { get; set; }

            [JsonProperty("qualification_num")]
            public string QualificationNum { get; set; }

            [JsonProperty("audit_status")]
            public int AuditStatus { get; set; }

            [JsonProperty("display_status")]
            public int DisplayStatus { get; set; }

            [JsonProperty("refuse_reason")]
            public int RefuseReason { get; set; }
        }
    }
}
