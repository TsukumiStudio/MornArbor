using Arbor;
using MornSound;
using UnityEngine;
using VContainer;

namespace MornArbor
{
    public class PlaySeState : StateBehaviour
    {
        [Inject] private MornSoundCore soundCore;
        [SerializeField] private MornSoundDataSo se;
        
        public override void OnStateBegin()
        {
            soundCore.PlaySe(se);
        }
    }
}