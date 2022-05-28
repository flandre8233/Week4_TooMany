using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITank : MonoBehaviour
{
    int AttackDistance;
    int StayHold0Time;
    int StayHold2Time;
    int AIStep;

    private void Start()
    {
        AttackDistance = Random.Range(15, 65);
        StayHold0Time = Random.Range(8, 19);
        StayHold2Time = Random.Range(3, 6);
    }

    public int GetAIStep()
    {
        return AIStep;
    }

    private void Update()
    {
        if (SingleTankSceneGameMode.instance.PlayerTank == null)
        {
            return;
        }
        float distance = Vector3.Distance(transform.position, SingleTankSceneGameMode.instance.PlayerTank.transform.position);
        if (AIStep == 0 && distance >= AttackDistance)
        {
            AIStep = 1;
        }

        if (AIStep == 1 && distance <= AttackDistance)
        {
            AIStep = 2;
        }

        if (AIStep == 2)
        {
            AIStep = 3;
            Invoke("StayHold", StayHold0Time);
        }
    }
    void StayHold()
    {
        AIStep = 4;
        Invoke("StayHold1", 1f);
    }

    void StayHold1()
    {
        AIStep = 5;
    }

    public void OnFireFinish()
    {
        AIStep = 6;
        Invoke("StayHold2", StayHold2Time);
    }

    void StayHold2()
    {
        AIStep = 1;
    }
}
