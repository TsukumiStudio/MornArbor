#if USE_MORNSTATE
using MornLib;
using StateLink = MornLib.Connection;
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
    internal class SetSpriteState : MornStateBehaviour
#else
    [Serializable]
    internal class SetSpriteState : StateBehaviour
#endif
    {
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private StateLink _nextState;
        
        public override void OnStateBegin()
        {
            if (_renderer != null && _sprites.Length > 0)
            {
                var index = Random.Range(0, _sprites.Length);
                _renderer.sprite = _sprites[index];
            }
            Transition(_nextState);
        }
    }
}