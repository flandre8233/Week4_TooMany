using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFire : MonoBehaviour
{
    [SerializeField] AITank ThisAI;
    [SerializeField] Transform FirePoint;


    // Update is called once per frame
    void Update()
    {
        if (ThisAI.GetAIStep() == 5)
        {
            ThisAI.OnFireFinish();
            FireShell();
        }
    }

    void FireShell()
    {
        GameObject ShellPrefab = Resources.Load<GameObject>("Shell");
        GameObject SpawnedShell = Instantiate(ShellPrefab, FirePoint);
        SpawnedShell.transform.parent = null;
    }
}
