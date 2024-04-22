using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IMeleeAttack : MonoBehaviour
{
    private GameObject player;
    [SerializeField] GameObject damageText;
    public int damage;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damage = player.GetComponent<CharacterStats>().getStrength();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            GameObject text = Instantiate(damageText);
            text.transform.position = other.transform.position;
            Quaternion _lookRotation = Quaternion.LookRotation((other.transform.position - player.transform.position).normalized);
            text.transform.rotation = _lookRotation;

            text.GetComponent<TextMeshPro>().text = damage.ToString();
            text.GetComponent<Rigidbody>().AddForce(transform.up * 7f, ForceMode.Impulse);
            text.GetComponent<Rigidbody>().AddForce(transform.forward, ForceMode.Impulse);
            other.GetComponent<BasicEnemyAI>().health -= damage;
        }

    }
}
