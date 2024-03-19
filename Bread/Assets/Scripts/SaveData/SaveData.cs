using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private ObjectData _ObjectData = new ObjectData();
    private void Start()
    {
        LoadFromJason();
        foreach (toggleableObject obj in _ObjectData.objs)
        {
            try
            {
                Destroy(GameObject.Find(obj.name));
            }
            catch {
                Debug.LogWarning(obj.name + " not found");
            }
        }
    }


    public void SaveIntoJson()
    {
        string potion = JsonUtility.ToJson(_ObjectData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/ObjectData.json", potion);
        Debug.Log(Application.persistentDataPath);
    }
    public void LoadFromJason()
    {
        _ObjectData = JsonUtility.FromJson<ObjectData>(System.IO.File.ReadAllText(Application.persistentDataPath + "/ObjectData.json"));
    }
}

[System.Serializable]
public class ObjectData
{
    public List<toggleableObject> objs = new List<toggleableObject>();
}

[System.Serializable]
public class toggleableObject
{
    public string name;
    public bool enabled;
}
