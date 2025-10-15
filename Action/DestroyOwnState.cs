using Arbor;

namespace MornArbor
{
    public class DestroyOwnState : StateBehaviour
    {
        public override void OnStateBegin()
        {
            Destroy(gameObject);
        }
    }
}