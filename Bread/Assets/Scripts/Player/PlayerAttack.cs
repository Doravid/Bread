using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField]
    private GameObject projectile;
    public AttackBar attackBar;
    public SelectorScroll scroll;

    private CharacterStats stats;
    private float timer;
    private void Start()
    {
        stats = this.GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackBar.currentAttacks[scroll.currentSelector].isMelee)
        {
            meleeAttack();
            return;

        }
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        if(Input.GetMouseButton((int)MouseButton.Left) && stats.getCurrentMana() >= 5 && timer <= 0)
        {
            stats.setCurrentMana(stats.getCurrentMana() - 5);
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);
        }

    }
    private void meleeAttack() {
    }
}
