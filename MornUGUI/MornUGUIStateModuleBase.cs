using System;

namespace MornLib
{
    [Serializable]
    internal abstract class MornUGUIStateModuleBase
    {
        public virtual void OnAwake(MornUGUIControlState parent)
        {
        }
        
        public virtual void OnStateBegin(MornUGUIControlState parent)
        {
        }

        public virtual void OnStateUpdate(MornUGUIControlState parent)
        {
        }

        public virtual void OnStateEnd(MornUGUIControlState parent)
        {
        }

        public virtual void OnEditorInitialize(MornUGUIControlState parent)
        {
        }
    }
}