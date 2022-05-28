using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollider : MonoBehaviour
{
    [SerializeField] Tank MyTank;
    [SerializeField] GameObject FireExplosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shell"))
        {
            MyTank.SetDead();
            FireExplosion.transform.parent = null;
            FireExplosion.SetActive(true);
            Destroy(other.transform.parent.gameObject);
        }
    }

}
