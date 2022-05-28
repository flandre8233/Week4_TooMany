using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using System.Linq;

public class ReloadTaskListener : TankMemberControlParts
{
    TankAmmunitionDepot reloader;
    public List<ControllerEnum> QTEReloadTask;

    public ReloadUIView ReloadUI;

    public static ReloadTaskListener Create(TankAmmunitionDepot _reloader, bool IsOne)
    {
        GameObject NewObejct = new GameObject();
        ReloadTaskListener Task = NewObejct.AddComponent<ReloadTaskListener>();
        NewObejct.name = Task.GetType().Name;
        Task.reloader = _reloader;
        Task.ReloadUI = _reloader.GetComponentInParent<Tank>().MyUIShower.Reload;
        Task.IsOne = IsOne;
        return Task;
    }

    void Start()
    {
        ControlBy = TankMember.Loader;
        MakeANewTask();
    }

    void MakeANewTask()
    {
        QTEReloadTask = new List<ControllerEnum>();
        for (int i = 0; i < 5; i++)
        {
            ControllerEnum NewEnum = (ControllerEnum)Random.Range(0, System.Enum.GetValues(typeof(ControllerEnum)).Length);
            QTEReloadTask.Add(NewEnum);
        }
        QTEReloadTask.Add(ControllerEnum.RightTrigger);
        ReloadUI.UpdateImageView(this);
    }

    [SerializeField] bool ThisFrameChecked = false;

    // Update is called once per frame
    void Update()
    {
        if (!TryGetGamePad())
        {
            return;
        }

        if (!ThisFrameChecked)
        {
            if (IsCurrentQTEPass())
            {


                QTEReloadTask.RemoveAt(0);
                ReloadUI.UpdateImageView(this);
                if (QTEReloadTask.Count <= 0)
                {
                    QTEFinish();
                }
                else
                {
                    GameObject SpawnPrefab = Resources.Load<GameObject>("Confirm");
                    GameObject Spawned = Instantiate(SpawnPrefab, new Vector3(), Quaternion.identity);
                    Destroy(Spawned, 5f);
                }
                ThisFrameChecked = true;
            }
            else if (IsWrongPress())
            {

                ReloadUI.OnWrongInput();
                MakeANewTask();
                ThisFrameChecked = true;

                GameObject SpawnPrefab = Resources.Load<GameObject>("Wrong");
                GameObject Spawned = Instantiate(SpawnPrefab, new Vector3(), Quaternion.identity);
                Destroy(Spawned, 5f);
            }
        }

        if (ThisFrameChecked && AllRelease())
        {
            ThisFrameChecked = false;
        }

        if (TargetGamePad.dpad.up.isPressed)
        {
            print("??");
        }
    }

    void QTEFinish()
    {
        reloader.OnReload();
        Destroy(gameObject);
    }

    bool IsWrongPress()
    {
        if (TargetGamePad.dpad.up.isPressed && QTEReloadTask[0] != ControllerEnum.DpadUp)
        {
            return true;
        }
        if (TargetGamePad.dpad.down.isPressed && QTEReloadTask[0] != ControllerEnum.DpadDown)
        {
            return true;
        }
        if (TargetGamePad.dpad.left.isPressed && QTEReloadTask[0] != ControllerEnum.DpadLeft)
        {
            return true;
        }
        if (TargetGamePad.dpad.right.isPressed && QTEReloadTask[0] != ControllerEnum.DpadRight)
        {
            return true;
        }
        if (TargetGamePad.leftTrigger.isPressed && QTEReloadTask[0] != ControllerEnum.LeftTrigger)
        {
            return true;
        }
        if (TargetGamePad.rightTrigger.isPressed && QTEReloadTask[0] != ControllerEnum.RightTrigger)
        {
            return true;
        }
        if (TargetGamePad.leftShoulder.isPressed && QTEReloadTask[0] != ControllerEnum.LeftShoulder)
        {
            return true;
        }
        if (TargetGamePad.leftStickButton.isPressed && QTEReloadTask[0] != ControllerEnum.LeftStick)
        {
            return true;
        }
        if (TargetGamePad.rightStickButton.isPressed && QTEReloadTask[0] != ControllerEnum.RightStick)
        {
            return true;
        }
        if (TargetGamePad.aButton.isPressed && QTEReloadTask[0] != ControllerEnum.A)
        {
            return true;
        }
        if (TargetGamePad.bButton.isPressed && QTEReloadTask[0] != ControllerEnum.B)
        {
            return true;

        }
        if (TargetGamePad.xButton.isPressed && QTEReloadTask[0] != ControllerEnum.X)
        {
            return true;
        }
        if (TargetGamePad.yButton.isPressed && QTEReloadTask[0] != ControllerEnum.Y)
        {
            return true;
        }
        return false;
    }

    bool IsCurrentQTEPass()
    {
        if (TargetGamePad.dpad.up.isPressed && QTEReloadTask[0] == ControllerEnum.DpadUp)
        {
            return true;
        }
        if (TargetGamePad.dpad.down.isPressed && QTEReloadTask[0] == ControllerEnum.DpadDown)
        {
            return true;

        }
        if (TargetGamePad.dpad.left.isPressed && QTEReloadTask[0] == ControllerEnum.DpadLeft)
        {
            return true;

        }
        if (TargetGamePad.dpad.right.isPressed && QTEReloadTask[0] == ControllerEnum.DpadRight)
        {
            return true;

        }
        if (TargetGamePad.leftTrigger.isPressed && QTEReloadTask[0] == ControllerEnum.LeftTrigger)
        {
            return true;

        }
        if (TargetGamePad.rightTrigger.isPressed && QTEReloadTask[0] == ControllerEnum.RightTrigger)
        {
            return true;

        }
        if (TargetGamePad.leftShoulder.isPressed && QTEReloadTask[0] == ControllerEnum.LeftShoulder)
        {
            return true;

        }
        if (TargetGamePad.leftStickButton.isPressed && QTEReloadTask[0] == ControllerEnum.LeftStick)
        {
            return true;

        }
        if (TargetGamePad.rightStickButton.isPressed && QTEReloadTask[0] == ControllerEnum.RightStick)
        {
            return true;

        }
        if (TargetGamePad.aButton.isPressed && QTEReloadTask[0] == ControllerEnum.A)
        {
            return true;

        }
        if (TargetGamePad.bButton.isPressed && QTEReloadTask[0] == ControllerEnum.B)
        {
            return true;

        }
        if (TargetGamePad.xButton.isPressed && QTEReloadTask[0] == ControllerEnum.X)
        {
            return true;

        }
        if (TargetGamePad.yButton.isPressed && QTEReloadTask[0] == ControllerEnum.Y)
        {
            return true;
        }
        return false;
    }

    bool AllRelease()
    {
        if (TargetGamePad.dpad.up.isPressed)
        {
            return false;
        }
        if (TargetGamePad.dpad.down.isPressed)
        {
            return false;

        }
        if (TargetGamePad.dpad.left.isPressed)
        {
            return false;

        }
        if (TargetGamePad.dpad.right.isPressed)
        {
            return false;

        }
        if (TargetGamePad.leftTrigger.isPressed)
        {
            return false;

        }
        if (TargetGamePad.rightTrigger.isPressed)
        {
            return false;

        }
        if (TargetGamePad.leftShoulder.isPressed)
        {
            return false;

        }
        if (TargetGamePad.rightShoulder.isPressed)
        {
            return false;

        }
        if (TargetGamePad.leftStickButton.isPressed)
        {
            return false;

        }
        if (TargetGamePad.rightStickButton.isPressed)
        {
            return false;

        }
        if (TargetGamePad.aButton.isPressed)
        {
            return false;

        }
        if (TargetGamePad.bButton.isPressed)
        {
            return false;

        }
        if (TargetGamePad.xButton.isPressed)
        {
            return false;

        }
        if (TargetGamePad.yButton.isPressed)
        {
            return false;
        }
        return true;
    }
}
