using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSoundControll : TankMemberControlParts
{
    [SerializeField] AudioSource audioSour;

    // Update is called once per frame
    void Update()
    {
        if (!TryGetGamePad())
        {
            return;
        }

        audioSour.volume = ((TargetGamePad.leftTrigger.ReadValue() + TargetGamePad.rightTrigger.ReadValue()) / 2) * 0.7f;
    }
}
