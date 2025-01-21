using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    private Dictionary<string, GameObject> dicLoadGameObject;
    private Dictionary<string, DataLevel> dicLoadLevel;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        Instance = this;

        dicLoadGameObject = new Dictionary<string, GameObject>();

        dicLoadLevel = new Dictionary<string, DataLevel>();
    }

    public GameObject Load(string path)
    {
        if (!dicLoadGameObject.ContainsKey(path))
        {
            GameObject objLoad = Resources.Load<GameObject>(path);

            dicLoadGameObject.Add(path, objLoad);

            return objLoad;
        }
        else
        {
            return dicLoadGameObject[path] as GameObject;
        }
    }

    public DataLevel LoadLevel(string path)
    {
        if (!dicLoadLevel.ContainsKey(path))
        {
            DataLevel objLoad = Resources.Load<DataLevel>(path);

            dicLoadLevel.Add(path, objLoad);

            return objLoad;
        }
        else
        {
            return dicLoadLevel[path];
        }
    }

    private void OnDestroy()
    {
        //foreach(var item in dicLoad)
        //{
        //    if(item.Value != null)
        //    {
        //        Resources.UnloadAsset(item.Value);
        //    }
        //}

        dicLoadGameObject.Clear();
        dicLoadLevel.Clear();
    }
}
