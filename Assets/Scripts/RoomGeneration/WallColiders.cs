using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColiders : MonoBehaviour
{
    private BoxCollider2D currBoxCollider;
    Transform player;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        currBoxCollider = GetComponentInChildren<BoxCollider2D>();
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (player.position.y > transform.position.y)
        {
            currBoxCollider.enabled = false;
        }
        else
        {
            currBoxCollider.enabled = true;
        }
    }
}
