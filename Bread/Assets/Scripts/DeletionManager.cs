using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeletionManager : MonoBehaviour
{
    private GameObject[] delete;
    private void Start()
    {
        delete = GameObject.FindGameObjectsWithTag("DeleteOnSceneLoad");
        refresh();
    }
    public void refresh()
    {
        foreach (GameObject obj in delete)
        {
            obj.gameObject.SetActive(false);
        }
    }
}
