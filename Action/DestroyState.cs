using Arbor;
using UnityEngine;

namespace MornArbor
{
    public class DestroyState : StateBehaviour
    {
        [SerializeField] private GameObject _target;

        public override void OnStateBegin()
        {
            if (_target == null)
            {
                return;
            }

            Destroy(_target);
        }
    }
}