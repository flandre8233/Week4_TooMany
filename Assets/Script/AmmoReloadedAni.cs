using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmmoReloadedAni : MonoBehaviour
{
    [SerializeField] RectTransform StartPoint;
    [SerializeField] RectTransform FinishPoint;
    RectTransform _RectTransform;

    vector3Lerp vector3Lerp;
    QuaternionLerp QuateLerp;

    public void StartAni()
    {
        gameObject.SetActive(true);
        vector3Lerp = new vector3Lerp();
        vector3Lerp.startLerp(StartPoint.anchoredPosition3D, FinishPoint.anchoredPosition3D, 0.3f, null, OnEnd);
        QuateLerp = new QuaternionLerp();
        QuateLerp.startLerp(Quaternion.Euler(0, 0, 45-180), Quaternion.Euler(0, 0, 45), 0.3f, null, OnEnd);
    }

    private void Start()
    {
        _RectTransform = GetComponent<RectTransform>();
        OnEnd();
    }

    // Update is called once per frame
    void Update()
    {
        if (vector3Lerp.isLerping)
        {
            _RectTransform.anchoredPosition3D = vector3Lerp.update();
            _RectTransform.rotation = QuateLerp.update();
        }
    }

    void OnEnd()
    {
        gameObject.SetActive(false);
    }
}
