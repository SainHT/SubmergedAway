using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    [SerializeField] private Animator animator;
    [SerializeField] private float moveSpeed = 5f;

    private GameObject attackArea;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackArea = transform.GetChild(0).gameObject;
    }

    void FixedUpdate()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        direction = new Vector2(dirX, dirY);

        animator.SetFloat("Vertical", dirY);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        
        direction.Normalize();


        rb.velocity = direction * moveSpeed;

        if (dirX == -1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (dirX == 1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (direction.y > 0){
            attackArea.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (direction.y < 0)
        {
            attackArea.transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (direction.x > 0)
        {
            attackArea.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else if (direction.x < 0)
        {
            attackArea.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
