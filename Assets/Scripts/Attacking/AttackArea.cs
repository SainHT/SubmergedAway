using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            Inventory inventory = transform.parent.gameObject.GetComponent<Inventory>();

            int damage = inventory.guns[inventory.currentGunIndex].damage;

            health.Damage(damage);
        }
    }
}