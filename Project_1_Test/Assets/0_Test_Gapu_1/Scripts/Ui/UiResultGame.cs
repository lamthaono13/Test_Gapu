using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiResultGame : UiCanvas
{
    [SerializeField] private Image imgResult;

    [SerializeField] private Sprite spriteWin;

    [SerializeField] private Sprite spriteLose;

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
        GameResult result = LevelManager.Instance.GameResultManager.GetGameResult();

        switch (result)
        {
            case GameResult.Win:

                imgResult.sprite = spriteWin;

                break;
            case GameResult.Lose:

                imgResult.sprite = spriteLose;

                break;
        }

        imgResult.SetNativeSize();
    }
}
