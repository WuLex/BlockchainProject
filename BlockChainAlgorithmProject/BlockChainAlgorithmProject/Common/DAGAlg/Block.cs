using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.DAGAlg
{
    public class Block
    {
        public List<Transaction> Transactions { get; set; }

        public Block(List<Transaction> transactions)
        {
            Transactions = transactions;
        }
    }
}
