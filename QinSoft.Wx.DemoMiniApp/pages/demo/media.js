// pages/demo/media.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    audioSrc: "https://m10.music.126.net/20200714095207/9cb523941c36c7365fbf7cb359f8fea8/ymusic/obj/w5zDlMODwrDDiGjCn8Ky/3142653095/f081/5df2/ba73/04f7fbc83e0dd515eb020a151444cc6c.mp3",
    audioPoster: "https://p2.music.126.net/LJmqN6twFqHp2BGsTp1yLg==/109951165118145287.jpg",
    audioName: "要我怎么办 - 李荣浩",
    audioAuthor: "李荣浩",

    photoSrc:null
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function (options) {
    const a1=wx.createAudioContext("a1")
    a1.play()
  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function () {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function () {

  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function () {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function () {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function () {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function () {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function () {

  },

  bindAudioError: function (e) {
    wx.showModal({
      cancelColor: 'cancelColor',
      content: JSON.stringify(e)
    })
  },

  bindCameraButtonTap: function (e) {
    const ctx = wx.createCameraContext()
    ctx.takePhoto({
      quality: 'high',
      success: (res) => {
        this.setData({
          photoSrc: res.tempImagePath
        })
      }
    })
  }
})