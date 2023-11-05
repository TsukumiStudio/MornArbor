using Arbor;
using UnityEngine;

namespace MornArbor.States
{
    public class ActivateState : StateBehaviour
    {
        [SerializeField] private GameObject _target;

        public override void OnStateBegin()
        {
            _target.SetActive(true);
        }

        public override void OnStateEnd()
        {
            _target.SetActive(false);
        }
    }
}