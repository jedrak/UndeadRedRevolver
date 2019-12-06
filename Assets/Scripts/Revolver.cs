using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Weapon
{
    public Revolver()
    {
        name = "Revolver";
        magazinesize = 6;
        lastFire = 0;
        FireDelay = 0;
        ReloadDelay = 0;
    }
    public float bulletforce = 10.0f;
    public override void Shoot(CameraShake camShake, Transform firePoint)
    {
        if (Time.time > lastFire + FireDelay + ReloadDelay)
        {
            ReloadDelay = 0;

            int rand = Random.Range(1, 7);

            GameObject bullet = Object.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            camShake.Shake(camShakeAmt, camShakeLength);

            //bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletforce, ForceMode2D.Impulse);
            Object.FindObjectOfType<AudioManager>().Play("gunshot" + rand);

            magazinesize--;

            if (magazinesize == 0) Reload();

            lastFire = Time.time;
        }
    }

    public override void Reload()
    {
        Object.FindObjectOfType<AudioManager>().Play("reload");
        magazinesize = 6;
        ReloadDelay = 0.5f;
    }
}
