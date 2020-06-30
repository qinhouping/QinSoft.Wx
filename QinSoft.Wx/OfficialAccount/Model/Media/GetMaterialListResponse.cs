using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Media
{
    public class GetMaterialListResponse<T> where T : MaterialListItem
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("item_count")]
        public int ItemCount { get; set; }

        [JsonProperty("item")]
        public T[] Item { get; set; }
    }

    public class MaterialListItem
    {
        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        [JsonProperty("update_time")]
        public long UpdateTime { get; set; }
    }

    public class NewsMaterislListItem : MaterialListItem
    {
        [JsonProperty("content")]
        public NewsMaterislListItemContent[] Content { get; set; }
    }

    public class NewsMaterislListItemContent
    {
        [JsonProperty("news_item")]
        public NewsMaterialArticle[] NewsItem { get; set; }
    }

    public class NotNewsMaterislListItem : MaterialListItem
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
