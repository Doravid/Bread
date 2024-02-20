using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    [SerializeField]
    private Transform player;
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
        PlayerPrefs.SetInt("LUCK", stats.getLuck());
        PlayerPrefs.SetInt("BREAD", stats.getBread());
        PlayerPrefs.SetInt("CURRENTHEALTH", stats.getCurrentHealth());
        PlayerPrefs.SetInt("CURRENTMANA", stats.getCurrentMana());
        PlayerPrefs.SetInt("MAXHEALTH", stats.getMaxHealth());
        PlayerPrefs.SetInt("MAXMANA", stats.getMaxMana());
    }
    public static void load(CharacterStats stats)
    {
        if (stats == null) { return; }
        stats.setStrength(PlayerPrefs.GetInt("STRENGTH", stats.getStrength()));
        stats.setLuck(PlayerPrefs.GetInt("LUCK", stats.getLuck()));
        stats.setBread(PlayerPrefs.GetInt("BREAD", stats.getBread()));
        stats.setCurrentHealth(PlayerPrefs.GetInt("CURRENTHEALTH", stats.getCurrentHealth()));
        stats.setCurrentMana(PlayerPrefs.GetInt("CURRENTMANA", stats.getCurrentMana()));
        stats.setMaxHealth(PlayerPrefs.GetInt("MAXHEALTH", stats.getMaxHealth()));
        stats.setMaxMana(PlayerPrefs.GetInt("MAXMANA", stats.getMaxMana()));
    }
}
