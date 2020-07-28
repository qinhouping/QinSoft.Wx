using QinSoft.Wx.MiniProgram.Model.Analysis;
using QinSoft.Wx.MiniProgram.Model.Auth;
using QinSoft.Wx.MiniProgram.Model.CustomerService;
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
    public abstract class MiniProgramService
    {
        #region 登录
        public abstract GetJsCode2SessionResponse GetJsCode2Session(string jsCode);
        #endregion

        #region 用户信息
        public abstract GetPaidUnionIdResponse GetPaidUnionId(string accessToken, string openId, string transactionId);

        public abstract GetPaidUnionIdResponse GetPaidUnionId(string accessToken, string openId, string outTradeNo, string mchId);
        #endregion

        #region 接口凭证
        public abstract GetAccessTokenResponse GetAccessToken();
        #endregion

        #region 数据分析
        public abstract GetDailyRetainResponse GetDailyRetain(string accessToken, GetDailyRetainRequest request);

        public abstract GetMonthlyRetainResponse GetMonthlyRetain(string accessToken, GetMonthlyRetainRequest request);

        public abstract GetWeeklyRetainResponse GetWeeklyRetain(string accessToken, GetWeeklyRetainRequest request);

        public abstract GetDailySummaryResponse GetDailySummay(string accessToken, GetDailySummaryRequest request);

        public abstract GetDailyVisitTrendResponse GetDailyVisitTrend(string accessToken, GetDailyVisistTrendRequest request);

        public abstract GetMonthlyVisitTrendResponse GetMonthlyVisitTrend(string accessToken, GetMonthlyVisistTrendRequest request);

        public abstract GetWeeklyVisitTrendResponse GetWeeklyVisitTrend(string accessToken, GetWeeklyVisistTrendRequest request);

        public abstract GetUserPortraitResponse GetUserPortrait(string accessToken, GetUserPortraitRequest request);

        public abstract GetVisitDistributionResponse GetVisitDistribution(string accessToken, GetVisitDistributionRequest request);

        public abstract GetVisitPageResponse GetVisitPage(string accessToken, GetVisitPageRequest request);
        #endregion

        #region 客服消息
        public abstract Task<Stream> GetTempMedia(string accessToken, string mediaId);

        public abstract SendCustomerServiceMessageResponse SendCustomerServiceMessage(string accessToken, CustomerServiceMsgBase message);

        public abstract SetTypingResponse SetTyping(string accessToken, SetTypingRequest request);

        public abstract Task<UploadTempMediaResponse> UploadTempMedia(string accessToken, string type, string fileName, Stream stream);
        #endregion

        #region 统一服务消息
        public abstract SendUniformMessageResponse SendUniformMessage(string accessToken, SendUniformMessageRequest request);
        #endregion

        #region 动态消息
        public abstract CreateActivityIdResponse CreateActivityId(string accessToken);

        public abstract SetUpdatableMsgResponse SetUpdatableMsg(string accessToken, SetUpdatableMsgRequest request);
        #endregion

        #region 插件
        public abstract ApplyPluginResponse ApplyPlugin(string accessToken, ApplyPluginRequest request);

        public abstract GetPluginDevApplyListResponse GetPluginDevApplyList(string accessToken, GetPluginDevApplyListRequest request);

        public abstract GetPluginListResponse GetPluginList(string accessToken, GetPluginListRequest request);

        public abstract SetDevPluginApplyStatusResponse SetDevPluginApplyStatus(string accessToken, SetDevPluginApplyStatusRequest request);

        public abstract UnbindPluginResponse UnbindPlugin(string accessToken, UnbindPluginRequest request);
        #endregion
    }
}
