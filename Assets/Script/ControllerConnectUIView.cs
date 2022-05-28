using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class ControllerConnectUIView : MonoBehaviour
{
    Image UiView;
    [SerializeField] int ConnectID;
    // Start is called before the first frame update
    void Start()
    {
        UiView = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        UiView.enabled = (Gamepad.all.Count > ConnectID);
        UiView.sprite = ControllerUIBase.instance.GetSprite( UiView.enabled && Gamepad.all[ConnectID].leftTrigger.ReadValue() + Gamepad.all[ConnectID].rightTrigger.ReadValue() >= 1.5f);
    }
}
