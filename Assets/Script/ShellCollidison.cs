using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellCollidison : MonoBehaviour
{
    [SerializeField] GameObject ShellOnHitGameobject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tank"))
        {
            ShellOnHitGameobject.SetActive(true);
            ShellOnHitGameobject.transform.parent = null;
            Destroy(ShellOnHitGameobject, 5);
        }
    }
}
