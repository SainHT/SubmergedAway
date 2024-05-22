using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private Image oxygenBar;
    [SerializeField] private Sprite[] oxygenBarStatus;
    [SerializeField] private int maxOxygen = 10;
    [SerializeField] private int oxygen = 10;

    [SerializeField] private Image healthBar;
    [SerializeField] private Sprite[] healthBarStatus;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int health = 10;

    private void Start()
    {
        oxygen = maxOxygen;
        oxygenBar.sprite = oxygenBarStatus[health];

        health = maxHealth;
        healthBar.sprite = healthBarStatus[health];

        StartCoroutine(OxygenLoss());
    }

    private IEnumerator OxygenLoss()
    {
        while (true)
        {
            yield return new WaitForSeconds(6f);
            if (oxygen > 0)
            {
                oxygen -= 1;
                oxygenBar.sprite = oxygenBarStatus[oxygen];
                if (oxygen == 0)
                {
                    StartCoroutine(HealthLoss());
                }
            }
        }
    }

    private IEnumerator HealthLoss()
    {
        while (oxygen == 0)
        {
            yield return new WaitForSeconds(6f);
            Damage(1);
        }
    }

    public void Damage(int amount)
    {
        StartCoroutine(Hurt());

        health -= amount;

        if (health >= 0)
        {
            healthBar.sprite = healthBarStatus[health];
        }

        if (health <= 0)
        {
            Die();
        }
    }

    public void AddOxygen(int amount)
    {
        if (oxygen + amount <= maxOxygen)
        {
            oxygen += amount;
        }
        else
        {
            oxygen = maxOxygen;
        }
    }

    public void Heal(int amount)
    {
        if (health + amount <= maxHealth)
        {
            health += amount;
        }
        else
        {
            health = maxHealth;
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
        UnityEngine.SceneManagement.SceneManager.LoadScene("Defeat");
    }
}