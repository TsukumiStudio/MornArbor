using System;
using System.Collections.Generic;
using Arbor;
using UnityEngine;

namespace MornArbor
{
    public class SubState : StateBehaviour , ISubStateCallback
    {
        [SerializeField] private GameObject subModule;
        [SerializeField] private List<StateNameAndStateLinkSet> stateNameAndStateLinkSetList;

        [Serializable]
        public struct StateNameAndStateLinkSet
        {
            public string StateName;
            public StateLink StateLink;
        }
        
        private StateExitTrigger stateExitTrigger;

        public override void OnStateBegin()
        {
            var instance = Instantiate(subModule, transform);
            stateExitTrigger = instance.AddComponent<StateExitTrigger>();
            stateExitTrigger.AddCallback(this);
        }

        public override void OnStateEnd()
        {
            stateExitTrigger.RemoveCallback(this);
        }

        void ISubStateCallback.Exit(string exitFlagName)
        {
            foreach (var stateLinkInfo in stateNameAndStateLinkSetList)
            {
                if (stateLinkInfo.StateName == exitFlagName)
                {
                    Transition(stateLinkInfo.StateLink);
                    return;
                }
            }
        }
    }
}