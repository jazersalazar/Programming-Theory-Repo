using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour 
{
    public GameObject bullet;
    public Transform barrelTip;

    void Update() 
    {
        if (Input.GetMouseButton(0))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        GameObject firedBullet = Instantiate(bullet, barrelTip.position, barrelTip.rotation) as GameObject;
        firedBullet.GetComponent<Rigidbody2D>().velocity = barrelTip.up * 20f;
    }
}
