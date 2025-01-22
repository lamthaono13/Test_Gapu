using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(menuName = "Data/DataGame")]
public class DataGame : SerializedScriptableObject
{
    public List<Level> ListLevels;
}

[System.Serializable]
public class Level
{
    public TypeLevel TypeLevel;
}