using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInit : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI itemName;
    public Item item;

    //TESTING
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            spawnItem(item);
        }
    }
    public void spawnItem(Item item)
    {
        image.sprite = item.itemImage;
        itemName.text = item.itemName;
    }
}
