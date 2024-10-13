using UnityEditor;
using UnityEditor.Callbacks;

namespace HauntSlayer.Editor.BehaviourTree
{
    [CustomEditor(typeof(Core.BehaviourTree.BehaviourTree))]
    public class BehaviourTreeAssetEditor : UnityEditor.Editor
    {
        // Add double click to open asset from SO
        [OnOpenAsset(1)]
        public static bool OnOpenAsset(int instanceID, int line)
        {
            // Get the object being opened
            var obj = EditorUtility.InstanceIDToObject(instanceID);
            if (obj is Core.BehaviourTree.BehaviourTree customData)
            {
                // Open the custom editor window
                BehaviourTreeEditor.Open(customData);
                return true; // Return true to prevent default behavior
            }

            return false; // Return false to allow default behavior for other assets
        }
    }
}