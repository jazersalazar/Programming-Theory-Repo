using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthkit : MonoBehaviour 
{
    public int recoverPoints;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int newHP = other.GetComponent<Status>().HP + recoverPoints;
            Player player = other.GetComponent<Player>();
            player.SetHP(newHP);
            player.PickupAudio();
            Destroy(gameObject);
        }
    }
}
