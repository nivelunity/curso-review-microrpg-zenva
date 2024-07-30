using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Stats")]
    public float moveSpeed;
    public int curHp;
    public int maxHp;
    public int damage;

    [Header("Combat")] 
    public KeyCode attackKey;
    public float attackRange;
    public float attackRate;
    private float lastAttackTime;

    [Header("Experience")] 
    public int curLevel;
    public int curXp;
    public int xpToNextLevel;
    public float levelXpModifier;
    
    [Header("Sprites")] 
    public Sprite downSprite;
    public Sprite upSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private Vector2 facingDirection;
    private Rigidbody2D rig;
    private SpriteRenderer avatar;
    private ParticleSystem hitEffect;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        avatar = GetComponent<SpriteRenderer>();
        hitEffect = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(attackKey))
        {
            if (Time.time - lastAttackTime >= attackRate)
                Attack();
        }
    }
    
    void Attack()
    {
        lastAttackTime = Time.time;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, facingDirection, attackRange, 1 << 8);

        if (hit.collider != null)
        {
            hit.collider.GetComponent<Enemy>().TakeDamage(damage);
            
            //Play Hit SFX
            hitEffect.transform.position = hit.collider.transform.position;
            hitEffect.Play();
        }
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
    public void TakeDamage(int damageTaken)
    {
        curHp -= damageTaken;
        if (curHp <= 0)
        {
          Die();
        }
    }
    
    void Die()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void AddXp(int xp)
    {
        curHp += xp;

        if (curXp >= xpToNextLevel) ;
        //LevelUp
    }
}
