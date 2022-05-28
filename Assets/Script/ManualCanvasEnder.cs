using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualCanvasEnder : MonoBehaviour
{
    [SerializeField] GameObject CameraModelOnly;
    [SerializeField] GameObject OneTankModelOnly;

    [SerializeField] GameObject AISpawner;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject Tank;

    [SerializeField] GameObject GameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        CameraModelOnly.SetActive(false);
        OneTankModelOnly.SetActive(false);
        gameObject.SetActive(false);
        AISpawner.SetActive(true);
        Camera.SetActive(true);
        Tank.SetActive(true);
        GameCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
