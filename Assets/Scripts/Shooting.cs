using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int magazinesize = 6;
    private float lastFire;
    public float FireDelay;
    public string weapon = "Revolver";
    public float ReloadDelay = 0;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletforce = 1f;
    // Handle camera shaking
    public float camShakeAmt = 0.05f;
    public float camShakeLength = 0.1f;
    CameraShake camShake;


    // Start is called before the first frame update

    void Start()
    {
        camShake = GetComponent<CameraShake>();
        
    }
    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.R))
        {
            magazinesize = 6;
            FindObjectOfType<AudioManager>().Play("reload");
            
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (weapon == "Obrzyn")
            {
             weapon = "Revolver";
             } 
            else
            {
                weapon = "Obrzyn";
            }




        }
        if (Input.GetButtonDown("Fire1") && Time.time > lastFire + FireDelay + ReloadDelay)
            {
            ReloadDelay = 0;

            Shoot();
            magazinesize--;

            if (magazinesize == 0)
            {
                FindObjectOfType<AudioManager>().Play("reload");
                magazinesize = 6;
                ReloadDelay = 0.5f;
            }
            lastFire = Time.time;
           
        }

    }
    void Shoot()
    {
        List<GameObject> bullets = new List<GameObject>();
        if (weapon.Equals("Obrzyn"))
        {
            camShake.Shake(camShakeAmt, camShakeLength);
            bullets.Add(Instantiate(bulletPrefab, firePoint.position, firePoint.rotation));
            bullets.Add(Instantiate(bulletPrefab, firePoint.position, firePoint.rotation));
            bullets.Add(Instantiate(bulletPrefab, firePoint.position, firePoint.rotation ));
            for (int i = 0; i < bullets.Count; i++)
            {
                Vector3 dis= firePoint.up;
                dis.x += -0.1f + 0.1f*i;
                dis.y += 0.2f - 0.2f * i;
            
                bullets[i].AddComponent<Rigidbody2D>().gravityScale = 0;
                bullets[i].GetComponent<Rigidbody2D>().AddForce(dis * bulletforce, ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().Play("shotgun");
            }
        }

        else if (weapon.Equals("Revolver"))
        {
            int rand = Random.Range(1, 7);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            camShake.Shake(camShakeAmt, camShakeLength);

            bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletforce, ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play("gunshot" + rand);
        }



    }
}
