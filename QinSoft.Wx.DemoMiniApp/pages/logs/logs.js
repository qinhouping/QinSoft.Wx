//logs.js
const log = require("../../utils/log.js")

Page({
  data: {
    logs: [],
    detailPagePath: "/pages/logs/logdetail"
  },

  onLoad: function () {
    this.setData({
      logs: log.getLogs()
    })
  },

  //手动刷新日志内容
  onPullDownRefresh: function () {
    this.setData({
      logs: log.getLogs()
    })
    wx.stopPullDownRefresh();
  },

  //查看日志详情处理
  onLogDetailTap(event) {
    const log = event.target.dataset.log
    var _this = this;
    wx.setStorage({
      data: log,
      key: 'logdetail',
      success: function () {
        wx.navigateTo({
          url: _this.data.detailPagePath + "?key=logdetail",
        })
      }
    })
  }
})
