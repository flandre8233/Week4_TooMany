using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReverseGearImageAnimation : MonoBehaviour
{
    [SerializeField] RectTransform GearImageTrans;
    bool Ison;
    public void OnRotate()
    {
        Ison = true;
        Invoke("Close", 1f);
    }

    void Close()
    {
        Ison = false;
    }

    public void ForceClose()
    {
        Close();
        CancelInvoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ison)
        {
            GearImageTrans.Rotate(new Vector3(0, 0, 720 * Time.deltaTime));
        }
    }
}
