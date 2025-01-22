using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapActionManager : MonoBehaviour
{
    public List<GameAction> GameActions;

    public virtual void Init()
    {
        InitActionMap();
    }

    public virtual void InitActionMap()
    {

    }

    public GameAction GetAction(int id)
    {
        return GameActions[id];
    }
}