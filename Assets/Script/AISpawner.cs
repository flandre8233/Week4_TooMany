using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : SingletonMonoBehavior<AISpawner>
{
    public void SpawnRandomPlace()
    {
        Vector3 RandomPos = GetRandomPos();
        if (Vector3.Distance(RandomPos, SingleTankSceneGameMode.instance.transform.position) <= 60)
        {
            SpawnRandomPlace();
            return;
        }

        SpawnAI(RandomPos);
        GameEnemyUIView.instance.UpdateView();
    }

    Vector3 GetRandomPos()
    {
        return new Vector3(Random.Range(-65, 65), 0, Random.Range(-65, 65)); ;
    }

    void SpawnAI(Vector3 Pos)
    {
        GameObject SpawnObject = Resources.Load<GameObject>("AI-Tank");
        Instantiate(SpawnObject, Pos, Quaternion.Euler(0, Random.Range(0, 360), 0));
        SingleTankSceneGameMode.instance.AICount++;
    }
}
