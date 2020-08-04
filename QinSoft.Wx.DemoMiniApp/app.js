//app.js
const log = require("utils/log.js")
const config = require("config.js")

App({
  globalData: {
    userInfo: null
  },

  onLaunch: function (options) {
    log.info("App.onLaunch", JSON.stringify(options))
    // 登录
    wx.login({
      success: res => {
        log.info("wx.login", JSON.stringify(res));
        // 调用服务端接口获取用户unionid等信息
        wx.request({
          url: config.GetJsCode2Session + "?jsCode=" + res.code,
          method: "get",
          dataType: "json",
          success: function (res) {
            log.success("GetJsCode2Session", JSON.stringify(res.data));
          },
          fail: function (res) {
            log.error("GetJsCode2Session", JSON.stringify(res));
          }
        })
      },
      fail: res => {
        log.error("wx.login", JSON.stringify(res));
      },
      complete: res => {
        log.info("wx.login", JSON.stringify(res));
      }
    })

    // 自动获取已授权用户信息
    wx.getSetting({
      success: res => {
        log.info("wx.getSetting", JSON.stringify(res));
        if (res.authSetting['scope.userInfo']) {
          wx.getUserInfo({
            success: res => {
              log.success("wx.getUserInfo", JSON.stringify(res));
              this.globalData.userInfo = res.userInfo
              // 回调用户获取结果
              if (this.userInfoReadyCallback) {
                this.userInfoReadyCallback(res.userInfo)
              }
            }
          })
        }
      }
    })
  },

  onShow: function (options) {
    log.info("App.onShow", JSON.stringify(options))
  },

  onHide: function (options) {
    log.info("App.onHide", JSON.stringify(options))
  },

  onError: function (options) {
    log.info("App.onError", JSON.stringify(options))
  },

  setUserInfo: function (userInfo) {
    this.globalData.userInfo = userInfo
    // 回调用户获取结果
    if (this.userInfoReadyCallback) {
      this.userInfoReadyCallback(userInfo)
    }
  }
})