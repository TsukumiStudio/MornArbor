using Arbor;

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