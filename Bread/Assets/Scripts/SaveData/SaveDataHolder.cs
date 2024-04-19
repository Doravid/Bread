using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDataHolder : MonoBehaviour
{
public void loadSceneFromSaveData()
    {
        Time.timeScale = 1.0f;
        GameObject.Find("SaveManager").GetComponent<SaveData>().loadCorrectScene();
    }
}
