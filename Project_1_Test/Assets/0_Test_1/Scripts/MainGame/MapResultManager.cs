using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MapResultManager : MonoBehaviour
{
    protected GameResult gameResult;

    public virtual void Init()
    {
        gameResult = GameResult.NotDeciced;
    }

    public GameResult GetGameResult()
    {
        return gameResult;
    }

    public abstract void SetGameResult(GameResult _gameResult);
}
