using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack;
    private float timer = 0f;

    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        Inventory inventory = transform.gameObject.GetComponent<Inventory>();
        timeToAttack = inventory.guns[inventory.currentGunIndex].timeToAttack;

        attacking = true;
        attackArea.SetActive(attacking);
    }
}
