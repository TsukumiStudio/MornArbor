#if USE_MORN_SAVE_KEY
using Arbor;
using UnityEngine;
using VContainer;

namespace MornLib
{
    public class MornSaveFloatState : StateBehaviour
    {
        [Inject] private IMornSaveKeyUserDataStore _save;
        [SerializeField] private MornSaveKey _saveKey;
        [SerializeField] private bool _isAdditive;
        [SerializeField] private float _value;

        public override void OnStateBegin()
        {
            var userData = _save.FloatTable.GetOrCreateUserData(_saveKey);
            if (_isAdditive)
            {
                userData.Value += _value;
            }
            else
            {
                userData.Value = _value;
            }
        }
    }
}
#endif