using MornLib;

namespace MornLib
{
#if USE_MORNSTATE
    internal class DestroyOwnState : MornStateBehaviour
#else
    internal class DestroyOwnState : StateBehaviour
#endif
    {
        public override void OnStateBegin()
        {
            Destroy(gameObject);
        }
    }
}