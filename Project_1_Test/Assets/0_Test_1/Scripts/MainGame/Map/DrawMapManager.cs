using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMapManager : MapManager
{
    //[SerializeField] private List<ObjectBase> listAllObject;

    [SerializeField] private LinesDrawer linesDrawer;

    [SerializeField] private CountTimeManager countTimeManager;

    public override void Init()
    {
        base.Init();

        countTimeManager.Init();
    }

    //public override void Init()
    //{
    //    base.Init();

    //    //for (int i = 0; i < listAllObject.Count; i++)
    //    //{
    //    //    listAllObject[i].Init();
    //    //}

    //    countTimeManager.Init();
    //}

    public override void OnEndGame()
    {
        StartCoroutine(WaitEndGame());
    }

    IEnumerator WaitEndGame()
    {
        yield return new WaitForSeconds(1);

        if (LevelManager.Instance.GameResultManager.GetGameResult() != GameResult.Lose)
        {
            LevelManager.Instance.GameResultManager.SetGameResult(GameResult.Win);

            GameManager.Instance.SoundManager.PlaySoundTrue();
        }

        yield return new WaitForSeconds(1);

        //gameActionManager.GetAction((int)MainGameAction.GameStart).ForceAction();

        if (LevelManager.Instance.GameResultManager.GetGameResult() == GameResult.Win)
        {
            uiMapManager.UiGameplay.GetUiPoppup<UiWin>((int)TypePopupDraw.Win).Show(true);
        }
        else
        {
            GameManager.Instance.LoadingManager.OnLoading(TypeLoading.LoadingToLobby, () => { GameManager.Instance.LoadLevel(""); });
        }


    }
}