using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour 
{
    public bool isAlive = true;
    public int killCount = 0;
    public int specialKillCount = 0;
    public bool quitting = false;

    public GameObject gameoverScreen;
    public GameObject player;
    public TextMeshProUGUI killCountText;
    public TextMeshProUGUI specialKillCountText;

    public void GameOver()
    {
        isAlive = false;
        gameoverScreen.SetActive(true);
        killCountText.text = "Killed: " + killCount;
        specialKillCountText.text = "Special: " + specialKillCount;
        player.SetActive(false);
    }

    public void AddKill()
    {
        killCount++;
    }

    public void AddSpecialKill()
    {
        specialKillCount++;
    }
    
    private void OnApplicationQuit()
    {
        quitting = true;
    }
}
