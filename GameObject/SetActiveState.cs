using Arbor;
using UnityEngine;

namespace MornArbor.States
{
    public class SetActiveState : StateBehaviour
    {
        [SerializeField] private FlexibleField<GameObject> _target;
        [SerializeField] private FlexibleField<bool> _isActive;

        public override void OnStateBegin()
        {
            _target.value.SetActive(_isActive.value);
        }
    }
}