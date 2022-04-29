using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{
    public string gunName;
    public int magazineSize, bulletsPerFire;
    public float damage, reloadTime, fireRate, bulletSpread;
    public bool automatic;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}