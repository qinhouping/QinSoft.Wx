// components/mycomp.js
const mybehavior = require("../behaviors/mybehavior.js")

Component({
  behaviors: [mybehavior],

  /**
   * 组件的属性列表
   */
  properties: {
    tip: {
      type: String,
      value: "tip",
      observer: function () {
        console.log(this.properties.tip)
      }
    }
  },

  /**
   * 组件的初始数据
   */
  data: {
  },

  /**
   * 组件的方法列表
   */
  methods: {
    onTap: function (event) {
      this.setData({
        count: this.data.count + 1
      })
    }
  },

  lifetimes: {
    created: function () {
      console.log("lifetimes.created")
    },
    attached: function () {
      console.log("lifetimes.attached")
    },
    ready: function () {
      console.log("lifetimes.ready")
    },
    moved: function () {
      console.log("lifetimes.moved")
    },
    detached: function () {
      console.log("lifetimes.detached")
    },
    error: function (error) {
      console.log("lifetimes.error", error)
    }
  },

  pageLifetimes: {
    show: function () {
      console.log("pageLifetimes.show")
    },
    hide: function () {
      console.log("pageLifetimes.hide")
    },
    resize: function () {
      console.log("pageLifetimes.resize")
    }
  },

  observers: {
    "tip": function (t) {
      console.log(t)
    }
  }
})
