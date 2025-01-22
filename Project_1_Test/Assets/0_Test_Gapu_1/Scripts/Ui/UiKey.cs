using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UiKey : UiCanvas
{
    [SerializeField] private TextMeshProUGUI textKey;
    [SerializeField] private Image imgKey;
    [SerializeField] private Button btnAdd;

    Tween tween;

    private void Start()
    {
        btnAdd.onClick.AddListener(OnClickBtnAdd);

        int currentKey = GameManager.Instance.DataManager.GetKey();

        textKey.text = currentKey.ToString();

        GameManager.Instance.DataManager.OnChangeKey += OnChangeKey;
    }

    void OnClickBtnAdd()
    {
        GameManager.Instance.DataManager.AddKey(1);
    }

    public void OnChangeKey()
    {
        //if(tween != null)
        //{
        //    tween.Kill();
        //}
        //else
        //{
        //    tween = imgKey.transform.DOScale(1.1f, 0.2f).OnComplete(() => { tween = null; });
        //}

        int currentKey = GameManager.Instance.DataManager.GetKey();

        textKey.text = currentKey.ToString();
    }
}
