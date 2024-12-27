using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bounce : SpecialObject
{
    [SerializeField] private GameObject objAnim;

    public override void Init()
    {
        base.Init();
    }

    public override void OnInteractChar()
    {
        base.OnInteractChar();

        objAnim.transform.DOScaleX(0.6f, 0.1f).OnComplete(() => { objAnim.transform.DOScaleX(1, 0.1f); });
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Human"))
        {
            OnInteractChar();
        }
    }
}
