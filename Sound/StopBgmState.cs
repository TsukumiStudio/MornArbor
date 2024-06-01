using Arbor;
using MornSound;
using UnityEngine;
using VContainer;

namespace MornArbor
{
    public class StopBgmState : StateBehaviour
    {
        [Inject] private MornSoundCore soundCore;
        [SerializeField] private StateLink stateLink;

        public override void OnStateBegin()
        {
            soundCore.StopBgm();
            Transition(stateLink);
        }
    }
}