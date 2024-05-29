using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.LightningNetwork
{
    // HTLC 类，代表哈希时间锁合约
    public class HTLC
    {
        public User Payee { get; }  // 支付的接受者
        public decimal Amount { get; }  // 支付金额
        public string HashLock { get; }  // 哈希锁定条件
        public bool Redeemed { get; set; }  // 支付是否已经被提取
        public string Secret { get; set; }  // 秘密值

        public HTLC(User payee, decimal amount, string hashLock)
        {
            Payee = payee;
            Amount = amount;
            HashLock = hashLock;
            Redeemed = false;
            Secret = null;
        }
    }
}
