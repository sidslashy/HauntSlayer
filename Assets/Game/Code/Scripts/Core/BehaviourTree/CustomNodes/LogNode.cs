using UnityEngine;

namespace HauntSlayer.Core.BehaviourTree.CustomNodes
{
    public class LogNode : ActionNode
    {
        public string logMessage;
        protected override void OnStarted()
        {
            Debug.Log($"OnStarted {logMessage}");
        }

        protected override State OnUpdate()
        {
            Debug.Log($"OnUpdate {logMessage}");
            return State.Success;
        }

        protected override void OnStopped()
        {
            Debug.Log($"OnStopped {logMessage}");
        }
    }
}