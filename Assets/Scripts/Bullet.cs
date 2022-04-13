using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public GameObject explosion;

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Bullet")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Enemy")
        {
            // TODO: add particle effects
            // GameObject e = Instantiate(explosion) as GameObject;
            // e.transform.position = transform.position;
            Destroy(other.gameObject);
        }
    }
}