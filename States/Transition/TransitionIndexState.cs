using Arbor;
using UnityEngine;

namespace MornArbor.States
{
    public sealed class TransitionIndexState : StateBehaviour
    {
        [SerializeField] private FlexibleField<int> _index;
        [SerializeField] private StateLink[] _nextLinks;

        public override void OnStateBegin()
        {
            var index = Mathf.Clamp(_index.value, 0, _nextLinks.Length);
            Transition(_nextLinks[index]);
        }
    }
}