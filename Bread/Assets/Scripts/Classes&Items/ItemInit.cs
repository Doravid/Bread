using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInit : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemQuantity;
    public Item item;
    public void spawnItem(Item itemSpawn)
    {
        item = itemSpawn;
        image.sprite = item.itemImage;
        itemName.text = item.itemName;
        itemQuantity.text = item.quantity.ToString();
    }
}
