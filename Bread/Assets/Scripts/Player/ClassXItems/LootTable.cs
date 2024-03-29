using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/LootTable")]
public class LootTable : ScriptableObject
{
    public struct itemAndDropChance
    {
        Item item;
        float dropChance;
    }
    public List<Item> drops;
    [SerializeField, Header("dropChace Element 0 corresponds to Drops Element 0")]
    public List<float> dropChance;
}
