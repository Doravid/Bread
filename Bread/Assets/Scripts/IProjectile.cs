using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IProjectile : MonoBehaviour
{
    [SerializeField]
    private bool isPlayerProjectile;
    public int damage;
    private GameObject player;
    [SerializeField] GameObject damageText;
     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damage = (int) ((float) player.GetComponent<CharacterStats>().getMaxMana() / 50f);
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
            if(other.tag == "Enemy")
            {
                GameObject text = Instantiate(damageText);
                text.transform.position = other.transform.position;
                Quaternion _lookRotation = Quaternion.LookRotation((other.transform.position - player.transform.position).normalized);
                text.transform.rotation = _lookRotation;

                text.GetComponent<TextMeshPro>().text = damage.ToString();
                text.GetComponent<Rigidbody>().AddForce(transform.up * 7f, ForceMode.Impulse);
                text.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
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
