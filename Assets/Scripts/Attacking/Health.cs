using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;

    public void Damage(int amount)
    {
        this.health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
