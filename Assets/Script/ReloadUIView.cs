using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReloadUIView : MonoBehaviour
{
    public Image[] Images;
    public void UpdateImageView()
    {
        GetComponent<CanvasGroup>().alpha = 0.15f;
        Images[0].color = new Color(1, 1, 1, 0);
        Images[1].color = new Color(1, 1, 1, 0);
        Images[2].color = new Color(1, 1, 1, 0);
    }

    public void OnWrongInput()
    {
        WrongInputView.Create(this);
    }
    public ReloadUIView UpdateImageView(ReloadTaskListener Task)
    {
        UpdateImageView();

        GetComponent<CanvasGroup>().alpha = 1f;
        for (int i = 0; i < Task.QTEReloadTask.Count; i++)
        {
            if (i >= 3)
            {
                break;
            }
            print(Task.QTEReloadTask[i]);
            Images[i].sprite = ControllerIconBase.instance.GetSprite(Task.QTEReloadTask[i]);
            if (i == 0)
            {
                Images[i].color = new Color(1, 1, 1, 1f);
            }
            if (i == 1)
            {
                Images[i].color = new Color(1, 1, 1, 0.7f);
            }
            if (i == 2)
            {
                Images[i].color = new Color(1, 1, 1, 0.3f);
            }
        }
        return this;
    }
}
