using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.SCPAlg
{
    public class StellarNode
    {
        public int NodeId { get; private set; }
        public List<int> QuorumSlice { get; private set; }
        private static List<StellarNode> AllNodes { get; set; }
        public StellarNode(int nodeId, List<int> quorumSlice)
        {
            NodeId = nodeId;
            QuorumSlice = quorumSlice;
        }
        public static void InitializeNodes(List<StellarNode> nodes)
        {
            AllNodes = nodes;
        }


        public bool AcceptTransaction(Transaction transaction)
        {
            // 检查Quorum Slice中的节点是否同意交易
            int agreementCount = 0;

            foreach (var nodeId in QuorumSlice)
            {
                StellarNode node = FindNodeById(nodeId);
                if (node != null && node.ValidateTransaction(transaction))
                {
                    agreementCount++;
                }
            }

            // 多数派原则
            return agreementCount >= QuorumSlice.Count / 2 + 1;
        }

        public bool ValidateTransaction(Transaction transaction)
        {
            // 在实际应用中，此处应该包含更多的验证逻辑
            // 这可能涉及到签名验证、交易有效性等
            Console.WriteLine($"Node {NodeId} validates transaction: {transaction.TransactionId}");
            return true;
        }

        private StellarNode FindNodeById(int nodeId)
        {
            // 在实际应用中，应该有一种方式来查找网络中的节点
            // 这可能涉及到网络通信或共享的节点列表
            // 简单地查找节点列表中的匹配节点
            StellarNode? foundNode = AllNodes.FirstOrDefault(node => node.NodeId == nodeId);

            if (foundNode != null)
            {
                Console.WriteLine($"Node {NodeId} found by {NodeId}");
            }
            else
            {
                Console.WriteLine($"Node {NodeId} not found by {NodeId}");
            }

            return foundNode;
        }
    }
}
