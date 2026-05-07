#if USE_MORNSTATE
using MornLib;
using System;
#else
using Arbor;
#endif
namespace MornLib
{
#if USE_MORNSTATE
    [Serializable]
    internal class QuitState : MornStateBehaviour
#else
    [Serializable]
    internal class QuitState : StateBehaviour
#endif
    {
        public override void OnStateBegin()
        {
            MornApp.Quit();
        }
    }
}