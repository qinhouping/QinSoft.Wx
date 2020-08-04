// 项目构建相关
var env = "dev"

var config = {
  dev: {
    GetJsCode2Session: "https://qinsoft.mynatapp.cc/MiniProgram/GetJsCode2Session"
  },
  test: {

  },
  prod: {

  }
}

module.exports = config[env]