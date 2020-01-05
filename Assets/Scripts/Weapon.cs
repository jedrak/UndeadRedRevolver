using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon
{
    public string name;
    protected int magazinesize;
    protected float lastFire;
    protected float FireDelay;
    protected float ReloadDelay;
    public GameObject bulletPrefab;
    public float camShakeAmt = 0.05f;
    public float camShakeLength = 0.1f;
    public abstract int Shoot(CameraShake camShake, Transform firePoint);
    public abstract void Reload();
    public abstract void setBulletType(GameObject bulletPrefab);
}
