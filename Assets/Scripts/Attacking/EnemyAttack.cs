using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackSpeed = 5f; // Speed at which the enemy attacks
    public int attackDamage = 1; // Damage dealt by the enemy's attack
    public float attackRange = 2f; // Distance at which the enemy can attack

    private GameObject player; // Reference to the player object
    private bool attacked = false;
    private float timeToAttack = 5f;
    private float timer = 0f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Find the player object by tag
    }

    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        // Check if the player is within attack range
        if (distanceToPlayer <= attackRange && !attacked)
        {
            AttackPlayer();
        }

        if (attacked)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0;
                attacked = false;
            }
        }

    }

    void AttackPlayer()
    {
        // Reduce the player's health by the attack damage
        player.GetComponent<PlayerHealth>().Damage(attackDamage);

        attacked = true;
    }
}
