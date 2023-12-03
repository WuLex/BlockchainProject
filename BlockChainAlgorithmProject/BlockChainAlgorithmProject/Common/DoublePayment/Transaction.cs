using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.DoublePayment
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public decimal Amount { get; set; }

        public bool IsConfirmed { get; set; } // 添加一个标识符表示交易是否已被确认
    }
}
