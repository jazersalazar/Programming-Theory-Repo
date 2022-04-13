using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all enemy.
public abstract class Enemy : Unit 
{
    public Color color;

    public float speed = 1.0f;
    public float attackRange = 1.0f;

    private Transform player;

    protected override void Start() 
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        SetColor();
    }

    protected virtual void Update() 
    {
        var distance = Vector2.Distance(gameObject.transform.position, player.position);

        // Move to player until it reach an attack range
        if (Vector2.Distance(gameObject.transform.position, player.position) > attackRange)
        {
            float step = speed * Time.deltaTime;
            gameObject.transform.position = Vector2.MoveTowards(transform.position, player.position, step);
            PlayerInRange();
        }
    }

    /// <summary>
    /// Override this function to implement what should happen when the player is in range.
    /// This is called every frame that the player is in range. 
    /// </summary>
    protected abstract void PlayerInRange(); 

    void SetColor()
    {
        var sr = GetComponentInChildren<SpriteRenderer>();
        sr.color = new Color(color.r, color.g, color.b, 1);
    }
}
