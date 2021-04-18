const axios = require('axios').default;
module.exports = {
  sell: (price) => {
    console.log("selling at " + price);
  },
  buy: (price) => {
    console.log("buying at " + price);
  }
};
