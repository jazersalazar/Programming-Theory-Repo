using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Unit 
{
    public Slider hpBar;
    public TextMeshProUGUI gunName;
    public TextMeshProUGUI magazineBullets;
    public TextMeshProUGUI totalBullets;
    private GameManager gm;

    protected override void Start()
    {
        base.Start();
        SetMaxHP(hp);
        ChangeGun();
        gm = GameObject.FindObjectOfType<GameManager>();
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

        if (currentHP <= 0)
        {
            gm.GameOver();
        }
    }

    public void ChangeGun()
    {
        gunName.text = "P";
        magazineBullets.text = "12";
        totalBullets.text = "∞";
    }

    public void ChangeGun(Gun gun)
    {
        gunName.text = gun.shortName;
        magazineBullets.text = gun.magazineSize.ToString();
        totalBullets.text = gun.bulletsCount.ToString();
    }
}
