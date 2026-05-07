#if USE_ARBOR
using Arbor;
namespace MornLib
{
    [Serializable]
    internal class QuitState : StateBehaviour
    {
        public override void OnStateBegin()
        {
            MornApp.Quit();
        }
    }
}
#endif
