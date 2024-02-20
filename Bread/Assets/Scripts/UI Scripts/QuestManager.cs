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
    public  List<Quest> activeQuests = new List<Quest>();
    public void startQuest(Quest newQuest)
    {
        activeQuests.Add(newQuest);
        newQuest.isActive = true;
    }
    public void incrementQuests(GameObject obj)
    {
        foreach (Quest quest in activeQuests)
        {
            if (quest.collection.Equals(obj) && !quest.isComplete)
            {
                quest.quantity = quest.quantity - 1; 
                if(quest.quantity <= 0)
                {
                    activeQuests.Remove(quest);
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
