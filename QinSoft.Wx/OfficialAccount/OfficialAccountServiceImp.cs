using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using QinSoft.Wx.Common;
using QinSoft.Wx.OfficialAccount.Model.AccessToken;
using QinSoft.Wx.OfficialAccount.Model.Account;
using QinSoft.Wx.OfficialAccount.Model.CustomerService;
using QinSoft.Wx.OfficialAccount.Model.Media;
using QinSoft.Wx.OfficialAccount.Model.Menu;
using QinSoft.Wx.OfficialAccount.Model.Subscribe;
using QinSoft.Wx.OfficialAccount.Model.Template;
using QinSoft.Wx.OfficialAccount.Model.User;
using QinSoft.Wx.OfficialAccount.Model.Web;

namespace QinSoft.Wx.OfficialAccount
{
    /// <summary>
    /// 公众号服务实现
    /// </summary>
    public class OfficialAccountServiceImp : OfficialAccountService
    {
        private OfficialAccountConfig officialAccountConfig;

        private Dictionary<string, string> urlDictionary;

        public OfficialAccountServiceImp(OfficialAccountConfig officialAccountConfig)
        {
            if (officialAccountConfig == null) throw new ArgumentNullException("officialAccountConfig");
            this.officialAccountConfig = officialAccountConfig;
            this.urlDictionary = new Dictionary<string, string>() {
                { "GetAccessToken","https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}" },
                { "CreateMenu","https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}" },
                { "CreateConditionalMenu","https://api.weixin.qq.com/cgi-bin/menu/addconditional?access_token={0}"},
                { "DeleteMenu","https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}"},
                { "DeleteConditionalMenu","https://api.weixin.qq.com/cgi-bin/menu/delconditional?access_token={0}" },
                { "AddCustomerService","https://api.weixin.qq.com/customservice/kfaccount/add?access_token={0}" },
                { "UpdateCustomerService","https://api.weixin.qq.com/customservice/kfaccount/update?access_token={0}" },
                { "DeleteCustomerService","https://api.weixin.qq.com/customservice/kfaccount/del?access_token={0}" },
                { "GetCustomerServiceList","https://api.weixin.qq.com/cgi-bin/customservice/getkflist?access_token={0}" },
                { "SendCustomerServiceMessage","https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}" },
                { "TypingCustomerService","https://api.weixin.qq.com/cgi-bin/message/custom/typing?access_token={0}" },
                { "SetTemplateIndustry","https://api.weixin.qq.com/cgi-bin/template/api_set_industry?access_token={0}" },
                { "GetTemplateIndustry","https://api.weixin.qq.com/cgi-bin/template/get_industry?access_token={0}" },
                { "GetTemplateId","https://api.weixin.qq.com/cgi-bin/template/api_add_template?access_token={0}"},
                { "GetTemplateList","https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token={0}" },
                { "DeleteTemplate","https://api.weixin.qq.com/cgi-bin/template/del_private_template?access_token={0}" },
                { "SendTemplateMessage","https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}" },
                { "SubscribeUrl","https://mp.weixin.qq.com/mp/subscribemsg?action={0}&appid={1}&scene={2}&template_id={3}&redirect_url={4}&reserved={5}#wechat_redirect" },
                { "SendSubscribeMessage","https://api.weixin.qq.com/cgi-bin/message/template/subscribe?access_token={0}" },
                { "CreateTag","https://api.weixin.qq.com/cgi-bin/tags/create?access_token={0}" },
                { "UpdateTag","https://api.weixin.qq.com/cgi-bin/tags/update?access_token={0}" },
                { "DeleteTag","https://api.weixin.qq.com/cgi-bin/tags/delete?access_token={0}" },
                { "GetTagList","https://api.weixin.qq.com/cgi-bin/tags/get?access_token={0}" },
                { "GetTagUserList", "https://api.weixin.qq.com/cgi-bin/user/tag/get?access_token={0}" },
                { "BatchTagging","https://api.weixin.qq.com/cgi-bin/user/tag/get?access_token={0}" },
                { "BatchUntagging","https://api.weixin.qq.com/cgi-bin/tags/members/batchuntagging?access_token={0}" },
                { "GetUserTagList","https://api.weixin.qq.com/cgi-bin/tags/getidlist?access_token={0}" },
                { "UpdateRemark","https://api.weixin.qq.com/cgi-bin/user/info/updateremark?access_token={0}" },
                { "GetUserInfo","https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang={2}" },
                { "BatchGetUserInfo","https://api.weixin.qq.com/cgi-bin/user/info/batchget?access_token={0}" },
                { "GetUserList","https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}" },
                { "GetBlackUserList","https://api.weixin.qq.com/cgi-bin/tags/members/getblacklist?access_token={0}" },
                { "CreateQRCode","https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}" },
                { "QRCodeUrl", "https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}"},
                { "GetShortUrl","https://api.weixin.qq.com/cgi-bin/shorturl?access_token={0}" },
                { "UploadMedia","https://api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}" },
                { "GetMedia","https://api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}" },
                { "AddNewsMaterial","https://api.weixin.qq.com/cgi-bin/material/add_news?access_token={0}" },
                { "UploadNewsMaterialImg","https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}" },
                { "UploadMaterial","https://api.weixin.qq.com/cgi-bin/material/add_material?access_token={0}&type={1}" },
                { "DownloadMaterial","https://api.weixin.qq.com/cgi-bin/material/get_material?access_token={0}" },
                { "DeleteMaterial","https://api.weixin.qq.com/cgi-bin/material/del_material?access_token={0}" },
                { "UpdateNewsMaterial","https://api.weixin.qq.com/cgi-bin/material/update_news?access_token={0}" },
                { "GetMaterialCount","https://api.weixin.qq.com/cgi-bin/material/get_materialcount?access_token={0}" },
                { "GetMaterialList","https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token={0}" },
                { "GetAuthorizeUrl","https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type={2}&scope={3}&state={4}#wechat_redirect" },
                { "GetOAuth2AccessToken"," https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type={3}" },
                { "RefreshOAuth2AccessToken","https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type={1}&refresh_token={2}" },
                { "GetOAuth2UserInfo","https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang={2}" },
                { "IsValidOAuth2AccessToken","https://api.weixin.qq.com/sns/auth?access_token={0}&openid={1}" },
                { "GetJsApiTicket","https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type={1}" }
            };
        }

        public override string CalculateJoinSignature(long timestamp, string nonce)
        {
            List<string> data = new List<string>();
            data.Add(timestamp.ToString());
            data.Add(nonce);
            data.Add(this.officialAccountConfig.Token);
            data.Sort();
            string joinStr = string.Join("", data);
            return joinStr.SHA1();
        }

        public override string GetAccessToken()
        {
            AccessTokenResponse response = RetryTools.Retry<AccessTokenResponse>(() =>
            {
                return HttpTools.Get<AccessTokenResponse>(string.Format(urlDictionary["GetAccessToken"], this.officialAccountConfig.AppId, this.officialAccountConfig.AppSecret), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            else return response.AccessToken;
        }

        #region 菜单
        public override void CreateMenu(string accessToken, MenuInfo menuInfo, bool isConditional = false)
        {
            CreateMenuResponse response = RetryTools.Retry<CreateMenuResponse>(() =>
            {
                return HttpTools.Post<CreateMenuResponse>(string.Format(urlDictionary[isConditional ? "CreateConditionalMenu" : "CreateMenu"], accessToken), null, null, menuInfo);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override void DeleteMenu(string accessToken, bool isConditional = false)
        {
            DeleteMenuResponse response = RetryTools.Retry<DeleteMenuResponse>(() =>
            {
                return HttpTools.Get<DeleteMenuResponse>(string.Format(urlDictionary[isConditional ? "DeleteConditionalMenu" : "DeleteMenu"], accessToken), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }
        #endregion

        #region 群发
        #endregion

        #region 客服

        public override void AddCustomerService(string accessToken, CustomerServiceActionRequest customerService)
        {
            CustomerServiceActionResponse response = RetryTools.Retry<CustomerServiceActionResponse>(() =>
            {
                return HttpTools.Post<CustomerServiceActionResponse>(string.Format(urlDictionary["AddCustomerService"], accessToken), null, null, customerService);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override void UpdateCustomerService(string accessToken, CustomerServiceActionRequest customerService)
        {
            CustomerServiceActionResponse response = RetryTools.Retry<CustomerServiceActionResponse>(() =>
            {
                return HttpTools.Post<CustomerServiceActionResponse>(string.Format(urlDictionary["UpdateCustomerService"], accessToken), null, null, customerService);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override void DeleteCustomerService(string accessToken, CustomerServiceActionRequest customerService)
        {
            CustomerServiceActionResponse response = RetryTools.Retry<CustomerServiceActionResponse>(() =>
            {
                return HttpTools.Post<CustomerServiceActionResponse>(string.Format(urlDictionary["DeleteCustomerService"], accessToken), null, null, customerService);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override CustomerServiceListItem[] GetCustomerServiceList(string accessToken)
        {
            CustomerServiceListResponse response = RetryTools.Retry<CustomerServiceListResponse>(() =>
            {
                return HttpTools.Get<CustomerServiceListResponse>(string.Format(urlDictionary["GetCustomerServiceList"], accessToken), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response.CustomerServiceList;
        }

        public override void SendCustomerServiceMessage(string accessToken, CustomerServiceMsgBase message)
        {
            CustomerServiceMsgResponse response = RetryTools.Retry<CustomerServiceMsgResponse>(() =>
            {
                return HttpTools.Post<CustomerServiceMsgResponse>(string.Format(urlDictionary["SendCustomerServiceMessage"], accessToken), null, null, message);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override void TypingCustomerService(string accessToken, TypingCustomerServiceRequest request)
        {
            TypingCustomerServiceResponse response = RetryTools.Retry<TypingCustomerServiceResponse>(() =>
            {
                return HttpTools.Post<TypingCustomerServiceResponse>(string.Format(urlDictionary["TypingCustomerService"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }
        #endregion

        #region 模板
        public override void SetTemplateIndustry(string accessToken, SetTemplateIndustryRequest request)
        {
            SetTemplateIndustryResponse response = RetryTools.Retry<SetTemplateIndustryResponse>(() =>
            {
                return HttpTools.Post<SetTemplateIndustryResponse>(string.Format(urlDictionary["SetTemplateIndustry"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override GetTemplateIndustryResponse GetTemplateIndustry(string accessToken)
        {
            GetTemplateIndustryResponse response = RetryTools.Retry<GetTemplateIndustryResponse>(() =>
            {
                return HttpTools.Get<GetTemplateIndustryResponse>(string.Format(urlDictionary["GetTemplateIndustry"], accessToken), null, null);
            });
            return response;
        }

        public override string GetTemplateId(string accessToken, string templateIdShort)
        {
            GetTemplateIdRequest request = new GetTemplateIdRequest() { TemplateIdShort = templateIdShort };
            GetTemplateIdResponse response = RetryTools.Retry<GetTemplateIdResponse>(() =>
            {
                return HttpTools.Post<GetTemplateIdResponse>(string.Format(urlDictionary["GetTemplateId"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response.TemplateId;
        }

        public override GetTemplateListResponse GetTemplateList(string accessToken)
        {
            GetTemplateListResponse response = RetryTools.Retry<GetTemplateListResponse>(() =>
            {
                return HttpTools.Get<GetTemplateListResponse>(string.Format(urlDictionary["GetTemplateList"], accessToken), null, null);
            });
            return response;
        }

        public override void DeleteTemplate(string accessToken, string templateId)
        {
            DeleteTemplateRequest request = new DeleteTemplateRequest() { TemplateId = templateId };
            DeleteTemplateResponse response = RetryTools.Retry<DeleteTemplateResponse>(() =>
            {
                return HttpTools.Post<DeleteTemplateResponse>(string.Format(urlDictionary["DeleteTemplate"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override string SendTemplateMessage(string accessToken, TemplateMessage message)
        {
            SendTemplateMessageResponse response = RetryTools.Retry<SendTemplateMessageResponse>(() =>
            {
                return HttpTools.Post<SendTemplateMessageResponse>(string.Format(urlDictionary["SendTemplateMessage"], accessToken), null, null, message);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response.MsgId;
        }
        #endregion

        #region 订阅
        public override string GetSubscribeUrl(string scene, string templateId, string redirectUrl, string reserved)
        {
            return string.Format(
                urlDictionary["SubscribeUrl"],
                "get_confirm",
                this.officialAccountConfig.AppId,
                scene,
                templateId,
                HttpUtility.UrlEncode(redirectUrl),
                HttpUtility.UrlEncode(reserved)
                );
        }

        public override void SendSubscribeMessage(string accessToken, SubscribeMessage message)
        {
            SendSubscribeMessageResponse response = RetryTools.Retry<SendSubscribeMessageResponse>(() =>
            {
                return HttpTools.Post<SendSubscribeMessageResponse>(string.Format(urlDictionary["SendSubscribeMessage"], accessToken), null, null, message);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }
        #endregion

        #region 用户
        public override CreateTagResponse CreateTag(string accessToken, CreateTagRequest request)
        {
            CreateTagResponse response = RetryTools.Retry<CreateTagResponse>(() =>
            {
                return HttpTools.Post<CreateTagResponse>(string.Format(urlDictionary["CreateTag"], accessToken), null, null, request);
            });
            return response;
        }

        public override void UpdateTag(string accessToken, UpdateTagRequest request)
        {
            UpdateTagResponse response = RetryTools.Retry<UpdateTagResponse>(() =>
            {
                return HttpTools.Post<UpdateTagResponse>(string.Format(urlDictionary["UpdateTag"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override void DeleteTag(string accessToken, DeleteTagRequest request)
        {
            DeleteTagResponse response = RetryTools.Retry<DeleteTagResponse>(() =>
            {
                return HttpTools.Post<DeleteTagResponse>(string.Format(urlDictionary["DeleteTag"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override GetTagListResponse GetTagList(string accessToken)
        {
            GetTagListResponse response = RetryTools.Retry<GetTagListResponse>(() =>
            {
                return HttpTools.Get<GetTagListResponse>(string.Format(urlDictionary["GetTagList"], accessToken), null, null);
            });
            return response;
        }

        public override GetTagUserListResponse GetTagUserList(string accessToken, GetTagUserListRequest request)
        {
            GetTagUserListResponse response = RetryTools.Retry<GetTagUserListResponse>(() =>
            {
                return HttpTools.Post<GetTagUserListResponse>(string.Format(urlDictionary["GetTagUserList"], accessToken), null, null, request);
            });
            return response;
        }

        public override void BatchTagging(string accessToken, BatchTaggingRequest request)
        {
            BatchTaggingResponse response = RetryTools.Retry<BatchTaggingResponse>(() =>
            {
                return HttpTools.Post<BatchTaggingResponse>(string.Format(urlDictionary["BatchTagging"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override void BatchUntagging(string accessToken, BatchUntaggingRequest request)
        {
            BatchUntaggingResponse response = RetryTools.Retry<BatchUntaggingResponse>(() =>
            {
                return HttpTools.Post<BatchUntaggingResponse>(string.Format(urlDictionary["BatchUntagging"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override GetUserTagListResponse GetUserTagList(string accessToken, GetUserTagListRequest request)
        {
            GetUserTagListResponse response = RetryTools.Retry<GetUserTagListResponse>(() =>
            {
                return HttpTools.Post<GetUserTagListResponse>(string.Format(urlDictionary["GetUserTagList"], accessToken), null, null, request);
            });
            return response;
        }

        public override void UpdateRemark(string accessToken, UpdateRemarkRequest request)
        {
            UpdateRemarkResponse response = RetryTools.Retry<UpdateRemarkResponse>(() =>
            {
                return HttpTools.Post<UpdateRemarkResponse>(string.Format(urlDictionary["UpdateRemark"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override UserInfo GetUserInfo(string accessToken, string openId, string lang = "zh_CN")
        {
            GetUserInfoResponse response = RetryTools.Retry<GetUserInfoResponse>(() =>
            {
                return HttpTools.Get<GetUserInfoResponse>(string.Format(urlDictionary["GetUserInfo"], accessToken, openId, lang), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public override UserInfo[] BatchGetUserInfo(string accessToken, BatchGetUserInfoRequest request)
        {
            BatchGetUserInfoResponse response = RetryTools.Retry<BatchGetUserInfoResponse>(() =>
            {
                return HttpTools.Get<BatchGetUserInfoResponse>(string.Format(urlDictionary["BatchGetUserInfo"], accessToken), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response.UserInfoList;
        }

        public override GetUserListResponse GetUserList(string accessToken, string nextOpenId)
        {
            GetUserListResponse response = RetryTools.Retry<GetUserListResponse>(() =>
            {
                return HttpTools.Get<GetUserListResponse>(string.Format(urlDictionary["GetUserList"], accessToken, nextOpenId), null, null);
            });
            return response;
        }

        public override GetBlackUserListResponse GetBlackUserList(string accessToken, GetBlackUserListRequest request)
        {
            GetBlackUserListResponse response = RetryTools.Retry<GetBlackUserListResponse>(() =>
            {
                return HttpTools.Post<GetBlackUserListResponse>(string.Format(urlDictionary["GetBlackUserList"], accessToken), null, null, request);
            });
            return response;
        }

        public override void BatchBlackList(string accessToken, BatchBlackListRequest request)
        {
            BatchBlackListResponse response = RetryTools.Retry<BatchBlackListResponse>(() =>
            {
                return HttpTools.Post<BatchBlackListResponse>(string.Format(urlDictionary["BatchBlackList"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override void BatchUnblackList(string accessToken, BatchUnblackListRequest request)
        {
            BatchUnblackListResponse response = RetryTools.Retry<BatchUnblackListResponse>(() =>
            {
                return HttpTools.Post<BatchUnblackListResponse>(string.Format(urlDictionary["BatchBlackList"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }
        #endregion

        #region 账户
        public override CreateQRCodeResponse CreateQRCode(string accessToken, CreateQRCodeRequest request)
        {
            CreateQRCodeResponse response = RetryTools.Retry<CreateQRCodeResponse>(() =>
            {
                return HttpTools.Post<CreateQRCodeResponse>(string.Format(urlDictionary["CreateQRCode"], accessToken), null, null, request);
            });
            return response;
        }

        public override string GetQRCodeUrl(string ticket)
        {
            return string.Format(urlDictionary["QRCodeUrl"], HttpUtility.UrlEncode(ticket));
        }

        public override string GetShortUrl(string accessToken, string longUrl)
        {
            GetShortUrlResponse response = RetryTools.Retry<GetShortUrlResponse>(() =>
            {
                return HttpTools.Post<GetShortUrlResponse>(string.Format(urlDictionary["GetShortUrl"], accessToken), null, null, new GetShortUrlRequest() { LongUrl = longUrl });
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response.ShortUrl;
        }
        #endregion

        #region 素材

        public async override Task<UploadMediaResponse> UploadMedia(string accessToken, string type, string fileName, Stream stream)
        {
            UploadMediaResponse response = await RetryTools.Retry<Task<UploadMediaResponse>>(async () =>
            {
                return await HttpTools.UploadAsync<UploadMediaResponse>(string.Format(urlDictionary["UploadMedia"], accessToken, type), stream, fileName);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public override DownloadMediaResponse DownloadVideoMedia(string accessToken, string mediaId)
        {
            DownloadMediaResponse response = RetryTools.Retry<DownloadMediaResponse>(() =>
            {
                return HttpTools.Get<DownloadMediaResponse>(string.Format(urlDictionary["GetMedia"], accessToken, mediaId), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public async override Task<Stream> DownloadMedia(string accessToken, string mediaId)
        {
            Stream stream = await RetryTools.Retry<Task<Stream>>(async () =>
            {
                return await HttpTools.DownloadAsync(string.Format(urlDictionary["GetMedia"], accessToken, mediaId), null, null);
            });
            return stream;
        }

        public override AddNewsMaterialResponse AddNewsMaterial(string accessToken, AddNewsMaterialRequest request)
        {
            AddNewsMaterialResponse response = RetryTools.Retry<AddNewsMaterialResponse>(() =>
            {
                return HttpTools.Post<AddNewsMaterialResponse>(string.Format(urlDictionary["AddNewsMaterial"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public async override Task<UploadNewsMaterialImgResponse> UploadNewsMaterialImg(string accessToken, string fileName, Stream stream)
        {
            UploadNewsMaterialImgResponse response = await RetryTools.Retry<Task<UploadNewsMaterialImgResponse>>(async () =>
            {
                return await HttpTools.UploadAsync<UploadNewsMaterialImgResponse>(string.Format(urlDictionary["UploadNewsMaterialImg"], accessToken), stream, fileName);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public async override Task<UploadMaterialResponse> UploadMaterial(string accessToken, string type, string fileName, Stream stream, UploadMaterialRequest request = null)
        {
            UploadMaterialResponse response = await RetryTools.Retry<Task<UploadMaterialResponse>>(async () =>
            {
                return await HttpTools.UploadAsync<UploadMaterialResponse>(string.Format(urlDictionary["UploadMaterial"], accessToken, type), stream, fileName, request != null ? new Dictionary<string, string>() { { "description", request.ToJson() } } : new Dictionary<string, string>());
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public override DownloadNewsMaterialResponse DownloadNewsMaterial(string accessToken, DownloadMaterialRequest request)
        {
            DownloadNewsMaterialResponse response = RetryTools.Retry<DownloadNewsMaterialResponse>(() =>
            {
                return HttpTools.Post<DownloadNewsMaterialResponse>(string.Format(urlDictionary["DownloadMaterial"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public override DownloadVideoMaterialResponse DownloadVideoMaterial(string accessToken, DownloadMaterialRequest request)
        {
            DownloadVideoMaterialResponse response = RetryTools.Retry<DownloadVideoMaterialResponse>(() =>
            {
                return HttpTools.Post<DownloadVideoMaterialResponse>(string.Format(urlDictionary["DownloadMaterial"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public async override Task<Stream> DownloadMaterial(string accessToken, DownloadMaterialRequest request)
        {
            Stream stream = await RetryTools.Retry<Task<Stream>>(async () =>
            {
                return await HttpTools.DownloadAsync(WebMethod.POST, string.Format(urlDictionary["DownloadMaterial"], accessToken), null, null, request);
            });
            return stream;
        }

        public override void DeleteMaterial(string accessToken, DeleteMaterialRequest request)
        {
            DeleteMaterialResponse response = RetryTools.Retry<DeleteMaterialResponse>(() =>
            {
                return HttpTools.Post<DeleteMaterialResponse>(string.Format(urlDictionary["DeleteMaterial"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override void UpdateNewsMaterial(string accessToken, UpdateNewsMaterialRequest request)
        {
            UpdateNewsMaterialResponse response = RetryTools.Retry<UpdateNewsMaterialResponse>(() =>
            {
                return HttpTools.Post<UpdateNewsMaterialResponse>(string.Format(urlDictionary["UpdateNewsMaterial"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
        }

        public override GetMaterialCountResponse GetMaterialCount(string accessToken)
        {
            GetMaterialCountResponse response = RetryTools.Retry<GetMaterialCountResponse>(() =>
            {
                return HttpTools.Get<GetMaterialCountResponse>(string.Format(urlDictionary["GetMaterialCount"], accessToken), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public override GetMaterialListResponse<T> GetMaterialList<T>(string accessToken, GetMaterialListRequest request)
        {
            GetMaterialListResponse<T> response = RetryTools.Retry<GetMaterialListResponse<T>>(() =>
            {
                return HttpTools.Post<GetMaterialListResponse<T>>(string.Format(urlDictionary["GetMaterialList"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }
        #endregion

        #region 页面开发
        public override string GetOAuth2Uri(string redirectUri, string scope, string state)
        {
            return string.Format(
                urlDictionary["GetAuthorizeUrl"],
                this.officialAccountConfig.AppId,
                HttpUtility.UrlEncode(redirectUri),
                "code",
                scope,
                state
                );
        }

        public override GetOAuth2AccessTokenResponse GetOAuth2AccessToken(string code)
        {
            GetOAuth2AccessTokenResponse response = RetryTools.Retry<GetOAuth2AccessTokenResponse>(() =>
            {
                return HttpTools.Get<GetOAuth2AccessTokenResponse>(string.Format(urlDictionary["GetOAuth2AccessToken"], this.officialAccountConfig.AppId, this.officialAccountConfig.AppSecret, code, "authorization_code"), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public override GetOAuth2AccessTokenResponse RefreshOAuth2AccessToken(string refreshToken)
        {
            GetOAuth2AccessTokenResponse response = RetryTools.Retry<GetOAuth2AccessTokenResponse>(() =>
            {
                return HttpTools.Get<GetOAuth2AccessTokenResponse>(string.Format(urlDictionary["RefreshOAuth2AccessToken"], this.officialAccountConfig.AppId, "refresh_token", refreshToken), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public override GetOAuth2UserInfoResponse GetOAuth2UserInfo(string accessToken, string openId, string lang = "zh_CN")
        {
            GetOAuth2UserInfoResponse response = RetryTools.Retry<GetOAuth2UserInfoResponse>(() =>
            {
                return HttpTools.Get<GetOAuth2UserInfoResponse>(string.Format(urlDictionary["GetOAuth2UserInfo"], accessToken, openId, lang), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public override IsValidOAuth2AccessTokenResponse IsValidOAuth2AccessToken(string accessToken, string openId)
        {
            IsValidOAuth2AccessTokenResponse response = RetryTools.Retry<IsValidOAuth2AccessTokenResponse>(() =>
            {
                return HttpTools.Get<IsValidOAuth2AccessTokenResponse>(string.Format(urlDictionary["IsValidOAuth2AccessToken"], accessToken, openId), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public override string GetJsApiTicket(string accessToken)
        {
            GetJsApiTicketResponse response = RetryTools.Retry<GetJsApiTicketResponse>(() =>
            {
                return HttpTools.Get<GetJsApiTicketResponse>(string.Format(urlDictionary["GetJsApiTicket"], accessToken, "jsapi"), null, null);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response.Ticket;
        }

        public override string CalculateJsApiSignature(string jsApiTicket, long timestamp, string nonce, string url)
        {
            url = url.Split('#')[0];
            List<string> data = new List<string>();
            data.Add(string.Format("{0}={1}", "noncestr", nonce));
            data.Add(string.Format("{0}={1}", "jsapi_ticket", jsApiTicket));
            data.Add(string.Format("{0}={1}", "timestamp", timestamp));
            data.Add(string.Format("{0}={1}", "url", url));
            data.Sort();
            string joinStr = string.Join("&", data);
            return joinStr.SHA1().ToLower();
        }
        #endregion
    }
}
