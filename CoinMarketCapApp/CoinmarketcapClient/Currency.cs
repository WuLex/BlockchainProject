using System;
using Newtonsoft.Json;

namespace NoobsMuc.Coinmarketcap.Client
{
    public class Currency
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Rank { get; set; }
        public decimal Price { get; set; }
        public decimal Volume24hUsd { get; set; }
        public decimal MarketCapUsd { get; set; }
        public decimal PercentChange1h { get; set; }
        public decimal PercentChange24h { get; set; }
        public decimal PercentChange7d { get; set; }

        #region 添加价格变动字段
        public double PercentChange30d { get; set; }
        
        public double PercentChange60d { get; set; }

        public double PercentChange90d { get; set; }

        #endregion
        public DateTime LastUpdated { get; set; }

        public DateTime DateAdded { get; set; }
        public decimal MarketCapConvert { get; set; }
        public string ConvertCurrency { get; set; }
    }
}