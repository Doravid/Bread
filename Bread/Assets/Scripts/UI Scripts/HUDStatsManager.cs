using MagicPigGames;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDStatsManager : MonoBehaviour
{
    public GameObject HealthBar;
    public GameObject ManaBar;
    public GameObject LevelBar;
    private CharacterStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<CharacterStats>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthBar != null) { HealthBar.GetComponent<ProgressBar>().SetProgress((float)stats.getCurrentHealth() / (float)stats.getMaxHealth()); }
        if(LevelBar != null) {
            LevelBar.GetComponent<ProgressBar>().SetProgress((float)( stats.getXp() / (float) stats.getXpToNextLevel()) );
            LevelBar.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = (string) stats.getLevel().ToString();
        }


        if (HealthBar != null)
        { ManaBar.GetComponent<ProgressBar>().SetProgress((float)stats.getCurrentMana() / (float)stats.getMaxMana()); }
            
    }
}
