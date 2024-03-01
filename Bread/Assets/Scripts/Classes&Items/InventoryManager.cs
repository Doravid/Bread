using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public GameObject itemPrefabTemplate;

    

    private void Awake()
    {
        if (inventory == null || itemPrefabTemplate == null) return;
        foreach (Item item in inventory.inventory)
        {
            Debug.Log(item.name);
            Debug.Log(itemPrefabTemplate.name + " | is null: " + itemPrefabTemplate == null);
            Instantiate(itemPrefabTemplate, transform, this).GetComponent<ItemInit>().spawnItem(item);
        }
    }
}
