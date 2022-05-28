using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPingFire : TankMemberControlParts
{
    [SerializeField] Transform FirePoint;
    bool Right1Pressed = false;
    bool IsReadyFire = true;

    void Update()
    {
        if (!TryGetGamePad())
        {
            return;
        }

        if (TargetGamePad.rightShoulder.isPressed)
        {
            if (!Right1Pressed)
            {
                OnFire();
            }
            Right1Pressed = true;
        }
        else
        {
            Right1Pressed = false;
        }

    }

    public void OnFire()
    {
        Right1Pressed = !Right1Pressed;
        print("OnFire");
        if (IsReadyFire)
        {
            IsReadyFire = false;
            FirePingShell();
            Invoke("ResetFire", 1f);
        }
    }

    void FirePingShell()
    {
        GameObject ShellPrefab = Resources.Load<GameObject>("PingShell");
        GameObject SpawnedShell = Instantiate(ShellPrefab, FirePoint);
        SpawnedShell.transform.parent = null;
    }

    void ResetFire()
    {
        IsReadyFire = true;

    }
}
