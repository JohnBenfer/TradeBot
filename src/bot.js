const axios = require('axios').default;
const transact = require('./transact');
const secret = require('../secret');
const fs = require('fs');

console.log("Starting Trade Bot");

let AAPLClose;

const IEX_KEY = secret.IEX_KEY;
// transact.buy();
// transact.sell();

loadData("SWN").then((res) => {
  AAPLClose = res;
  console.log("AAPL Close data:");
  console.log(AAPLClose);
});



function sleep(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

async function loadData(ticker) {
  const filePath = "../data/" + ticker + "Close.txt";
  let closeData;

  try {
    let file = fs.readFileSync(filePath, "utf8");
    file = JSON.parse(file);
    return file;
  } catch(e) {
    console.log("file does not exit: " + e);
  }
  console.log("Fetching data...");
  await axios.get("https://cloud.iexapis.com/stable/stock/" + ticker + "/intraday-prices?token=" + IEX_KEY + "&chartLast=480").then((response) => {
    closeData = loadClose(response.data);
    recordData(filePath, closeData);
    console.log("Done.");
  }).catch((e) => {
    console.warn("Failed to load data" + e);
  });
  return closeData;
}

function loadClose(data) {
  let closeData = [];
  data.forEach((dataPoint) => {
    closeData.push(dataPoint.close);
  });
  return closeData;
}

function recordData(filePath, data) {
  fs.writeFileSync(filePath, JSON.stringify(data));
}

async function go() {
  for(let i = 0; i < 10; i++) {
    await sleep(1000);
    transact.buy();
    await sleep(1000);
    transact.sell();
  }
}
