using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    [SerializeField] private Animator animator;

    private bool attacking = false;

    private float timeToAttack;
    private float timer = 0f;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                animator.SetFloat("Attacking", 0);
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        animator.SetFloat("Attacking", 1);

        Inventory inventory = transform.gameObject.GetComponent<Inventory>();
        timeToAttack = inventory.guns[inventory.currentGunIndex].timeToAttack;

        attacking = true;
        attackArea.SetActive(attacking);
    }
}
