using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMapActionManager : MapActionManager
{
    public override void Init()
    {
        base.Init();
    }

    public override void InitActionMap()
    {
        base.InitActionMap();

        GameActions = new List<GameAction>();

        for(int i = 0; i < System.Enum.GetValues(typeof(DrawGameAction)).Length; i++)
        {
            GameActions.Add(new GameAction(((DrawGameAction)i).ToString()));
        }
    }
}

public enum DrawGameAction
{
    StartGame,
    Pause,
    StartCount,
    EndGame
}
