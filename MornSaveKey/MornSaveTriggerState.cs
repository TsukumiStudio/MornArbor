#if USE_MORN_SAVE_KEY
using Arbor;
using UnityEngine;
using VContainer;

namespace MornLib
{
    public class MornSaveTriggerState : StateBehaviour
    {
        [Inject] private IMornSaveKeyUserDataStore _save;
        [SerializeField] private MornSaveKey _saveKey;

        public override void OnStateBegin()
        {
            _save.TriggerTable.GetOrCreateUserData(_saveKey);
        }
    }
}
#endif