using HauntSlayer.Core.BehaviourTree;
using UnityEditor.Experimental.GraphView;

namespace HauntSlayer.Editor.BehaviourTree
{
    public class NodeView : Node
    {
        public BTNode node;

        public NodeView(BTNode node)
        {
            this.node = node;
            title = node.name;
        }
    }
}