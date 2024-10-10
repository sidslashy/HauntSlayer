using System.Collections.Generic;
using HauntSlayer.Core.BehaviourTree;
using HauntSlayer.Core.BehaviourTree.CustomNodes;
using UnityEngine;

namespace Game.Code.Scripts.Temp
{
    public class BehaviourTreeRunner : MonoBehaviour
    {
        public BehaviourTree bt;

        void Start()
        {
            bt = ScriptableObject.CreateInstance<BehaviourTree>();

            var log = ScriptableObject.CreateInstance<LogNode>();
            log.logMessage = "Hello BT :D ";
            var log1Wait = ScriptableObject.CreateInstance<WaitNode>();
            
            var log2 = ScriptableObject.CreateInstance<LogNode>();
            log2.logMessage = "MSG 2 ";
            var log2Wait = ScriptableObject.CreateInstance<WaitNode>();
            
            var sequencer = ScriptableObject.CreateInstance<SequencerNode>();
            sequencer.children = new List<BTNode> {log,log1Wait,log2,log2Wait};
            
            var repeat = ScriptableObject.CreateInstance<RepeatNode>();
            repeat.child = sequencer;
            repeat.isEndless = true;

            bt.rootNode = repeat;
        }

        void Update()
        {
            bt.Update();
        }

    }
}