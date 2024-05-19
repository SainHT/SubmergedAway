using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColiders : MonoBehaviour
{
    private BoxCollider2D currBoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        currBoxCollider = GetComponentInChildren<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform player = GameObject.Find("Player").transform;
        if (player.position.y > transform.position.y){
            currBoxCollider.enabled = false;
        }
        else{
            currBoxCollider.enabled = true;
        }
    }
}
