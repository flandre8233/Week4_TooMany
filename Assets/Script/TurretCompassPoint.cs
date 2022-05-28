using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurretCompassPoint : MonoBehaviour
{
    [SerializeField] GameObject Turrent;
    [SerializeField] Text text;

    // Update is called once per frame
    void Update()
    {
        if (Turrent == null)
        {
            return;
        }
        float Compass = (int)Turrent.transform.eulerAngles.y;
        if (Compass >= 350 || Compass <= 10)
        {
            text.text = "North";

        }
        else if (Compass >= 80 && Compass <= 100)
        {
            text.text = "East";


        }
        else if (Compass >= 160 && Compass <= 180)
        {
            text.text = "South";


        }
        else if (Compass >= 260 && Compass <= 280)
        {
            text.text = "West";

        }
        else
        {
            text.text = ((int)Compass).ToString();
        }
    }
}
