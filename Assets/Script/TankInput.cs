using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;
public class TankInput : TankMemberControlParts
{
    private void Update()
    {
        if (!TryGetGamePad())
        {
            return;
        }

        if (TargetGamePad.leftTrigger.IsPressed())
        {
            OnBreak();
        }
    }

    public void OnBreak()
    {
        print("OnBreak");
    }
}
