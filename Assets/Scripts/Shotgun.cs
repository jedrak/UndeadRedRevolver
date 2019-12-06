using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public Shotgun()
    {
        name = "Revolver";
        magazinesize = 6;
        lastFire = 0;
        FireDelay = 0;
        ReloadDelay = 0;
    }
    public float bulletforce = 1f;
    public override void Shoot(CameraShake camShake, Transform firePoint)
    {
        if (Time.time > lastFire + FireDelay + ReloadDelay)
        {
            ReloadDelay = 0;

            List<GameObject> bullets = new List<GameObject>();

            camShake.Shake(camShakeAmt, camShakeLength);
            bullets.Add(Object.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation));
            bullets.Add(Object.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation));
            bullets.Add(Object.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation));
            for (int i = 0; i < bullets.Count; i++)
            {
                Vector3 dis = firePoint.up;
                dis.x += -0.1f + 0.1f * i;

                if (i != 1) dis.y += -0.1f;

                //bullets[i].AddComponent<Rigidbody2D>().gravityScale = 0;
                bullets[i].GetComponent<Rigidbody2D>().AddForce(dis * bulletforce, ForceMode2D.Impulse);
                Object.FindObjectOfType<AudioManager>().Play("shotgun");
            }

            magazinesize = magazinesize - 3;

            if (magazinesize == 0) Reload();

            lastFire = Time.time;
        }
    }

    public override void Reload()
    {
        Object.FindObjectOfType<AudioManager>().Play("reload");
        magazinesize = 6;
        ReloadDelay = 1.0f;
    }
}
