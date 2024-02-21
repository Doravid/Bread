using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelWarp : MonoBehaviour
{
    public string sceneName;
    [SerializeField]
    Scene scene;
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
            SceneManager.LoadScene(sceneName);

        }
    }
    
}
