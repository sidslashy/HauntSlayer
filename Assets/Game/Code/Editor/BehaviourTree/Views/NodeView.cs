using HauntSlayer.Core.BehaviourTree;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace HauntSlayer.Editor.BehaviourTree
{
    public class NodeView : Node
    {
        public BTNode node;

        public NodeView(BTNode node)
        {
            this.node = node;
            title = node.name;
            viewDataKey = node.guid;

            style.left = node.position.x;
            style.top = node.position.y;
        }

        public override void SetPosition(Rect newPos)
        {
            node.position.x = newPos.xMin;
            node.position.y = newPos.yMin;
            base.SetPosition(newPos);
            EditorUtility.SetDirty(node);
        }
    }
}