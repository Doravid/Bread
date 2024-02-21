using SUPERCharacter;
using System.Collections.Generic;
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)){
            toggleMenu();
        }
    }
    public void startQuest(Quest newQuest)
    {
        Debug.Log(newQuest.quantity);
        playerQuests._quests_.Add(newQuest);
        newQuest.isActive = true;
    }
    public void incrementQuests(GameObject obj)
    {
        foreach (Quest quest in playerQuests._quests_)
        {
            Debug.Log("COLLECTION: " + quest.collection);
            Debug.Log("OBJ: " + obj);

            if (obj.GetComponent<BasicEnemyAI>().enemyName == quest.collection.GetComponent<BasicEnemyAI>().enemyName && !quest.isComplete)
            {
                quest.quantityCollected++; 
                if(quest.quantity - quest.quantityCollected <= 0)
                {
                    playerQuests._quests_.Remove(quest);
                    quest.isComplete = true;
                    quest.isActive = false;
                }
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
            panelUI.SetActive(true);
        }
        else
        {
            player.GetComponent<SUPERCharacterAIO>().UnpausePlayer();
            panelUI.SetActive(false);
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
