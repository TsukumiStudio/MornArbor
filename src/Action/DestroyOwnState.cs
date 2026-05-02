using MornLib;

namespace MornLib
{
    internal class DestroyOwnState : StateBehaviour
    {
        public override void OnStateBegin()
        {
            Destroy(gameObject);
        }
    }
}