using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Quest")]
public class Quest : ScriptableObject
{
    public int quantity, quantityCollected;
    public GameObject collection;
    public bool isComplete;
    public bool isActive;
    public int id;
    public int previousQuestId;
    public PlayerBuff questReward;
    public string questName, questDescription;
    public Sprite questIcon;
    
}

