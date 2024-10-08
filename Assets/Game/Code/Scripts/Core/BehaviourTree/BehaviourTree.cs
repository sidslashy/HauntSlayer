using UnityEngine;

namespace HauntSlayer.Core.BehaviourTree
{
    [CreateAssetMenu(menuName = "BehaviourTree", fileName = "BT_")]
    public class BehaviourTree : ScriptableObject
    {
        public BTNode rootNode;
        public BTNode.State treeState = BTNode.State.Running;

        public BTNode.State Update()
        {
            if (rootNode.state == BTNode.State.Running)
            {
                treeState = rootNode.Update();
            }
            
            return treeState;
        }
    }
}