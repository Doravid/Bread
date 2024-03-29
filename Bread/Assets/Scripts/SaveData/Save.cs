using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{

    private void Awake()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat("PPX"), PlayerPrefs.GetFloat("PPY"), PlayerPrefs.GetFloat("PPZ"));
    }
    void Update()
    {
        PlayerPrefs.SetFloat("PPX", transform.position.x);
        PlayerPrefs.SetFloat("PPY", transform.position.y);
        PlayerPrefs.SetFloat("PPZ", transform.position.z);
    }
    public static void saveStats(CharacterStats stats)
    {
        if (stats == null) { return; }
        PlayerPrefs.SetInt("STRENGTH", stats.getStrength());
        PlayerPrefs.SetInt("XP", stats.getXp());
        PlayerPrefs.SetInt("XPTONEXTLEVEL", stats.getXpToNextLevel());
        PlayerPrefs.SetInt("LEVEL", stats.getLevel());
        PlayerPrefs.SetInt("CURRENTHEALTH", stats.getCurrentHealth());
        PlayerPrefs.SetInt("CURRENTMANA", stats.getCurrentMana());
        PlayerPrefs.SetInt("MAXHEALTH", stats.getMaxHealth());
        PlayerPrefs.SetInt("MAXMANA", stats.getMaxMana());
        PlayerPrefs.SetInt("HEALTHREGEN", stats.getHealthRegen());
        PlayerPrefs.SetInt("MANAREGEN", stats.getManaRegen());
        PlayerPrefs.SetString("WARPTO", stats.warpPoint);
    }
    public static void load(CharacterStats stats)
    {
        if (stats == null) { return; }
        stats.setStrength(PlayerPrefs.GetInt("STRENGTH", stats.getStrength()));
        stats.setXp(PlayerPrefs.GetInt("XP"));
        stats.setXpToNextLevel(PlayerPrefs.GetInt("XPTONEXTLEVEL"));
        stats.setLevel(PlayerPrefs.GetInt("LEVEL", stats.getLevel()));
        stats.setCurrentHealth(PlayerPrefs.GetInt("CURRENTHEALTH", stats.getCurrentHealth()));
        stats.setCurrentMana(PlayerPrefs.GetInt("CURRENTMANA", stats.getCurrentMana()));
        stats.setMaxHealth(PlayerPrefs.GetInt("MAXHEALTH", stats.getMaxHealth()));
        stats.setMaxMana(PlayerPrefs.GetInt("MAXMANA", stats.getMaxMana()));
        stats.setHealthRegen(PlayerPrefs.GetInt("HEALTHREGEN", stats.getHealthRegen()));
        stats.setManaRegen(PlayerPrefs.GetInt("MANAREGEN", stats.getManaRegen()));
        stats.warpPoint = PlayerPrefs.GetString("WARPTO", "");

        
    }
    public static void saveObejcts()
    {

    }
}
