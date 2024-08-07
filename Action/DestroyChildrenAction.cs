using Arbor;
using UnityEngine;

namespace MornArbor.Action
{
    public class DestroyChildrenAction : StateBehaviour
    {
        [SerializeField] private Transform _parent;

        public override void OnStateBegin()
        {
            for (var i = _parent.childCount - 1; i >= 0; i--)
            {
                Destroy(_parent.GetChild(i).gameObject);
            }
        }
    }
}