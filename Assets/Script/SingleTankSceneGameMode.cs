using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTankSceneGameMode : SingletonMonoBehavior<SingleTankSceneGameMode>
{
    public Tank PlayerTank;
    public int AICount = 0;
    public int Level = 0;

    private void Start()
    {
        Invoke("LevelUP", 3);
    }

    public void OnAITankDead()
    {
        if (AICount <= 0)
        {
            Invoke("LevelUP", 3);
        }
    }

    void LevelUP()
    {
        Level++;
        GameWaveUIView.instance.UpdateView();
        for (int i = 0; i < Level; i++)
        {
            AISpawner.instance.SpawnRandomPlace();
        }
    }
}
