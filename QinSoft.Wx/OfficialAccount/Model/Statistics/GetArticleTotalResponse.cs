using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount.Model.Statistics
{
    public class GetArticleTotalResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("list")]
        public GetArticleTotalResponseData[] List { get; set; }
    }

    public class GetArticleTotalResponseData
    {
        [JsonProperty("ref_date")]
        public string RefDate { get; set; }

        [JsonProperty("msgid")]
        public string msgid { get; set; }

        [JsonProperty("title")]
        public string Titel { get; set; }

        [JsonProperty("details")]
        public GetArticleTotalResponseDataDetail[] Details { get; set; }
    }

    public class GetArticleTotalResponseDataDetail
    {
        [JsonProperty("stat_date")]
        public string StatDate { get; set; }

        [JsonProperty("target_user")]
        public int TargetUser { get; set; }

        [JsonProperty("int_page_read_user")]
        public int IntPageReadUser { get; set; }

        [JsonProperty("int_page_read_count")]
        public int IntPageReadCount { get; set; }

        [JsonProperty("ori_page_read_user")]
        public int OriPageReadUser { get; set; }

        [JsonProperty("ori_page_read_count")]
        public int OriPageReadCount { get; set; }

        [JsonProperty("share_user")]
        public int ShareUser { get; set; }

        [JsonProperty("share_count")]
        public int ShareCount { get; set; }

        [JsonProperty("add_to_fav_user")]
        public int AddToFavUser { get; set; }

        [JsonProperty("add_to_fav_count")]
        public int AddToFavCount { get; set; }

        [JsonProperty("int_page_from_session_read_user")]
        public int IntPageFromSessionReadUser { get; set; }

        [JsonProperty("int_page_from_session_read_count")]
        public int IntPageFromSessionReadCount { get; set; }

        [JsonProperty("int_page_from_hist_msg_read_user")]
        public int IntPageFromHistMsgReadUser { get; set; }

        [JsonProperty("int_page_from_hist_msg_read_count")]
        public int IntPageFromHistMsgReadCount { get; set; }

        [JsonProperty("int_page_from_feed_read_user")]
        public int IntPageFromFeedReadUser { get; set; }

        [JsonProperty("int_page_from_friends_read_user")]
        public int IntPageFromFriendsReadUser { get; set; }

        [JsonProperty("int_page_from_friends_read_count")]
        public int IntPageFromFriendsReadCount { get; set; }

        [JsonProperty("int_page_from_other_read_user")]
        public int IntPageFromOtherReadUser { get; set; }

        [JsonProperty("int_page_from_other_read_count")]
        public int IntPageFromOtherReadCount { get; set; }

        [JsonProperty("feed_share_from_session_user")]
        public int FeedShareFromSessionUser { get; set; }

        [JsonProperty("feed_share_from_session_cnt")]
        public int FeedShareFromSessionCnt { get; set; }

        [JsonProperty("feed_share_from_feed_user")]
        public int FeedShareFromFeedUser { get; set; }

        [JsonProperty("feed_share_from_feed_count")]
        public int FeedShareFromFeedCount { get; set; }

        [JsonProperty("feed_share_from_other_user")]
        public int FeedShareFromOtherUser { get; set; }

        [JsonProperty("feed_share_from_other_count")]
        public int FeedShareFromOtherCount { get; set; }
    }
}
