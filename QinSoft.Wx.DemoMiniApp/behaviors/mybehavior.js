// behavior是组件的复用
module.exports = Behavior({
  options: {
    pureDatePattern: /^_/
  },
  data: {
    count: 0
  },

  lifetimes: {
    created: function () {
      console.log("mybehavior.created")
    },
    attached: function () {
      console.log("mybehavior.attached")
    },
    ready: function () {
      console.log("mybehavior.ready")
    },
    moved: function () {
      console.log("mybehavior.moved")
    },
    detached: function () {
      console.log("mybehavior.detached")
    },
    error: function () {
      console.log("mybehavior.error")
    }
  },

  pageLifetimes: {
    show: function () {
      console.log("mybehavior.show")
    },
    hide: function () {
      console.log("mybehavior.hide")
    },
    resize: function () {
      console.log("mybehavior.resize")
    }
  },

  observers: {
    "count": function (c) {
      if (c >= 2) {
        // 触发myevent事件
        this.triggerEvent("myevent", {
          count: c
        }, {
          bubbles: true,
          composed: false,
          capturePhase: true
        })
      }
    }
  }
})