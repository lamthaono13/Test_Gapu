using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTimeManager : MonoBehaviour
{
    private bool canCount;

    private float timeCount;

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

                LevelManager.Instance.UiGameManager.UiGameplay.UiCountTime.SetTime(count, false);
            }
            else
            {
                canCount = false;

                LevelManager.Instance.UiGameManager.UiGameplay.UiCountTime.SetTime(count, true);

                LevelManager.Instance.GameActionManager.EndGameAction.ForceAction();
            }
        }
    }

    public void Init(float _timeCount)
    {
        timeCount = _timeCount;

        LevelManager.Instance.GameActionManager.StartCountAction.ActionAdd(OnStartCount);
    }

    public void OnStartCount()
    {
        count = timeCount;

        LevelManager.Instance.UiGameManager.UiGameplay.UiCountTime.SetTime(count, false);

        LevelManager.Instance.UiGameManager.UiGameplay.UiCountTime.Show(true);

        canCount = true;
    }
}
