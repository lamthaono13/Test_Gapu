using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectBase : MonoBehaviour
{
    //private UnityAction gameStart;

    //private UnityAction pause;

    //private UnityAction startCount;

    //private UnityAction endGame;

    protected virtual void Start()
    {
        Init();
    }

    public virtual void Init()
    {
        //gameStart += OnGameStart;
        //pause += OnPause;
        //startCount += OnStartCount;
        //endGame += OnEndGame;

        LevelManager.Instance.MapManager.MapActionManager.GetAction((int)DrawGameAction.StartGame).ActionAdd(OnGameStart);
        LevelManager.Instance.MapManager.MapActionManager.GetAction((int)DrawGameAction.Pause).ActionAdd(OnPause);
        LevelManager.Instance.MapManager.MapActionManager.GetAction((int)DrawGameAction.StartCount).ActionAdd(OnStartCount);
        LevelManager.Instance.MapManager.MapActionManager.GetAction((int)DrawGameAction.EndGame).ActionAdd(OnEndGame);
    }

    public virtual void OnGameStart()
    {

    }

    public virtual void OnPause()
    {

    }

    public virtual void OnStartCount()
    {

    }

    public virtual void OnEndGame()
    {

    }

    protected virtual void OnDestroy()
    {
        //gameStart -= OnGameStart;
        //pause -= OnPause;
        //startCount -= OnStartCount;
        //endGame -= OnEndGame;

        LevelManager.Instance.MapManager.MapActionManager.GetAction((int)DrawGameAction.StartGame).ActionRemove(OnGameStart);
        LevelManager.Instance.MapManager.MapActionManager.GetAction((int)DrawGameAction.Pause).ActionRemove(OnPause);
        LevelManager.Instance.MapManager.MapActionManager.GetAction((int)DrawGameAction.StartCount).ActionRemove(OnStartCount);
        LevelManager.Instance.MapManager.MapActionManager.GetAction((int)DrawGameAction.EndGame).ActionRemove(OnEndGame);
    }
}
