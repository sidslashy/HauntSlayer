using UnityEditor;
using UnityEngine;

namespace HauntSlayer.Editor.BehaviourTree
{
    [CustomEditor(typeof(Core.BehaviourTree.BehaviourTree))]
    public class BehaviourTreeAssetEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            
            base.OnInspectorGUI();
            
            if (GUILayout.Button("Open"))
            {
                BehaviourTreeEditor.Open((Core.BehaviourTree.BehaviourTree)target);
            }
        }
    }
}