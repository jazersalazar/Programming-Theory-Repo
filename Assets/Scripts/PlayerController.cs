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
    public bool isReloading;
    private bool shootGun;
    private bool reloadGun;

    [Space]
    [Header("References:")]
    public Rigidbody2D rb;
    public GameObject crosshair;
    public Transform firePoint;
    public Player player;
    public CameraShake cameraShake;

    [Space]
    [Header("Prefabs:")]
    public GameObject bulletPrefab;

    void Update() 
    {
        ProcessInput();
        Move();
        Aim();
        Reload();
        Shoot();
    }

    void ProcessInput()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        shootGun = Input.GetButtonDown("Fire1");
        reloadGun = Input.GetKeyDown(KeyCode.R);
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
        if (shootGun && !isReloading && int.Parse(player.magazineBullets.text) > 0)
        {
            StartCoroutine(cameraShake.Shake(.1f, .1f));
            int bulletCount = player.playerGun.bulletsPerFire;
            player.ReduceBullets(bulletCount);
            
            if (player.gunName.text == "SG") {
                bulletCount = 6;
            }

            float angleStep = player.playerGun.bulletSpread / bulletCount;
            float aimAngle = firePoint.rotation.eulerAngles.z;
            float centeringOffset = (player.playerGun.bulletSpread / 2) + (angleStep / 2); //offsets every projectile so the spread is centered on the mouse cursor

            for (int i = 0; i < bulletCount; i++)
            {
                float currentBulletAngle = Random.Range(0, angleStep * bulletCount);
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimAngle + currentBulletAngle - centeringOffset));
                
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);

                bullet.transform.position += bullet.transform.up * i / bulletCount;

                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(bullet.transform.up * BULLET_BASE_SPEED, ForceMode2D.Impulse);
            }
        }
    }

    void Reload()
    {
        if (reloadGun) {
            isReloading = true;
            Invoke("PlayerReload", player.playerGun.reloadTime);
        }
    }

    void PlayerReload()
    {
        player.ReloadGun();
        isReloading = false;
    }
}
