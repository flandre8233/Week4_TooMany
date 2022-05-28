using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSoundControll : TankMemberControlParts
{
    [SerializeField] AudioSource audioSour;

    // Update is called once per frame
    void Update()
    {
        if (!TryGetGamePad())
        {
            return;
        }

        audioSour.volume = ((((TargetGamePad.leftTrigger.ReadValue() + TargetGamePad.rightTrigger.ReadValue()) / 2) - 1) * -1) * 0.7f;
    }
}
