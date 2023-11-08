using Arbor;
using Cinemachine;
using UnityEngine;

namespace MornArbor.States
{
    public sealed class CinemachineEnablerState : StateBehaviour
    {
        [SerializeField] private FlexibleField<CinemachineVirtualCamera> _camera;
        [SerializeField] private FlexibleField<bool> _isActive;

        public override void OnStateBegin()
        {
            _camera.value.enabled = _isActive.value;
        }
    }
}