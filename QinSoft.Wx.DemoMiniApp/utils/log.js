const logKey = "system.logs"

const saveLog = (type, message) => {
  var logs = wx.getStorageSync(logKey) || []
  logs.unshift({
    time: new Date(),
    type: type,
    message: message
  })
  wx.setStorageSync(logKey, logs)
}

const success = message => {
  saveLog("success", message)
}

const info = message => {
  saveLog("info", message)
}

const warning = message => {
  saveLog("warning", message)
}

const error = message => {
  saveLog("error", message)
}

const getLogs = () => {
  return wx.getStorageSync(logKey) || []
}

module.exports = {
  success: success,
  info: info,
  warning: warning,
  error: error,
  getLogs: getLogs
}