using System;
﻿using MornLib;

namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    internal class DestroyOwnState : MornStateBehaviour
#else
    [Serializable]
    internal class DestroyOwnState : StateBehaviour
#endif
    {
        public override void OnStateBegin()
        {
            Destroy(gameObject);
        }
    }
}