using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;
public class ManualListener : MonoBehaviour
{
    [SerializeField] int ConnectID;

    [SerializeField] GameObject NextObject;

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.all[ConnectID].bButton.IsPressed())
        {
            OnNext();
        }
    }

    public void OnNext()
    {
        gameObject.SetActive(false);
        NextObject.SetActive(true);
    }
}
