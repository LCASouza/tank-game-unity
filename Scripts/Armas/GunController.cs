using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnBullet;
    [SerializeField] private float delayToShotBullet;

    [SerializeField] private int maxAmmo;
    [SerializeField] private int maxAmmoMagazine;
    [SerializeField] private int currentAmmoMagazine;
    public int currentTotalAmmo;

    public ParticleSystem fireEffect;

    private float cooldownToShotBullet = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentAmmoMagazine < maxAmmoMagazine && currentTotalAmmo > 0)
        {
            controlReload();
        }

        cooldownToShotBullet += Time.deltaTime * 1;
    }

    private void FixedUpdate()
    {
        if ((cooldownToShotBullet >= delayToShotBullet) && Input.GetButton("Fire1") && currentAmmoMagazine > 0)
        {
            fireBullet();
        }
    }

    private void controlReload()
    {
        currentTotalAmmo += currentAmmoMagazine;
        currentAmmoMagazine = 0;
        if (currentTotalAmmo<maxAmmoMagazine)
        {
            currentAmmoMagazine = currentTotalAmmo;
        }
        else
        {
            currentAmmoMagazine = maxAmmoMagazine;
        }
        currentTotalAmmo -= currentAmmoMagazine;
    }

    private void fireBullet()
    {
        cooldownToShotBullet = 0f;
        currentAmmoMagazine -= 1;
        var bala = GameObject.Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
        Instantiate(fireEffect, spawnBullet.position, spawnBullet.rotation);
    }
}
