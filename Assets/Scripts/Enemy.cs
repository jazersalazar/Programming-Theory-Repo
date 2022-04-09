using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public float speed = 1.0f;

    private Transform target;

    void Start() 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() 
    {
        var distance = Vector2.Distance(transform.position, target.position);

        if (Vector2.Distance(transform.position, target.position) > 1f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }
}
