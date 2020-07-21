﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram.Model.CustomerService
{
    public class UploadTempMediaResponse
    {
        [JsonProperty("errcode")]
        public int ErrCode { get; set; }

        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("media_id")]
        public string MediaId { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }
    }
}