using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;

    [Header("Sprites")] 
    public Sprite downSprite;
    public Sprite upSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private Vector2 facingDirection;
    private Rigidbody2D rig;
    private SpriteRenderer avatar;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        avatar = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 vel = new Vector2(x, y);

        if (vel.magnitude != 0)
            facingDirection = vel;
        
        UpdateSpriteDirection();
        
        rig.velocity = vel * moveSpeed;
     
    }

    void UpdateSpriteDirection()
    {
        if (facingDirection == Vector2.up)
            avatar.sprite = upSprite;
        else if(facingDirection == Vector2.down)
            avatar.sprite = downSprite;
        else if(facingDirection == Vector2.left)
            avatar.sprite = leftSprite;
        else if(facingDirection == Vector2.right)
            avatar.sprite = rightSprite;
    }   
}
