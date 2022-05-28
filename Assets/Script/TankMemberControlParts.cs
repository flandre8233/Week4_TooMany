using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;
public class TankMemberControlParts : MonoBehaviour
{
    public bool IsOne;
    [SerializeField] protected TankMember ControlBy;
    protected Gamepad TargetGamePad{
        get{
           return TankInputMember.instance.GetGamepad(ControlBy, IsOne);
        }
    }

    protected bool TryGetGamePad()
    {
        return (TargetGamePad != null);
    }
}
