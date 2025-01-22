using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiWin : UiCanvas
{
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnChooseLevel;
    [SerializeField] private Button btnReplay;
    [SerializeField] private Button btnNext;

    private void Start()
    {
        btnBack.onClick.AddListener(OnClickBtnBack);
        btnChooseLevel.onClick.AddListener(OnClickBtnChooseLevel);
        btnReplay.onClick.AddListener(OnClickBtnReplay);
        btnNext.onClick.AddListener(OnClickBtnNext);
    }

    public override void Show(bool _isShow)
    {
        base.Show(_isShow);

        if (_isShow)
        {
            GameManager.Instance.SoundManager.PlaySoundInGame(false);
        }
    }

    void OnClickBtnBack()
    {
        GameManager.Instance.LoadingManager.OnLoading(TypeLoading.LoadingToLobby, () => { GameManager.Instance.LoadLobby(""); });
    }

    void OnClickBtnChooseLevel()
    {
        GameManager.Instance.LoadingManager.OnLoading(TypeLoading.LoadingToLobby, () => { GameManager.Instance.LoadLevel(""); });
    }

    void OnClickBtnReplay()
    {
        GameManager.Instance.LoadingManager.OnLoading(TypeLoading.LoadingToLobby, () => { GameManager.Instance.LoadLevel(""); });
    }

    void OnClickBtnNext()
    {
        GameManager.Instance.LoadingManager.OnLoading(TypeLoading.LoadingToLobby, () => { GameManager.Instance.LoadLevel(""); });
    }
}
