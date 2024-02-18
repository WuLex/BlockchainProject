using System;

namespace CoinMarketCapApp.Models
{
    /// <summary>
    /// "USD": {
    //  "price": 27655.709546238617,
    //  "volume_24h": 11849090531.601503,
    //  "volume_change_24h": 12.5807,
    //  "percent_change_1h": 0.38343715,
    //  "percent_change_24h": 0.20067455,
    //  "percent_change_7d": 2.08759976,
    //  "percent_change_30d": 7.50508054,
    //  "percent_change_60d": -4.70737278,
    //  "percent_change_90d": -8.65623308,
    //  "market_cap": 539436008851.7173,
    //  "market_cap_dominance": 49.6656,
    //  "fully_diluted_market_cap": 580769900471.01,
    //  "tvl": null,
    //  "last_updated": "2023-10-06T08:26:00.000Z"
    //}
    /// </summary>
    public class CryptoCoin
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CmcRank { get; set; }

        public string Symbol { get; set; }

        public decimal PercentChange7d { get; set; }
        public double PercentChange30d { get; set; }
        public double PercentChange60d { get; set; }
        public double PercentChange90d { get; set; }

        public DateTime LaunchedDate { get; set; }
    }
}