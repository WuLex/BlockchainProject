using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.DHTAlg
{
    /// <summary>
    /// 表示一个节点的类。
    /// </summary>
    public class Node
    {
        /// <summary>
        /// 节点的唯一标识符。
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// 存储键值对的字典。
        /// </summary>
        public Dictionary<string, string> Data { get; private set; }

        /// <summary>
        /// 路由表，用于存储其他节点的信息。
        /// </summary>
        public Dictionary<string, Node> RoutingTable { get; private set; }

        /// <summary>
        /// 创建一个新的节点。
        /// </summary>
        /// <param name="id">节点的唯一标识符。</param>
        public Node(string id)
        {
            Id = id;
            Data = new Dictionary<string, string>();
            RoutingTable = new Dictionary<string, Node>();
        }

        /// <summary>
        /// 将键值对存储到节点的数据中。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        public void Store(string key, string value)
        {
            Data[key] = value;
        }

        /// <summary>
        /// 根据键检索节点中的值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>与键关联的值。</returns>
        public string Retrieve(string key)
        {
            if (Data.ContainsKey(key))
            {
                return Data[key];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 将其他节点添加到路由表中。
        /// </summary>
        /// <param name="nodeId">其他节点的标识符。</param>
        /// <param name="node">其他节点的实例。</param>
        public void AddToRoutingTable(string nodeId, Node node)
        {
            RoutingTable[nodeId] = node;
        }
    }
}
