using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace HauntSlayer.Editor.BehaviourTree
{
    public class BehaviourTreeEditor : EditorWindow
    {
        [SerializeField] private VisualTreeAsset m_VisualTreeAsset = default;

        public BehaviourTreeView treeView;
        public InspectorView inspectorView;

        [MenuItem("Behaviour Tree/Editor")]
        public static void OpenWindow()
        {
            BehaviourTreeEditor wnd = GetWindow<BehaviourTreeEditor>();
            wnd.titleContent = new GUIContent("Behaviour Tree Editor");
        }
        
        
        public static void Open(Core.BehaviourTree.BehaviourTree target)
        {
            // Check if window already open
            if (FocusOpenWindow(target))
            {
                return;
            }
            
            BehaviourTreeEditor window =
                CreateWindow<BehaviourTreeEditor>(typeof(BehaviourTreeEditor), typeof(SceneView));
            window.titleContent = new GUIContent($"{target.name}",
                EditorGUIUtility.GetIconForObject(target));
            window.Load(target);
        }

        public void CreateGUI()
        {
            // Each editor window contains a root VisualElement object
            VisualElement root = rootVisualElement;

            // Instantiate UXML
            m_VisualTreeAsset.CloneTree(root);
        }

        private void OnSelectionChange()
        {
            Core.BehaviourTree.BehaviourTree tree = Selection.activeObject as Core.BehaviourTree.BehaviourTree;
            if (tree)
            {
                FocusOpenWindow(tree);
            }
        }

        private static bool FocusOpenWindow(Core.BehaviourTree.BehaviourTree tree)
        {
            var windows = Resources.FindObjectsOfTypeAll<BehaviourTreeEditor>();
            foreach (var w in windows)
            {
                if (w.treeView.tree == tree)
                {
                    w.Focus();
                    return true;
                }
            }

            return false;
        }


        private void Load(Core.BehaviourTree.BehaviourTree target)
        {
            VisualElement root = rootVisualElement;
            
            treeView = root.Q<BehaviourTreeView>();
            inspectorView = root.Q<InspectorView>();
            
            treeView.PopulateView(target);
        }
    }
}