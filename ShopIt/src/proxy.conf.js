const PROXY_CONFIG = [
  {
    context: [
      "/CountryRate",
      "/Product",
      "/Order"
    ],
    target: "https://localhost:7170",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
