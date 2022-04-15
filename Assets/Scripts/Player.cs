using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Unit 
{
    public Slider hpBar;

    protected override void Start()
    {
        base.Start();
        SetMaxHP(hp);
    }

    public void SetMaxHP(int maxHP)
    {
        hpBar.maxValue = maxHP;
        hpBar.value = maxHP;
    }

    public override void SetHP(int newHP)
    {
        base.SetHP(newHP);
        hpBar.value = newHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        SetHP(currentHP);
    }
}