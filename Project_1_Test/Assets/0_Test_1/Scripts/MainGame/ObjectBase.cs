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

    public virtual void Init()
    {
        //gameStart += OnGameStart;
        //pause += OnPause;
        //startCount += OnStartCount;
        //endGame += OnEndGame;

        LevelManager.Instance.GameActionManager.GameStartAction.ActionAdd(OnGameStart);
        LevelManager.Instance.GameActionManager.PauseAction.ActionAdd(OnPause);
        LevelManager.Instance.GameActionManager.StartCountAction.ActionAdd(OnStartCount);
        LevelManager.Instance.GameActionManager.EndGameAction.ActionAdd(OnEndGame);
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

        LevelManager.Instance.GameActionManager.GameStartAction.ActionRemove(OnGameStart);
        LevelManager.Instance.GameActionManager.PauseAction.ActionRemove(OnPause);
        LevelManager.Instance.GameActionManager.StartCountAction.ActionRemove(OnStartCount);
        LevelManager.Instance.GameActionManager.EndGameAction.ActionRemove(OnEndGame);
    }
}
