using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        int quantity = item.quantity;
        int quantHolder = quantity;
  
        while(quantity >= item.maxStack)
        {
            item.quantity = item.maxStack;
            GameObject tempItemA = Instantiate(itemPrefabTemplate, transform, false);
            tempItemA.GetComponent<ItemInit>().spawnItem(item);
            quantity -= item.maxStack;
        }
        item.quantity = quantHolder;
        item.quantity %= item.maxStack;
        if (item.quantity == 0)
        {
            item.quantity = quantHolder;
            return;
        }
        GameObject tempItem = Instantiate(itemPrefabTemplate, transform, false);
        tempItem.GetComponent<ItemInit>().spawnItem(item);
        item.quantity = quantHolder;
    }
    public void removeItem(Item item)
    {
        
    inventory.inventory.Remove(item);

        int numItems = transform.childCount;
        for(int i = 0; i < numItems; i++)
        {
            if (transform.GetChild(i).GetComponent<ItemInit>().item.itemName.Equals(item.itemName))
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
    public void removeItem(Item item, int amount)
    {
        if(amount >= item.quantity)
        {
            removeItem(item);
            return;
        }
        item.quantity -= amount;
        int amountLeft = amount;
        int numItems = transform.childCount;
        for (int i = numItems-1; i >= 0; i--)
        {
            if (!transform.GetChild(i).GetComponent<ItemInit>().item.itemName.Equals(item.itemName)) continue;
            if (int.Parse(transform.GetChild(i).GetComponent<ItemInit>().itemQuantity.text) < amountLeft)
            {
                Destroy(transform.GetChild(i).gameObject);
                amountLeft -= int.Parse(transform.GetChild(i).GetComponent<ItemInit>().itemQuantity.text);
            }
            else {
                transform.GetChild(i).GetComponent<ItemInit>().itemQuantity.text =
                    (int.Parse(transform.GetChild(i).GetComponent<ItemInit>().itemQuantity.text) -amountLeft).ToString();
                break;
            }
        }

    }
    public void addItem(Item item)
    {
        Debug.Log("Add Item: " + item.name);
        int quantity = item.quantity;

        if (item.quantity == 0)
        {
            Debug.Log("First Item Pickup");
            item.quantity = 1;
            GameObject tempItem = Instantiate(itemPrefabTemplate, transform, false);
            tempItem.GetComponent<ItemInit>().spawnItem(item);
            inventory.inventory.Add(item);
        }

        else if ((item.quantity % item.maxStack) == 0)
        {
            Debug.Log("There");
            item.quantity++;
            item.quantity %= item.maxStack;
            GameObject tempItem = Instantiate(itemPrefabTemplate, transform, false);
            tempItem.GetComponent<ItemInit>().spawnItem(item);
            item.quantity = ++quantity;
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Item aliveItem = transform.GetChild(i).GetComponent<ItemInit>().item;
                if ((int.Parse(transform.GetChild(i).GetComponent<ItemInit>().itemQuantity.text) % aliveItem.maxStack) != 0 && aliveItem.itemName.Equals(item.itemName))
                {
                    Destroy(transform.GetChild(i).gameObject);
                    GameObject tempItem = Instantiate(itemPrefabTemplate, transform, false);
                    item.quantity %= item.maxStack;
                    item.quantity++;
                    tempItem.GetComponent<ItemInit>().spawnItem(item);
                    item.quantity = ++quantity;
                    break;
                }
            }
        }
    }
}
