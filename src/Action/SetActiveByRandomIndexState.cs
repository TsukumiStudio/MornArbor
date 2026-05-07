#if USE_MORNSTATE
using MornLib;
using System;
#else
using Arbor;
#endif
using UnityEngine;
using Random = UnityEngine.Random;

namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    internal class SetActiveByRandomIndexState : MornStateBehaviour
#else
    [Serializable]
    internal class SetActiveByRandomIndexState : StateBehaviour
#endif
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private Vector2Int _range;

        public override void OnStateBegin()
        {
            var activeIndex = Random.Range(_range.x, _range.y + 1);
            for (var i = 0; i < _parent.childCount; i++)
            {
                _parent.GetChild(i).gameObject.SetActive(i == activeIndex);
            }
        }
    }
}
