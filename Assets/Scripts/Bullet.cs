using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public GameObject explosion;
    private GameManager gm;
    private SpawnManager sm;

    private void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        sm = GameObject.FindObjectOfType<SpawnManager>();
    }

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

            // Drop random weapon with 10% chance
            bool dropWeapon = Random.Range(0f, 100.0f) >= 90f ? true : false;
            if (dropWeapon)
            {
                sm.SpawnWeapon(other.transform);
            }

            gm.AddKill();
            if (other.GetComponent<Status>().IsSpecial)
            {
                gm.AddSpecialKill();
            }

            Destroy(other.gameObject);
        }
    }
}
