﻿using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HauntSlayer.Core.BehaviourTree
{
    [CreateAssetMenu(menuName = "BehaviourTree", fileName = "BT_")]
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
            BTNode node = ScriptableObject.CreateInstance(type) as BTNode;
            node.name = type.Name;
            node.guid = GUID.Generate().ToString();
            nodes.Add(node);
            
            AssetDatabase.AddObjectToAsset(node, this);
            AssetDatabase.SaveAssets();
            return node;
        }

        public void DeleteNode(BTNode node)
        {
            nodes.Remove(node);
            AssetDatabase.RemoveObjectFromAsset(node);
            AssetDatabase.SaveAssets();

        }
    }
}