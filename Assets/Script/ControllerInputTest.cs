using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;
using UnityEngine;
public class ControllerInputTest : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        print(Gamepad.all.Count);
        ((DualShockGamepad)Gamepad.all[0]).SetLightBarColor(Color.red);
        //((DualShockGamepad)Gamepad.all[1]).SetLightBarColor(Color.blue);
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.all.Count >= 2)
        {
            if ((Gamepad.all[0]).aButton.IsPressed())
            {
                print("0 aButtonPressed");

            }

            if (Gamepad.all[1].aButton.IsPressed())
            {
                print("1 aButtonPressed");
            }
        }

        //Debug.Log(string.Join("\n", Gamepad.all));
        if (Gamepad.current.aButton.IsPressed())
        {
            print(Gamepad.current.deviceId);
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log(context.action.triggered);
        Debug.Log(context.control.device.deviceId);
    }
}
