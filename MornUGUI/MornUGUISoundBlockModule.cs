using System;
using UnityEngine;

namespace MornLib
{
    [Serializable]
    internal class MornUGUISoundBlockModule : MornUGUIStateModuleBase
    {
        [SerializeField] private bool _ignore;
        [SerializeField] [ReadOnly] private int _leftFrame;

        public override void OnStateBegin(MornUGUIControlState parent)
        {
            if (_ignore)
            {
                return;
            }

            var blockFrame = MornUGUIGlobal.I.BlockFrame;
            if (blockFrame > 0)
            {
                _leftFrame = blockFrame;
                MornUGUIService.I.BlockOn();
            }
        }

        public override void OnStateUpdate(MornUGUIControlState parent)
        {
            if (_ignore)
            {
                return;
            }

            if (_leftFrame > 0)
            {
                _leftFrame--;
                if (_leftFrame == 0)
                {
                    MornUGUIService.I.BlockOff();
                }
            }
        }

        public override void OnStateEnd(MornUGUIControlState parent)
        {
            if (_ignore)
            {
                return;
            }

            MornUGUIService.I.BlockOff();
        }
    }
}