using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private float timeWaitLoadDataDone;

    [SerializeField] private Camera cameraGame;

    [SerializeField] private GameActionManager gameActionManager;

    [SerializeField] private UiGameManager uiGameManager;

    //[SerializeField] private LinesDrawer linesDrawer;

    [SerializeField] private GameResultManager gameResultManager;

    [SerializeField] private MapManager mapManager;

    //[SerializeField] private CountTimeManager countTimeManager;

    public Camera CameraGame => cameraGame;

    public GameResultManager GameResultManager => gameResultManager;

    public GameActionManager GameActionManager => gameActionManager;

    public UiGameManager UiGameManager => uiGameManager;

    public MapManager MapManager => mapManager;

    private int currentLevel;

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
        currentLevel = GameManager.Instance.DataManager.GetLevel();

        gameResultManager.Init();

        gameActionManager.Init();

        //linesDrawer.Init();

        mapManager.Init();

        //countTimeManager.Init(timeCount);

        //

        gameActionManager.GetAction((int)MainGameAction.EndGame).ActionAdd(OnEndGame);
    }

    IEnumerator WaitForLoadingData()
    {
        yield return new WaitForSeconds(timeWaitLoadDataDone);

        GameManager.Instance.SoundManager.PlaySoundInGame(true);

        GameManager.Instance.OnLoadingSceneDone(GameState.IN_GAME);
    }

    public void OnEndGame()
    {
        //StartCoroutine(WaitEndGame());
    }

    //IEnumerator WaitEndGame()
    //{
    //    yield return new WaitForSeconds(1);

    //    if(gameResultManager.GetGameResult() != GameResult.Lose)
    //    {
    //        gameResultManager.SetGameResult(GameResult.Win);
    //    }

    //    yield return new WaitForSeconds(1);

    //    //gameActionManager.GetAction((int)MainGameAction.GameStart).ForceAction();

    //    GameManager.Instance.LoadingManager.OnLoading(TypeLoading.LoadingToLobby, () => { GameManager.Instance.LoadLevel(""); });
    //}

    public int GetCurrentLevel()
    {
        return currentLevel;
    }
}