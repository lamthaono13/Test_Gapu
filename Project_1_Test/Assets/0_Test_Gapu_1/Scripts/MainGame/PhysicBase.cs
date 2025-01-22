using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicBase : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private List<Collider2D> colls;

    public Rigidbody2D Rb => rb;

    public virtual void Init()
    {

    }

    public virtual void AddForce(Vector2 forceAdd, ForceMode2D forceMode)
    {
        rb.AddForce(forceAdd, forceMode);
    }
}
