using System;

namespace HauntSlayer.Core.BehaviourTree.CustomNodes
{
    public class SequencerNode : CompositeNode
    {
        private int _currentIndex;
        protected override void OnStarted()
        {
            _currentIndex = 0;
        }

        protected override State OnUpdate()
        {
            var childNode = children[_currentIndex];

            switch (childNode.Update())
            {
                case State.Running:
                    return State.Running;
                case State.Success:
                    _currentIndex++;
                    break;
                case State.Failure:
                    return State.Failure;
            }

            return _currentIndex == children.Count ? State.Success : State.Running;
        }

        protected override void OnStopped()
        {
        }
    }
}