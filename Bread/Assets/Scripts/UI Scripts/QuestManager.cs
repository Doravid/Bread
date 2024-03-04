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
    private GameObject descriptionHolder;
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
        Debug.Log(newQuest.quantity);
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
                //Legacy Code
/*                if(quest.quantity - quest.quantityCollected <= 0)
                {
                    playerQuests._quests_.Remove(quest);
                    quest.isComplete = true;
                    quest.isActive = false;
                }*/
            }
        }
    }
    
    //UI Managment (I may want to move these later as they server a different function to the rest of the class)
    public void toggleMenu()
    {
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
    public void cancelSelection()
    {
        foreach(Transform child in descriptionHolder.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    public bool isInUI()
    {
        return this.inUI;
    }
}





//Legacy Code

/*    public class quest {
        
        private GameObject TargetObject;
        private int Quantity;
        private bool isComplete;
        public quest(GameObject targetObject, int quantity)
        {
            this.TargetObject = targetObject;
            this.Quantity = quantity;
            this.isComplete = false;
        }
        //Setters and Getters (Is Complete is overloaded)
        public GameObject getTargetObject() { return this.TargetObject; }
        public int getQuantity() {  return this.Quantity; }
        public bool IsComplete() {  return this.isComplete; }
        public void setTargetObject(GameObject obj) {  if(obj != null) this.TargetObject = obj; }
        public void setQuantity(int quant) {  this.Quantity = quant; }
        public void IsComplete(bool isComplete) {  this.isComplete = isComplete; }

    }*/
