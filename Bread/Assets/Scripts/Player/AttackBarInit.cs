using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackBarInit : MonoBehaviour
{
    public AttackBar attackBar;

    private void Start()
    {
            if(attackBar.currentAttacks.Count > 4)
        {
            Debug.LogWarning("Warning: Too many Attacks In Attack Bar");
            return;
        }
    for(int i = 0; i < attackBar.currentAttacks.Count; i++)
        {
            transform.GetChild(i).GetComponent<Image>().enabled = true;
            transform.GetChild(i).GetComponent<Image>().sprite = attackBar.currentAttacks[i].attackSprite;
        }
    }
}
