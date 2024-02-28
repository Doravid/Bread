using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterStats : MonoBehaviour
{
    

    public string warpPoint;
    //Regenerative Stats (Non-permanant)
    [SerializeField, Header("Status")]
    private int currentHealth, currentMana, xp;
   
    //Stats that affect attacks, skills, etc...
    [SerializeField, Header("Permanant Stats")]
    private int strength, level, maxHealth, maxMana, xpToNextLevel;

    // Each quest has a unique ID, this array stores all the quest IDs that the player has beaten
    [SerializeField]
    public PlayerQuests questZ;
    [SerializeField]
    private float healthTimer, manaTimer, healthTimerLength, manaTimerLength;
    [SerializeField]
    private int healthRegenAmount, manaRegenAmount;

    private void Awake()
    {
        Save.load(this);
    }

    void Start()
    {
        if (warpPoint != null && warpPoint != "" && GameObject.Find(warpPoint) != null)
        {
            
            transform.position = GameObject.Find(warpPoint).transform.position;
            warpPoint = "";
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Save.saveStats(this);
        }
        if(healthTimer <= 0 && currentHealth < maxHealth)
        {
            currentHealth += healthRegenAmount;
            healthTimer += healthTimerLength;
        }
        if (manaTimer <= 0 && currentMana < maxMana)
        {
            currentMana += manaRegenAmount;
            manaTimer += manaTimerLength;
        }
        if(healthTimer > 0)
        {
            healthTimer -= Time.deltaTime;
        }
        if(manaTimer > 0)
        {
            manaTimer -= Time.deltaTime;
        }
        if(xp >= xpToNextLevel)
        {
            levelUp();
        }
        
    }
    //GETTERS
    public int getCurrentHealth(){return currentHealth;}
    public int getCurrentMana(){return currentMana;}
    public int getStrength(){return strength;}
    public int getXp(){return xp;}
    public int getLevel(){return level;}
    public int getMaxHealth(){return maxHealth;}
    public int getMaxMana() { return maxMana; }
    public int getXpToNextLevel(){return xpToNextLevel;}
    public int getHealthRegen(){return healthRegenAmount;}
    public int getManaRegen(){return manaRegenAmount;}
    public List<int> getCompletedQuests() { return questZ._quests; }
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
    public void setXp(int xp)
    {
        this.xp = xp;
    }
    public void setXpToNextLevel(int xpToNext)
    {
        this.xpToNextLevel = xpToNext;
    }
    public void setLevel(int level)
    {
        this.level = level;
    }
    public void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }
    public void setMaxMana(int maxMana)
    {
        this.maxMana = maxMana;
    } 
    public void setHealthRegen(int healthRegen)
    {
        this.healthRegenAmount = healthRegen;
    }
    public void setManaRegen(int manaRegen)
    {
        this.manaRegenAmount = manaRegen;
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
    private void levelUp()
    {
        xp -= xpToNextLevel;
        level++;
        maxHealth += 10;
        maxMana += 10;
        manaRegenAmount++;
        healthRegenAmount++;
        strength++;
        xpToNextLevel = (int)((float)xpToNextLevel * 1.2);
    }
    
}
