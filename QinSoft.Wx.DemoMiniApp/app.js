//app.js
const log = require("utils/log.js")

App({
  onLaunch: function () {
    // 登录
    wx.login({
      success: res => {
        log.success("wx.login success" + JSON.stringify(res));
        wx.request({
          url: this.globalData.urlDictionary.GetJsCode2Session + "?jsCode=" + res.code,
          method: "get",
          dataType: "json",
          success: function (res) {
            log.success("GetJsCode2Session success" + JSON.stringify(res.data));
          },
          fail: function (res) {
            log.success("GetJsCode2Session fail" + JSON.stringify(res));
          }
        })
      },
      fail: res => {
        log.success("wx.login fail" + JSON.stringify(res));
      },
      complete: res => {
        log.success("wx.login complete" + JSON.stringify(res));
      }
    })

    // 获取用户信息
    wx.getSetting({
      success: res => {
        if (res.authSetting['scope.userInfo']) {
          wx.getUserInfo({
            success: res => {
              log.success("自动获取用户信息" + JSON.stringify(res));
              this.globalData.userInfo = res.userInfo

              if (this.userInfoReadyCallback) {
                this.userInfoReadyCallback(res)
              }
            }
          })
        }
      }
    })
  },
  globalData: {
    userInfo: null,
    urlDictionary: {
      GetJsCode2Session: "https://qinsoft.mynatapp.cc/MiniProgram/GetJsCode2Session"
    }
  }
})