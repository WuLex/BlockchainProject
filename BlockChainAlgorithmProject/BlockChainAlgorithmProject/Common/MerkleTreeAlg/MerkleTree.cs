using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.MerkleTreeAlg
{
    /// <summary>
    /// Merkle树实现
    /// </summary>
    public class MerkleTree
    {
        private List<string> leaves; // 叶子节点列表，即原始数据列表
        private List<string> nodes; // 所有节点列表，包括叶子节点和中间节点

        /// <summary>
        /// 构造函数，初始化Merkle树
        /// </summary>
        /// <param name="data">原始数据列表</param>
        public MerkleTree(List<string> data)
        {
            leaves = data;
            nodes = new List<string>();

            BuildTree(); // 构建Merkle树
        }

        /// <summary>
        /// 构建Merkle树
        /// </summary>
        private void BuildTree()
        {
            while (leaves.Count > 1)
            {
                List<string> newLevel = new List<string>();

                // 逐对组合叶子节点，并计算哈希值
                for (int i = 0; i < leaves.Count; i += 2)
                {
                    string left = leaves[i];
                    string right = (i + 1 < leaves.Count) ? leaves[i + 1] : "";
                    string combined = CombineAndHash(left, right);

                    newLevel.Add(combined);
                    nodes.Add(combined);
                }

                leaves = newLevel;
            }
        }

        /// <summary>
        /// 组合两个字符串并计算哈希值
        /// </summary>
        /// <param name="left">左侧字符串</param>
        /// <param name="right">右侧字符串</param>
        /// <returns>合并后的哈希值</returns>
        private string CombineAndHash(string left, string right)
        {
            string combined = left + right;
            byte[] combinedBytes = Encoding.UTF8.GetBytes(combined);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(combinedBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// 获取Merkle树的根节点
        /// </summary>
        /// <returns>根节点的哈希值</returns>
        public string GetRoot()
        {
            return leaves[0];
        }

        /// <summary>
        /// 获取Merkle树的所有节点（包括叶子节点和中间节点）
        /// </summary>
        /// <returns>所有节点的哈希值列表</returns>
        public List<string> GetNodes()
        {
            return nodes;
        }
    }
}
