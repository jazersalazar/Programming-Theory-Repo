using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public float speed = 1.0f;

    private Transform player;

    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() 
    {
        var distance = Vector2.Distance(transform.position, player.position);

        if (Vector2.Distance(transform.position, player.position) > 1f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.position, step);
        }
    }
}
