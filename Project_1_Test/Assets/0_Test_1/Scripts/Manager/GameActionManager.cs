using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameActionManager : MonoBehaviour
{
    public GameAction GameStartAction;

    public GameAction PauseAction;

    public GameAction StartCountAction;

    public GameAction EndGameAction;

    public void Init()
    {
        InitActionGame();

        //StartCountAction.ActionAdd(() => { Debug.Log("123"); });
    }

    public void InitActionGame()
    {
        GameStartAction = new GameAction(MainGameAction.GameStart.ToString());

        PauseAction = new GameAction(MainGameAction.Pause.ToString());

        StartCountAction = new GameAction(MainGameAction.StartCount.ToString());

        EndGameAction = new GameAction(MainGameAction.EndGame.ToString());
    }
}

public enum MainGameAction
{
    GameStart,
    Pause,
    StartCount,
    EndGame
}

public class GameAction
{
    public UnityAction OnAction;

    //public EventGameAction OnAction;

    public string Name;

    public GameAction(string name)
    {
        Name = name;
    }

    //public void ListenerAdd(UnityEvent actionAdd)
    //{
    //    actionAdd.AddListener(OnAction);
    //}

    //public void ListenerRemove(UnityEvent actionRemove)
    //{
    //    actionRemove.RemoveListener(OnAction);
    //}

    public void ActionAdd(UnityAction actionAdd)
    {
        OnAction += actionAdd;
    }

    public void ActionRemove(UnityAction actionRemove)
    {
        OnAction -= actionRemove;
    }

    public void ForceAction()
    {
        Debug.Log("Action Force: " + Name);

        OnAction?.Invoke();
    }
}
