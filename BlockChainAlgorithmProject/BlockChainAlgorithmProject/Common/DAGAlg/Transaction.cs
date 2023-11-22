using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.DAGAlg
{
    public class Transaction
    {
        public string TransactionData { get; set; }

        public Transaction(string data)
        {
            TransactionData = data;
        }
    }
}
