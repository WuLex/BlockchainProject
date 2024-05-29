using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.UTXOAlg
{
    public class TransactionInput
    {
        public string TransactionOutputId { get; set; } // 交易输出ID
        public TransactionOutput UTXO { get; set; } // UTXO
    }
}
