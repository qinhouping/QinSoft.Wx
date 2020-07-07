﻿using QinSoft.Wx.OfficialAccount.Model.Account;
using QinSoft.Wx.OfficialAccount.Model.CustomerService;
using QinSoft.Wx.OfficialAccount.Model.Mass;
using QinSoft.Wx.OfficialAccount.Model.Media;
using QinSoft.Wx.OfficialAccount.Model.Menu;
using QinSoft.Wx.OfficialAccount.Model.Subscribe;
using QinSoft.Wx.OfficialAccount.Model.Template;
using QinSoft.Wx.OfficialAccount.Model.User;
using QinSoft.Wx.OfficialAccount.Model.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.OfficialAccount
{
    /// <summary>
    /// 公众号服务
    /// </summary>
    public abstract class OfficialAccountService
    {
        public abstract string CalculateJoinSignature(long timestamp, string nonce);

        public abstract string GetAccessToken();

        #region 菜单
        public abstract void CreateMenu(string accessToken, MenuInfo menuInfo, bool isConditional = false);

        public abstract void DeleteMenu(string accessToken, bool isConditional = false);
        #endregion

        #region 客服

        public abstract void AddCustomerService(string accessToken, CustomerServiceActionRequest customerService);

        public abstract void UpdateCustomerService(string accessToken, CustomerServiceActionRequest customerService);

        public abstract void DeleteCustomerService(string accessToken, CustomerServiceActionRequest customerService);

        public abstract CustomerServiceListItem[] GetCustomerServiceList(string accessToken);

        public abstract void SendCustomerServiceMessage(string accessToken, CustomerServiceMsgBase message);

        public abstract void TypingCustomerService(string accessToken, TypingCustomerServiceRequest action);
        #endregion

        #region 群发
        public abstract MassTagMsgSendResponse SendMassTagMessage(string accessToken, MassTagMsgBase message);

        public abstract void DeleteMassTagMessageSend(string accessToken, DeleteMassTagMsgSendRequest request);

        public abstract MassPreviewMsgSendResponse SendMassPreviewMessage(string accessToken, MassPreviewMsgBase message);

        public abstract GetMassSpeedResponse GetMassSpeed(string accessToken);

        public abstract void SetMassSpeed(string accessToken, SetMassSpeedRequest request);
        #endregion

        #region 模板
        public abstract void SetTemplateIndustry(string accessToken, SetTemplateIndustryRequest request);

        public abstract GetTemplateIndustryResponse GetTemplateIndustry(string accessToken);

        public abstract string GetTemplateId(string accessToken, string templateIdShort);

        public abstract GetTemplateListResponse GetTemplateList(string accessToken);

        public abstract void DeleteTemplate(string accessToken, string templateId);

        public abstract string SendTemplateMessage(string accessToken, TemplateMessage message);
        #endregion

        #region 订阅
        public abstract string GetSubscribeUrl(string scene, string templateId, string redirectUrl, string reserved);

        public abstract void SendSubscribeMessage(string accessToken, SubscribeMessage message);
        #endregion

        #region 用户
        public abstract CreateTagResponse CreateTag(string accessToken, CreateTagRequest request);

        public abstract void UpdateTag(string accessToken, UpdateTagRequest request);

        public abstract void DeleteTag(string accessToken, DeleteTagRequest request);

        public abstract GetTagListResponse GetTagList(string accessToken);

        public abstract GetTagUserListResponse GetTagUserList(string accessToken, GetTagUserListRequest request);

        public abstract void BatchTagging(string accessToken, BatchTaggingRequest request);

        public abstract void BatchUntagging(string accessToken, BatchUntaggingRequest request);

        public abstract GetUserTagListResponse GetUserTagList(string accessToken, GetUserTagListRequest request);

        public abstract void UpdateRemark(string accessToken, UpdateRemarkRequest request);

        public abstract UserInfo GetUserInfo(string accessToken, string openId, string lang = "zh_CN");

        public abstract UserInfo[] BatchGetUserInfo(string accessToken, BatchGetUserInfoRequest request);

        public abstract GetUserListResponse GetUserList(string accessToken, string nextOpenId);

        public abstract GetBlackUserListResponse GetBlackUserList(string accessToken, GetBlackUserListRequest request);

        public abstract void BatchBlackList(string accessToken, BatchBlackListRequest request);

        public abstract void BatchUnblackList(string accessToken, BatchUnblackListRequest request);
        #endregion

        #region 账号
        public abstract CreateQRCodeResponse CreateQRCode(string accessToken, CreateQRCodeRequest request);

        public abstract string GetQRCodeUrl(string ticket);

        public abstract string GetShortUrl(string accessToken, string longUrl);
        #endregion

        #region 素材
        #region 临时素材
        public abstract Task<UploadMediaResponse> UploadMedia(string accessToken, string type, string fileName, Stream stream);

        public abstract UploadVideoResponse UploadVideoMedia(string accessToken, UploadVideoRequest request);

        public abstract DownloadMediaResponse DownloadVideoMedia(string accessToken, string mediaId);

        public abstract Task<Stream> DownloadMedia(string accessToken, string mediaId);
        #endregion

        #region 永久素材
        public abstract AddNewsMaterialResponse AddNewsMaterial(string accessToken, AddNewsMaterialRequest request);

        public abstract Task<UploadNewsMaterialImgResponse> UploadNewsMaterialImg(string accessToken, string fileName, Stream stream);

        public abstract Task<UploadMaterialResponse> UploadMaterial(string accessToken, string type, string fileName, Stream stream, UploadMaterialRequest request = null);

        public abstract DownloadNewsMaterialResponse DownloadNewsMaterial(string accessToken, DownloadMaterialRequest request);

        public abstract DownloadVideoMaterialResponse DownloadVideoMaterial(string accessToken, DownloadMaterialRequest request);

        public abstract Task<Stream> DownloadMaterial(string accessToken, DownloadMaterialRequest request);

        public abstract void DeleteMaterial(string accessToken, DeleteMaterialRequest request);

        public abstract void UpdateNewsMaterial(string accessToken, UpdateNewsMaterialRequest request);

        public abstract GetMaterialCountResponse GetMaterialCount(string accessToken);

        public abstract GetMaterialListResponse<T> GetMaterialList<T>(string accessToken, GetMaterialListRequest request) where T : MaterialListItem;
        #endregion
        #endregion

        #region 微信网页开发
        public abstract string GetOAuth2Uri(string redirectUri, string scope, string state);

        public abstract GetOAuth2AccessTokenResponse GetOAuth2AccessToken(string code);

        public abstract GetOAuth2AccessTokenResponse RefreshOAuth2AccessToken(string refreshToken);

        public abstract GetOAuth2UserInfoResponse GetOAuth2UserInfo(string accessToken, string openId, string lang = "zh_CN");

        public abstract IsValidOAuth2AccessTokenResponse IsValidOAuth2AccessToken(string accessToken, string openId);

        public abstract string GetJsApiTicket(string accessToken);

        public abstract string CalculateJsApiSignature(string jsApiTicket, long timestamp, string nonce, string url);
        #endregion

        #region 统计
        #endregion
    }
}
