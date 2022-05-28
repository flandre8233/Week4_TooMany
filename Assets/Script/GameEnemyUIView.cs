using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameEnemyUIView : SingletonMonoBehavior<GameEnemyUIView>
{
    [SerializeField] Text text;

    // Start is called before the first frame update
    public void UpdateView()
    {
        text = GetComponent<Text>();
        text.text = "Enemy: " + SingleTankSceneGameMode.instance.AICount;
        GetComponent<Animator>().Play("TextUpdateJump", 0, 0);
    }
}
