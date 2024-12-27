using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGameplay : UiCanvas
{
    [SerializeField] private Button btnBack;

    [SerializeField] private Button btnReplay;

    [SerializeField] private UiResultGame uiResultGame;

    [SerializeField] private UiCountTime uiCountTime;

    public UiResultGame UiResultGame => uiResultGame;

    public UiCountTime UiCountTime => uiCountTime;

    private void Start()
    {
        btnBack.onClick.AddListener(OnClickBtnBack);

        btnReplay.onClick.AddListener(OnClickBtnReplay);
    }

    private void OnClickBtnBack()
    {
        GameManager.Instance.LoadingManager.OnLoading(TypeLoading.LoadingToLobby, () => { GameManager.Instance.LoadLobby(""); });
    }

    private void OnClickBtnReplay()
    {
        GameManager.Instance.LoadingManager.OnLoading(TypeLoading.LoadingToLobby, () => { GameManager.Instance.LoadLevel(""); });
    }
}
