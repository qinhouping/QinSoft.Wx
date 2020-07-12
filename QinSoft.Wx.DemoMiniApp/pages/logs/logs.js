//logs.js
const util = require('../../utils/util.js')
const log = require("../../utils/log.js")

Page({
  data: {
    logs: []
  },
  onLoad: function () {
    this.setData({
      logs: log.getLogs()
    })
    wx.stopPullDownRefresh();
  },
  onPullDownRefresh: function () {
    this.onLoad()
    wx.showToast({
      title: "已经刷新",
    })
  }
})
