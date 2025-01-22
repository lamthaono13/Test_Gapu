using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameActionManager : MonoBehaviour
{
    //public GameAction GameStartAction;

    //public GameAction PauseAction;

    //public GameAction StartCountAction;

    //public GameAction EndGameAction;

    public List<GameAction> GameActions; 

    public void Init()
    {
        InitActionGame();

        //StartCountAction.ActionAdd(() => { Debug.Log("123"); });
    }

    public void InitActionGame()
    {
        GameActions = new List<GameAction>();

        for (int i = 0; i < System.Enum.GetValues(typeof(MainGameAction)).Length; i++)
        {
            GameActions.Add(new GameAction(((MainGameAction)i).ToString()));
        }

        //GameStartAction = new GameAction(MainGameAction.GameStart.ToString());

        //PauseAction = new GameAction(MainGameAction.Pause.ToString());

        //EndGameAction = new GameAction(MainGameAction.EndGame.ToString());
    }

    public GameAction GetAction(int id)
    {
        return GameActions[id];
    }
}

public enum MainGameAction
{
    GameStart,
    Pause,
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
