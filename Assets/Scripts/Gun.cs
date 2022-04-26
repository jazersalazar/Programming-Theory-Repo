using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour 
{
    public string gunName;
    public int magazineSize, bulletsPerFire;
    public float damage, reloadTime, fireRate, bulletSpread;
    public bool automatic;
    public TextMeshPro acronym;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
