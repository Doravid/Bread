 using SUPERCharacter;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;
public class QuestManager : MonoBehaviour
{
    [SerializeField]
    GameObject panelUI;
    private bool inUI;
    private GameObject player;
    [SerializeField]
    private PlayerQuests playerQuests;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (panelUI == null){ panelUI = GameObject.FindGameObjectWithTag("QuestMenu"); }
        panelUI.SetActive(false);
        inUI = false;
    }
    public void startQuest(Quest newQuest)
    {
        playerQuests.currentQuests.Add(newQuest);
        newQuest.isActive = true;
    }
    public void enemyKilled(GameObject obj)
    {
        incrementQuests(obj);
        BasicEnemyAI enemy = obj.GetComponent<BasicEnemyAI>();
        player.GetComponent<CharacterStats>().setXp(player.GetComponent<CharacterStats>().getXp() + enemy.xpValue);
    }
    private void incrementQuests(GameObject obj)
    {

        foreach (Quest quest in playerQuests.currentQuests)
        {
            if (obj.GetComponent<BasicEnemyAI>().enemyName == quest.collection.GetComponent<BasicEnemyAI>().enemyName && !quest.isComplete)
            {
                quest.quantityCollected++; 
            }
        }
    }
    
    //UI Managment (I may want to move these later as they server a different function to the rest of the class)
    public void toggleMenu()
    {
        GameObject right = panelUI.transform.GetChild(1).gameObject;
        for(int i = 0; i < right.transform.childCount; i++)
        {
            if(right.transform.GetChild(i).GetComponent<TurnInManager>() != null)
            {
                right.transform.GetChild(i).GetComponent<TurnInManager>().refreshQuests();
            }
            
        }
        if (!inUI)
        {
            inUI = true;
            player.GetComponent<SUPERCharacterAIO>().PausePlayer(PauseModes.FreezeInPlace);
            player.GetComponent<PlayerAttack>().enabled = false;
            panelUI.SetActive(true);
        }
        else
        {
            player.GetComponent<SUPERCharacterAIO>().UnpausePlayer();
            panelUI.SetActive(false);
            player.GetComponent<PlayerAttack>().enabled = true;
            inUI = false;
        }
    }

    public bool isInUI()
    {
        return this.inUI;
    }
}
