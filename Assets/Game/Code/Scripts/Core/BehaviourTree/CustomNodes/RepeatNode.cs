using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace HauntSlayer.Core.BehaviourTree.CustomNodes
{
    public class RepeatNode : DecoratorNode
    {
        public bool isEndless;
        
        public int repeatCount = 1;

        private int currentCount;
        
        protected override void OnStarted()
        {
            currentCount = 0;
        }

        protected override State OnUpdate()
        {

            if (isEndless)
            {
                child.Update();
                return State.Running;
            }

            if (currentCount < repeatCount)
            {
                child.Update();
                currentCount++;
                return State.Running;
            }

            return State.Success;
            
        }

        protected override void OnStopped()
        {
            
        }
    }
}