using UnityEngine;

namespace HauntSlayer.Core.BehaviourTree.CustomNodes
{
    public class WaitNode : ActionNode
    {
        public float waitTime = 1f;
        private float _startTime;
        
        protected override void OnStarted()
        {
            _startTime = Time.time;
        }

        protected override State OnUpdate()
        {
            return Time.time - _startTime >= waitTime ? State.Success : State.Running;
        }

        protected override void OnStopped()
        {
            
        }
    }
}