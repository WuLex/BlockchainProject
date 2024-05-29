using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.LightningNetwork
{
    // 用户类，代表闪电网络中的一个参与者
    public class User
    {
        public string Name { get; }

        public User(string name)
        {
            Name = name;
        }

        // 验证哈希锁定条件的方法（用于中间人验证）
        public bool VerifyHashLock(HTLC htlc, string hashLock)
        {
            return htlc.HashLock.Equals(hashLock, StringComparison.OrdinalIgnoreCase);
        }

        // 验证秘密值是否匹配哈希锁定条件的方法（用于最终收款人验证）
        public bool VerifyHashLock(HTLC htlc, string secret, bool isSecret)
        {
            return htlc.HashLock.Equals(HashHelper.GenerateSHA256Hash(secret), StringComparison.OrdinalIgnoreCase);
        }

        // 提取支付并公布秘密值的方法
        public void Redeem(HTLC htlc, string secret)
        {
            if (VerifyHashLock(htlc, secret, true))
            {
                htlc.Redeemed = true;
                htlc.Secret = secret;
            }
        }
    }
}
