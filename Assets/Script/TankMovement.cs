using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;
public class TankMovement : TankMemberControlParts
{
    bool LeftShoulderPressed = false;
    bool RightShoulderPressed = false;
    [SerializeField] bool IsLeftReverseGear;
    [SerializeField] bool IsRightReverseGear;
    Rigidbody Rigidbody;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    protected void Update()
    {
        if (!TryGetGamePad())
        {
            return;
        }

        if (TargetGamePad.leftShoulder.isPressed)
        {
            if (!LeftShoulderPressed)
            {
                OnLeftReverseGearSwitch();
            }
            LeftShoulderPressed = true;
        }
        else
        {
            LeftShoulderPressed = false;
        }

         if (TargetGamePad.rightShoulder.isPressed)
        {
            if (!RightShoulderPressed)
            {
                OnRightReverseGearSwitch();
            }
            RightShoulderPressed = true;
        }
        else
        {
            RightShoulderPressed = false;
        }

        float LeftTrackForce = TargetGamePad.leftTrigger.ReadValue() * (IsLeftReverseGear ? -.5f : 1);
        float RightTrackForce = TargetGamePad.rightTrigger.ReadValue() * (IsRightReverseGear ? -.5f : 1);

        MoveTank( ( LeftTrackForce + RightTrackForce )/ 2);
        TurnTank(LeftTrackForce - RightTrackForce);

    }

    public void OnLeftReverseGearSwitch()
    {
        IsLeftReverseGear = !IsLeftReverseGear;
        GetComponent<Tank>().MyUIShower.SetLeftGear(IsLeftReverseGear);
    } public void OnRightReverseGearSwitch()
    {
        IsRightReverseGear = !IsRightReverseGear;
        GetComponent<Tank>().MyUIShower.SetRightGear(IsRightReverseGear);
    }

    public void MoveTank(float Analog)
    {
        Vector3 movement = transform.forward * Analog * 5f * Time.deltaTime;
        Rigidbody.MovePosition(Rigidbody.position + movement);
    }

    public void TurnTank(float DeviationForce)
    {
        float turn = DeviationForce * 67.5f * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        Rigidbody.MoveRotation(Rigidbody.rotation * turnRotation);
    }

}
