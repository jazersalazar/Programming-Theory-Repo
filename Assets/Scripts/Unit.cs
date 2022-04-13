using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ABSTRACTION
public abstract class Unit : MonoBehaviour 
{
    public int hp;
    public int stamina;
    public int currentHP;

    private Status status;

    protected virtual void Start() 
    {
        status = GetComponent<Status>();
        SetHP(hp);
        currentHP = GetHP();
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
    
    public virtual string GetName()
    {
        return "Unit";
    }
}
