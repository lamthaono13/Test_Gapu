using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiCountTime : UiCanvas
{
    [SerializeField] private TextMeshProUGUI textTime;

    public override void Show(bool _isShow)
    {
        if (_isShow)
        {
            Init();
        }

        base.Show(_isShow);
    }

    private void Init()
    {

    }

    public void SetTime(float time, bool isShow)
    {
        if (!isShow)
        {
            int a = (int)time;

            //Debug.Log(a);

            if(a >= 0)
            {
                textTime.text = a.ToString();
            }
        }
        else
        {
            Show(false);
        }
    }
}