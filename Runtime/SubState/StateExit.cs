using Arbor;
using UnityEngine;

namespace MornArbor
{
    public class StateExit : StateBehaviour
    {
        [SerializeField] private string exitFlagName;
        public string ExitFlagName => exitFlagName;

        public override void OnStateBegin()
        {
            var stateExitTrigger = GetComponent<StateExitTrigger>();
            stateExitTrigger.Exit(exitFlagName);
        }
    }
}