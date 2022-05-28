using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameWaveUIView : SingletonMonoBehavior<GameWaveUIView>
{
    [SerializeField] Text text;

    // Start is called before the first frame update
    public void UpdateView()
    {
        text = GetComponent<Text>();
        text.text = "Wave : " + SingleTankSceneGameMode.instance.Level;
        GetComponent<Animator>().Play("TextUpdateJump", 0, 0);
    }
}
