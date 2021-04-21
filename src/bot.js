const axios = require('axios').default;
const transact = require('./transact');
const secret = require('../secret');
const fs = require('fs');
const readline = require('readline');

let closeData;
let results = [];
let TICKER;

const IEX_KEY = secret.IEX_KEY;
// transact.buy();
// transact.sell();

console.clear();

start();

async function start() {
  console.clear();
  TICKER = (await askQuestion("Enter stock ticker: ")).toUpperCase().trim();
  // test();
// test1y();
  test5y();
}

async function test() {
  let closeData = await loadIntraDayData(TICKER);
  const resultsFile = "../data/" + TICKER + "/" + TICKER + "-Results.json";
  const avgPrice = getAvgPrice(closeData);
  for(let stp = 1; stp < 50; stp++) {
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
  sortedResults = filterResults(sortedResults, 0.005, avgPrice);
  recordData(resultsFile, sortedResults);
  analyzeSingleStock(sortedResults);
}

async function test1y() {
  let closeData = await load1YData(TICKER);
  const resultsFile = "../data/" + TICKER + "/" + TICKER + "-1Y-Results.json";
  const avgPrice = getAvgPrice(closeData);
  for(let stp = 1; stp < 100; stp++) {
    for(let ltp = 10; ltp < 100; ltp++) {
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
  sortedResults = filterResults(sortedResults, 0.005, avgPrice);
  recordData(resultsFile, sortedResults);
  analyzeSingleStock(sortedResults);
}

async function test5y() {
  let closeData = await load5YData(TICKER);
  const resultsFile = "../data/" + TICKER + "/" + TICKER + "-5Y-Results.json";
  const avgPrice = getAvgPrice(closeData);
  for(let stp = 10; stp < 100; stp++) {
    for(let ltp = 20; ltp < 300; ltp++) {
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
  sortedResults = filterResults(sortedResults, 0.005, avgPrice);
  recordData(resultsFile, sortedResults);
  analyzeSingleStock(sortedResults);
}

function analyzeSingleStock(data) {
  let totalLongStpProfits = 0;
  let totalLongLtpProfits = 0;
  let total = 0;
  data.forEach((dataPoint, i) => {
    if(dataPoint.ltp > dataPoint.stp) {
      totalLongLtpProfits++;
    } else {
      totalLongStpProfits++;
    }
    total += dataPoint.profit;
  });
  console.log("Average profit: " + Math.ceil(total/data.length*100) / 100);
  console.log("Profits with longer LTP: " + totalLongLtpProfits);
  console.log("Profits with longer STP: " + totalLongStpProfits);
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
  return filteredResults.slice(0, 500);
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
        transact.sell(TICKER, prices[i]);
        if (prices[i]) {
          sell += prices[i];
          sellCount++;
        }

      }
      staHigh = false;
    }
  }

  if (spendCount === sellCount) {
    // console.log("Profit: $" + (sell - spend).toString());
    return sell - spend;
  } else if (spendCount === sellCount + 1) {
    // console.log("spendCount: " + spendCount);
    // console.log("sellCount: " + sellCount);
    // console.log("profit: $" + (sell - spend + lastBuy).toString());
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


async function loadIntraDayData(ticker) {
  const dirPath = "../data/" + ticker;
  const filePath = dirPath + "/" + ticker + "-Close.txt";
  let closeData;
 
  verifyDir(dirPath);

  try {
    let file = fs.readFileSync(filePath, "utf8");
    file = JSON.parse(file);
    return file;
  } catch (e) {
    console.log("No cached data");
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

async function load1YData(ticker) {
  const dirPath = "../data/" + ticker;
  const filePath = dirPath + "/" + ticker + "-1Y.txt";
  let closeData;
 
  verifyDir(dirPath);

  try {
    let file = fs.readFileSync(filePath, "utf8");
    file = JSON.parse(file);
    return file;
  } catch (e) {
    console.log("No cached data");
  }
  console.log("Fetching data...");
  await axios.get(
                  "https://cloud.iexapis.com/stable/stock/" +
                  ticker +
                  "/chart/1y?token=" +
                  IEX_KEY).
    then((response) => {
      closeData = loadClose(response.data);
      recordData(filePath, closeData);
      console.log("Done.");
    }).catch((e) => {
      console.warn("Failed to load data" + e);
    });
  return closeData;
}

async function load5YData(ticker) {
  const dirPath = "../data/" + ticker;
  const filePath = dirPath + "/" + ticker + "-5Y.txt";
  let closeData;
 
  verifyDir(dirPath);

  try {
    let file = fs.readFileSync(filePath, "utf8");
    file = JSON.parse(file);
    return file;
  } catch (e) {
    console.log("No cached data");
  }
  console.log("Fetching data...");
  await axios.get(
                  "https://cloud.iexapis.com/stable/stock/" +
                  ticker +
                  "/chart/5y?token=" +
                  IEX_KEY).
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

