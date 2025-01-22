using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMapManager : MonoBehaviour
{
    private UiGameplay uiGameplay;

    public UiGameplay UiGameplay => uiGameplay;

    public virtual void Init(UiGameplay _uiGameplay)
    {
        uiGameplay = _uiGameplay;
    }
}
