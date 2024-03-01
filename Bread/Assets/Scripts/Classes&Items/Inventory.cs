using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Custom/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> inventory;
    public List<Item> equiped;
}
