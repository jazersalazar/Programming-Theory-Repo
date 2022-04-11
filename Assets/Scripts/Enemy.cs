using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Base class for all enemy.
public abstract class Enemy : MonoBehaviour 
{
    public float speed = 1.0f;
    public float attackRange = 1.0f;
    public Color color;

    private Transform player;

    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() 
    {
        var distance = Vector2.Distance(transform.position, player.position);

        // Move to player until it reach an attack range
        if (Vector2.Distance(transform.position, player.position) > attackRange)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.position, step);
            PlayerInRange();
        }
    }

    void SetColor()
    {
        var sr = GetComponentInChildren<SpriteRenderer>();
        sr.color = color;
    }

    /// <summary>
    /// Override this function to implement what should happen when the player is in range.
    /// This is called every frame that the player is in range. 
    /// </summary>
    protected abstract void PlayerInRange();

    public virtual string GetName()
    {
        return "Enemy";
    }
}
