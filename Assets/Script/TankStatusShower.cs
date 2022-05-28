using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TankStatusShower : MonoBehaviour
{
    [SerializeField] CanvasGroup LeftGear;
    [SerializeField] CanvasGroup RightGear;
    [SerializeField] CanvasGroup TurretGear;
    [SerializeField] CanvasGroup Ammo;
    public ReloadUIView Reload;
    public AmmoReloadedAni ReloadedAni;
    public void SetLeftGear(bool IsOn)
    {
        LeftGear.alpha = (IsOn ? 1 : 0.15f);
        if (IsOn)
        {
            LeftGear.GetComponent<ReverseGearImageAnimation>().OnRotate();
        }
        else
        {
            LeftGear.GetComponent<ReverseGearImageAnimation>().ForceClose();
        }
    }
    public void SetRightGear(bool IsOn)
    {
        RightGear.alpha = (IsOn ? 1 : 0.15f);
        if (IsOn)
        {
            RightGear.GetComponent<ReverseGearImageAnimation>().OnRotate();
        }
        else
        {
            RightGear.GetComponent<ReverseGearImageAnimation>().ForceClose();
        }
    }
    public void SetTurretGear(bool IsOn)
    {
        TurretGear.alpha = (IsOn ? 1 : 0.15f);
        if (IsOn)
        {
            TurretGear.GetComponent<ReverseGearImageAnimation>().OnRotate();
        }
        else
        {
            TurretGear.GetComponent<ReverseGearImageAnimation>().ForceClose();
        }
    }
    public void SetAmmoGear(bool IsOn)
    {
        Ammo.alpha = (IsOn ? 1 : 0.15f);
        if (IsOn)
        {
            ReloadedAni.StartAni();
        }
    }

    private void Start()
    {
        SetLeftGear(false);
        SetRightGear(false);
        SetTurretGear(false);
        SetAmmoGear(true);
        Reload.UpdateImageView();
    }
}
