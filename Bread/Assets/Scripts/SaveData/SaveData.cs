using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{

    [SerializeField] private SceneData _SceneData = new SceneData();
    private static bool exists;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if ( exists == false)
        {
            exists = true;
        }
        else { Destroy(gameObject); }
        LoadFromJason();
        if (!SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            loadCorrectScene();
        }
        foreach (toggleableObject obj in _SceneData.objs)
        {
        if(GameObject.Find(obj.name) == null)
            {
                Debug.LogWarning(obj.name + " not found");
                return;
            }
            GameObject.Find(obj.name).SetActive(false);
        }
    }
    public void SaveIntoJson()
    {
        string sceneData = JsonUtility.ToJson(_SceneData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/ObjectData.json", sceneData);
    }
    public void LoadFromJason()
    {
        _SceneData = JsonUtility.FromJson<SceneData>(System.IO.File.ReadAllText(Application.persistentDataPath + "/ObjectData.json"));
    }
    public void addObject(string objName, bool isEnabled)
    {
        toggleableObject obja = new toggleableObject { name = objName, enabled =isEnabled};
        _SceneData.objs.Add(obja);
    }
    public void updateObject(string name, bool newEnabled)
    {
        foreach(toggleableObject obje in _SceneData.objs)
        {
            if (obje.name.Equals(name))
            {
                obje.enabled = newEnabled;
                return;
            }
        }
    }
    public void removeObject(string name)
    {
        foreach (toggleableObject obje in _SceneData.objs)
        {
            if (obje.name.Equals(name))
            {
                _SceneData.objs.Remove(obje);
            }
        }
    }
    public void changeSceneName(string name)
    {
        _SceneData.sceneName = name;
    }

    public void OnApplicationQuit()
    {
        SaveIntoJson();
    }
    public void loadCorrectScene()
    {
        if(_SceneData.sceneName == null || _SceneData.sceneName.Length == 0)
        {
            _SceneData.sceneName = "TutorialZone";
        }
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName(_SceneData.sceneName))
        {
            Debug.Log(_SceneData.sceneName);
            SceneManager.LoadScene(_SceneData.sceneName);
        }
    }
    public void quitGame()
    {
        SaveIntoJson();
        Application.Quit();
    }
}

[System.Serializable]
public class SceneData
{
    public List<toggleableObject> objs = new List<toggleableObject>();
    public string sceneName;
}


[System.Serializable]
public class toggleableObject
{
    public string name;
    public bool enabled;
}