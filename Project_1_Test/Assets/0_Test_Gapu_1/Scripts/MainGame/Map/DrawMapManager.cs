using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMapManager : MapManager
{
    [SerializeField] private CountTimeManager countTimeManager;

    private float timeCheckResultGame = 1;
    private float timeWaitShowResultGame = 1;

    public override void Init()
    {
        base.Init();

        countTimeManager.Init();
    }

    public override void OnEndGame()
    {
        StartCoroutine(WaitEndGame());
    }

    IEnumerator WaitEndGame()
    {
        yield return new WaitForSeconds(timeCheckResultGame);

        if (LevelManager.Instance.GameResultManager.GetGameResult() != GameResult.Lose)
        {
            LevelManager.Instance.GameResultManager.SetGameResult(GameResult.Win);

            GameManager.Instance.SoundManager.PlaySoundTrue();
        }

        yield return new WaitForSeconds(timeWaitShowResultGame);

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