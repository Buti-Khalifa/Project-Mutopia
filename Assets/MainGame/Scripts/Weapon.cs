using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    public int currentClip, maxClipSize = 10, currentAmmo, maxAmmoSize = 100;


    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public GameObject bullet5;
    public GameObject bullet6;
    public GameObject bullet7;
    public GameObject bullet8;
    public GameObject bullet9;
    public GameObject bullet10;
    public GameObject bullet11;
    public GameObject bullet12;

    public void Fire()
    {
        if (currentClip > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            currentClip--;
        }


    }

    void Update()
    {
        RemoveBullet();
    }

    public void Reload()
    {
        if (currentAmmo > 0)
        {
            int reloadAmount = maxClipSize - currentClip;
            reloadAmount = (currentAmmo - reloadAmount) >= 0 ? reloadAmount : currentAmmo;
            currentClip += reloadAmount;
            currentAmmo -= reloadAmount;
            ResetOnReload();

        }
    }

    public void AddAmmo(int ammoAmount)
    {
        currentAmmo += ammoAmount;
        if (currentAmmo > maxAmmoSize)
        {
            currentAmmo = maxAmmoSize;
        }
    }

    public void RemoveBullet()
    {
        if (currentClip == 11)
        {
            bullet1.SetActive(false);
        }
        if (currentClip == 10)
        {
            bullet2.SetActive(false);
        }
        if (currentClip == 9)
        {
            bullet3.SetActive(false);
        }
        if (currentClip == 8)
        {
            bullet4.SetActive(false);
        }
        if (currentClip == 7)
        {
            bullet5.SetActive(false);
        }
        if (currentClip == 6)
        {
            bullet6.SetActive(false);
        }
        if (currentClip == 5)
        {
            bullet7.SetActive(false);
        }
        if (currentClip == 4)
        {
            bullet8.SetActive(false);
        }
        if (currentClip == 3)
        {
            bullet9.SetActive(false);
        }
        if (currentClip == 2)
        {
            bullet10.SetActive(false);
        }
        if (currentClip == 1)
        {
            bullet11.SetActive(false);
        }
        if (currentClip == 0)
        {
            bullet12.SetActive(false);
        }
    }

    void ResetOnReload()
    {
        bullet1.SetActive(true);
        bullet2.SetActive(true);
        bullet3.SetActive(true);
        bullet4.SetActive(true);
        bullet5.SetActive(true);
        bullet6.SetActive(true);
        bullet7.SetActive(true);
        bullet8.SetActive(true);
        bullet9.SetActive(true);
        bullet10.SetActive(true);
        bullet11.SetActive(true);
        bullet12.SetActive(true);
    }
}
