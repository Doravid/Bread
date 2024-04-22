using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Custom/Attack")]
public class Attack : ScriptableObject
{
    public int manaCost, damageAmount;
    public Sprite attackSprite;
    public string attackName;
    public GameObject model;
    public bool isMelee;
    public float timeBetweenAttacks;
    public float currentTimer;
}

