using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]
    private bool isPlayerProjectile;
    [SerializeField]
    private int damage;
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
        if(isPlayerProjectile)
        {
            Debug.Log(other);
            if(other.tag == "Enemy")
            {
                other.GetComponent<BasicEnemyAI>().health -= damage;
                Destroy(gameObject);
            }

        }
        
        if (other.tag == "Player")
        {
            if (!isPlayerProjectile)
            {
                other.GetComponent<CharacterStats>().dealDamage(damage);
                Destroy(gameObject);
            }

        }
        
    }
}
