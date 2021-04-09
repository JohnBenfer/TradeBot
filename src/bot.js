const axios = require('axios').default;
const transact = require('./transact');

console.log("Starting Trade Bot");

transact.buy();
transact.sell();

load();

function sleep(ms) {
  return new Promise(resolve => setTimeout(resolve, ms));
}

async function load() {
  for(let i = 0; i < 10; i++) {
    await sleep(1000);
    transact.buy();
    await sleep(1000);
    transact.sell();
  }
}
