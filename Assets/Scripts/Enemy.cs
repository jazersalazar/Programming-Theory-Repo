using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public float speed = 1.0f;

    private Transform target;

    // Start is called before the first frame update
    void Start() 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update() 
    {
        if (Vector2.Distance(transform.position, target.position) > 1.5f)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }
}
