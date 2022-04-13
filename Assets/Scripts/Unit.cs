using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour 
{
    public int hp;
    public int stamina;

    private Status status;

    void Start() 
    {
        status = GetComponent<Status>();
        SetHP(hp);
    }

    public int GetHP()
    {
        return status.HP;
    }

    public void SetHP(int newHP)
    {
        status.HP = newHP;
    }

    public int GetStamina()
    {
        return status.Stamina;
    }

    public void SetStamina(int newStamina)
    {
        status.Stamina = newStamina;
    }
}
