using Arbor;
using UnityEngine;

namespace MornArbor
{
    public class DestroyChildrenState : StateBehaviour
    {
        [SerializeField] private FlexibleField<Transform> _parent;

        public override void OnStateBegin()
        {
            for (var i = _parent.value.childCount - 1; i >= 0; i--) Destroy(_parent.value.GetChild(i).gameObject);
        }
    }
}