using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon //: MonoBehaviour
{
    public string name;
    protected int magazinesize;
    protected float lastFire;
    protected float FireDelay;
    protected float ReloadDelay;
    public GameObject bulletPrefab;
    public float camShakeAmt = 0.05f;
    public float camShakeLength = 0.1f;
    public int Magazinesize { get => magazinesize; set => magazinesize = value; }
    public abstract void Shoot(CameraShake camShake, Transform firePoint);
    public abstract void Reload();
    public void setBulletType(GameObject bulletPrefab)
    {
        this.bulletPrefab = bulletPrefab;
    }
}
