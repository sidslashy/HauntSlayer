using HauntSlayer.Core.BehaviourTree;
using HauntSlayer.Editor.BehaviourTree;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class BehaviourTreeEditor : EditorWindow
{
    [SerializeField] private VisualTreeAsset m_VisualTreeAsset = default;

    private BehaviourTreeView _treeView;
    private InspectorView _inspectorView;

    [MenuItem("Behaviour Tree/Editor")]
    public static void OpenWindow()
    {
        BehaviourTreeEditor wnd = GetWindow<BehaviourTreeEditor>();
        wnd.titleContent = new GUIContent("Behaviour Tree Editor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // Instantiate UXML
        m_VisualTreeAsset.CloneTree(root);

        _treeView = root.Q<BehaviourTreeView>();
        _inspectorView = root.Q<InspectorView>();
    }

    private void OnSelectionChange()
    {
        BehaviourTree tree = Selection.activeObject as BehaviourTree;
        if (tree)
        {
            _treeView.PopulateView(tree);
        }
    }
}