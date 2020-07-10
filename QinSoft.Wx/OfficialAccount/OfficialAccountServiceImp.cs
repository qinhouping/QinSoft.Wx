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
using QinSoft.Wx.OfficialAccount.Model.Mass;
using QinSoft.Wx.OfficialAccount.Model.Media;
using QinSoft.Wx.OfficialAccount.Model.Menu;
using QinSoft.Wx.OfficialAccount.Model.Subscribe;
using QinSoft.Wx.OfficialAccount.Model.Template;
using QinSoft.Wx.OfficialAccount.Model.User;
using QinSoft.Wx.OfficialAccount.Model.Web;
using QinSoft.Wx.OfficialAccount.Model.WxShop;

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
                { "AddKFAccount","https://api.weixin.qq.com/customservice/kfaccount/add?access_token={0}" },
                { "UpdateKFAccount","https://api.weixin.qq.com/customservice/kfaccount/update?access_token={0}" },
                { "DeleteKFAccount","https://api.weixin.qq.com/customservice/kfaccount/del?access_token={0}&kf_account={1}" },
                { "InviteKFAccount","https://api.weixin.qq.com/customservice/kfaccount/inviteworker?access_token={0}" },
                { "GetFKAccountList","https://api.weixin.qq.com/cgi-bin/customservice/getkflist?access_token={0}" },
                { "UploadKFAccountHeadImg","https://api.weixin.qq.com/customservice/kfaccount/uploadheadimg?access_token={0}&kf_account={1}" },
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
                { "UploadVideoMedia","https://api.weixin.qq.com/cgi-bin/media/uploadvideo?access_token={0}" },
                { "GetMedia","https://api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}" },
                { "UploadImageMaterial","https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}" },
                { "AddNewsMaterial","https://api.weixin.qq.com/cgi-bin/material/add_news?access_token={0}" },
                { "UpdateNewsMaterial","https://api.weixin.qq.com/cgi-bin/material/update_news?access_token={0}" },
                { "UploadMaterial","https://api.weixin.qq.com/cgi-bin/material/add_material?access_token={0}&type={1}" },
                { "DownloadMaterial","https://api.weixin.qq.com/cgi-bin/material/get_material?access_token={0}" },
                { "DeleteMaterial","https://api.weixin.qq.com/cgi-bin/material/del_material?access_token={0}" },
                { "GetMaterialCount","https://api.weixin.qq.com/cgi-bin/material/get_materialcount?access_token={0}" },
                { "GetMaterialList","https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token={0}" },
                { "GetAuthorizeUrl","https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type={2}&scope={3}&state={4}#wechat_redirect" },
                { "GetOAuth2AccessToken"," https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type={3}" },
                { "RefreshOAuth2AccessToken","https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type={1}&refresh_token={2}" },
                { "GetOAuth2UserInfo","https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang={2}" },
                { "IsValidOAuth2AccessToken","https://api.weixin.qq.com/sns/auth?access_token={0}&openid={1}" },
                { "GetJsApiTicket","https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type={1}" },
                { "GetUserSummary","https://api.weixin.qq.com/datacube/getusersummary?access_token={0}" },
                { "GetUserCumulate","https://api.weixin.qq.com/datacube/getusercumulate?access_token={0}" },
                { "SendMassTagMessage","https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token={0}" },
                { "DeleteMassTagMessageSend","https://api.weixin.qq.com/cgi-bin/message/mass/delete?access_token={0}" },
                { "SendMassPreviewMessage","https://api.weixin.qq.com/cgi-bin/message/mass/preview?access_token={0}" },
                { "GetMassSpeed","https://api.weixin.qq.com/cgi-bin/message/mass/speed/get?access_token={0}" },
                { "SetMassSpeed","https://api.weixin.qq.com/cgi-bin/message/mass/speed/set?access_token={0}" },
                { "AddWxShop","http://api.weixin.qq.com/cgi-bin/poi/addpoi?access_token={0}" },
                { "GetWxShop","http://api.weixin.qq.com/cgi-bin/poi/getpoi?access_token={0}" },
                { "GetWxShopList","https://api.weixin.qq.com/cgi-bin/poi/getpoilist?access_token={0}" }
            };
        }

        #region 基础

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

        public override AccessTokenResponse GetAccessToken()
        {
            return RetryTools.Retry<AccessTokenResponse>(() =>
            {
                return HttpTools.Get<AccessTokenResponse>(string.Format(urlDictionary["GetAccessToken"], this.officialAccountConfig.AppId, this.officialAccountConfig.AppSecret), null, null);
            });
        }
        #endregion

        #region 菜单
        public override CreateMenuResponse CreateMenu(string accessToken, MenuInfo menuInfo, bool isConditional = false)
        {
            return RetryTools.Retry<CreateMenuResponse>(() =>
            {
                return HttpTools.Post<CreateMenuResponse>(string.Format(urlDictionary[isConditional ? "CreateConditionalMenu" : "CreateMenu"], accessToken), null, null, menuInfo);
            });
        }

        public override DeleteMenuResponse DeleteMenu(string accessToken, bool isConditional = false)
        {
            return RetryTools.Retry<DeleteMenuResponse>(() =>
            {
                return HttpTools.Get<DeleteMenuResponse>(string.Format(urlDictionary[isConditional ? "DeleteConditionalMenu" : "DeleteMenu"], accessToken), null, null);
            });
        }
        #endregion

        #region 客服

        public override AddKFAccountResponse AddFKAccount(string accessToken, AddKFAccountRequest request)
        {
            return RetryTools.Retry<AddKFAccountResponse>(() =>
            {
                return HttpTools.Post<AddKFAccountResponse>(string.Format(urlDictionary["AddFKAccount"], accessToken), null, null, request);
            });
        }

        public override UpdateKFAccountResponse UpdateKFAccount(string accessToken, UpdateKFAccountRequest request)
        {
            return RetryTools.Retry<UpdateKFAccountResponse>(() =>
            {
                return HttpTools.Post<UpdateKFAccountResponse>(string.Format(urlDictionary["UpdateKFAccount"], accessToken), null, null, request);
            });
        }

        public override DeleteKFAccountResponse DeleteKFAccount(string accessToken, string kfAccount)
        {
            return RetryTools.Retry<DeleteKFAccountResponse>(() =>
            {
                return HttpTools.Get<DeleteKFAccountResponse>(string.Format(urlDictionary["DeleteKFAccount"], accessToken, kfAccount), null, null);
            });
        }

        public override InviteKFAccountResponse InviteKFAccount(string accessToken, InviteKFAccountRequest request)
        {
            return RetryTools.Retry<InviteKFAccountResponse>(() =>
            {
                return HttpTools.Post<InviteKFAccountResponse>(string.Format(urlDictionary["InviteKFAccount"], accessToken), null, null, request);
            });
        }

        public override GetFKAccountList GetFKAccountList(string accessToken)
        {
            return RetryTools.Retry<GetFKAccountList>(() =>
            {
                return HttpTools.Get<GetFKAccountList>(string.Format(urlDictionary["GetFKAccountList"], accessToken), null, null);
            });
        }

        public override async Task<UploadKFAccountHeadImgResponse> UploadKFAccountHeadImg(string accessToken, string kfAccount, Stream stream, string fileName)
        {
            return await RetryTools.Retry<Task<UploadKFAccountHeadImgResponse>>(async () =>
            {
                return await HttpTools.UploadAsync<UploadKFAccountHeadImgResponse>(string.Format(urlDictionary["UploadKFAccountHeadImg"], accessToken), stream, "media", fileName);
            });
        }

        public override SendCustomerServiceMsgResponse SendCustomerServiceMessage(string accessToken, CustomerServiceMsgBase message)
        {
            return RetryTools.Retry<SendCustomerServiceMsgResponse>(() =>
            {
                return HttpTools.Post<SendCustomerServiceMsgResponse>(string.Format(urlDictionary["SendCustomerServiceMessage"], accessToken), null, null, message);
            });
        }

        public override TypingCustomerServiceResponse TypingCustomerService(string accessToken, TypingCustomerServiceRequest request)
        {
            return RetryTools.Retry<TypingCustomerServiceResponse>(() =>
            {
                return HttpTools.Post<TypingCustomerServiceResponse>(string.Format(urlDictionary["TypingCustomerService"], accessToken), null, null, request);
            });
        }
        #endregion

        #region 群发
        public override MassTagMsgSendResponse SendMassTagMessage(string accessToken, MassTagMsgBase message)
        {
            return RetryTools.Retry<MassTagMsgSendResponse>(() =>
            {
                return HttpTools.Post<MassTagMsgSendResponse>(string.Format(urlDictionary["SendMassTagMessage"], accessToken), null, null, message);
            });
        }

        public override DeleteMassTagMsgSendResponse DeleteMassTagMessageSend(string accessToken, DeleteMassTagMsgSendRequest request)
        {
            return RetryTools.Retry<DeleteMassTagMsgSendResponse>(() =>
            {
                return HttpTools.Post<DeleteMassTagMsgSendResponse>(string.Format(urlDictionary["DeleteMassTagMessageSend"], accessToken), null, null, request);
            });
        }

        public override MassPreviewMsgSendResponse SendMassPreviewMessage(string accessToken, MassPreviewMsgBase message)
        {
            return RetryTools.Retry<MassPreviewMsgSendResponse>(() =>
            {
                return HttpTools.Post<MassPreviewMsgSendResponse>(string.Format(urlDictionary["SendMassPreviewMessage"], accessToken), null, null, message);
            });
        }

        public override GetMassSpeedResponse GetMassSpeed(string accessToken)
        {
            return RetryTools.Retry<GetMassSpeedResponse>(() =>
            {
                return HttpTools.Post<GetMassSpeedResponse>(string.Format(urlDictionary["GetMassSpeed"], accessToken), null, null, null);
            });
        }

        public override SetMassSpeedResponse SetMassSpeed(string accessToken, SetMassSpeedRequest request)
        {
            return RetryTools.Retry<SetMassSpeedResponse>(() =>
            {
                return HttpTools.Post<SetMassSpeedResponse>(string.Format(urlDictionary["SetMassSpeed"], accessToken), null, null, request);
            });
        }
        #endregion

        #region 模板
        public override SetTemplateIndustryResponse SetTemplateIndustry(string accessToken, SetTemplateIndustryRequest request)
        {
            return RetryTools.Retry<SetTemplateIndustryResponse>(() =>
            {
                return HttpTools.Post<SetTemplateIndustryResponse>(string.Format(urlDictionary["SetTemplateIndustry"], accessToken), null, null, request);
            });
        }

        public override GetTemplateIndustryResponse GetTemplateIndustry(string accessToken)
        {
            return RetryTools.Retry<GetTemplateIndustryResponse>(() =>
             {
                 return HttpTools.Get<GetTemplateIndustryResponse>(string.Format(urlDictionary["GetTemplateIndustry"], accessToken), null, null);
             });
        }

        public override GetTemplateIdResponse GetTemplateId(string accessToken, GetTemplateIdRequest request)
        {
            return RetryTools.Retry<GetTemplateIdResponse>(() =>
            {
                return HttpTools.Post<GetTemplateIdResponse>(string.Format(urlDictionary["GetTemplateId"], accessToken), null, null, request);
            });
        }

        public override GetTemplateListResponse GetTemplateList(string accessToken)
        {
            return RetryTools.Retry<GetTemplateListResponse>(() =>
            {
                return HttpTools.Get<GetTemplateListResponse>(string.Format(urlDictionary["GetTemplateList"], accessToken), null, null);
            });
        }

        public override DeleteTemplateResponse DeleteTemplate(string accessToken, DeleteTemplateRequest request)
        {
            return RetryTools.Retry<DeleteTemplateResponse>(() =>
             {
                 return HttpTools.Post<DeleteTemplateResponse>(string.Format(urlDictionary["DeleteTemplate"], accessToken), null, null, request);
             });
        }

        public override SendTemplateMessageResponse SendTemplateMessage(string accessToken, TemplateMessage message)
        {
            return RetryTools.Retry<SendTemplateMessageResponse>(() =>
            {
                return HttpTools.Post<SendTemplateMessageResponse>(string.Format(urlDictionary["SendTemplateMessage"], accessToken), null, null, message);
            });
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

        public override SendSubscribeMessageResponse SendSubscribeMessage(string accessToken, SubscribeMessage message)
        {
            return RetryTools.Retry<SendSubscribeMessageResponse>(() =>
            {
                return HttpTools.Post<SendSubscribeMessageResponse>(string.Format(urlDictionary["SendSubscribeMessage"], accessToken), null, null, message);
            });
        }
        #endregion

        #region 用户
        public override CreateTagResponse CreateTag(string accessToken, CreateTagRequest request)
        {
            return RetryTools.Retry<CreateTagResponse>(() =>
            {
                return HttpTools.Post<CreateTagResponse>(string.Format(urlDictionary["CreateTag"], accessToken), null, null, request);
            });
        }

        public override UpdateTagResponse UpdateTag(string accessToken, UpdateTagRequest request)
        {
            return RetryTools.Retry<UpdateTagResponse>(() =>
            {
                return HttpTools.Post<UpdateTagResponse>(string.Format(urlDictionary["UpdateTag"], accessToken), null, null, request);
            });
        }

        public override DeleteTagResponse DeleteTag(string accessToken, DeleteTagRequest request)
        {
            return RetryTools.Retry<DeleteTagResponse>(() =>
            {
                return HttpTools.Post<DeleteTagResponse>(string.Format(urlDictionary["DeleteTag"], accessToken), null, null, request);
            });
        }

        public override GetTagListResponse GetTagList(string accessToken)
        {
            return RetryTools.Retry<GetTagListResponse>(() =>
            {
                return HttpTools.Get<GetTagListResponse>(string.Format(urlDictionary["GetTagList"], accessToken), null, null);
            });
        }

        public override GetTagUserListResponse GetTagUserList(string accessToken, GetTagUserListRequest request)
        {
            return RetryTools.Retry<GetTagUserListResponse>(() =>
            {
                return HttpTools.Post<GetTagUserListResponse>(string.Format(urlDictionary["GetTagUserList"], accessToken), null, null, request);
            });
        }

        public override BatchTaggingResponse BatchTagging(string accessToken, BatchTaggingRequest request)
        {
            return RetryTools.Retry<BatchTaggingResponse>(() =>
            {
                return HttpTools.Post<BatchTaggingResponse>(string.Format(urlDictionary["BatchTagging"], accessToken), null, null, request);
            });
        }

        public override BatchUntaggingResponse BatchUntagging(string accessToken, BatchUntaggingRequest request)
        {
            return RetryTools.Retry<BatchUntaggingResponse>(() =>
            {
                return HttpTools.Post<BatchUntaggingResponse>(string.Format(urlDictionary["BatchUntagging"], accessToken), null, null, request);
            });
        }

        public override GetUserTagListResponse GetUserTagList(string accessToken, GetUserTagListRequest request)
        {
            return RetryTools.Retry<GetUserTagListResponse>(() =>
            {
                return HttpTools.Post<GetUserTagListResponse>(string.Format(urlDictionary["GetUserTagList"], accessToken), null, null, request);
            });
        }

        public override UpdateRemarkResponse UpdateRemark(string accessToken, UpdateRemarkRequest request)
        {
            return RetryTools.Retry<UpdateRemarkResponse>(() =>
            {
                return HttpTools.Post<UpdateRemarkResponse>(string.Format(urlDictionary["UpdateRemark"], accessToken), null, null, request);
            });
        }

        public override GetUserInfoResponse GetUserInfo(string accessToken, string openId, string lang = "zh_CN")
        {
            return RetryTools.Retry<GetUserInfoResponse>(() =>
            {
                return HttpTools.Get<GetUserInfoResponse>(string.Format(urlDictionary["GetUserInfo"], accessToken, openId, lang), null, null);
            });
        }

        public override BatchGetUserInfoResponse BatchGetUserInfo(string accessToken, BatchGetUserInfoRequest request)
        {
            return RetryTools.Retry<BatchGetUserInfoResponse>(() =>
            {
                return HttpTools.Get<BatchGetUserInfoResponse>(string.Format(urlDictionary["BatchGetUserInfo"], accessToken), null, null);
            });
        }

        public override GetUserListResponse GetUserList(string accessToken, string nextOpenId)
        {
            return RetryTools.Retry<GetUserListResponse>(() =>
            {
                return HttpTools.Get<GetUserListResponse>(string.Format(urlDictionary["GetUserList"], accessToken, nextOpenId), null, null);
            });
        }

        public override GetBlackUserListResponse GetBlackUserList(string accessToken, GetBlackUserListRequest request)
        {
            return RetryTools.Retry<GetBlackUserListResponse>(() =>
            {
                return HttpTools.Post<GetBlackUserListResponse>(string.Format(urlDictionary["GetBlackUserList"], accessToken), null, null, request);
            });
        }

        public override BatchBlackListResponse BatchBlackList(string accessToken, BatchBlackListRequest request)
        {
            return RetryTools.Retry<BatchBlackListResponse>(() =>
            {
                return HttpTools.Post<BatchBlackListResponse>(string.Format(urlDictionary["BatchBlackList"], accessToken), null, null, request);
            });
        }

        public override BatchUnblackListResponse BatchUnblackList(string accessToken, BatchUnblackListRequest request)
        {
            return RetryTools.Retry<BatchUnblackListResponse>(() =>
            {
                return HttpTools.Post<BatchUnblackListResponse>(string.Format(urlDictionary["BatchBlackList"], accessToken), null, null, request);
            });
        }
        #endregion

        #region 账户
        public override CreateQRCodeResponse CreateQRCode(string accessToken, CreateQRCodeRequest request)
        {
            return RetryTools.Retry<CreateQRCodeResponse>(() =>
            {
                return HttpTools.Post<CreateQRCodeResponse>(string.Format(urlDictionary["CreateQRCode"], accessToken), null, null, request);
            });
        }

        public override string GetQRCodeUrl(string ticket)
        {
            return string.Format(urlDictionary["QRCodeUrl"], HttpUtility.UrlEncode(ticket));
        }

        public override GetShortUrlResponse GetShortUrl(string accessToken, string longUrl)
        {
            return RetryTools.Retry<GetShortUrlResponse>(() =>
            {
                return HttpTools.Post<GetShortUrlResponse>(string.Format(urlDictionary["GetShortUrl"], accessToken), null, null, new GetShortUrlRequest() { LongUrl = longUrl });
            });
        }
        #endregion

        #region 素材
        #region 临时素材
        public async override Task<UploadMediaResponse> UploadMedia(string accessToken, string type, string fileName, Stream stream)
        {
            return await RetryTools.Retry<Task<UploadMediaResponse>>(async () =>
            {
                return await HttpTools.UploadAsync<UploadMediaResponse>(string.Format(urlDictionary["UploadMedia"], accessToken, type), stream, "media", fileName);
            });
        }

        public override UploadVideoResponse UploadVideoMedia(string accessToken, UploadVideoRequest request)
        {
            return RetryTools.Retry<UploadVideoResponse>(() =>
            {
                return HttpTools.Post<UploadVideoResponse>(string.Format(urlDictionary["UploadVideoMedia"], accessToken), null, null, request);
            });
        }

        public override DownloadMediaResponse DownloadVideoMedia(string accessToken, string mediaId)
        {
            return RetryTools.Retry<DownloadMediaResponse>(() =>
            {
                return HttpTools.Get<DownloadMediaResponse>(string.Format(urlDictionary["GetMedia"], accessToken, mediaId), null, null);
            });
        }

        public async override Task<Stream> DownloadMedia(string accessToken, string mediaId)
        {
            return await RetryTools.Retry<Task<Stream>>(async () =>
            {
                return await HttpTools.DownloadAsync(string.Format(urlDictionary["GetMedia"], accessToken, mediaId), null, null);
            });
        }
        #endregion

        #region 永久素材

        public override AddNewsMaterialResponse AddNewsMaterial(string accessToken, AddNewsMaterialRequest request)
        {
            return RetryTools.Retry<AddNewsMaterialResponse>(() =>
            {
                return HttpTools.Post<AddNewsMaterialResponse>(string.Format(urlDictionary["AddNewsMaterial"], accessToken), null, null, request);
            });
        }

        public override UpdateNewsMaterialResponse UpdateNewsMaterial(string accessToken, UpdateNewsMaterialRequest request)
        {
            return RetryTools.Retry<UpdateNewsMaterialResponse>(() =>
            {
                return HttpTools.Post<UpdateNewsMaterialResponse>(string.Format(urlDictionary["UpdateNewsMaterial"], accessToken), null, null, request);
            });
        }

        public async override Task<UploadImageMaterialResponse> UploadImageMaterial(string accessToken, string fileName, Stream stream)
        {
            return await RetryTools.Retry<Task<UploadImageMaterialResponse>>(async () =>
            {
                return await HttpTools.UploadAsync<UploadImageMaterialResponse>(string.Format(urlDictionary["UploadImageMaterial"], accessToken), stream, "media", fileName);
            });
        }

        public async override Task<UploadMaterialResponse> UploadMaterial(string accessToken, string type, string fileName, Stream stream, UploadMaterialRequest request = null)
        {
            return await RetryTools.Retry<Task<UploadMaterialResponse>>(async () =>
            {
                return await HttpTools.UploadAsync<UploadMaterialResponse>(string.Format(urlDictionary["UploadMaterial"], accessToken, type), stream, "media", fileName, request != null ? new Dictionary<string, string>() { { "description", request.ToJson() } } : new Dictionary<string, string>());
            });
        }

        public override DownloadNewsMaterialResponse DownloadNewsMaterial(string accessToken, DownloadMaterialRequest request)
        {
            return RetryTools.Retry<DownloadNewsMaterialResponse>(() =>
            {
                return HttpTools.Post<DownloadNewsMaterialResponse>(string.Format(urlDictionary["DownloadMaterial"], accessToken), null, null, request);
            });
        }

        public override DownloadVideoMaterialResponse DownloadVideoMaterial(string accessToken, DownloadMaterialRequest request)
        {
            return RetryTools.Retry<DownloadVideoMaterialResponse>(() =>
            {
                return HttpTools.Post<DownloadVideoMaterialResponse>(string.Format(urlDictionary["DownloadMaterial"], accessToken), null, null, request);
            });
        }

        public async override Task<Stream> DownloadMaterial(string accessToken, DownloadMaterialRequest request)
        {
            return await RetryTools.Retry<Task<Stream>>(async () =>
            {
                return await HttpTools.DownloadAsync(WebMethod.POST, string.Format(urlDictionary["DownloadMaterial"], accessToken), null, null, request);
            });
        }

        public override DeleteMaterialResponse DeleteMaterial(string accessToken, DeleteMaterialRequest request)
        {
            return RetryTools.Retry<DeleteMaterialResponse>(() =>
            {
                return HttpTools.Post<DeleteMaterialResponse>(string.Format(urlDictionary["DeleteMaterial"], accessToken), null, null, request);
            });
        }

        public override GetMaterialCountResponse GetMaterialCount(string accessToken)
        {
            return RetryTools.Retry<GetMaterialCountResponse>(() =>
            {
                return HttpTools.Get<GetMaterialCountResponse>(string.Format(urlDictionary["GetMaterialCount"], accessToken), null, null);
            });
        }

        public override GetMaterialListResponse<T> GetMaterialList<T>(string accessToken, GetMaterialListRequest request)
        {
            return RetryTools.Retry<GetMaterialListResponse<T>>(() =>
            {
                return HttpTools.Post<GetMaterialListResponse<T>>(string.Format(urlDictionary["GetMaterialList"], accessToken), null, null, request);
            });
        }
        #endregion
        #endregion

        #region 网页开发
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
            return RetryTools.Retry<GetOAuth2AccessTokenResponse>(() =>
            {
                return HttpTools.Get<GetOAuth2AccessTokenResponse>(string.Format(urlDictionary["GetOAuth2AccessToken"], this.officialAccountConfig.AppId, this.officialAccountConfig.AppSecret, code, "authorization_code"), null, null);
            });
        }

        public override GetOAuth2AccessTokenResponse RefreshOAuth2AccessToken(string refreshToken)
        {
            return RetryTools.Retry<GetOAuth2AccessTokenResponse>(() =>
            {
                return HttpTools.Get<GetOAuth2AccessTokenResponse>(string.Format(urlDictionary["RefreshOAuth2AccessToken"], this.officialAccountConfig.AppId, "refresh_token", refreshToken), null, null);
            });
        }

        public override GetOAuth2UserInfoResponse GetOAuth2UserInfo(string accessToken, string openId, string lang = "zh_CN")
        {
            return RetryTools.Retry<GetOAuth2UserInfoResponse>(() =>
            {
                return HttpTools.Get<GetOAuth2UserInfoResponse>(string.Format(urlDictionary["GetOAuth2UserInfo"], accessToken, openId, lang), null, null);
            });
        }

        public override IsValidOAuth2AccessTokenResponse IsValidOAuth2AccessToken(string accessToken, string openId)
        {
            return RetryTools.Retry<IsValidOAuth2AccessTokenResponse>(() =>
            {
                return HttpTools.Get<IsValidOAuth2AccessTokenResponse>(string.Format(urlDictionary["IsValidOAuth2AccessToken"], accessToken, openId), null, null);
            });
        }

        public override GetJsApiTicketResponse GetJsApiTicket(string accessToken)
        {
            return RetryTools.Retry<GetJsApiTicketResponse>(() =>
            {
                return HttpTools.Get<GetJsApiTicketResponse>(string.Format(urlDictionary["GetJsApiTicket"], accessToken, "jsapi"), null, null);
            });
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

        #region 门店
        public override AddWxShopResponse AddWxShop(string accessToken, AddWxShopRequest request)
        {
            AddWxShopResponse response = RetryTools.Retry<AddWxShopResponse>(() =>
            {
                return HttpTools.Post<AddWxShopResponse>(string.Format(urlDictionary["AddWxShop"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public override GetWxShopResponse GetWxShop(string accessToken, GetWxShopRequest request)
        {
            GetWxShopResponse response = RetryTools.Retry<GetWxShopResponse>(() =>
            {
                return HttpTools.Post<GetWxShopResponse>(string.Format(urlDictionary["GetWxShop"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }

        public override GetWxShopListResponse GetWxShopList(string accessToken, GetWxShopListRequest request)
        {
            GetWxShopListResponse response = RetryTools.Retry<GetWxShopListResponse>(() =>
            {
                return HttpTools.Post<GetWxShopListResponse>(string.Format(urlDictionary["GetWxShopList"], accessToken), null, null, request);
            });
            if (response.ErrCode != 0) throw new OfficialAccountException(response.ErrCode, response.ErrMsg);
            return response;
        }
        #endregion
    }
}
