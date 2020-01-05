using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riffle : Weapon
{
    public Riffle()
    {
        name = "Riffle";
        magazinesize = 3;
        lastFire = 0;
        FireDelay = 0;
        ReloadDelay = 0;
        //Debug.Log("Riffle");
    }
    public float bulletforce = 15.0f;
    public override int Shoot(CameraShake camShake, Transform firePoint)
    {
        if (Time.time > lastFire + FireDelay + ReloadDelay)
        {
            ReloadDelay = 0;


            GameObject bullet = Object.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            camShake.Shake(camShakeAmt, camShakeLength);

            //bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletforce, ForceMode2D.Impulse);
            Object.FindObjectOfType<AudioManager>().Play("riffle");

            magazinesize--;

            if (magazinesize == 0) Reload();

            lastFire = Time.time;

            return 1;
        }
        return 0;
    }

    public override void Reload()
    {
        Object.FindObjectOfType<AudioManager>().Play("reload");
        magazinesize = 3;
        ReloadDelay = 0.5f;
    }
    public override void setBulletType(GameObject bulletPrefab)
    {
        this.bulletPrefab = bulletPrefab;
        this.bulletPrefab.GetComponent<BulletController>().lifeTime = 3.0f;
    }
}
