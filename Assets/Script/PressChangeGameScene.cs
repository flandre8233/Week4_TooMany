using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PressChangeGameScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (IsPress(0) || IsPress(1) || IsPress(2) || IsPress(3))
        {
            RestartGame();
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    bool IsPress(int ConnectID)
    {
        if ((Gamepad.all.Count > ConnectID))
        {
            return Gamepad.all[ConnectID].startButton.IsPressed();
        }
        return false;
    }
}
