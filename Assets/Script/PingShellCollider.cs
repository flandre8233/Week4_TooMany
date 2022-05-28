using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingShellCollider : MonoBehaviour
{
    [SerializeField] GameObject DestorySaveObject;
    [SerializeField] GameObject MetalImpact7;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tank"))
        {
            MetalImpact7.SetActive(true);
            MetalImpact7.transform.parent = null;
            DestorySaveObject.transform.parent = null;
            Destroy(MetalImpact7, 5f);
            Destroy(DestorySaveObject, 5f);
            Destroy(transform.parent.gameObject);
        }
    }
}
