using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTextPromt : MonoBehaviour
{
    private bool playerInSightRange;
    public LayerMask whatIsPlayer;
    public GameObject objectToTurnOn;
    public Quest quest;

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, 5f, whatIsPlayer);
        if (Input.GetKeyDown(KeyCode.E) && playerInSightRange)
        {
            objectToTurnOn.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void resetMouse()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        quest.quantityCollected++;
    }
}
