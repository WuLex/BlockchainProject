using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.SCPAlg
{
    public class Transaction
    {
        public int TransactionId { get; private set; }

        public Transaction(int transactionId)
        {
            TransactionId = transactionId;
        }
    }
}
