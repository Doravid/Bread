using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTopping : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    private GameObject[] gameObjects = new GameObject[2];
    private void Start()
    {
        updateEquipment();
    }

    public void updateEquipment()
    {
        if (inventory.Seasoning1 != null && inventory.Seasoning1.itemModel != null)
        {
            gameObjects[0] = (Instantiate(inventory.Seasoning1.itemModel, transform));
        }
        else if (inventory.Seasoning2 != null)
        {
            gameObjects[1] = (Instantiate(inventory.Seasoning2.itemModel, transform));
        }
    }
    public void deleteSeasoning1()
    {
        Destroy(gameObjects[0]);
        gameObjects[0] = null;
    }
    public void deleteSeasoning2()
    {
        Destroy(gameObjects[1]);
        gameObjects[0] = null;
    }


}
