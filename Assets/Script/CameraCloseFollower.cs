using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCloseFollower : TankMemberControlParts
{
    public Transform target;
    public float distance = 3.0f;
    public float height = 3.0f;
    public float damping = 5.0f;
    public bool smoothRotation = true;
    public bool followBehind = true;
    public float rotationDamping = 10.0f;
    public float HandControllRotate = 60;
    public float LeftHandRotateSpeed = 45;
    public float LeftHandRotateVal = 0;

    private void OnEnable()
    {
        LeftHandRotateVal = 0;
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }
        if (!TryGetGamePad())
        {
            return;
        }

        Vector3 wantedPosition;
        if (followBehind)
            wantedPosition = target.TransformPoint(0, height, -distance);
        else
            wantedPosition = target.TransformPoint(0, height, distance);

        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);

        if (smoothRotation)
        {
            LeftHandRotateVal += LeftHandRotateSpeed * TargetGamePad.leftStick.x.ReadValue() * Time.deltaTime;
            Vector3 TargetLook = target.position + new Vector3(0, 2.5f, 0);
            Quaternion wantedRotation = Quaternion.LookRotation(TargetLook - transform.position, target.up);
            wantedRotation.eulerAngles += new Vector3(0, (HandControllRotate * TargetGamePad.rightStick.x.ReadValue()), 0);
            wantedRotation.eulerAngles += new Vector3(0, LeftHandRotateVal, 0);
            //Quaternion ownRotation = Quaternion.RotateTowards;
            transform.rotation = Quaternion.Slerp(transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
        }
        else transform.LookAt(target, target.up);
    }
}
