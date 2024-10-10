using Unity.VisualScripting;
using UnityEngine;

namespace HauntSlayer.Core.BehaviourTree
{
    public abstract class BTNode : ScriptableObject
    {
        public enum State
        {
            Running,
            Success,
            Failure
        }

        public string guid;

        public State state = State.Running;
        
        protected bool hasStarted = false;

        public State Update()
        {
            if (!hasStarted)
            {
                hasStarted = true;
                OnStarted();
            }

            state = OnUpdate();

            if (state == State.Success || state == State.Failure)
            {
                hasStarted = false;
                OnStopped();
            }
            
            return state;
        }

        protected abstract void OnStarted();
        protected abstract State OnUpdate();
        protected abstract void OnStopped();


    }
}