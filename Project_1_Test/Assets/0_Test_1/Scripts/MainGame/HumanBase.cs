using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBase : CharBase
{
    public override void OnStartCount()
    {
        base.OnStartCount();

        physicBase.Rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Gai"))
        {
            LevelManager.Instance.GameResultManager.SetGameResult(GameResult.Lose);

            Destroy(gameObject);
        }
    }
}
