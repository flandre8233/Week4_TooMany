using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITankMovement : MonoBehaviour
{
    AITank ThisAI;
    // Start is called before the first frame update
    void Start()
    {
        ThisAI = GetComponent<AITank>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SingleTankSceneGameMode.instance.PlayerTank == null)
        {
            return;
        }

        if (ThisAI.GetAIStep() == 1)
        {
            transform.position += transform.forward * 2.5f * Time.deltaTime;

            Vector3 difference = SingleTankSceneGameMode.instance.PlayerTank.transform.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.x, difference.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0.0f, rotationZ, 0.0f), 1 * Time.deltaTime);
        }
    }
}
