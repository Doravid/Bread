using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnInManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Accept, TurnIn, toDestroy;
    [SerializeField]
    private Quest quest;
    [SerializeField]
    private PlayerQuests playerQuests;

    
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
    public void tryQuestTurnIn()
    {
        if (quest.isActive && (quest.quantity - quest.quantityCollected) <= 0)
        {
            quest.isActive = false;
            quest.isComplete = true;
            playerQuests._quests.Add(quest.id);
            playerQuests._quests_.Remove(quest);
            Destroy(gameObject);
            Destroy(toDestroy);
        }
    }
}
