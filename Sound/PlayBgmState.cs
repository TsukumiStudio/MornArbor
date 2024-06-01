using Arbor;
using MornSound;
using UnityEngine;
using VContainer;

namespace MornArbor
{
    public class PlayBgmState : StateBehaviour
    {
        [Inject] private MornSoundCore soundCore;
        [SerializeField] private MornSoundDataSo bgm;
        
        public override void OnStateBegin()
        {
            soundCore.PlayBgm(bgm);
        }
    }
}