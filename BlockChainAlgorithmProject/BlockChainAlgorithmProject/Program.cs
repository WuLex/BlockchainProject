using BlockChainAlgorithmProject.Common.DAGAlg;

#region DAG算法实例
// 模拟并发的区块
List<Block> concurrentBlocks1 = new List<Block>
        {
            new Block(new List<Transaction> { new Transaction("Tx1"), new Transaction("Tx2") }),
            new Block(new List<Transaction> { new Transaction("Tx3"), new Transaction("Tx4") })
        };

List<Block> concurrentBlocks2 = new List<Block>
        {
            new Block(new List<Transaction> { new Transaction("Tx5"), new Transaction("Tx6") }),
            new Block(new List<Transaction> { new Transaction("Tx7"), new Transaction("Tx8") })
        };

// 创建两棵树
TreeNode tree1 = new TreeNode(concurrentBlocks1[0]);
TreeNode tree2 = new TreeNode(concurrentBlocks2[0]);

// 将并发的区块加入树中
foreach (var block in concurrentBlocks1.Skip(1))
{
    tree1.Children.Add(new TreeNode(block));
}

foreach (var block in concurrentBlocks2.Skip(1))
{
    tree2.Children.Add(new TreeNode(block));
}

// 合并两棵树
TreeNode mergedTree = DAGSimulation.MergeTree(tree1, tree2);

// 输出合并后的树结构
Console.WriteLine("合并后的树:");
Console.WriteLine("根区块交易:");

foreach (var transaction in mergedTree.Block.Transactions)
{
    Console.WriteLine(transaction.TransactionData);
}

Console.WriteLine("子区块:");

foreach (var child in mergedTree.Children)
{
    Console.WriteLine("子区块交易:");
    foreach (var transaction in child.Block.Transactions)
    {
        Console.WriteLine(transaction.TransactionData);
    }
}


#endregion
Console.ReadKey();