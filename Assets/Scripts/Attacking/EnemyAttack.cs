using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float timeToAttack = 5f;
    [SerializeField] private float attackingTime = 0.45f;
    public int attackDamage = 1;
    public float attackRange = 2f;
    private GameObject player;
    private bool attacked = false;
    private float timer = 0f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
    }

    private IEnumerator TimeToAttack()
    {
        yield return new WaitForSeconds(timeToAttack);
        attacked = false;
    }

    private IEnumerator AttackingTime()
    {
        yield return new WaitForSeconds(attackingTime);
        animator.SetFloat("Attacking", 0);
    }

    void AttackPlayer()
    {
        animator.SetFloat("Attacking", 1);

        player.GetComponent<PlayerHealth>().Damage(attackDamage);

        attacked = true;

        StartCoroutine(TimeToAttack());
        StartCoroutine(AttackingTime());
    }
}
