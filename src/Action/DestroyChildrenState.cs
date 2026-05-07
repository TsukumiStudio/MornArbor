using Arbor;
﻿using MornLib;
using UnityEngine;
using System;

namespace MornLib
{
    [Serializable]
    internal class DestroyChildrenState : StateBehaviour
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