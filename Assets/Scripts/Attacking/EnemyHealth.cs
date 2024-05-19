using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Slider healthBar;
    private FloatingStatusBar floatingHealthBar;

    private void Awake()
    {
        floatingHealthBar = healthBar.GetComponent<FloatingStatusBar>();
    }

    private void Start()
    {
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
        Destroy(gameObject);
    }
}
