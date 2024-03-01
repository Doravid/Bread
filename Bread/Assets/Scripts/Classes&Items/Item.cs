using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName ="Custom/Item")]
public class Item : ScriptableObject
{
    public int quantity, maxStack, sellValue;
    public GameObject itemModel;
    public Sprite itemImage;
    public PlayerBuff buff;
    public bool equipable;
    public string itemName;
}

