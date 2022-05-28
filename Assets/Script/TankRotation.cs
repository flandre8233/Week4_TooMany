using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;
public class TankRotation : TankMemberControlParts
{
    [SerializeField] float TurnSpeed;
    Rigidbody Rigidbody;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!TryGetGamePad())
        {
            return;
        }
        
        //TurnTank(TargetGamePad.leftStick.ReadValue().x);
    }

    public void TurnTank(float Analog)
    {
        float turn = Analog * TurnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        Rigidbody.MoveRotation(Rigidbody.rotation * turnRotation);
    }
}
