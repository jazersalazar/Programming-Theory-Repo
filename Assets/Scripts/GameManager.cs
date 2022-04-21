using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public bool isAlive = true;

    public void GameOver()
    {
        isAlive = false;
        Debug.Log("GameOver");
    }
}
