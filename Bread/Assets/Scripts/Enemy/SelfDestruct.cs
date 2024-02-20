using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    // Start is called before the first frame update
     void Start()
    {
        StartCoroutine(SelfDestructa());
    }

     IEnumerator SelfDestructa()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player"))
        {
            other.GetComponent<CharacterStats>().dealDamage(5);
        }
        Destroy(gameObject);
    }
}
