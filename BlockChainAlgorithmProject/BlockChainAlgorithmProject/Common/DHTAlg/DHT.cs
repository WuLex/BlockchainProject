using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.DHTAlg
{
    /// <summary>
    /// 表示一个简单的分布式哈希表（DHT）。
    /// </summary>
    public class DHT
    {
        private Dictionary<string, Node> nodes = new Dictionary<string, Node>();

        /// <summary>
        /// 向DHT中添加一个节点。
        /// </summary>
        /// <param name="node">要添加的节点。</param>
        public void AddNode(Node node)
        {
            nodes[node.Id] = node;
        }

        /// <summary>
        /// 从DHT中移除指定标识符的节点。
        /// </summary>
        /// <param name="nodeId">要移除的节点的标识符。</param>
        public void RemoveNode(string nodeId)
        {
            if (nodes.ContainsKey(nodeId))
            {
                nodes.Remove(nodeId);
            }
        }

        /// <summary>
        /// 将键值对分发到DHT中的节点。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        public void DistributeData(string key, string value)
        {
            foreach (var node in nodes.Values)
            {
                if (IsResponsibleNode(key, node))
                {
                    node.Store(key, value);
                    break;
                }
            }
        }

        /// <summary>
        /// 根据键从DHT中的节点中检索数据。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>与键关联的值。</returns>
        public string RetrieveData(string key)
        {
            foreach (var node in nodes.Values)
            {
                if (IsResponsibleNode(key, node))
                {
                    return node.Retrieve(key);
                }
            }

            return null;
        }

        /// <summary>
        /// 确定哪个节点负责存储特定的键。
        /// </summary>
        /// <param name="key">要存储的键。</param>
        /// <param name="node">要检查的节点。</param>
        /// <returns>如果节点负责存储键，则为true；否则为false。</returns>
        private bool IsResponsibleNode(string key, Node node)
        {
            // 这里我们假设节点ID是整数字符串
            if (!int.TryParse(key, out int keyInt) || !int.TryParse(node.Id, out int nodeIdInt))
            {
                throw new ArgumentException("Key and node ID should be integer strings.");
            }

            // 节点负责存储键，如果它的ID最接近键
            return Math.Abs(keyInt - nodeIdInt) <= 1;
        }
    }
}
