using System.Collections.Generic;

namespace HauntSlayer.Core.BehaviourTree
{
    public abstract class CompositeNode : BTNode
    {
        public List<BTNode> children = new();
    }
}