using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMapManager : MapManager
{
    [SerializeField] private List<ObjectBase> listAllObject;

    public override void Init()
    {
        base.Init();

        for (int i = 0; i < listAllObject.Count; i++)
        {
            listAllObject[i].Init();
        }
    }
}