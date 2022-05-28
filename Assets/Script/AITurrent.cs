using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITurrent : MonoBehaviour
{
    [SerializeField] AITank ThisAI;
    // Update is called once per frame
    void Update()
    {
        if (SingleTankSceneGameMode.instance.PlayerTank == null)
        {
            return;
        }

        if (ThisAI.GetAIStep() == 3)
        {
            Vector3 difference = SingleTankSceneGameMode.instance.PlayerTank.transform.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, rotationZ + Random.Range( -45,45) , 0.0f), 1 * Time.deltaTime);
        }
    }
}
