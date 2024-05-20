using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int healOnDeath = 1;
    [SerializeField] private Slider healthBar;
    private FloatingStatusBar floatingHealthBar;
    private PlayerHealth playerHealth;

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
        health -= amount;
        floatingHealthBar.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        playerHealth.Heal(healOnDeath);
        Destroy(gameObject);
    }
}
