using BlockChainAlgorithmProject.Common.DoublePayment;
using BlockChainAlgorithmProject.Common.MerkleTreeAlg;
using BlockChainAlgorithmProject.Common.SCPAlg;
using System.Xml.Linq;
using Transaction = BlockChainAlgorithmProject.Common.DoublePayment.Transaction;


#region 防止双重支付
//模拟了一个简化的双花防范机制，
//通过在交易中添加一个确认状态并在 AddBlock 方法中模拟确认来确保双花问题得到解决。
//实际的区块链系统可能需要更复杂的机制和智能合约来处理这类问题。


//每个交易都有一个唯一的标识符（通过 Guid.NewGuid().ToString() 生成）。
//交易被添加到交易池中，并在创建新区块时从交易池中选择。在 AddTransaction 中，
//我们检查交易池中是否已经存在具有相同标识符的交易，以防止双重支付。
//请注意，实际应用中可能需要更多的机制来确保交易的安全性和唯一性。

// 创建一个区块链实例
var blockchain = new Blockchain();

// 模拟一个有效的交易
var validTransaction = new Transaction
{
    TransactionId = Guid.NewGuid().ToString(), // 生成唯一的交易标识符
    Sender = "Alice",
    Receiver = "Bob",
    Amount = 10
};
// 将有效交易添加到交易池中
blockchain.AddTransaction(validTransaction);

// 尝试模拟双重支付
var doubleSpendTransaction = new Transaction
{
    TransactionId = Guid.NewGuid().ToString(), // 生成唯一的交易标识符
    Sender = "Alice",
    Receiver = "Charlie",
    Amount = 5
};
// 将双重支付交易添加到交易池中
blockchain.AddTransaction(doubleSpendTransaction);
blockchain.AddTransaction(doubleSpendTransaction); // 尝试进行双重支付

// 将交易打包到区块中
blockchain.AddBlock();

// 验证区块链的有效性
bool isValid = blockchain.ValidateChain();
Console.WriteLine($"区块链是否有效: {isValid}");
#endregion

#region 实现双重支付漏洞并进行验证  Blockchain_ORINGIN.txt
//// 创建一个区块链实例
//var blockchain = new Blockchain();

//// 模拟一个有效的交易
//var validTransaction = new List<Transaction>
//        {
//            new Transaction { Sender = "Alice", Receiver = "Bob", Amount = 10 }
//        };
//// 将有效交易添加到区块链中
//blockchain.AddBlock(validTransaction);

//// 尝试模拟双重支付
//var doubleSpendTransaction = new List<Transaction>
//        {
//            new Transaction { Sender = "Alice", Receiver = "Charlie", Amount = 5 },
//            new Transaction { Sender = "Alice", Receiver = "Charlie", Amount = 5 } // 双重支付
//        };
//// 将双重支付交易添加到区块链中
//blockchain.AddBlock(doubleSpendTransaction);

//// 验证区块链的有效性
//bool isValid = blockchain.ValidateChain();
//Console.WriteLine($"区块链是否有效: {isValid}");
#endregion


#region 模拟Stellar Consensus Protocol（SCP）的共识算法

////三个节点的Quorum Slice 分别是 {2, 3}、{ 1, 3}、{ 1, 2}。
////要达成共识，每个节点的Quorum Slice 中的节点都需要同意交易。
////在这个例子中，每个节点的Quorum Slice 中包含了其他两个节点，
////但是由于我们设置的多数派原则是超过一半的节点同意，所以至少需要两个节点同意。

////在模拟中，我们只有一个节点 node1 执行了 AcceptTransaction 方法，
////它的 Quorum Slice 中包含了 node2 和 node3。
////但是由于 node2 和 node3 并没有执行 AcceptTransaction 方法，
////因此它们并没有表达对交易的同意，所以 consensusReached 始终为 false。

//// 创建一些模拟节点
//StellarNode node1 = new StellarNode(1, new List<int> { 2, 3 });
//StellarNode node2 = new StellarNode(2, new List<int> { 1, 3 });
//StellarNode node3 = new StellarNode(3, new List<int> { 1, 2 });

//List<StellarNode> nodes = new List<StellarNode>
//{
//    node1,
//    node2,
//    node3
//};
//StellarNode.InitializeNodes(nodes);
//// 创建模拟交易
//Transaction transaction = new Transaction(1);

//// 模拟节点之间的交互和共识过程
////bool consensusReached = node1.AcceptTransaction(transaction);
//bool consensusReached1 = node1.AcceptTransaction(transaction);
//bool consensusReached2 = node2.AcceptTransaction(transaction);
//bool consensusReached3 = node3.AcceptTransaction(transaction);

//// 任意两个节点同意即可达成共识
//bool consensusReached = consensusReached1 || consensusReached2 || consensusReached3;

//if (consensusReached)
//{
//    Console.WriteLine("已达成共识。交易已接受。");
//}
//else
//{
//    Console.WriteLine("未达成共识。交易被拒绝。");
//}
#endregion


#region Merkle 树

//List<string> data = new List<string>
//{
//    "数据1",
//    "数据2",
//    "数据3",
//    "数据4"
//};

//MerkleTree merkleTree = new MerkleTree(data);

//Console.WriteLine("Merkle 树节点:");
//foreach (var node in merkleTree.GetNodes())
//{
//    Console.WriteLine(node);
//}

//Console.WriteLine("\nMerkle 树根:");
//Console.WriteLine(merkleTree.GetRoot());

#endregion MyRegion

#region DAG算法实例

//// 模拟并发的区块
//List<Block> concurrentBlocks1 = new List<Block>
//        {
//            new Block(new List<Transaction> { new Transaction("Tx1"), new Transaction("Tx2") }),
//            new Block(new List<Transaction> { new Transaction("Tx3"), new Transaction("Tx4") })
//        };

//List<Block> concurrentBlocks2 = new List<Block>
//        {
//            new Block(new List<Transaction> { new Transaction("Tx5"), new Transaction("Tx6") }),
//            new Block(new List<Transaction> { new Transaction("Tx7"), new Transaction("Tx8") })
//        };

//// 创建两棵树
//TreeNode tree1 = new TreeNode(concurrentBlocks1[0]);
//TreeNode tree2 = new TreeNode(concurrentBlocks2[0]);

//// 将并发的区块加入树中
//foreach (var block in concurrentBlocks1.Skip(1))
//{
//    tree1.Children.Add(new TreeNode(block));
//}

//foreach (var block in concurrentBlocks2.Skip(1))
//{
//    tree2.Children.Add(new TreeNode(block));
//}

//// 合并两棵树
//TreeNode mergedTree = DAGSimulation.MergeTree(tree1, tree2);

//// 输出合并后的树结构
//Console.WriteLine("合并后的树:");
//Console.WriteLine("根区块交易:");

//foreach (var transaction in mergedTree.Block.Transactions)
//{
//    Console.WriteLine(transaction.TransactionData);
//}

//Console.WriteLine("子区块:");

//foreach (var child in mergedTree.Children)
//{
//    Console.WriteLine("子区块交易:");
//    foreach (var transaction in child.Block.Transactions)
//    {
//        Console.WriteLine(transaction.TransactionData);
//    }
//}

#endregion DAG算法实例

#region Scrypt是一种用于密码学安全目的的哈希函数，旨在提供对抗特定类型的攻击，尤其是硬件攻击。

//// 示例1: 使用Scrypt进行密码哈希
//string password = "signking";
//string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());

//Console.WriteLine($"Password: {password}");
//Console.WriteLine($"Hashed Password: {hashedPassword}");

//// 示例2: 验证密码
//string userInputPassword = "signking";
//bool passwordMatches = BCrypt.Net.BCrypt.Verify(userInputPassword, hashedPassword);

//Console.WriteLine($"Password Matches: {passwordMatches}");

#endregion Scrypt是一种用于密码学安全目的的哈希函数，旨在提供对抗特定类型的攻击，尤其是硬件攻击。

Console.ReadKey();