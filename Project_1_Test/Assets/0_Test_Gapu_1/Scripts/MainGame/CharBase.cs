using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBase : ObjectBase
{
    [SerializeField] protected PhysicBase physicBase;

    public PhysicBase PhysicBase => physicBase;

    public override void Init()
    {
        base.Init();

        physicBase.Init();
    }
}
