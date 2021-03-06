using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    private GameManager gm;

    private void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag != "Bullet" && other.tag != "Item")
        {
            Destroy(gameObject);
        }

        if (other.tag == "Enemy")
        {
            gm.AddKill();
            if (other.GetComponent<Status>().IsSpecial)
            {
                gm.AddSpecialKill();
            }

            Destroy(other.gameObject);
        }
    }
}
