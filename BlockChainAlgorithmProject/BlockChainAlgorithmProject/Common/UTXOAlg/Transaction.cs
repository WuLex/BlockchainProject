using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.UTXOAlg
{
    public class Transaction
    {
        public string Id { get; set; } // 交易ID
        public List<TransactionInput> Inputs { get; set; } // 交易输入
        public List<TransactionOutput> Outputs { get; set; } // 交易输出

        public Transaction(string id, List<TransactionInput> inputs, List<TransactionOutput> outputs)
        {
            Id = id;
            Inputs = inputs;
            Outputs = outputs;
        }
    }

}
