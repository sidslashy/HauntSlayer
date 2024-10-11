using System;
using HauntSlayer.Core.BehaviourTree;
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


        // TODO: Figure out why is the class being imported like this.
        public void PopulateView(Core.BehaviourTree.BehaviourTree tree)
        {
            this.tree = tree;

            graphViewChanged -= OnGraphViewChanged;
            DeleteElements(graphElements);
            graphViewChanged += OnGraphViewChanged;
  
            tree.nodes.ForEach(n => CreateNodeView(n));

            
        }

        private GraphViewChange OnGraphViewChanged(GraphViewChange graphviewchange)
        {
            if (graphviewchange.elementsToRemove != null)
            {
                graphviewchange.elementsToRemove.ForEach(elem =>
                {
                    NodeView nodeView = elem as NodeView;
                    if (nodeView != null)
                    {
                        tree.DeleteNode(nodeView.node);
                    }
                });
                
            }

            return graphviewchange;
        }

        public void CreateNode(Type type)
        {
            BTNode node = tree.CreateNode(type);
            CreateNodeView(node);
        }

        public void CreateNodeView(BTNode node)
        {
            var nodeView = new NodeView(node);
            AddElement(nodeView);
        }
    }
}