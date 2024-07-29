using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;
    
    [Header("Stats")]
    public float chaseRange;
    public float attackRange;
    private Player player;
    
    private Rigidbody2D rig;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float playerDist = Vector2.Distance(transform.position, player.transform.position);
        if (playerDist <= attackRange)
        {
            //attack player
            rig.velocity = Vector2.zero;
        }else if(playerDist <= chaseRange)
        {
            Chase();
        }
        else
        {
            rig.velocity = Vector2.zero;
        }
    }

    void Chase()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;
        rig.velocity = dir * moveSpeed;
    }
}

