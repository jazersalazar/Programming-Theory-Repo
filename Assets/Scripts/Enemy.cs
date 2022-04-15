using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public abstract class Enemy : Unit 
{
    public Color color;

    public float speed = 1.0f;
    public float attackRange = 1.0f;
    public int attackDamage = 1;
    public float attackCooldown = 1.0f;
    public bool canAttack = true;

    protected Transform target;
    protected Player player;

    protected override void Start() 
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        player = target.GetComponent<Player>();
        SetColor();
    }

    protected virtual void Update() 
    {
        var distance = Vector2.Distance(gameObject.transform.position, target.position);

        // Move to player until it reach an attack range
        if (Vector2.Distance(gameObject.transform.position, target.position) > attackRange)
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
        else
        {
            PlayerInRange();
        }
    }

    protected virtual void PlayerInRange()
    {
        if (canAttack)
        {
            player.TakeDamage(attackDamage);
            StartCoroutine(AttackCooldown());
        }
    } 

    protected virtual IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    void SetColor()
    {
        var sr = GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(color.r, color.g, color.b, 1);
    }
}
