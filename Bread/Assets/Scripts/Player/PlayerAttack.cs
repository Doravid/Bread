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
    private void Start()
    {
        stats = this.GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;
        if (Input.GetMouseButton((int)MouseButton.Left) && !attackBar.currentAttacks[scroll.currentSelector].attackName.Equals("Null"))
        {
            //Does a melee attack if the current attack is a melee attack, otherwise do a ranged attack. 
            if (attackBar.currentAttacks[scroll.currentSelector].isMelee)
            {
                meleeAttack();
            }
            else rangedAttack();
            return;

        }
        foreach(Attack atk in attackBar.currentAttacks)
        {
            if(atk.currentTimer > 0)
            {
                atk.currentTimer -= Time.deltaTime;
            }
        }


    }
    private void meleeAttack() {
        if (attackBar.currentAttacks[scroll.currentSelector].currentTimer > 0) return;
        //Adds the cooldown for using the attack to the cooldown timer.
        attackBar.currentAttacks[scroll.currentSelector].currentTimer += attackBar.currentAttacks[scroll.currentSelector].timeBetweenAttacks;
        //Creates the weapon from the slot and adds the weapons damage to the weapon gameobject,
        //Get the <IMeleeAttack>component from the child because the parrent is a rotation point.
        Instantiate(attackBar.currentAttacks[scroll.currentSelector].model, transform.position, transform.rotation, transform).GetComponentInChildren<IMeleeAttack>().damage += attackBar.currentAttacks[scroll.currentSelector].damageAmount;
    }
    private void rangedAttack()
    {
        if (attackBar.currentAttacks[scroll.currentSelector].currentTimer > 0) return;
        if (stats.getCurrentMana() >= 5)
        {
            stats.setCurrentMana(stats.getCurrentMana() - 5);
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 5f, ForceMode.Impulse);
            rb.gameObject.GetComponent<IProjectile>().damage += attackBar.currentAttacks[scroll.currentSelector].damageAmount;
            attackBar.currentAttacks[scroll.currentSelector].currentTimer += attackBar.currentAttacks[scroll.currentSelector].timeBetweenAttacks;
        }
    }
}
