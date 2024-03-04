using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField]
    private GameObject prog;
    private void Awake()
    {
        Accept.SetActive(false);
        TurnIn.SetActive(false);
    }

    void Start()
    {
        Debug.Log("Quest: " + quest.id + " is active? | " + quest.isActive);
            if (quest.isActive)
            {
                TurnIn.SetActive(true);
        }
        else { Accept.SetActive(true);}

            TMPro.TextMeshProUGUI progress = prog.GetComponent<TMPro.TextMeshProUGUI>();  
        if (progress != null)
        {
            Debug.Log(progress.text);
            progress.text = quest.quantityCollected + "/" + quest.quantity;
            Debug.Log(progress.text);
        }
    }
    public void tryQuestTurnIn()
    {
        if (quest.isActive && (quest.quantity - quest.quantityCollected) <= 0)
        {
            quest.isActive = false;
            quest.isComplete = true;
            playerQuests.completedQuests.Add(quest);
            playerQuests.currentQuests.Remove(quest);
            Destroy(gameObject);
            Destroy(toDestroy);
            questRewards();
        }
    }
    public void acceptQuest()
    {

    }

    private void questRewards()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null) { return; }

        CharacterStats player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        if (quest.questReward.XP != 0)
        {
            player.setXp(quest.questReward.XP + player.getXp());
        }
        if (quest.questReward.Strength != 0)
        {
            player.setStrength(player.getStrength() + quest.questReward.Strength);
        }
        if (quest.questReward.MaxMana != 0)
        {
            player.setMaxMana(quest.questReward.MaxMana + player.getMaxMana());
        }
        if (quest.questReward.MaxHealth != 0)
        {
            player.setMaxHealth(quest.questReward.MaxHealth + player.getMaxHealth());

        }
        if (quest.questReward.Gold != 0)
        {
            //GOLD IS FAKE AT THE MOMENT SORRY
        }
    }
}
