using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFire : TankMemberControlParts
{
    [SerializeField] Transform FirePoint;
    bool RightTriggerPressed = false;
    void Update()
    {
        if (!TryGetGamePad())
        {
            return;
        }

        if (TargetGamePad.rightTrigger.isPressed)
        {
            if (!RightTriggerPressed)
            {
                OnFire();
            }
            RightTriggerPressed = true;
        }
        else
        {
            RightTriggerPressed = false;
        }

    }

    public void OnFire()
    {
        RightTriggerPressed = !RightTriggerPressed;
        print("OnFire");
        if (GetComponent<TankAmmunitionDepot>().IsLoaded)
        {
            GetComponent<TankAmmunitionDepot>().IsLoaded = false;
            GetComponentInParent<Tank>().MyUIShower.SetAmmoGear(false);
            FireShell();
            ReloadTaskListener.Create(GetComponent<TankAmmunitionDepot>(),IsOne);
        }
    }

    void FireShell()
    {
        GameObject ShellPrefab = Resources.Load<GameObject>("Shell");
        GameObject SpawnedShell = Instantiate(ShellPrefab, FirePoint);
        SpawnedShell.transform.parent = null;
    }
}
