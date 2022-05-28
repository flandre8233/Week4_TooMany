using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerUIBase : SingletonMonoBehavior<ControllerUIBase>
{
    [SerializeField] Sprite[] ControllerDisplay;
    public Sprite GetSprite(bool IsConnected)
    {
        return ControllerDisplay[(IsConnected ? 1 : 0)];
    }
}
