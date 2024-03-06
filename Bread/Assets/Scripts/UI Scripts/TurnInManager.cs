using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurnInManager : MonoBehaviour
{
    public class VariableHolder
    {

    }
    [SerializeField, Header("Set These Varibles")]
    private Quest quest;
    [SerializeField] private GameObject npc;
    [Space, Header("Do not touch. I'm not sure hiding these breaks stuff, so they stay"), Space]

    [SerializeField]
    private GameObject Accept;
    [SerializeField]
    private GameObject TurnIn, ButtonPrefab;
    [SerializeField]
    private PlayerQuests playerQuests;
    [SerializeField]
    private GameObject prog;
    [SerializeField] private QuestManager questManager;

    [SerializeField] Image questIcon;
    [SerializeField] TextMeshProUGUI title, description;

    public VariableHolder instance = new VariableHolder();

    private GameObject button;

    private List<int> completedQuestIds;
    private void Awake()
    {
        Accept.SetActive(false);
        TurnIn.SetActive(false);
        title.text = quest.questName;
        description.text = quest.questDescription;
        questIcon.sprite = quest.questIcon;
        if (questManager == null)
        {
            questManager = GameObject.Find("QuestManager").GetComponent<QuestManager>();
        }
    }

    void Start()
    {
        initButton();
        if (quest.isActive)
        {
            TurnIn.SetActive(true);
        }
        else { Accept.SetActive(true); }
        updateProgress();

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

            refreshQuests();
        }
    }
    public void acceptQuest()
    {
        questManager.startQuest(quest);
        Accept.gameObject.SetActive(false);
        TurnIn.gameObject.SetActive(true);
    }
    private void parseCompletedQuests()
    {
        completedQuestIds = new List<int>();
        foreach (Quest quest in playerQuests.completedQuests)
        {
            completedQuestIds.Add(quest.id);
        }
    }

    public void initButton(){
        parseCompletedQuests();
        if (button != null) return;
        if (completedQuestIds.Contains(quest.previousQuestId) || quest.previousQuestId == 0) {

            Debug.LogWarning(ButtonPrefab == null);
            GameObject gameObject1 = Instantiate(ButtonPrefab, npc.transform);
            button = gameObject1;
        QuestInit qInit = button.GetComponent<QuestInit>();
        button.GetComponent<QuestInit>().description = gameObject;
        button.GetComponent<Button>().onClick.AddListener(customOnClick);
            qInit.questA = quest;
            qInit.init();
        }
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
    private void customOnClick()
    {
        int numquests = transform.parent.childCount;
        for(int i = 0; i < numquests; i++)
        {
            transform.parent.GetChild(i).GetChild(0).gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void refreshQuests()
    {
        updateProgress();
        int numQuests = transform.parent.childCount;
        for(int i = 0; i < numQuests; i++)
        {
            transform.parent.GetChild(i).GetComponent<TurnInManager>().initButton();
        }
    }
    private void updateProgress()
    {
        TMPro.TextMeshProUGUI progress = prog.GetComponent<TMPro.TextMeshProUGUI>();
        if (progress != null)
        {
            progress.text = quest.quantityCollected + "/" + quest.quantity;
        }
    }
}
