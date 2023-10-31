using System;

namespace CoinMarketCapApp.Models
{
    public class CryptoCoin
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public int CmcRank { get; set; }

        public string Symbol { get; set; }

        public DateTime LaunchedDate { get; set; }
    }
}