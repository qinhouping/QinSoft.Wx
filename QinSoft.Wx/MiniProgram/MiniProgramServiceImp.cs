﻿using QinSoft.Wx.Common;
using QinSoft.Wx.MiniProgram.Model.Analysis;
using QinSoft.Wx.MiniProgram.Model.Auth;
using QinSoft.Wx.MiniProgram.Model.CustomerService;
using QinSoft.Wx.MiniProgram.Model.NearByPoi;
using QinSoft.Wx.MiniProgram.Model.Plugin;
using QinSoft.Wx.MiniProgram.Model.UniformMessage;
using QinSoft.Wx.MiniProgram.Model.UpdatableMessage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QinSoft.Wx.MiniProgram
{
    public class MiniProgramServiceImp : MiniProgramService
    {
        private MiniProgramConfig MiniProgramConfig;
        private Dictionary<string, string> urlDictionary;

        public MiniProgramServiceImp(MiniProgramConfig MiniProgramConfig)
        {
            this.MiniProgramConfig = MiniProgramConfig;
            this.urlDictionary = new Dictionary<string, string>()
            {
                { "GetJsCode2Session","https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type={3}" },
                { "GetPaidUnionId","https://api.weixin.qq.com/wxa/getpaidunionid?access_token={0}&openid={1}&{2}" },
                { "GetAccessToken","https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}" },
                { "GetDailyRetain","https://api.weixin.qq.com/datacube/getweanalysisappiddailyretaininfo?access_token={0}" },
                { "GetMonthlyRetain","https://api.weixin.qq.com/datacube/getweanalysisappidmonthlyretaininfo?access_token={0}" },
                { "GetWeeklyRetain","https://api.weixin.qq.com/datacube/getweanalysisappidweeklyretaininfo?access_token={0}" },
                { "GetDailySummary","https://api.weixin.qq.com/datacube/getweanalysisappiddailysummarytrend?access_token={0}" },
                { "GetDailyVisitTrend","https://api.weixin.qq.com/datacube/getweanalysisappiddailyvisittrend?access_token={0}" },
                { "GetMonthlyVisiTrend","https://api.weixin.qq.com/datacube/getweanalysisappidmonthlyvisittrend?access_token={0}" },
                { "GetWeeklyVisitTrend","https://api.weixin.qq.com/datacube/getweanalysisappidweeklyvisittrend?access_token={0}" },
                { "GetUserPortrait","https://api.weixin.qq.com/datacube/getweanalysisappiduserportrait?access_token={0}" },
                { "GetVisitDistribution","https://api.weixin.qq.com/datacube/getweanalysisappidvisitdistribution?access_token={0}" },
                { "GetVisitPage","https://api.weixin.qq.com/datacube/getweanalysisappidvisitpage?access_token={0}" },
                { "GetTempMedia","https://api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}" },
                { "SendCustomerServiceMessage","https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}" },
                { "SetTyping","https://api.weixin.qq.com/cgi-bin/message/custom/typing?access_token={0}" },
                { "UploadTempMedia","https://api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}" },
                { "SendUniformMessage","https://api.weixin.qq.com/cgi-bin/message/wxopen/template/uniform_send?access_token={0}" },
                { "CreateActivityId","https://api.weixin.qq.com/cgi-bin/message/wxopen/activityid/create?access_token={0}" },
                { "SetUpdatableMsg","https://api.weixin.qq.com/cgi-bin/message/wxopen/updatablemsg/send?access_token={0}" },
                { "ApplyPlugin","https://api.weixin.qq.com/wxa/plugin?access_token={0}" },
                { "GetPluginDevApplyList","https://api.weixin.qq.com/wxa/devplugin?access_token={0}" },
                { "GetPluginList","https://api.weixin.qq.com/wxa/plugin?access_token={0}" },
                { "SetDevPluginApplyStatus","https://api.weixin.qq.com/wxa/devplugin?access_token={0}" },
                { "UnbindPlugin", "https://api.weixin.qq.com/wxa/plugin?access_token={0}" },
                { "AddNearbyPoi","https://api.weixin.qq.com/wxa/addnearbypoi?access_token={0}" },
                { "DeleteNearbyPoi","https://api.weixin.qq.com/wxa/delnearbypoi?access_token={0}" },
                { "GetNearByPoiList","https://api.weixin.qq.com/wxa/getnearbypoilist?page={0}&page_rows={1}&access_token={2}" },
                { "SetNearByPoiShowStatus","https://api.weixin.qq.com/wxa/setnearbypoishowstatus?access_token={0}" }
            };
        }

        #region 登录
        public override GetJsCode2SessionResponse GetJsCode2Session(string jsCode)
        {
            return RetryTools.Retry<GetJsCode2SessionResponse>(() =>
            {
                return HttpTools.Get<GetJsCode2SessionResponse>(string.Format(urlDictionary["GetJsCode2Session"], this.MiniProgramConfig.AppId, this.MiniProgramConfig.AppSecret, jsCode, "authorization_code"), null, null);
            });
        }
        #endregion

        #region 用户信息
        public override GetPaidUnionIdResponse GetPaidUnionId(string accessToken, string openId, string transactionId)
        {
            return RetryTools.Retry<GetPaidUnionIdResponse>(() =>
            {
                return HttpTools.Get<GetPaidUnionIdResponse>(string.Format(urlDictionary["GetPaidUnionId"], accessToken, openId, string.Format("transaction_id={0}", transactionId)), null, null);
            });
        }

        public override GetPaidUnionIdResponse GetPaidUnionId(string accessToken, string openId, string outTradeNo, string mchId)
        {
            return RetryTools.Retry<GetPaidUnionIdResponse>(() =>
            {
                return HttpTools.Get<GetPaidUnionIdResponse>(string.Format(urlDictionary["GetPaidUnionId"], accessToken, openId, string.Format("out_trade_no={0}&mch_id={1}", outTradeNo, mchId)), null, null);
            });
        }
        #endregion

        #region 接口凭证
        public override GetAccessTokenResponse GetAccessToken()
        {
            return RetryTools.Retry<GetAccessTokenResponse>(() =>
            {
                return HttpTools.Get<GetAccessTokenResponse>(string.Format(urlDictionary["GetAccessToken"], "client_credential", this.MiniProgramConfig.AppId, this.MiniProgramConfig.AppSecret), null, null);
            });
        }
        #endregion

        #region 数据分析
        public override GetDailyRetainResponse GetDailyRetain(string accessToken, GetDailyRetainRequest request)
        {
            return RetryTools.Retry<GetDailyRetainResponse>(() =>
            {
                return HttpTools.Post<GetDailyRetainResponse>(string.Format(urlDictionary["GetDailyRetain"], accessToken), null, null, request);
            });
        }
        public override GetMonthlyRetainResponse GetMonthlyRetain(string accessToken, GetMonthlyRetainRequest request)
        {
            return RetryTools.Retry<GetMonthlyRetainResponse>(() =>
            {
                return HttpTools.Post<GetMonthlyRetainResponse>(string.Format(urlDictionary["GetMonthlyRetain"], accessToken), null, null, request);
            });
        }

        public override GetWeeklyRetainResponse GetWeeklyRetain(string accessToken, GetWeeklyRetainRequest request)
        {
            return RetryTools.Retry<GetWeeklyRetainResponse>(() =>
            {
                return HttpTools.Post<GetWeeklyRetainResponse>(string.Format(urlDictionary["GetWeeklyRetain"], accessToken), null, null, request);
            });
        }

        public override GetDailySummaryResponse GetDailySummay(string accessToken, GetDailySummaryRequest request)
        {
            return RetryTools.Retry<GetDailySummaryResponse>(() =>
            {
                return HttpTools.Post<GetDailySummaryResponse>(string.Format(urlDictionary["GetDailySummay"], accessToken), null, null, request);
            });
        }
        public override GetDailyVisitTrendResponse GetDailyVisitTrend(string accessToken, GetDailyVisistTrendRequest request)
        {
            return RetryTools.Retry<GetDailyVisitTrendResponse>(() =>
            {
                return HttpTools.Post<GetDailyVisitTrendResponse>(string.Format(urlDictionary["GetDailyVisitTrend"], accessToken), null, null, request);
            });
        }

        public override GetMonthlyVisitTrendResponse GetMonthlyVisitTrend(string accessToken, GetMonthlyVisistTrendRequest request)
        {
            return RetryTools.Retry<GetMonthlyVisitTrendResponse>(() =>
            {
                return HttpTools.Post<GetMonthlyVisitTrendResponse>(string.Format(urlDictionary["GetMonthlyVisitTrend"], accessToken), null, null, request);
            });
        }

        public override GetWeeklyVisitTrendResponse GetWeeklyVisitTrend(string accessToken, GetWeeklyVisistTrendRequest request)
        {
            return RetryTools.Retry<GetWeeklyVisitTrendResponse>(() =>
            {
                return HttpTools.Post<GetWeeklyVisitTrendResponse>(string.Format(urlDictionary["GetWeeklyVisitTrend"], accessToken), null, null, request);
            });
        }

        public override GetUserPortraitResponse GetUserPortrait(string accessToken, GetUserPortraitRequest request)
        {
            return RetryTools.Retry<GetUserPortraitResponse>(() =>
            {
                return HttpTools.Post<GetUserPortraitResponse>(string.Format(urlDictionary["GetUserPortrait"], accessToken), null, null, request);
            });
        }

        public override GetVisitDistributionResponse GetVisitDistribution(string accessToken, GetVisitDistributionRequest request)
        {
            return RetryTools.Retry<GetVisitDistributionResponse>(() =>
            {
                return HttpTools.Post<GetVisitDistributionResponse>(string.Format(urlDictionary["GetVisitDistribution"], accessToken), null, null, request);
            });
        }

        public override GetVisitPageResponse GetVisitPage(string accessToken, GetVisitPageRequest request)
        {
            return RetryTools.Retry<GetVisitPageResponse>(() =>
            {
                return HttpTools.Post<GetVisitPageResponse>(string.Format(urlDictionary["GetVisitPage"], accessToken), null, null, request);
            });
        }
        #endregion

        #region 客服消息
        public override async Task<Stream> GetTempMedia(string accessToken, string mediaId)
        {
            return await RetryTools.Retry<Task<Stream>>(async () =>
            {
                return await HttpTools.DownloadAsync(string.Format(urlDictionary["GetTempMedia"], accessToken, mediaId), null, null);
            });
        }

        public override SendCustomerServiceMessageResponse SendCustomerServiceMessage(string accessToken, CustomerServiceMsgBase message)
        {
            return RetryTools.Retry<SendCustomerServiceMessageResponse>(() =>
            {
                return HttpTools.Post<SendCustomerServiceMessageResponse>(string.Format(urlDictionary["SendCustomerServiceMessage"], accessToken), null, null, message);
            });
        }

        public override SetTypingResponse SetTyping(string accessToken, SetTypingRequest request)
        {
            return RetryTools.Retry<SetTypingResponse>(() =>
            {
                return HttpTools.Post<SetTypingResponse>(string.Format(urlDictionary["SetTyping"], accessToken), null, null, request);
            });
        }

        public override async Task<UploadTempMediaResponse> UploadTempMedia(string accessToken, string type, string fileName, Stream stream)
        {
            return await RetryTools.Retry<Task<UploadTempMediaResponse>>(async () =>
            {
                return await HttpTools.UploadAsync<UploadTempMediaResponse>(string.Format(urlDictionary["UploadTempMedia"], accessToken, type), stream, "media", fileName);
            });
        }
        #endregion

        #region 统一服务消息
        public override SendUniformMessageResponse SendUniformMessage(string accessToken, SendUniformMessageRequest request)
        {
            return RetryTools.Retry<SendUniformMessageResponse>(() =>
            {
                return HttpTools.Post<SendUniformMessageResponse>(string.Format(urlDictionary["SendUniformMessage"], accessToken), null, null, request);
            });
        }
        #endregion

        #region 动态消息
        public override CreateActivityIdResponse CreateActivityId(string accessToken)
        {
            return RetryTools.Retry<CreateActivityIdResponse>(() =>
            {
                return HttpTools.Get<CreateActivityIdResponse>(string.Format(urlDictionary["CreateActivityId"], accessToken), null, null);
            });
        }

        public override SetUpdatableMsgResponse SetUpdatableMsg(string accessToken, SetUpdatableMsgRequest request)
        {
            return RetryTools.Retry<SetUpdatableMsgResponse>(() =>
            {
                return HttpTools.Post<SetUpdatableMsgResponse>(string.Format(urlDictionary["SetUpdatableMsg"], accessToken), null, null, request);
            });
        }
        #endregion

        #region 插件
        public override ApplyPluginResponse ApplyPlugin(string accessToken, ApplyPluginRequest request)
        {
            return RetryTools.Retry<ApplyPluginResponse>(() =>
            {
                return HttpTools.Post<ApplyPluginResponse>(string.Format(urlDictionary["ApplyPlugin"], accessToken), null, null, request);
            });
        }

        public override GetPluginDevApplyListResponse GetPluginDevApplyList(string accessToken, GetPluginDevApplyListRequest request)
        {
            return RetryTools.Retry<GetPluginDevApplyListResponse>(() =>
            {
                return HttpTools.Post<GetPluginDevApplyListResponse>(string.Format(urlDictionary["GetPluginDevApplyList"], accessToken), null, null, request);
            });
        }

        public override GetPluginListResponse GetPluginList(string accessToken, GetPluginListRequest request)
        {
            return RetryTools.Retry<GetPluginListResponse>(() =>
            {
                return HttpTools.Post<GetPluginListResponse>(string.Format(urlDictionary["GetPluginList"], accessToken), null, null, request);
            });
        }

        public override SetDevPluginApplyStatusResponse SetDevPluginApplyStatus(string accessToken, SetDevPluginApplyStatusRequest request)
        {
            return RetryTools.Retry<SetDevPluginApplyStatusResponse>(() =>
            {
                return HttpTools.Post<SetDevPluginApplyStatusResponse>(string.Format(urlDictionary["SetDevPluginApplyStatus"], accessToken), null, null, request);
            });
        }

        public override UnbindPluginResponse UnbindPlugin(string accessToken, UnbindPluginRequest request)
        {
            return RetryTools.Retry<UnbindPluginResponse>(() =>
            {
                return HttpTools.Post<UnbindPluginResponse>(string.Format(urlDictionary["UnbindPlugin"], accessToken), null, null, request);
            });
        }
        #endregion

        #region 附加小程序
        public override AddNearByPoiResponse AddNearbyPoi(string accessToken, AddNearByPoiRequest request)
        {
            return RetryTools.Retry<AddNearByPoiResponse>(() =>
            {
                return HttpTools.Post<AddNearByPoiResponse>(string.Format(urlDictionary["AddNearbyPoi"], accessToken), null, null, request);
            });
        }

        public override DeleteNearByPoiResponse DeleteNearByPoi(string accessToken, DeleteNearByPoiRequest request)
        {
            return RetryTools.Retry<DeleteNearByPoiResponse>(() =>
            {
                return HttpTools.Post<DeleteNearByPoiResponse>(string.Format(urlDictionary["DeleteNearByPoi"], accessToken), null, null, request);
            });
        }

        public override GetNearByPoiListResponse GetNearByPoiList(string accessToken, int page, int pageRows)
        {
            return RetryTools.Retry<GetNearByPoiListResponse>(() =>
            {
                return HttpTools.Get<GetNearByPoiListResponse>(string.Format(urlDictionary["GetNearByPoiList"], page, pageRows, accessToken), null, null);
            });
        }
        public override SetNearByPoiShowStatusResponse SetNearByPoiShowStatus(string accessToken, SetNearByPoiShowStatusRequest request)
        {
            return RetryTools.Retry<SetNearByPoiShowStatusResponse>(() =>
            {
                return HttpTools.Post<SetNearByPoiShowStatusResponse>(string.Format(urlDictionary["SetNearByPoiShowStatus"], accessToken), null, null, request);
            });
        }
        #endregion
    }
}
