using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGameplay : UiCanvas
{
    //[SerializeField] private UiResultGame uiResultGame;

    //[SerializeField] private UiCountTime uiCountTime;

    //public UiResultGame UiResultGame => uiResultGame;

    //public UiCountTime UiCountTime => uiCountTime;

    public List<UiCanvas> UiPoppups;

    public T GetUiPoppup<T>(int id)
    {
        return UiPoppups[id].gameObject.GetComponent<T>();
    }

    public UiCanvas GetCanvas(int id)
    {
        return UiPoppups[id];
    }
}
