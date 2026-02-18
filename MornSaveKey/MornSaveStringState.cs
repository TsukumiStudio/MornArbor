#if USE_MORN_SAVE_KEY
using Arbor;
using UnityEngine;
using VContainer;

namespace MornLib
{
    public class MornSaveStringState : StateBehaviour
    {
        [Inject] private IMornSaveKeyUserDataStoreSolver _save;
        [SerializeField] private MornSaveKey _saveKey;
        [SerializeField] private string _value;

        public override void OnStateBegin()
        {
            var userData = _save.Solve().StringTable.GetOrCreateUserData(_saveKey);
            userData.Value = _value;
        }
    }
}
#endif