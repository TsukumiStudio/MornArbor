using Arbor;
using System;
﻿using MornLib;

namespace MornLib
{
    [Serializable]
    internal class DestroyOwnState : StateBehaviour
    {
        public override void OnStateBegin()
        {
            Destroy(gameObject);
        }
    }
}