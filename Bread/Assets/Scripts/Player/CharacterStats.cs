using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    //Regenerative Stats (Non-permanant)
    [SerializeField, Header("Status")]
    private int currentHealth, currentMana;
   
    //Stats that affect attacks, skills, etc...
    [SerializeField, Header("Player Stat")]
    private int strength, luck, bread, maxHealth, maxMana;

    // Each quest has a unique ID, this array stores all the quest IDs that the player has beaten
    [SerializeField]
    public PlayerQuests questZ;



    // Start is called before the first frame update
    void Start()
    {
        Save.load(this);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Save.saveStats(this);
        }
    }
    //GETTERS
    public int getCurrentHealth(){return currentHealth;}
    public int getCurrentMana(){return currentMana;}
    public int getStrength(){return strength;}
    public int getLuck(){return luck;}
    public int getBread(){return bread;}
    public int getMaxHealth(){return maxHealth;}
    public int getMaxMana(){return maxMana;
    }public List<int> getCompletedQuests() { return questZ._quests; }
    //SETTERS
    public void setCurrentHealth(int currentHealth)
    {
        this.currentHealth = currentHealth;
    }
    public void setCurrentMana(int currentMana)
    {
        this.currentMana = currentMana;
    }
    public void setStrength(int strength)
    {
        this.strength = strength;
    }
    public void setLuck(int luck)
    {
        this.luck = luck;
    }
    public void setBread(int bread)
    {
        this.bread = bread;
    }
    public void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }
    public void setMaxMana(int maxMana)
    {
        this.maxMana = maxMana;
    }
    public void setCompletedQuests(List<int> completedQuests)
    {
        this.questZ._quests = completedQuests;
    }
    //Custom Functions
    public void dealDamage(int damage)
    {
        this.currentHealth -= damage;
    }
    public void addCompletedQuest(int questId)
    {
        this.questZ._quests.Add(questId);
    }
}
