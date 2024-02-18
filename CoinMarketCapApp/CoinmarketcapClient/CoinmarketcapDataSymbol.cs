using Newtonsoft.Json;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;

namespace NoobsMuc.Coinmarketcap.Client
{
    public class CoinmarketcapDataSymbol
    {
        public Status status { get; set; }

        public DataItemSymbol dataItem { get; set; }
    }

    public class CurrenyData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public int? num_market_pairs { get; set; }
        public DateTime date_added { get; set; }
        public List<Tag> tags { get; set; }
        public decimal? max_supply { get; set; }
        public decimal? circulating_supply { get; set; }

        //[JsonConverter(typeof(BigIntegerJsonConverter))]
        //[JsonIgnore]
        public decimal? total_supply { get; set; }
        public Platform platform { get; set; }
        public int? is_active { get; set; }
        public int? cmc_rank { get; set; }
        public int? is_fiat { get; set; }

        //[JsonIgnore]
        //[JsonConverter(typeof(BigIntegerJsonConverter))]

        public decimal? self_reported_circulating_supply { get; set; }

        //[JsonIgnore]
        //[JsonConverter(typeof(BigIntegerJsonConverter))]

        public decimal? self_reported_market_cap { get; set; }

        public object tvl_ratio { get; set; }
        public DateTime last_updated { get; set; }
        public Quote quote { get; set; }
    }

    public class DataItemSymbol
    {
        public List<CurrenyData> CurrenyData { get; set; }
    }

    public class Platform
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string slug { get; set; }
        public string token_address { get; set; }
    }

    public class Tag
    {
        public string slug { get; set; }
        public string name { get; set; }
        public string category { get; set; }
    }
}