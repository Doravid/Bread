using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SelfDestructa());

    }

    IEnumerator SelfDestructa()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
