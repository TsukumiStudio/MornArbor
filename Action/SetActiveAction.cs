using Arbor;
using UnityEngine;

namespace MornArbor.Action
{
    public class SetActiveAction : StateBehaviour
    {
        [SerializeField] private GameObject _target;
        [SerializeField] private bool _isActive;

        public override void OnStateBegin()
        {
            _target.SetActive(_isActive);
        }
    }
}