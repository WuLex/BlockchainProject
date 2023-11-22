using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChainAlgorithmProject.Common.DAGAlg
{
    public class TreeNode
    {
        public Block Block { get; set; }
        public List<TreeNode> Children { get; set; }

        public TreeNode(Block block)
        {
            Block = block;
            Children = new List<TreeNode>();
        }
    }

}
