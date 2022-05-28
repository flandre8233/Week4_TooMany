using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSwitcher : TankMemberControlParts
{
    [SerializeField] CameraFollower NormalFollower;
    [SerializeField] CameraCloseFollower CloseFollower;
    [SerializeField] GameObject CmdCompassPointUIView;
    [SerializeField] GameObject AimImage;

    bool Pressed = false;

    private void Update()
    {
        if (!TryGetGamePad())
        {
            return;
        }

        if (TargetGamePad.rightTrigger.ReadValue() + TargetGamePad.leftTrigger.ReadValue() >= 1.5f)
        {
            if (!Pressed)
            {
                GameObject SpawnPrefab = Resources.Load<GameObject>("zoomin");
                GameObject Spawned = Instantiate(SpawnPrefab, new Vector3(), Quaternion.identity);
                Destroy(Spawned, 5f);

                SwitchCamera();
            }
            Pressed = true;
        }
        else
        {
            if (Pressed)
            {
                GameObject SpawnPrefab = Resources.Load<GameObject>("zoomout");
                GameObject Spawned = Instantiate(SpawnPrefab, new Vector3(), Quaternion.identity);
                Destroy(Spawned, 5f);

                SwitchCamera();
            }
            Pressed = false;
        }
    }

    void SwitchCamera()
    {
        print("SwitchCamera");
        NormalFollower.enabled = (Pressed);
        CloseFollower.enabled = (!Pressed);
        CmdCompassPointUIView.SetActive(CloseFollower.enabled);
        AimImage.SetActive(CloseFollower.enabled);
    }
}
