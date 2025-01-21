using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTimeManager : MonoBehaviour
{
    private bool canCount;

    [SerializeField] private float timeCount;

    private float count;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canCount)
        {
            if(count > 0)
            {
                count -= Time.deltaTime;

                LevelManager.Instance.MapManager.UiMapManager.UiGameplay.GetUiPoppup<UiCountTime>((int)TypePopupDraw.CountTime).SetTime(count, false);
            }
            else
            {
                canCount = false;

                LevelManager.Instance.MapManager.UiMapManager.UiGameplay.GetUiPoppup<UiCountTime>((int)TypePopupDraw.CountTime).SetTime(count, true);

                LevelManager.Instance.GameActionManager.GetAction((int)MainGameAction.EndGame).ForceAction();
            }
        }
    }

    public void Init()
    {
        LevelManager.Instance.MapManager.MapActionManager.GetAction((int)DrawGameAction.StartCount).ActionAdd(OnStartCount);
    }

    public void OnStartCount()
    {
        count = timeCount;

        Debug.Log(LevelManager.Instance.MapManager.UiMapManager.UiGameplay.GetCanvas((int)TypePopupDraw.CountTime));

        LevelManager.Instance.MapManager.UiMapManager.UiGameplay.GetUiPoppup<UiCountTime>((int)TypePopupDraw.CountTime).SetTime(count, false);

        LevelManager.Instance.MapManager.UiMapManager.UiGameplay.GetUiPoppup<UiCountTime>((int)TypePopupDraw.CountTime).Show(true);

        canCount = true;
    }
}
