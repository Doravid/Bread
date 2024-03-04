using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public Inventory inventory;
    public GameObject itemPrefabTemplate;
    [SerializeField] private Image CrustSprite;
    [SerializeField] private Image Seasoning1Sprite;
    [SerializeField] private Image Seasoning2Sprite;
    [SerializeField] private Image CoatingSprite;
    private CharacterStats characterStats;

    

    private void Awake()
    {
        characterStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>();
        if (inventory == null || itemPrefabTemplate == null) return;
        foreach (Item item in inventory.inventory)
        {
            spawnItem(item);
        }

        if(inventory.Crust != null)
        {
            CrustSprite.sprite = inventory.Crust.itemImage;
            CrustSprite.gameObject.SetActive(true);
            characterStats.loadBuff(inventory.Crust.buff);
        } 
        if(inventory.Seasoning1 != null)
        {
            Seasoning1Sprite.gameObject.SetActive(true);
            Seasoning1Sprite.sprite = inventory.Seasoning1.itemImage;
            characterStats.loadBuff(inventory.Seasoning1.buff);
        }  
        if(inventory.Seasoning2 != null)
        {
            Seasoning2Sprite.gameObject.SetActive(true);
            Seasoning2Sprite.sprite = inventory.Seasoning2.itemImage;
            characterStats.loadBuff(inventory.Seasoning2.buff);
        }     
        if(inventory.Coating != null)
        {
            CoatingSprite.gameObject.SetActive(true);
            CoatingSprite.sprite = inventory.Coating.itemImage;
            characterStats.loadBuff(inventory.Coating.buff);
        }
    }
    private void spawnItem(Item item)
    {
        GameObject tempItem = Instantiate(itemPrefabTemplate, transform, false);
        tempItem.GetComponent<ItemInit>().spawnItem(item);
    }
    public void addItem(Item item)
    {
        GameObject tempItem = Instantiate(itemPrefabTemplate, transform, false);
        tempItem.GetComponent<ItemInit>().spawnItem(item);
        inventory.inventory.Add(item);  
    }
}
