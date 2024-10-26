#if USE_MORN_BEAT
using Arbor;
using VContainer;

namespace MornBeat
{
    public class MornBeatStopAction : StateBehaviour
    {
        [Inject] private MornBeatControllerMono _beatController;

        public override void OnStateBegin()
        {
            _beatController.ResetBeat();
        }
    }
}
#endif