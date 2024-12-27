using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    public static LobbyManager Instance;

    [SerializeField] private UiLobbyManager uiLobbyManager;

    [SerializeField] private float timeWaitLoadDataDone;

    public UiLobbyManager UiLobbyManager => uiLobbyManager;

    [SerializeField] private Camera cameraLobby;

    public Camera Camera => cameraLobby;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameManager.Instance.SoundManager.PlaySoundBgLobby(true);

        StartCoroutine(WaitForLoadingData());

        uiLobbyManager.Init();
    }

    IEnumerator WaitForLoadingData()
    {
        yield return new WaitForSeconds(timeWaitLoadDataDone);
        GameManager.Instance.OnLoadingSceneDone(GameState.LOBBY);
    }

    public void OnClickBtn()
    {
        GameManager.Instance.LoadingManager.OnLoading(TypeLoading.LoadingToInGame, () => 
        {
            GameManager.Instance.LoadScene(2, TypeLoadScene.Additive, "");
        });
    }
}