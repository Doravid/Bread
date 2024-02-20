using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcceptedOrTurnIn : MonoBehaviour
{
    [SerializeField]
    private GameObject Accept, TurnIn;
    [SerializeField]
    private Quest quest;
    void Start()
    {
        Accept.SetActive(true);
        TurnIn.SetActive(false);
            if (quest.isActive)
            {
                Accept.SetActive(false);
                TurnIn.SetActive(true);
            }

    }
}
