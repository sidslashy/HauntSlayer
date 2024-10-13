using System;
using HauntSlayer.Core.BehaviourTree;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace HauntSlayer.Editor.BehaviourTree
{
    public class BehaviourTreeView : GraphView
    {
        public new class UxmlFactory : UxmlFactory<BehaviourTreeView, UxmlTraits> { }

        public Core.BehaviourTree.BehaviourTree tree;
        public BehaviourTreeView()
        {
            Insert(0,new GridBackground());
            
            this.AddManipulator(new ContentZoomer());
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            
            
            var styleSheet =
                AssetDatabase.LoadAssetAtPath<StyleSheet>(
                    "Assets/Game/Code/Editor/BehaviourTree/BehaviourTreeEditor.uss");
            styleSheets.Add(styleSheet);
        }

        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            base.BuildContextualMenu(evt);
            {
                var types = TypeCache.GetTypesDerivedFrom<ActionNode>();
                foreach (var type in types)
                {
                    evt.menu.AppendAction($"[{type.BaseType.Name}] {type.Name}", (a) =>  CreateNode(type));
                }
            }
            
            {
                var types = TypeCache.GetTypesDerivedFrom<CompositeNode>();
                foreach (var type in types)
                {
                    evt.menu.AppendAction($"[{type.BaseType.Name}] {type.Name}", (a) =>  CreateNode(type));
                }
            }
            
            {
                var types = TypeCache.GetTypesDerivedFrom<DecoratorNode>();
                foreach (var type in types)
                {
                    evt.menu.AppendAction($"[{type.BaseType.Name}] {type.Name}", (a) =>  CreateNode(type));
                }
            }
          
        }
        
        public void PopulateView(Core.BehaviourTree.BehaviourTree tree)
        {
            this.tree = tree;

            graphViewChanged -= OnGraphViewChanged;
            graphViewChanged += OnGraphViewChanged;
  
            tree.nodes.ForEach(CreateNodeView);

            
        }

        private GraphViewChange OnGraphViewChanged(GraphViewChange graphChanges)
        {
            // from Unity's side
            focusable = true; 
            Focus();
            
            if (graphChanges.elementsToRemove != null)
            {
                graphChanges.elementsToRemove.ForEach(elem =>
                {
                    NodeView nodeView = elem as NodeView;
                    if (nodeView != null)
                    {
                        tree.DeleteNode(nodeView.node);
                    }
                });
            }
            
            return graphChanges;
        }

        private void CreateNode(Type type)
        {
            BTNode node = tree.CreateNode(type);
            CreateNodeView(node);
        }

        private void CreateNodeView(BTNode node)
        {
            var nodeView = new NodeView(node);
            AddElement(nodeView);
        }
    }
}