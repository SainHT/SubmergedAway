using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int healOnDeath = 1;
    [SerializeField] private Slider healthBar;
    private FloatingStatusBar floatingHealthBar;
    private PlayerHealth playerHealth;
    private float hurtCooldown = 0.09f;
    private float deathTime = 0.05f;

    private void Awake()
    {
        floatingHealthBar = healthBar.GetComponent<FloatingStatusBar>();
    }

    private void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

        health = maxHealth;
        floatingHealthBar.UpdateHealthBar(health, maxHealth);
    }

    public void Damage(int amount)
    {
        animator.SetFloat("Hurt", 1);
        health -= amount;
        floatingHealthBar.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
        StartCoroutine(Die());
        }

        StartCoroutine(HurtCooldown());
    }

    private IEnumerator HurtCooldown() 
    {
        yield return new WaitForSeconds(hurtCooldown);
        animator.SetFloat("Hurt", 0);
    } 
    
    private IEnumerator Die()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        animator.SetFloat("Death", 1);
        yield return new WaitForSeconds(1f);
        animator.SetFloat("Death", 0);
        playerHealth.Heal(healOnDeath);
        Destroy(gameObject);
    }
}
