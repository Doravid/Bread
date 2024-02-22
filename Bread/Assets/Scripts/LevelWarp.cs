using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWarp : MonoBehaviour
{
    public string sceneName;
    public string sceneStartLocation;
    private void Start()
    {
        if(sceneName == null)
        {
            sceneName = SceneManager.GetActiveScene().name; 
        }
    }
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<CharacterStats>().warpPoint = sceneStartLocation;
            Save.saveStats(other.GetComponent<CharacterStats>());
            SceneManager.LoadScene(sceneName);
            
        }
    }
    
}
