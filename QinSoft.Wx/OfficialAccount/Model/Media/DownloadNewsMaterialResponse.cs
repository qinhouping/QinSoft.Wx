using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Media
{
    public class DownloadNewsMaterialResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("news_item")]
        public DownloadNewsMaterialArticle[] NewsItem { get; set; }
    }

    public class DownloadNewsMaterialArticle
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("thumb_media_id")]
        public string ThumbMediaId { get; set; }

        [JsonProperty("show_cover_pic")]
        public int ShowCoverPic { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("digest")]
        public string Digest { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("content_source_url")]
        public string ContentSourceUrl { get; set; }
    }
}
