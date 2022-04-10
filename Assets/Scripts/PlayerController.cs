using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    [Header("Attributes:")]
    public float MOVEMENT_BASE_SPEED = 1.0f;
    public float BULLET_BASE_SPEED = 1.0f;
    public float CROSSHAIR_DISTANCE = 1.0f;

    [Space]
    [Header("Statistics:")]
    public Vector2 movementDirection;
    public Vector2 mousePosition;
    public float movementSpeed;
    public bool endOfAiming;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;
    public GameObject crosshair;
    public Transform firePoint;

    [Space]
    [Header("Prefabs:")]
    public GameObject bulletPrefab;

    void Update() 
    {
        ProcessInput();
        Move();
        Aim();
        Shoot();
    }

    void ProcessInput()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        endOfAiming = Input.GetButton("Fire1");
    }
    
    void Move()
    {
        rb.velocity = movementDirection * movementSpeed * MOVEMENT_BASE_SPEED;
    }

    void Aim()
    {
        // Look at the mouse position
        Vector2 lookDirection = mousePosition - rb.position;
        var lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = lookAngle;
    }

    void Shoot()
    {
        if (endOfAiming)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = firePoint.up * BULLET_BASE_SPEED;
        }
    }
}
