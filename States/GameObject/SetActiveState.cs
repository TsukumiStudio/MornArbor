using Arbor;
using UnityEngine;

namespace MornArbor.States
{
    public class SetActiveState : StateBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private FlexibleField<bool> _isActive;

        public override void OnStateBegin()
        {
            _target.SetActive(_isActive.value);
        }
    }
}