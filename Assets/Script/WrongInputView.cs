using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WrongInputView : MonoBehaviour
{
    ReloadUIView ReloadUIView;
    [SerializeField] Image image;

    Vector2 Gravity = new Vector2(0, -9.81f);
    Vector2 Force;


    public static WrongInputView Create(ReloadUIView _ReloadUIView)
    {
        GameObject GamePrefab = Resources.Load<GameObject>("WrongInputImage");
        GameObject SpawnObject = Instantiate(GamePrefab, _ReloadUIView.Images[0].transform);
        WrongInputView InputView = SpawnObject.GetComponent<WrongInputView>();
        InputView.ReloadUIView = _ReloadUIView;
        InputView.Init();
        return InputView;
    }

    private void Init()
    {
        Force = Random.insideUnitCircle * 10;
        image.sprite = ReloadUIView.Images[0].sprite;
        image.color = new Color(1, 0, 0, .5f);
        RectTransform ThisRect = GetComponent<RectTransform>();
        ThisRect.anchoredPosition = new Vector2(0, 0);
        Destroy(gameObject, 10);
    }

    private void Update()
    {
        RectTransform ThisRect = GetComponent<RectTransform>();
        Force += Gravity * Time.deltaTime;
        ThisRect.anchoredPosition += Force;
    }

}
