using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float moveSpeed = 20.0f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 mousePosition;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate() 
    { 
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Look at the mouse position
        Vector2 lookDirection = mousePosition - rb.position;
        var lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = lookAngle;
    }
}
