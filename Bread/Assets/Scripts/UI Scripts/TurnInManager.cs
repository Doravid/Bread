using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnInManager : MonoBehaviour
{
    [SerializeField] string npcName;
    [SerializeField]
    private GameObject Accept, TurnIn, ButtonPrefab;
    [SerializeField]
    private Quest quest;
    [SerializeField]
    private PlayerQuests playerQuests;
    [SerializeField]
    private GameObject prog;
    [SerializeField] private QuestManager questManager;

    [SerializeField] Image questIcon;
    [SerializeField] TextMeshProUGUI title, description;

    private GameObject button;
    private void Awake()
    {
        Accept.SetActive(false);
        TurnIn.SetActive(false);
        title.text = quest.questName;
        description.text = quest.questDescription;
        questIcon.sprite = quest.questIcon;
    }

    void Start()
    {
        GameObject parent = GameObject.Find(npcName);
        button = Instantiate(ButtonPrefab, parent.transform);
        button.GetComponent<QuestInit>().description = gameObject;
       

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
            Destroy(button);
            questRewards();
        }
    }
    public void acceptQuest()
    {
        questManager.startQuest(quest);
        Accept.gameObject.SetActive(false);
        TurnIn.gameObject.SetActive(true);
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
