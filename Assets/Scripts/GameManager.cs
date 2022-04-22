using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour 
{
    public bool isAlive = true;
    public int killCount = 0;
    public int specialKillCount = 0;

    public GameObject gameoverScreen;

    public void GameOver()
    {
        isAlive = false;
        gameoverScreen.SetActive(true);
        GameObject.Find("Killed").GetComponent<TextMeshProUGUI>().text = "Killed: " + killCount;
        GameObject.Find("Special").GetComponent<TextMeshProUGUI>().text = "Special: " + specialKillCount;
    }

    public void AddKill()
    {
        killCount++;
    }

    public void AddSpecialKill()
    {
        specialKillCount++;
    }
}
