using System;
using Arbor;
using MornScene;
using UnityEngine;

namespace MornArbor.States
{
    [Serializable]
    public class FlexibleMornSceneObject : FlexibleField<MornSceneObject>
    {
        public FlexibleMornSceneObject(MornSceneObject value) : base(value)
        {
        }

        public FlexibleMornSceneObject(AnyParameterReference parameter) : base(parameter)
        {
        }

        public FlexibleMornSceneObject(InputSlotAny slot) : base(slot)
        {
        }

        public static explicit operator MornSceneObject(FlexibleMornSceneObject flexible)
        {
            return flexible.value;
        }

        public static explicit operator FlexibleMornSceneObject(MornSceneObject value)
        {
            return new FlexibleMornSceneObject(value);
        }
    }

    [Serializable]
    public class InputSlotMornSceneObject : InputSlot<MornSceneObject>
    {
    }

    [Serializable]
    public class OutputSlotMornSceneObject : OutputSlot<MornSceneObject>
    {
    }

    [AddComponentMenu("")]
    public class MornSceneObjectVariable : Variable<MornSceneObject>
    {
    }
}