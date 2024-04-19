using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleAttack : MonoBehaviour
{
    public GameObject weapon;
    [SerializeField]
    private CharacterStats stats;
    [SerializeField]
    private float timeBetweenAttacks;
    private float timer;
    private void Start()
    {
        if(timeBetweenAttacks == 0)
        {
            timeBetweenAttacks = 0.1f;
        }
        stats = this.GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        if( && timer <= 0)
        {
            timer += timeBetweenAttacks;
            stats.setCurrentMana(stats.getCurrentMana() - 5);
            Rigidbody rb = Instantiate(weapon, transform.position, transform.rotation, transform).GetComponent<Rigidbody>();

        }

    }
}
