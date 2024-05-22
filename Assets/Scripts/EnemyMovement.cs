using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private Vector2 playerPos;
    private Vector2 oldPlayerPos;
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float spotRange = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

    }

    void FixedUpdate()
    {
        playerPos = player.transform.position;

        if (oldPlayerPos != playerPos && Vector2.Distance(transform.position, playerPos) > spotRange)
        {
            Vector2 currentPos = transform.position;

            Vector2 direction = playerPos - currentPos;

            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);

            direction.Normalize();

            rb.velocity = direction * moveSpeed;

            if (direction.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.GetChild(0).GetChild(0).localScale = new Vector3(-1, 1, 1);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
                transform.GetChild(0).GetChild(0).localScale = new Vector3(1, 1, 1);
            }

            oldPlayerPos = playerPos;
        }
    }
}
