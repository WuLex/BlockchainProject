using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.UTXOAlg
{
    public class TransactionOutput
    {
        public decimal Value { get; set; } // 交易输出金额
        public string Recipient { get; set; } // 接收者地址
        public string ParentTransactionId { get; set; } // 父交易ID

        public TransactionOutput(decimal value, string recipient, string parentTransactionId)
        {
            Value = value;
            Recipient = recipient;
            ParentTransactionId = parentTransactionId;
        }
    }
}
