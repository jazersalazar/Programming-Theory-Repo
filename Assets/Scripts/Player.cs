using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Unit 
{
    public Slider hpBar;
    public TextMeshProUGUI gunName, magazineBullets, totalBullets;
    public Gun playerGun, defaultGun;
    public AudioSource gunAudio;

    private GameManager gm;

    protected override void Start()
    {
        base.Start();
        SetMaxHP(hp);
        ChangeGun();
        gm = GameObject.FindObjectOfType<GameManager>();
        gunAudio = gameObject.GetComponent<AudioSource>();
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
        gunName.text = defaultGun.shortName;
        magazineBullets.text = defaultGun.magazineSize.ToString();
        totalBullets.text = ValidateBulletCount(defaultGun.bulletsCount);

        playerGun = defaultGun;
    }

    public void ChangeGun(Gun gun)
    {
        gunName.text = gun.shortName;
        magazineBullets.text = gun.magazineSize.ToString();
        totalBullets.text = gun.bulletsCount.ToString();

        playerGun = gun;

        LoadGunAudio(playerGun.reloadAudio);
    }

    public void ReduceBullets(int bulletCount = 1)
    {
        int remainingBullets = int.Parse(magazineBullets.text) - bulletCount;
        magazineBullets.text = remainingBullets.ToString();
        LoadGunAudio(playerGun.shotAudio);

        if (remainingBullets == 0) {
            if (playerGun.bulletsCount == 0 && playerGun != defaultGun)
            {
                Invoke("ChangeGun", playerGun.reloadTime);
            }
            else 
            {
                Invoke("ReloadGun", playerGun.reloadTime);
            }
        }
    }

    public void ReloadGun()
    {
        int bulletCount = 0;

        if (int.Parse(magazineBullets.text) == playerGun.magazineSize) return;

        if (playerGun.bulletsCount > playerGun.magazineSize || playerGun.bulletsCount < 0)
        {
            bulletCount = playerGun.magazineSize;
        }
        else
        {
            bulletCount = playerGun.bulletsCount;
        }
        
        if (playerGun.bulletsCount > 0) {
            playerGun.bulletsCount -= bulletCount - int.Parse(magazineBullets.text);
        }

        magazineBullets.text = bulletCount.ToString();
        totalBullets.text = ValidateBulletCount(playerGun.bulletsCount);
        LoadGunAudio(playerGun.reloadAudio);
    }

    public string ValidateBulletCount(int bulletCount)
    {
        return bulletCount >= 0 ? bulletCount.ToString() : "∞";
    }

    private void LoadGunAudio(AudioClip clip)
    {
        if (clip != gunAudio.clip)
        {
            gunAudio.clip = clip;
        }

        if (gunAudio.isPlaying)
        {
            gunAudio.Stop();
        }

        gunAudio.Play();
    }
}
