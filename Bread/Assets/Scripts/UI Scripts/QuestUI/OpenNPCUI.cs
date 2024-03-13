using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNPCUI : MonoBehaviour
{
    private bool playerInSightRange;
    public LayerMask whatIsPlayer;
    public GameObject buttonPromt;
    public QuestManager manager;

    // Start is called before the first frame update
    void Start()
    {        
        buttonPromt.SetActive(false);
        whatIsPlayer = LayerMask.GetMask("WhatIsPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, 5f, whatIsPlayer);
        if (playerInSightRange)
        {
            buttonPromt.SetActive(!manager.isInUI());
        }
        else {

            Cursor.visible = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && playerInSightRange){
            manager.toggleMenu();
            
        }
    }
}
