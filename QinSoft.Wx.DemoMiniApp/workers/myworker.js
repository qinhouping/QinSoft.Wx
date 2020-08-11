worker.onMessage(function (res) {
  sleep(10000)
  console.log(res)
})

function sleep(delay) {
  var start = (new Date()).getTime();
  while ((new Date()).getTime() - start < delay) {
    continue;
  }
}