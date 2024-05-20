using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColiders : MonoBehaviour
{
    private BoxCollider2D currBoxCollider;
    Transform player;
    SpriteRenderer spriteRenderer;

    int prio;

    void Start()
    {
        currBoxCollider = GetComponentInChildren<BoxCollider2D>();
        player = GameObject.Find("Player").transform;
        prio = transform.GetComponent<SpriteRenderer>().sortingOrder;
    }

    void Update()
    {
        if (player.position.y > transform.position.y)
        {
            currBoxCollider.enabled = false;
            transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 1001;
        }
        else
        {
            currBoxCollider.enabled = true;
            transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = prio;
        }
    }
}
