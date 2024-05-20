using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private Vector2 playerPos;
    private Vector2 oldPlayerPos;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float attackRange = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

    }

    void FixedUpdate()
    {
        playerPos = player.transform.position;

        if (oldPlayerPos != playerPos && Vector2.Distance(transform.position, playerPos) > attackRange)
        {
            Vector2 currentPos = transform.position;

            Vector2 direction = playerPos - currentPos;
            direction.Normalize();

            rb.velocity = direction * moveSpeed;

            if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (direction.y < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            oldPlayerPos = playerPos;
        }
    }
}
