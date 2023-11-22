using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.DAGAlg
{
   
    public class DAGSimulation
    {
        public static TreeNode MergeTree(TreeNode tree1, TreeNode tree2)
        {
            // 模拟简单的树合并逻辑
            TreeNode mergedTree = new TreeNode(new Block(new List<Transaction>()));
            mergedTree.Block.Transactions.AddRange(tree1.Block.Transactions);
            mergedTree.Block.Transactions.AddRange(tree2.Block.Transactions);
            //// 合并两棵树的区块
            //foreach (var child1 in tree1.Children)
            //{
            //    mergedTree.Children.Add(child1);
            //}

            //foreach (var child2 in tree2.Children)
            //{
            //    mergedTree.Children.Add(child2);
            //}

            // 合并两棵树的区块
            mergedTree.Children.AddRange(tree1.Children);
            mergedTree.Children.AddRange(tree2.Children);

            // 在实际应用中，可能需要更复杂的合并逻辑

            return mergedTree;
        }

        public static void PrintTree(TreeNode node, string prefix = "")
        {
            Console.WriteLine($"{prefix}子区块交易:");
            foreach (var transaction in node.Block.Transactions)
            {
                Console.WriteLine($"{prefix}{transaction.TransactionData}");
            }

            foreach (var child in node.Children)
            {
                PrintTree(child, $"{prefix}\t");
            }
        }
    }
}
