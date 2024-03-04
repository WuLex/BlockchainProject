namespace BlockChainAlgorithmProject.Common.BRC20Alg
{
    /// <summary>
    ///  C#模拟BRC20链下服务
    /// </summary>
    public class BRC20Service
    {
        //Balances 字段是一个静态字典，用于存储所有代币持有者的余额
        //数据可以来自以下几个来源：
        //手动输入：在开发过程中，可以手动输入数据来初始化 Balances 字典。
        //数据库：在生产环境中，可以将数据存储在数据库中，并在程序启动时从数据库中加载数据。
        //链下服务：如果使用链下服务来维护代币持有者的余额，则可以从链下服务中获取数据。
        // 手动赋值
        //Balances["alice"] = 100;
        // 数据库操作
        //using (var db = new MyDatabase())
        //{
        //  db.Balances.Add("alice", 100);
        //}
        // 链下服务 API
        //    var response = await Http.GetAsync("https://api.example.com/balances");
        //    var balances = JsonConvert.DeserializeObject<Dictionary<string, uint>>(response.Content.ReadAsStringAsync().Result);
        //    Balances = balances;
        private static Dictionary<string, uint> Balances = new Dictionary<string, uint>() {
            { "alice", 100 },
            { "bob", 200 },
        };

        #region 使用数据库模拟持有者列表

        public static uint BalanceOf(string address)
        {
            if (!Balances.ContainsKey(address))
            {
                return 0;
            }

            return Balances[address];
        }

        public static bool Transfer(string fromAddress, string toAddress, uint amount)
        {
            if (!Balances.ContainsKey(fromAddress) || Balances[fromAddress] < amount)
            {
                return false;
            }

            Balances[fromAddress] -= amount;
            Balances[toAddress] = (Balances.ContainsKey(toAddress) ? Balances[toAddress] + amount : amount);
            return true;
        }

        #endregion 使用数据库模拟持有者列表

        #region 使用 HTTP 服务模拟链下服务

        //public static HttpResponseMessage BalanceOf(HttpRequestMessage request)
        //{
        //    string address = request.GetUri().Query["address"];

        //    if (!Balances.ContainsKey(address))
        //    {
        //        return request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    uint balance = Balances[address];
        //    return request.CreateResponse(HttpStatusCode.OK, new JsonResult(balance));
        //}

        //public static HttpResponseMessage Transfer(HttpRequestMessage request)
        //{
        //    string fromAddress = request.GetUri().Query["fromAddress"];
        //    string toAddress = request.GetUri().Query["toAddress"];
        //    uint amount = Convert.ToInt32(request.GetUri().Query["amount"]);

        //    if (!Balances.ContainsKey(fromAddress) || Balances[fromAddress] < amount)
        //    {
        //        return request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    Balances[fromAddress] -= amount;
        //    Balances[toAddress] = (Balances.ContainsKey(toAddress) ? Balances[toAddress] + amount : amount);
        //    return request.CreateResponse(HttpStatusCode.OK, new JsonResult(new { }));
        //}

        #endregion 使用 HTTP 服务模拟链下服务
    }
}