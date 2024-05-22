using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    [SerializeField] private Animator animator;
    [SerializeField] float timeToAttack = 2f;
    private float attackingTime = 0.3f;
    private bool canAttack;

    void Start()
    {
        canAttack = true;
        attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space)))
        {
            Attack();
        }
    }

    private IEnumerator TimeToAttack() 
    {
        yield return new WaitForSeconds(timeToAttack);
        canAttack = true;
    }

    private IEnumerator AttackingTime() 
    {
        yield return new WaitForSeconds(attackingTime);
        attackArea.SetActive(false);
        animator.SetFloat("Attacking", 0);
    }

    private void Attack()
    {
        if (canAttack == true) 
        {
            animator.SetFloat("Attacking", 1);

            canAttack = false;

            Inventory inventory = transform.gameObject.GetComponent<Inventory>();
            timeToAttack = inventory.guns[inventory.currentGunIndex].timeToAttack;

            attackArea.SetActive(true);

            StartCoroutine(TimeToAttack());
            StartCoroutine(AttackingTime());
        }
    }
}
