//index.js
const log = require("../../utils/log.js")

//获取应用实例
const app = getApp()

Page({
  data: {
    userInfo: null,
    hasUserInfo: false
  },

  onLoad: function () {
    if (app.globalData.userInfo) {
      // 全局用户信息
      this.setData({
        userInfo: app.globalData.userInfo,
        hasUserInfo: true
      })
    } else {
      // 用户获取结果回调
      app.userInfoReadyCallback = userInfo => {
        this.setData({
          userInfo: userInfo,
          hasUserInfo: true
        })
      }
    }
  },

  //手动获取用户信息事件处理
  onGetUserInfo: function (event) {
    log.success("onGetUserInfo", JSON.stringify(event));
    if (event.detail.errMsg == "getUserInfo:ok") {
      app.setUserInfo(event.detail.userInfo)
    }
  },

  onMyEvent: function (event) {
    wx.showModal({
      title: "系统提示",
      content: "需要清除本地缓存吗?",
      success: function (res) {
        if (res.confirm) {
          wx.clearStorageSync()
          wx.createWorker("/workers/myworker.js").postMessage(res)
        }
      }
    })
  }
})
