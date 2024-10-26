#if USE_MORN_BEAT
using Arbor;
using UnityEngine;
using VContainer;

namespace MornBeat
{
    public class MornBeatPlayAction : StateBehaviour
    {
        [SerializeField] private MornBeatMemoSo _beatMemo;
        [Inject] private MornBeatControllerMono _beatController;

        public override void OnStateBegin()
        {
            _beatController.InitializeBeat(_beatMemo);
        }
    }
}
#endif