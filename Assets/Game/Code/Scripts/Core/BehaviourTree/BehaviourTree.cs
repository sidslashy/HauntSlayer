using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HauntSlayer.Core.BehaviourTree
{
    [CreateAssetMenu(menuName = "Behaviour Tree", fileName = "BT_")]
    public class BehaviourTree : ScriptableObject
    {
        public BTNode rootNode;
        public BTNode.State treeState = BTNode.State.Running;
        public List<BTNode> nodes;

        public BTNode.State Update()
        {
            if (rootNode.state == BTNode.State.Running)
            {
                treeState = rootNode.Update();
            }
            
            return treeState;
        }

        public BTNode CreateNode(System.Type type)
        {
            var node = CreateInstance(type) as BTNode;
            //if (node == null) return null;
            node.name = type.Name;
            node.guid = GUID.Generate().ToString();
            nodes.Add(node);

            AssetDatabase.AddObjectToAsset(node, this);
            AssetDatabase.SaveAssets();
            return node;
            
            
            // else{             BehaviourTreeSO newtree = ScriptableObject.CreateInstance("BehaviourTreeSO") as BehaviourTreeSO;
            //     string path = $"Assets/DEBUGTREE.asset";
            //     AssetDatabase.CreateAsset(newtree, path);
            //     // AssetDatabase.AddObjectToAsset(newtree, newtree);
            //     AssetDatabase.Refresh();
            //     EditorUtility.SetDirty(newtree);
            //     AssetDatabase.SaveAssets();
            //     tree = newtree;   } 

        }

        public void DeleteNode(BTNode node)
        {
            nodes.Remove(node);
            AssetDatabase.RemoveObjectFromAsset(node);
            AssetDatabase.SaveAssets();

        }
        
        
        
    }
}