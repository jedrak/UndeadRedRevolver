using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Weapon
{

    private int magazinesize;
    private float lastFire;
    public float FireDelay;
    public string weapon;
    public float ReloadDelay;
    public GameObject bulletPrefab;
   
    public float bulletforce = 1f;
    public override void Shoot(CameraShake camShake,Transform firePoint)
    {
        int rand = Random.Range(1, 7);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        camShake.Shake(camShakeAmt, camShakeLength);

        //bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletforce, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play("gunshot" + rand);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
