using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStatus : SingletonMonoBehavior<CanvasStatus>
{
    [SerializeField] GameObject game;
    [SerializeField] GameObject Gameover;

    public void ToGameover()
    {
        game.SetActive(false);
        Gameover.SetActive(true);
    }
}
