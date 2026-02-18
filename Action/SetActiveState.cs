using Arbor;
using UnityEngine;

namespace MornLib
{
    internal class SetActiveState : StateBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private bool _isActive;

        public override void OnStateBegin()
        {
            _target.SetActive(_isActive);
        }
    }
}