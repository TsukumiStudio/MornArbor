using Arbor;
using UnityEngine;

namespace MornArbor
{
    public class RegisterRollbackSceneAct : StateBehaviour
    {
        [SerializeField] private string _key;

        public override void OnStateBegin()
        {
            MornArborService.I.RegisterRollbackScene(_key, gameObject.scene);
        }
    }
}