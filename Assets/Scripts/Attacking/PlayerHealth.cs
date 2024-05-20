using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int health = 10;
    [SerializeField] private SpriteRenderer playerHealthBar;
    [SerializeField] private Sprite[] healthBarStatus;
    [SerializeField] private Animator animator;

    private void Start() 
    {
        health = maxHealth;
        playerHealthBar.sprite = healthBarStatus[health];

        StartCoroutine(OxygenLoss());
    }

    IEnumerator OxygenLoss() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(2f);
            Damage(1);
        }
    }

    public void Damage(int amount)
    {
        StartCoroutine(Hurt());

        health -= amount;

        if (health >= 0) 
        {
            playerHealthBar.sprite = healthBarStatus[health];
        }

        if (health <= 0)
        {
            Die();
        }
    }

    private IEnumerator Hurt() 
    {
        animator.SetFloat("Hurt", 1);
        yield return new WaitForSeconds(0.3f);
        animator.SetFloat("Hurt", 0);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}