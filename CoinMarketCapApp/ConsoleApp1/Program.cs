using Newtonsoft.Json;
using NoobsMuc.Coinmarketcap.Client;
using System.Text.Json;
using System.Text.RegularExpressions;

var content = @"{
	""status"": {
		""timestamp"": ""2023-10-30T10:41:05.748Z"",
		""error_code"": 0,
		""error_message"": null,
		""elapsed"": 61,
		""credit_count"": 25,
		""notice"": null,
		""total_count"": 8828
	},
	""data"": [{
		""id"": 1,
		""name"": ""Bitcoin"",
		""symbol"": ""BTC"",
		""slug"": ""bitcoin"",
		""num_market_pairs"": 10513,
		""date_added"": ""2010-07-13T00:00:00.000Z"",
		""tags"": [""mineable"", ""pow"", ""sha-256"", ""store-of-value"", ""state-channel"", ""coinbase-ventures-portfolio"", ""three-arrows-capital-portfolio"", ""polychain-capital-portfolio"", ""binance-labs-portfolio"", ""blockchain-capital-portfolio"", ""boostvc-portfolio"", ""cms-holdings-portfolio"", ""dcg-portfolio"", ""dragonfly-capital-portfolio"", ""electric-capital-portfolio"", ""fabric-ventures-portfolio"", ""framework-ventures-portfolio"", ""galaxy-digital-portfolio"", ""huobi-capital-portfolio"", ""alameda-research-portfolio"", ""a16z-portfolio"", ""1confirmation-portfolio"", ""winklevoss-capital-portfolio"", ""usv-portfolio"", ""placeholder-ventures-portfolio"", ""pantera-capital-portfolio"", ""multicoin-capital-portfolio"", ""paradigm-portfolio"", ""bitcoin-ecosystem"", ""ftx-bankruptcy-estate""],
		""max_supply"": 21000000,
		""circulating_supply"": 19528175,
		""total_supply"": 19528175,
		""infinite_supply"": false,
		""platform"": null,
		""cmc_rank"": 1,
		""self_reported_circulating_supply"": null,
		""self_reported_market_cap"": null,
		""tvl_ratio"": null,
		""last_updated"": ""2023-10-30T10:39:00.000Z"",
		""quote"": {
			""USD"": {
				""price"": 34522.13090978538,
				""volume_24h"": 14255409050.89585,
				""volume_change_24h"": 47.5325,
				""percent_change_1h"": -0.29158721,
				""percent_change_24h"": 0.96909869,
				""percent_change_7d"": 13.17129724,
				""percent_change_30d"": 28.03334228,
				""percent_change_60d"": 26.83991544,
				""percent_change_90d"": 19.42280727,
				""market_cap"": 674154213779.1981,
				""market_cap_dominance"": 52.893,
				""fully_diluted_market_cap"": 724964749105.49,
				""tvl"": null,
				""last_updated"": ""2023-10-30T10:39:00.000Z""
			}
		}
	}, {
		""id"": 1027,
		""name"": ""Ethereum"",
		""symbol"": ""ETH"",
		""slug"": ""ethereum"",
		""num_market_pairs"": 7655,
		""date_added"": ""2015-08-07T00:00:00.000Z"",
		""tags"": [""pos"", ""smart-contracts"", ""ethereum-ecosystem"", ""coinbase-ventures-portfolio"", ""three-arrows-capital-portfolio"", ""polychain-capital-portfolio"", ""binance-labs-portfolio"", ""blockchain-capital-portfolio"", ""boostvc-portfolio"", ""cms-holdings-portfolio"", ""dcg-portfolio"", ""dragonfly-capital-portfolio"", ""electric-capital-portfolio"", ""fabric-ventures-portfolio"", ""framework-ventures-portfolio"", ""hashkey-capital-portfolio"", ""kenetic-capital-portfolio"", ""huobi-capital-portfolio"", ""alameda-research-portfolio"", ""a16z-portfolio"", ""1confirmation-portfolio"", ""winklevoss-capital-portfolio"", ""usv-portfolio"", ""placeholder-ventures-portfolio"", ""pantera-capital-portfolio"", ""multicoin-capital-portfolio"", ""paradigm-portfolio"", ""injective-ecosystem"", ""layer-1"", ""ftx-bankruptcy-estate""],
		""max_supply"": null,
		""circulating_supply"": 120269587.66633837,
		""total_supply"": 120269587.66633837,
		""infinite_supply"": true,
		""platform"": null,
		""cmc_rank"": 2,
		""self_reported_circulating_supply"": null,
		""self_reported_market_cap"": null,
		""tvl_ratio"": null,
		""last_updated"": ""2023-10-30T10:39:00.000Z"",
		""quote"": {
			""USD"": {
				""price"": 1814.5278051464613,
				""volume_24h"": 6216403192.58461,
				""volume_change_24h"": 54.9021,
				""percent_change_1h"": -0.43063777,
				""percent_change_24h"": 1.63325286,
				""percent_change_7d"": 8.44253152,
				""percent_change_30d"": 8.32034994,
				""percent_change_60d"": 6.44301098,
				""percent_change_90d"": -1.01609728,
				""market_cap"": 218232510934.0709,
				""market_cap_dominance"": 17.1221,
				""fully_diluted_market_cap"": 218232510934.07,
				""tvl"": null,
				""last_updated"": ""2023-10-30T10:39:00.000Z""
			}
		}
	}, {
		""id"": 825,
		""name"": ""Tether USDt"",
		""symbol"": ""USDT"",
		""slug"": ""tether"",
		""num_market_pairs"": 64623,
		""date_added"": ""2015-02-25T00:00:00.000Z"",
		""tags"": [""payments"", ""stablecoin"", ""asset-backed-stablecoin"", ""avalanche-ecosystem"", ""solana-ecosystem"", ""arbitrum-ecosytem"", ""moonriver-ecosystem"", ""injective-ecosystem"", ""bnb-chain"", ""usd-stablecoin"", ""optimism-ecosystem""],
		""max_supply"": null,
		""circulating_supply"": 84538113416.02579,
		""total_supply"": 87625667476.69608,
		""platform"": {
			""id"": 1027,
			""name"": ""Ethereum"",
			""symbol"": ""ETH"",
			""slug"": ""ethereum"",
			""token_address"": ""0xdac17f958d2ee523a2206206994597c13d831ec7""
		},
		""infinite_supply"": true,
		""cmc_rank"": 3,
		""self_reported_circulating_supply"": null,
		""self_reported_market_cap"": null,
		""tvl_ratio"": null,
		""last_updated"": ""2023-10-30T10:38:00.000Z"",
		""quote"": {
			""USD"": {
				""price"": 1.0001093554627893,
				""volume_24h"": 23256428392.609417,
				""volume_change_24h"": 44.6013,
				""percent_change_1h"": -0.00654944,
				""percent_change_24h"": -0.03378456,
				""percent_change_7d"": -0.01210538,
				""percent_change_30d"": 0.0041459,
				""percent_change_60d"": 0.01527209,
				""percent_change_90d"": 0.05352291,
				""market_cap"": 84547358120.54173,
				""market_cap_dominance"": 6.6274,
				""fully_diluted_market_cap"": 87635249822.12,
				""tvl"": null,
				""last_updated"": ""2023-10-30T10:38:00.000Z""
			}
		}
	}, {
		""id"": 1839,
		""name"": ""BNB"",
		""symbol"": ""BNB"",
		""slug"": ""bnb"",
		""num_market_pairs"": 1707,
		""date_added"": ""2017-07-25T00:00:00.000Z"",
		""tags"": [""marketplace"", ""centralized-exchange"", ""payments"", ""smart-contracts"", ""alameda-research-portfolio"", ""multicoin-capital-portfolio"", ""bnb-chain"", ""layer-1"", ""sec-security-token"", ""alleged-sec-securities"", ""celsius-bankruptcy-estate""],
		""max_supply"": null,
		""circulating_supply"": 151703886.01666242,
		""total_supply"": 151703886.01666242,
		""infinite_supply"": false,
		""platform"": null,
		""cmc_rank"": 4,
		""self_reported_circulating_supply"": null,
		""self_reported_market_cap"": null,
		""tvl_ratio"": null,
		""last_updated"": ""2023-10-30T10:38:00.000Z"",
		""quote"": {
			""USD"": {
				""price"": 227.8896937834594,
				""volume_24h"": 253973640.22659466,
				""volume_change_24h"": 24.0071,
				""percent_change_1h"": -0.11613185,
				""percent_change_24h"": 0.97250126,
				""percent_change_7d"": 3.67783979,
				""percent_change_30d"": 5.98298521,
				""percent_change_60d"": 1.89807231,
				""percent_change_90d"": -6.8154641,
				""market_cap"": 34571752130.09802,
				""market_cap_dominance"": 2.7118,
				""fully_diluted_market_cap"": 34571752130.1,
				""tvl"": null,
				""last_updated"": ""2023-10-30T10:38:00.000Z""
			}
		}
	}, {
		""id"": 52,
		""name"": ""XRP"",
		""symbol"": ""XRP"",
		""slug"": ""xrp"",
		""num_market_pairs"": 1123,
		""date_added"": ""2013-08-04T00:00:00.000Z"",
		""tags"": [""medium-of-exchange"", ""enterprise-solutions"", ""arrington-xrp-capital-portfolio"", ""galaxy-digital-portfolio"", ""a16z-portfolio"", ""pantera-capital-portfolio"", ""ftx-bankruptcy-estate""],
		""max_supply"": 100000000000,
		""circulating_supply"": 53560508378,
		""total_supply"": 99988331658,
		""infinite_supply"": false,
		""platform"": null,
		""cmc_rank"": 5,
		""self_reported_circulating_supply"": null,
		""self_reported_market_cap"": null,
		""tvl_ratio"": null,
		""last_updated"": ""2023-10-30T10:39:00.000Z"",
		""quote"": {
			""USD"": {
				""price"": 0.5582720128324389,
				""volume_24h"": 853423063.9603124,
				""volume_change_24h"": 54.345,
				""percent_change_1h"": -0.21197779,
				""percent_change_24h"": 0.95082452,
				""percent_change_7d"": 5.19769702,
				""percent_change_30d"": 7.73746904,
				""percent_change_60d"": 6.49707165,
				""percent_change_90d"": -19.10130069,
				""market_cap"": 29901332820.514767,
				""market_cap_dominance"": 2.346,
				""fully_diluted_market_cap"": 55827201283.24,
				""tvl"": null,
				""last_updated"": ""2023-10-30T10:39:00.000Z""
			}
		}
	}, {
		""id"": 3408,
		""name"": ""USDC"",
		""symbol"": ""USDC"",
		""slug"": ""usd-coin"",
		""num_market_pairs"": 14688,
		""date_added"": ""2018-10-08T00:00:00.000Z"",
		""tags"": [""medium-of-exchange"", ""stablecoin"", ""asset-backed-stablecoin"", ""coinbase-ventures-portfolio"", ""hedera-hashgraph-ecosystem"", ""fantom-ecosystem"", ""arbitrum-ecosytem"", ""moonriver-ecosystem"", ""bnb-chain"", ""usd-stablecoin"", ""optimism-ecosystem""],
		""max_supply"": null,
		""circulating_supply"": 25051689957.13854,
		""total_supply"": 25051689957.13854,
		""platform"": {
			""id"": 1027,
			""name"": ""Ethereum"",
			""symbol"": ""ETH"",
			""slug"": ""ethereum"",
			""token_address"": ""0xa0b86991c6218b36c1d19d4a2e9eb0ce3606eb48""
		},
		""infinite_supply"": false,
		""cmc_rank"": 6,
		""self_reported_circulating_supply"": null,
		""self_reported_market_cap"": null,
		""tvl_ratio"": null,
		""last_updated"": ""2023-10-30T10:39:00.000Z"",
		""quote"": {
			""USD"": {
				""price"": 0.9999643208283027,
				""volume_24h"": 3342401112.04941,
				""volume_change_24h"": 47.6765,
				""percent_change_1h"": -0.01014679,
				""percent_change_24h"": -0.04014824,
				""percent_change_7d"": -0.0001993,
				""percent_change_30d"": -0.00966306,
				""percent_change_60d"": -0.00094274,
				""percent_change_90d"": 0.00146947,
				""market_cap"": 25050796133.591248,
				""market_cap_dominance"": 1.965,
				""fully_diluted_market_cap"": 25050796133.59,
				""tvl"": null,
				""last_updated"": ""2023-10-30T10:39:00.000Z""
			}
		}
	}, {
		""id"": 24882,
		""name"": ""4-CHAN"",
		""symbol"": ""4CHAN"",
		""slug"": ""4-chan-token"",
		""num_market_pairs"": 6,
		""date_added"": ""2023-05-03T03:19:48.000Z"",
		""tags"": [""memes""],
		""max_supply"": null,
		""circulating_supply"": 0,
		""total_supply"": 87312730404451700000,
		""platform"": {
			""id"": 1027,
			""name"": ""Ethereum"",
			""symbol"": ""ETH"",
			""slug"": ""ethereum"",
			""token_address"": ""0xe0A458BF4AcF353cB45e211281A334BB1d837885""
		},
		""infinite_supply"": false,
		""cmc_rank"": 2170,
		""self_reported_circulating_supply"": 76897978427491700000,
		""self_reported_market_cap"": 3755863.5523559,
		""tvl_ratio"": null,
		""last_updated"": ""2023-10-30T10:39:00.000Z"",
		""quote"": {
			""USD"": {
				""price"": 4.8842162423e-14,
				""volume_24h"": 3599864.01261899,
				""volume_change_24h"": -15.9894,
				""percent_change_1h"": -7.36614693,
				""percent_change_24h"": -19.04758425,
				""percent_change_7d"": 94.4245242,
				""percent_change_30d"": 97.43827668,
				""percent_change_60d"": 93.34609486,
				""percent_change_90d"": 22.60191316,
				""market_cap"": 0,
				""market_cap_dominance"": 0,
				""fully_diluted_market_cap"": 4264542.56,
				""tvl"": null,
				""last_updated"": ""2023-10-30T10:39:00.000Z""
			}
		}
	}]
}";


JsonConvert.DefaultSettings = () => new JsonSerializerSettings
{
    Converters = new List<JsonConverter> { new BigIntegerJsonConverter() }
};

CoinmarketcapItemData result1 = JsonConvert.DeserializeObject<CoinmarketcapItemData>(content);
Console.WriteLine(result1.DataList.Count());

#region 正则表达式匹配多个整数值并替换成字符串形式
//// 使用正则表达式匹配多个整数值并替换成字符串形式
var newContentJsonString = ReplaceFieldsInJson(content, new (string, string)[]
	   {
			("\"total_supply\": (\\d+\\.\\d+)", "\"total_supply\": \"$1\""),
			("\"self_reported_circulating_supply\": (\\d+\\.\\d+)", "\"self_reported_circulating_supply\": \"$1\""),
			("\"self_reported_market_cap\": (\\d+\\.\\d+)", "\"self_reported_market_cap\": \"$1\""),
	   });
static string ReplaceFieldsInJson(string jsonString, (string pattern, string replacement)[] replacements)
{
	var jsonParts = jsonString.Split(':');

	for (int i = 0; i < jsonParts.Length; i++)
	{
		foreach (var (pattern, replacement) in replacements)
		{
			jsonParts[i] = Regex.Replace(jsonParts[i], pattern, replacement);
		}
	}

	return string.Join(":", jsonParts);
}


//static string ReplaceFieldsInJson(string jsonString, (string pattern, string replacement)[] replacements)
//{
//string newJsonString = jsonString;

//foreach (var (pattern, replacement) in replacements)
//{
//newJsonString = Regex.Replace(newJsonString, pattern, replacement);
//}

//return newJsonString;
//}

#endregion