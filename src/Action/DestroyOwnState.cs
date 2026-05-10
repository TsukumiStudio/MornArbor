#if USE_ARBOR
using System;
using Arbor;
using MornLib;

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
#endif
