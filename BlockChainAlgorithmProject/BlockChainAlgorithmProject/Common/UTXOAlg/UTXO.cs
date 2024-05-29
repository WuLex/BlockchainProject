using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.UTXOAlg
{
    public class UTXO
    {
        private static List<TransactionOutput> UTXOs = new List<TransactionOutput>();

        public static void AddOutput(TransactionOutput output)
        {
            UTXOs.Add(output);
        }

        public static List<TransactionOutput> GetUTXOs()
        {
            return UTXOs;
        }

        public static void RemoveOutput(TransactionOutput output)
        {
            UTXOs.Remove(output);
        }
    }
}
