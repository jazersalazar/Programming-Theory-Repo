using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour 
{
    public string shortName;
    public int bulletsCount, magazineSize, bulletsPerFire;
    public float damage, reloadTime, fireRate, bulletSpread;
    public bool automatic;
    public AudioClip shotAudio, reloadAudio;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.ChangeGun(gameObject.GetComponent<Gun>());
            player.PickupAudio();
            Destroy(gameObject);
        }
    }
}
