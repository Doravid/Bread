using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTopping : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    private GameObject obj;
    private bool objEx = false;
    private void Start()
    {
        updateEquipment();
    }

    public void updateEquipment()
    {
        bool sea1Exists = inventory.Seasoning1 != null;
        bool sea2Exists = inventory.Seasoning2 != null;
        if (sea1Exists && !objEx)
        {
            obj = Instantiate(inventory.Seasoning1.itemModel, transform);
            objEx = true;
        }
        else if (sea2Exists && !objEx)
        {
           Instantiate(inventory.Seasoning2.itemModel, transform);
            objEx = true;
        }
    }
    public void deleteSeasoning1()
    {
        Destroy(transform.GetChild(0).gameObject);
        objEx = false;
        updateEquipment();
    }
    //Deprecated but I'm too lazy to rewire everything
    public void deleteSeasoning2()
    {
        deleteSeasoning1();
    }

}
