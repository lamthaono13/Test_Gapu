using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiMain : UiCanvas
{
    [SerializeField] private Button btnBack;

    [SerializeField] private Button btnReplay;

    [SerializeField] private Button btnKey;

    [SerializeField] private Button btnHint;

    [SerializeField] private Button btnNext;

    private void Start()
    {
        btnBack.onClick.AddListener(OnClickBtnBack);

        btnReplay.onClick.AddListener(OnClickBtnReplay);

        btnKey.onClick.AddListener(OnClickBtnKey);

        btnHint.onClick.AddListener(OnClickBtnHint);

        btnNext.onClick.AddListener(OnClickBtnNext);
    }

    private void OnClickBtnBack()
    {
        GameManager.Instance.LoadingManager.OnLoading(TypeLoading.LoadingToLobby, () => { GameManager.Instance.LoadLobby(""); });
    }

    private void OnClickBtnReplay()
    {
        GameManager.Instance.LoadingManager.OnLoading(TypeLoading.LoadingToLobby, () => { GameManager.Instance.LoadLevel(""); });
    }

    private void OnClickBtnKey()
    {
        GameManager.Instance.DataManager.AddKey(1);
    }

    private void OnClickBtnHint()
    {
        int a = GameManager.Instance.DataManager.GetKey();

        if(a > 0)
        {
            GameManager.Instance.DataManager.AddKey(-1);
        }
    }

    private void OnClickBtnNext()
    {
        GameManager.Instance.LoadingManager.OnLoading(TypeLoading.LoadingToLobby, () => { GameManager.Instance.LoadLevel(""); });
    }
}
