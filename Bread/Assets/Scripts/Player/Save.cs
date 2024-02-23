using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private void Start()
    {
        
    }
    void Update()
    {
        PlayerPrefs.SetFloat("PPX", player.position.x);
        PlayerPrefs.SetFloat("PPY", player.position.y);
        PlayerPrefs.SetFloat("PPZ", player.position.z);
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
        stats.warpPoint = PlayerPrefs.GetString("WARPTO", "");
    }
}
