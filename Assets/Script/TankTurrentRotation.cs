using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;
public class TankTurrentRotation : TankMemberControlParts
{
    bool LeftShoulderPressed = false;
    [SerializeField] bool IsReverseGear;
    // Update is called once per frame
    void Update()
    {
        if (!TryGetGamePad())
        {
            return;
        }

        if (TargetGamePad.leftShoulder.isPressed)
        {
            if (!LeftShoulderPressed)
            {
                OnReverseGearSwitch();
            }
            LeftShoulderPressed = true;
        }
        else
        {
            LeftShoulderPressed = false;
        }

        SpinDetection spinDetection = GetComponent<SpinDetection>();
        transform.Rotate(new Vector3(0, (22.5f / 2) * Time.deltaTime * spinDetection.CheckPointFlowCounter * (IsReverseGear ? -1 : 1), 0));
        Spin2Detection spin2Detection = GetComponent<Spin2Detection>();
        transform.Rotate(new Vector3(0, (22.5f / 12) * Time.deltaTime * spin2Detection.CheckPointFlowCounter * (IsReverseGear ? -1 : 1), 0));
    }

    public void OnReverseGearSwitch()
    {
        IsReverseGear = !IsReverseGear;
        GetComponentInParent<Tank>().MyUIShower.SetTurretGear(IsReverseGear);
    }
}
