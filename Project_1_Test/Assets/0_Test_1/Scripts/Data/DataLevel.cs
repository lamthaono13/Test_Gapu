using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Data/DataLevel")]
public class DataLevel : SerializedScriptableObject
{
    public TypeLevel TypeLevel;

    public GameObject ObjLevelLoad;

    public GameObject UiLevelLoad;
}

public enum TypeLevel
{
    Draw
}