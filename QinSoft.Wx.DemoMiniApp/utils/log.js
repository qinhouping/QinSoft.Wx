const logKey = "system.logs"

const saveLog = (type, action, content) => {
  var logs = wx.getStorageSync(logKey) || []
  logs.unshift({
    time: new Date(),
    type: type,
    action: action,
    content: content
  })
  wx.setStorageSync(logKey, logs)
  return logs.length
}

const success = (action, content) => {
  return saveLog("success", action, content)
}

const info =  (action, content)  => {
  return saveLog("info", action, content)
}

const warning =  (action, content)  => {
  return saveLog("warning", action, content)
}

const error =  (action, content)  => {
  return saveLog("error", action, content)
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