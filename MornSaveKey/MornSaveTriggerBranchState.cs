#if USE_MORN_SAVE_KEY
using Arbor;
using UnityEngine;
using VContainer;

namespace MornLib
{
    public class MornSaveTriggerBranchState : StateBehaviour
    {
        [Inject] private IMornSaveKeyUserDataStore _save;
        [SerializeField] private MornSaveKey _saveKey;
        [SerializeField] private StateLink _successState;
        [SerializeField] private StateLink _failedState;

        public override void OnStateBegin()
        {
            var hasUserData = _save.TriggerTable.Contains(_saveKey);
            Transition(hasUserData ? _successState : _failedState);
        }
    }
}
#endif