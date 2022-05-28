using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;
public class SelectCanvasHoldListener : MonoBehaviour
{
    [SerializeField] Transform NextCanvas;
    // Update is called once per frame
    void Update()
    {
        if (IsReady(0) && IsReady(1) && IsReady(2) && IsReady(3))
        {
            OnNextCanvas();
        }
    }

    void OnNextCanvas()
    {
        gameObject.SetActive(false);
        NextCanvas.gameObject.SetActive(true);
    }

    bool IsReady(int ConnectID)
    {
        if ((Gamepad.all.Count > ConnectID))
        {
            return Gamepad.all[ConnectID].leftTrigger.ReadValue() + Gamepad.all[ConnectID].rightTrigger.ReadValue() >= 1.5f;
        }
        return false;
    }
}
