using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterStats : MonoBehaviour
{

    //Regenerative Stats (Non-permanant)
    [SerializeField, Header("Status")]
    private int currentHealth; 
    [SerializeField]
    private int currentMana, xp;

    [SerializeField, Header("Permanant Stats")]
    private int strength;
    [SerializeField] private int level, maxHealth, maxMana, xpToNextLevel;

    // Each quest has a unique ID, this array stores all the quest IDs that the player has beaten
    [SerializeField, Header("Quest List")]
    public PlayerQuests playerQuests;
    [SerializeField, Header("Quest List")]
    public InventoryManager playerInventory;
    [Header("Class")]
    public Class currentClass;
    public string warpPoint;


    private float regenTimer, regenTimerLength = 1;
    [SerializeField, Header("Regeneration Value")]
    private int healthRegenAmount, manaRegenAmount;

    private void Awake()
    {
        Save.load(this);
        Instantiate(currentClass.classModel, transform);
    }
    void Start()
    {
        if (warpPoint != null && warpPoint != "" && GameObject.Find(warpPoint) != null)
        {
            Debug.Log("Warping");
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
        if(regenTimer <= 0)
        {
            if(currentHealth < maxHealth)
            {
                if(currentHealth + healthRegenAmount > maxHealth)
                {
                    currentHealth = maxHealth;
                }
                else
                {
                    currentHealth += healthRegenAmount;
                }
            }

            if (currentMana < maxMana)
            {
                if (currentMana + manaRegenAmount > maxMana)
                {
                    currentMana = maxMana;
                }
                else
                {
                    currentMana += manaRegenAmount;
                }
            }
            
            regenTimer += regenTimerLength;
        }

        if(regenTimer > 0)
        {
            regenTimer -= Time.deltaTime;
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
    public List<Quest> getCompletedQuests() { return playerQuests.completedQuests; }
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
    public void setCompletedQuests(List<Quest> completedQuests)
    {
        this.playerQuests.completedQuests = completedQuests;
    }
    //Custom Functions
    public void dealDamage(int damage)
    {
        this.currentHealth -= damage;
    }
    public void addCompletedQuest(Quest quest)
    {
        this.playerQuests.completedQuests.Add(quest);
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
    public void loadBuff(PlayerBuff buff)
    {
        Debug.Log(buff.Strength);
            if (buff.alreadyApplied) return;
        //ADDS UNAPPLIED BUFFS to: XP, Strength, MaxMana, and MaxHealth.
        xp += buff.XP;
        strength += buff.Strength;
        maxMana += buff.MaxMana;
        maxHealth += buff.MaxHealth;
        buff.alreadyApplied = true;
    }

    public void removeBuff(PlayerBuff buff)
    {
        if (!buff.alreadyApplied) Debug.LogError(buff.name + " has already been removed!");
        if (buff.XP != 0) Debug.LogError(buff.name + " should not be removed, it is a permanant buff! (xp != 0)");
        //ADDS UNAPPLIED BUFFS to: XP, Strength, MaxMana, and MaxHealth.
        strength -= buff.Strength;
        maxMana -= buff.MaxMana;
        maxHealth -= buff.MaxHealth;
        buff.alreadyApplied = false;
    }
    public void enemyKilled(GameObject obj)
    {
        incrementEnemyQuest(obj);
                BasicEnemyAI enemy = obj.GetComponent<BasicEnemyAI>();
        xp += enemy.xpValue;
    }
    public void collectItem(Item item)
    {
        incrementItemQuest(item);
        playerInventory.addItem(item);
    }
    public void incrementQuestName(string name)
    {
        foreach (Quest quest in playerQuests.currentQuests)
        {
            
            if (quest.questName == name)
            {
                quest.quantityCollected++;
            }
        }
    }
    private void incrementEnemyQuest(GameObject obj)
    {
        foreach (Quest quest in playerQuests.currentQuests)
        {
            if (quest.collection.GetComponent<BasicEnemyAI>() == null) continue;
            if (obj.GetComponent<BasicEnemyAI>().enemyName == quest.collection.GetComponent<BasicEnemyAI>().enemyName && !quest.isComplete)
            {
                quest.quantityCollected++;
            }
        }
    }
    private void incrementItemQuest(Item item)
    {
        foreach (Quest quest in playerQuests.currentQuests)
        {
            if (quest.collection.GetComponent<ICollectable>() == null) continue;
            if (item.itemName == quest.collection.GetComponent<ICollectable>().item.itemName && !quest.isComplete)
            {
                quest.quantityCollected++;
            }
        }
    }

}
