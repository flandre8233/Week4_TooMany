using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ControllerEnum
{
    DpadUp,
    DpadDown,
    DpadLeft,
    DpadRight,
    X, Y, A, B,
    LeftStick,
    RightStick,
    LeftShoulder,
    LeftTrigger,
    RightTrigger
}

public class ControllerIconBase : SingletonMonoBehavior<ControllerIconBase>
{
    [SerializeField] Sprite[] IconBase;

    public Sprite GetSprite(ControllerEnum Enum)
    {
        return IconBase[(int)Enum];
    }

}
