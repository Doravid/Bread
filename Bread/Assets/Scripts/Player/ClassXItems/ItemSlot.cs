using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] Inventory playerInventory;
    [SerializeField] GameObject itemPrefab;
    [SerializeField] Image sprite;
    [SerializeField] SpawnTopping spawnTopping;
    [SerializeField] private InventoryManager inventoryManager;
    private CharacterStats characterStats;
    private void Awake()
    {
        characterStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
    }
    public void OnDrop(PointerEventData eventData)
    {
       
        Debug.Log("Droped!");
        if (eventData.pointerDrag != null)
        {
            GameObject droppedItem = eventData.pointerDrag.gameObject;

            switch (name)
            {
                case "Crust":
                    if (droppedItem.GetComponent<ItemInit>().item.equipmentType != "Crust") return;
                    unEquipItem("Crust");
                    playerInventory.Crust = droppedItem.GetComponent<ItemInit>().item;
                    cleanUp(droppedItem);
                    break; 

                case "Seasoning1":
                    if (droppedItem.GetComponent<ItemInit>().item.equipmentType != "Seasoning") return;
                    unEquipItem("Seasoning1");
                    playerInventory.Seasoning1 = droppedItem.GetComponent<ItemInit>().item;
                    spawnTopping.updateEquipment();
                    cleanUp(droppedItem);
                    
                    break;

                case "Seasoning2":
                    if (droppedItem.GetComponent<ItemInit>().item.equipmentType != "Seasoning") return;
                    unEquipItem("Seasoning2");
                    playerInventory.Seasoning2 = droppedItem.GetComponent<ItemInit>().item;
                    spawnTopping.updateEquipment();
                    cleanUp(droppedItem);
                    
                    break;
                case "Coating":
                    if (droppedItem.GetComponent<ItemInit>().item.equipmentType != "Coating") return;
                    unEquipItem("Coating");
                    playerInventory.Coating = droppedItem.GetComponent<ItemInit>().item;
                    cleanUp(droppedItem);
                    
                    break;

                default:
                    Debug.LogError("Error: " + name + " is not an equipment slot.");
                    break;
            }
        }
    }
    private void cleanUp(GameObject droppedItem)
    {
        
        sprite.gameObject.SetActive(true);
        sprite.sprite = droppedItem.GetComponent<ItemInit>().item.itemImage;
        characterStats.loadBuff(droppedItem.GetComponent<ItemInit>().item.buff);
        GameObject.FindGameObjectWithTag("Player").GetComponent<HUDStatsManager>().updateStats();

        droppedItem.transform.parent = droppedItem.GetComponent<ItemMovement>().parent;
        
        
        inventoryManager.removeItem(droppedItem.GetComponent<ItemInit>().item, 1);
    }
    public void unEquipItem(string slot)
    {
        sprite.gameObject.SetActive(false);
        sprite.sprite = null;
        
        switch (slot)
        {
            case "Crust":
                if (playerInventory.Crust == null) return;
                inventoryManager.addItem(playerInventory.Crust);
                characterStats.removeBuff(playerInventory.Crust.buff);
                playerInventory.Crust = null;
                break;          
            case "Seasoning1":
                if (playerInventory.Seasoning1 == null) return;
                inventoryManager.addItem(playerInventory.Seasoning1);
                characterStats.removeBuff(playerInventory.Seasoning1.buff);
                playerInventory.Seasoning1 = null;
                spawnTopping.deleteSeasoning1();
                break;
            case "Seasoning2":
                if (playerInventory.Seasoning2 == null) return;
                inventoryManager.addItem(playerInventory.Seasoning2);
                characterStats.removeBuff(playerInventory.Seasoning2.buff);
                playerInventory.Seasoning2 = null;
                spawnTopping.deleteSeasoning2();
                
                break;         
            case "Coating":
                if (playerInventory.Coating == null) return;
                inventoryManager.addItem(playerInventory.Coating);
                characterStats.removeBuff(playerInventory.Coating.buff);
                playerInventory.Coating = null;
                break;
            default: 
                break;
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<HUDStatsManager>().updateStats();
    }
}
