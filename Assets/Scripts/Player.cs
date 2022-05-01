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
    private int magazineSize;
    private float reloadTime;

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
        magazineSize = 12;
        totalBullets.text = "∞";
        reloadTime = 0.5f;
    }

    public void ChangeGun(Gun gun)
    {
        gunName.text = gun.shortName;
        magazineBullets.text = gun.magazineSize.ToString();
        magazineSize = gun.magazineSize;
        totalBullets.text = gun.bulletsCount.ToString();
        reloadTime = gun.reloadTime;
    }

    public void ReduceBullets(int bulletCount)
    {
        int remainingBullets = int.Parse(magazineBullets.text) - bulletCount;
        magazineBullets.text = remainingBullets.ToString();

        if (remainingBullets == 0) {
            if (GetTotalBullets() == 0)
            {
                ChangeGun();
            }
            else 
            {
                Invoke("ReloadGun", reloadTime);
            }
        }
    }

    public bool ReloadGun()
    {
        
        int bulletCount = 0;
        int remainingBullets = GetTotalBullets();

        if (int.Parse(magazineBullets.text) == magazineSize || remainingBullets == 0) return false;

        if (remainingBullets > magazineSize)
        {
            bulletCount = magazineSize;
        }
        else
        {
            bulletCount = remainingBullets;
        }
        remainingBullets -= bulletCount;

        magazineBullets.text = bulletCount.ToString();
        if (gunName.text != "P") {
            totalBullets.text = remainingBullets.ToString();
        }

        return false;
    }

    public int GetTotalBullets()
    {
        return gunName.text == "P" ? 99 : int.Parse(totalBullets.text); 
    }
}
