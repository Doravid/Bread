using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWarp : MonoBehaviour
{
    public string sceneName;
    public string sceneStartLocation;
    private SaveData saveData;
    private void Start()
    {
        saveData = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveData>();
        if (sceneName == null)
        {
            sceneName = SceneManager.GetActiveScene().name; 
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            saveData.changeSceneName(sceneName);
            saveData.SaveIntoJson();
            other.GetComponent<CharacterStats>().warpPoint = sceneStartLocation;
            Save.saveStats(other.GetComponent<CharacterStats>());
            SceneManager.LoadScene(sceneName);
            
        }
    }
    
}
