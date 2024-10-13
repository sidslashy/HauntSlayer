using UnityEditor;
using UnityEngine;

namespace HauntSlayer.Editor.BehaviourTree
{
    [CustomEditor(typeof(Core.BehaviourTree.BehaviourTree))]
    public class BehaviourTreeAssetEditor : UnityEditor.Editor
    {
        
        private void OnEnable()
        {
            // // Check if the selected object is a CustomData instance
            // CustomData data = (CustomData)target;
            //
            // // Open the custom editor window
            // CustomDataEditorWindow.Open(data);
            
            BehaviourTreeEditor.Open((Core.BehaviourTree.BehaviourTree)target);
        }
        
        public override void OnInspectorGUI()
        {
            
            base.OnInspectorGUI();
            
            // if (GUILayout.Button("Open"))
            // {
            //     BehaviourTreeEditor.Open((Core.BehaviourTree.BehaviourTree)target);
            // }
        }
    }
}