using BlockChainAlgorithmProject.Common.DoublePayment;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace BlockChainAlgorithmProject.Common.DoublePayment
{
    public class Blockchain
    {
        private List<Block> chain;            // 区块链中的区块列表
        private List<Transaction> transactionPool;  // 存储待确认的交易列表

        public Blockchain()
        {
            // 初始化区块链
            InitializeBlockchain();
        }

        // 初始化区块链，创建创世区块
        private void InitializeBlockchain()
        {
            chain = new List<Block>
        {
            CreateGenesisBlock()
        };
            transactionPool = new List<Transaction>();
        }

        // 添加交易到交易池
        public void AddTransaction(Transaction transaction)
        {
            // 检查交易池中是否存在双重支付
            if (transactionPool.Any(t => t.TransactionId == transaction.TransactionId))
            {
                Console.WriteLine($"检测到交易双重支付：{transaction.TransactionId}");
                return;
            }

            // 添加交易到交易池，但标记为未确认
            transaction.IsConfirmed = false;
            transactionPool.Add(transaction);
        }

        // 创建创世区块
        private Block CreateGenesisBlock()
        {
            return new Block
            {
                Index = 0,
                Timestamp = DateTime.Now,
                Transactions = new List<Transaction>(),
                PreviousHash = "0",
                Hash = CalculateHash(0, DateTime.Now, new List<Transaction>(), "0")
            };
        }

        // 添加新区块到区块链
        public void AddBlock()
        {
            // 仅在区块中包含来自交易池的交易
            var transactions = new List<Transaction>(transactionPool);
            transactionPool.Clear();

            // 获取前一个区块
            var previousBlock = chain[chain.Count - 1];

            // 创建新区块
            var newBlock = new Block
            {
                Index = previousBlock.Index + 1,
                Timestamp = DateTime.Now,
                Transactions = transactions,
                PreviousHash = previousBlock.Hash,
                Hash = CalculateHash(previousBlock.Index + 1, DateTime.Now, transactions, previousBlock.Hash)
            };

            // 将新区块添加到区块链
            chain.Add(newBlock);

            // 模拟确认交易
            foreach (var transaction in transactions)
            {
                transaction.IsConfirmed = true;
            }
        }

        // 验证整个区块链的有效性
        public bool ValidateChain()
        {
            for (int i = 1; i < chain.Count; i++)
            {
                var currentBlock = chain[i];
                var previousBlock = chain[i - 1];

                // 检查当前区块中的每个交易是否已确认
                foreach (var transaction in currentBlock.Transactions)
                {
                    // 在验证之前检查交易是否已确认
                    if (!transaction.IsConfirmed)
                    {
                        Console.WriteLine($"无效的区块：在区块 {currentBlock.Index} 中发现未确认的交易");
                        return false;
                    }
                }

                // 检查当前区块的哈希值是否正确
                if (currentBlock.Hash != CalculateHash(currentBlock.Index, currentBlock.Timestamp, currentBlock.Transactions, previousBlock.Hash))
                {
                    Console.WriteLine("无效的区块：哈希值不匹配");
                    return false;
                }

                // 检查当前区块的PreviousHash是否与前一个区块的哈希值匹配
                if (currentBlock.PreviousHash != previousBlock.Hash)
                {
                    Console.WriteLine("无效的区块：上一个哈希值不匹配");
                    return false;
                }
            }

            return true;
        }

        // 计算区块的哈希值
        private string CalculateHash(int index, DateTime timestamp, List<Transaction> transactions, string previousHash)
        {
            var input = $"{index}-{timestamp}-{string.Join(",", transactions)}-{previousHash}";

            // 使用SHA256算法计算哈希值
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(bytes).Replace("-", "").ToLower();
            }
        }
    }
}