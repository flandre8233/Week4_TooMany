using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public TankStatusShower MyUIShower;

    public void SetDead()
    {
        Destroy(gameObject);
        if (GetComponent<TankInput>())
        {
            print("GameOver");
            CanvasStatus.instance.ToGameover();
        }
        else
        {
            SingleTankSceneGameMode.instance.AICount--;
            SingleTankSceneGameMode.instance.OnAITankDead();
            GameEnemyUIView.instance.UpdateView();
        }
    }

}
