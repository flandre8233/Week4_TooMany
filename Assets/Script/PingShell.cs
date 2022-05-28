using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingShell : MonoBehaviour
{
    [SerializeField] Transform ColliderTrans;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeColliderTag", 0.2f);
        Destroy(gameObject, 10);
    }
    void ChangeColliderTag()
    {
        ColliderTrans.gameObject.tag = "PingShell";
        ColliderTrans.gameObject.SetActive(true);
    }
}
