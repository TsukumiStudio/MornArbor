using Arbor;
using UnityEngine;

namespace MornLib
{
    internal class SetActiveByIndexState : StateBehaviour
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private int _activeIndex;

        public override void OnStateBegin()
        {
            for (var i = 0; i < _parent.childCount; i++)
            {
                _parent.GetChild(i).gameObject.SetActive(i == _activeIndex);
            }
        }
    }
}