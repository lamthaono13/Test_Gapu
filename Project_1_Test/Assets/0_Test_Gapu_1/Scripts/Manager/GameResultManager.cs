using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResultManager : MonoBehaviour
{
    private GameResult gameResult;

    public void Init()
    {
        gameResult = GameResult.NotDeciced;
    }

    public GameResult GetGameResult()
    {
        return gameResult;
    }

    public void SetGameResult(GameResult _gameResult)
    {
        gameResult = _gameResult;
    }
}

public enum GameResult
{
    NotDeciced,
    Win,
    Lose
}