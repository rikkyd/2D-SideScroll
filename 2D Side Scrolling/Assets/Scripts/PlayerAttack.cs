using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown; // Attack cooldown time in seconds
    private Animator anim; // Reference to the player's animator component
    private PlayerMovement playerMovement; // Reference to the player's movement component
    private float cooldownTimer = Mathf.Infinity; // Cooldown timer initialized to infinity

    // For firing fireballs
    [SerializeField] private Transform firePoint; // Transform representing the fireball spawn point
    [SerializeField] private GameObject[] fireballs; // Array of fireball prefabs

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // Get the animator component
        playerMovement = GetComponent<PlayerMovement>(); // Get the movement component
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (Input.GetKey(KeyCode.F) && cooldownTimer > attackCooldown)
        {
            Attack();  
        }
    }

    private void Attack()
    {
        anim.SetTrigger("attack"); // Trigger the "attack" animation (assuming it's set up)
        cooldownTimer = 0;

        fireballs[CheckFireball()].transform.position = firePoint.position;
        fireballs[CheckFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int CheckFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0; // If all fireballs are active, return the first one
    }
}