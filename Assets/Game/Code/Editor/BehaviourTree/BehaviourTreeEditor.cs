using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UIElements;

namespace HauntSlayer.Editor.BehaviourTree
{
    public class BehaviourTreeEditor : EditorWindow
    {
        [SerializeField] private VisualTreeAsset m_VisualTreeAsset = default;

        private static bool _isOpenTriggered;
        
        public BehaviourTreeView treeView;
        public InspectorView inspectorView;

        [MenuItem("Behaviour Tree/Editor")]
        public static void OpenWindow()
        {
            BehaviourTreeEditor wnd = GetWindow<BehaviourTreeEditor>();
            wnd.titleContent = new GUIContent("Behaviour Tree Editor");
        }

        private void OnEnable()
        {
            // Auto close window incase editor reopens, this is to prevent blank graph editor window from opening.
            if (!_isOpenTriggered)
            {
                Close();
            }
        }

        public static void Open(Core.BehaviourTree.BehaviourTree target)
        {
            if (!target)
                return;
            
            _isOpenTriggered = true;
            
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
            
            treeView = root.Q<BehaviourTreeView>();
            inspectorView = root.Q<InspectorView>();
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
            treeView.PopulateView(target);
        }
    }
}