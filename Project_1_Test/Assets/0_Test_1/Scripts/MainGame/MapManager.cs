using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class MapManager : MonoBehaviour
{
    [SerializeField] protected UiMapManager uiMapManager;

    [SerializeField] protected MapActionManager mapActionManager;

    public UiMapManager UiMapManager => uiMapManager;

    public MapActionManager MapActionManager => mapActionManager;

    protected DataLevel dataLevel;

    public virtual async void Init()
    {
        mapActionManager.Init();

        LevelManager.Instance.GameActionManager.GetAction((int)MainGameAction.EndGame).ActionAdd(OnEndGame);

        await InstantiateMap();
    }

    public async Task InstantiateMap()
    {
        dataLevel = ResourceManager.Instance.LoadLevel("DataLevel/DataLevel" + LevelManager.Instance.GetCurrentLevel().ToString());

        Instantiate(dataLevel.ObjLevelLoad, this.transform);

        GameObject objUiGamePlay = Instantiate(dataLevel.UiLevelLoad, this.transform);

        uiMapManager.Init(objUiGamePlay.GetComponent<UiGameplay>());

        await Task.CompletedTask;
    }

    public abstract void OnEndGame();
}
