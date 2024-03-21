using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNPCUI : MonoBehaviour
{
    private bool shouldPrompt;
    public GameObject buttonPromt;
    public QuestManager manager;

    // Start is called before the first frame update
    void Start()
    {        
        buttonPromt.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonPromt.SetActive(!manager.isInUI());
            shouldPrompt = true;
        }
    }
    private void Update()
    {
        if (shouldPrompt && Input.GetKeyDown(KeyCode.E))
        {
            manager.toggleMenu();
            buttonPromt.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        buttonPromt.SetActive(false);
        shouldPrompt=false;
    }
}