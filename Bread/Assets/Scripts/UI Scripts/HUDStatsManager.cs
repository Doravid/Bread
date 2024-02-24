using MagicPigGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDStatsManager : MonoBehaviour
{
    public GameObject HealthBar, ManaBar, LevelBar, statsMenu;
    private CharacterStats stats;
    [SerializeField]
    private TMPro.TextMeshProUGUI maxHealth, maxMana, strength, manaRegen, healthRegen; 
    private bool inStatMenu;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<CharacterStats>();
        inStatMenu = false;
        statsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyUp(KeyCode.Tab))
        {
            toggleStatMenu();
        }
        if (HealthBar != null) { HealthBar.GetComponent<ProgressBar>().SetProgress((float)stats.getCurrentHealth() / (float)stats.getMaxHealth()); }
        if(LevelBar != null) {
            LevelBar.GetComponent<ProgressBar>().SetProgress((float) stats.getXp() / (float) stats.getXpToNextLevel());
            LevelBar.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = (string) stats.getLevel().ToString();
        }


        if (HealthBar != null)
        { ManaBar.GetComponent<ProgressBar>().SetProgress((float)stats.getCurrentMana() / (float)stats.getMaxMana()); }
            
    }

    private void toggleStatMenu()
    {
        updateStats();
        statsMenu.SetActive(!statsMenu.activeSelf);
    }
    private void updateStats()
    {
        maxHealth.text = stats.getMaxHealth().ToString();
        maxMana.text = stats.getMaxMana().ToString();
        strength.text = stats.getStrength().ToString();
        healthRegen.text = stats.getHealthRegen().ToString();
        manaRegen.text = stats.getManaRegen().ToString();
    }
}
