const axios = require('axios').default;
const transact = require('./transact');
const secret = require('../secret');
const fs = require('fs');
const readline = require('readline');

let closeData;
let results = [];

const IEX_KEY = secret.IEX_KEY;
// transact.buy();
// transact.sell();

console.clear();

start();
// test();

async function test() {
  const ticker = (await askQuestion("Enter stock ticker: ")).toUpperCase().trim();
  let closeData = await loadData(ticker);
  const resultsFile = "../data/" + ticker + "/" + ticker + "-Results.json";
  const avgPrice = getAvgPrice(closeData);
  for(let stp = 1; stp < 30; stp++) {
    for(let ltp = 10; ltp < 150; ltp++) {
      const profit = runMovingAvg(closeData, stp, ltp);
      if(profit > 0) {
        results.push(
          {
            profit: Math.ceil(profit * 100) / 100,
            percent: `${Math.ceil((profit / avgPrice * 100) * 100) / 100}%`,
            stp: stp,
            ltp: ltp 
          }
        );
      }
    }
  }
  let sortedResults = orderResults(results);
  sortedResults = filterResults(sortedResults, 0.0001, avgPrice);
  recordData(resultsFile, sortedResults);
}

async function start() {
  console.clear();
  const t = (await askQuestion("Enter stock ticker: ")).toUpperCase().trim();
  const shortTermPeriod = (await askQuestion("Enter short term period in minutes: ")).trim();
  const longTermPeriod = (await askQuestion("Enter long term period in minutes: ")).trim();
  closeData = await loadData(t);
  console.log(t + " Close data:");
  console.log(closeData);
  runMovingAvg(closeData, shortTermPeriod, longTermPeriod);
}

function getAvgPrice(prices) {
  let total = 0;
  prices.forEach((price) => {
    total += price;
  });
  return total/prices.length;
}

function filterResults(results, threshold, avgPrice) {
  let filteredResults = [];
  results.forEach((result) => {
    if(result.profit >= avgPrice * threshold) {
      filteredResults.push(result);
    }
  });
  return filteredResults;
}

function compare( a, b ) {
  if ( a.profit < b.profit ){
    return -1;
  }
  if ( a.profit > b.profit ){
    return 1;
  }
  return 0;
}

function orderResults(results) {
  return results.sort(compare).reverse();
}

function runMovingAvg(prices, stp, ltp) {
  let sta = null;
  let lta = null;
  let staHigh = false;
  let spend = 0;
  let spendCount = 0;
  let sell = 0;
  let sellCount = 0;
  let lastBuy = 0;
  // iterates over every price starting at long term period
  for (let i = ltp; i < prices.length; i++) {
    sta = getTermAvg(prices, i - stp, i);
    lta = getTermAvg(prices, i - ltp, i);
    if (sta > lta) {

      if (!staHigh) {
        transact.buy(prices[i]);
        if (prices[i]) {
          spend += prices[i];
          spendCount++;
          lastBuy = prices[i];
        }
      }
      staHigh = true;
    } else {

      if (staHigh) {
        transact.sell(prices[i]);
        if (prices[i]) {
          sell += prices[i];
          sellCount++;
        }

      }
      staHigh = false;
    }
  }

  if (spendCount === sellCount) {
    console.log("Profit: $" + (sell - spend).toString());
    return sell - spend;
  } else if (spendCount === sellCount + 1) {
    console.log("spendCount: " + spendCount);
    console.log("sellCount: " + sellCount);
    console.log("profit: $" + (sell - spend + lastBuy).toString());
    return sell - spend + lastBuy;
  }

}

function getTermAvg(prices, start, end) {
  let l = end - start;
  let total = 0;
  for (let i = start; i < end; i++) {
    total += prices[i];
  }
  return total / l;
}


function askQuestion(query) {
  const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
  });

  return new Promise(resolve => rl.question(query, ans => {
    rl.close();
    resolve(ans);
  }));
}




function sleep(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

async function loadData(ticker) {
  const dirPath = "../data/" + ticker;
  const filePath = dirPath + "/" + ticker + "-Close.txt";
  let closeData;
 
  verifyDir(dirPath);

  try {
    let file = fs.readFileSync(filePath, "utf8");
    file = JSON.parse(file);
    return file;
  } catch (e) {
    console.log("file does not exit: " + e);
  }
  console.log("Fetching data...");
  await axios.get(
                  "https://cloud.iexapis.com/stable/stock/" +
                  ticker +
                  "/intraday-prices?token=" +
                  IEX_KEY +
                  "&chartLast=480").
    then((response) => {
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
  data.forEach((dataPoint, i) => {
    closeData.push(dataPoint.close ? dataPoint.close : closeData[i-1]);
  });
  return closeData;
}

function recordData(filePath, data) {
  fs.writeFileSync(filePath, JSON.stringify(data));
}

function verifyDir(dirPath) {
  if(!fs.existsSync(dirPath)) {
    fs.mkdir(dirPath, { recursive: true }, (err) => {
      if (err) throw err;
    });
  }
}

