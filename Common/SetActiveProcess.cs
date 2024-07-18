using Arbor;
using UnityEngine;

namespace MornArbor
{
    public class SetActiveProcess : StateBehaviour, IProcessState
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private bool _isActive;
        public bool IsActive => _target.activeSelf != _isActive;

        public override void OnStateBegin()
        {
            _target.SetActive(_isActive);
        }
    }
}