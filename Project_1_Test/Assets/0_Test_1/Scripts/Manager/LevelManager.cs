using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private float timeCount;

    [SerializeField] private float timeWaitLoadDataDone;

    [SerializeField] private GameActionManager gameActionManager;

    [SerializeField] private UiGameManager uiGameManager;

    [SerializeField] private LinesDrawer linesDrawer;

    [SerializeField] private GameResultManager gameResultManager;

    private MapManager mapManager;

    [SerializeField] private CountTimeManager countTimeManager;

    public GameResultManager GameResultManager => gameResultManager;

    public GameActionManager GameActionManager => gameActionManager;

    public UiGameManager UiGameManager => uiGameManager;

    public TypeLevel TypeLevel { get; private set; }

    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        StartCoroutine(WaitForLoadingData());

        //

        Init();
    }

    private void Init()
    {
        gameResultManager.Init();

        gameActionManager.Init();

        linesDrawer.Init();

        mapManager.Init();

        countTimeManager.Init(timeCount);

        //

        gameActionManager.EndGameAction.ActionAdd(OnEndGame);
    }

    IEnumerator WaitForLoadingData()
    {
        yield return new WaitForSeconds(timeWaitLoadDataDone);
        GameManager.Instance.OnLoadingSceneDone(GameState.IN_GAME);
    }

    public void OnEndGame()
    {
        StartCoroutine(WaitEndGame());
    }

    IEnumerator WaitEndGame()
    {
        yield return new WaitForSeconds(1);

        if(gameResultManager.GetGameResult() != GameResult.Lose)
        {
            gameResultManager.SetGameResult(GameResult.Win);
        }

        yield return new WaitForSeconds(1);

        gameActionManager.GameStartAction.ForceAction();

        GameManager.Instance.LoadingManager.OnLoading(TypeLoading.LoadingToLobby, () => { GameManager.Instance.LoadLevel(""); });
    }
}

public enum TypeLevel
{
    Protect,
    Prevent
}