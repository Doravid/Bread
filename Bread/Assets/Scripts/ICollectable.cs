using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICollectable : MonoBehaviour
{
    public Item item;
    private SaveData saveData;
    private void Awake()
    {
        saveData = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveData>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<CharacterStats>().collectItem(item);
            saveData.addObject(name, false);
            Destroy(gameObject);
            
        }
    }
}
