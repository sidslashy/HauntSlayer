using UnityEngine.UIElements;

namespace HauntSlayer.Editor.BehaviourTree
{
    public class SplitView : TwoPaneSplitView
    {
        public new class UxmlFactory : UxmlFactory<SplitView, UxmlTraits> { }
    }
}