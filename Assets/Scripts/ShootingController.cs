using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    enum AmmoType
    {
        DEFAULT,
        BOUNCY,
        PENETRATING,
        LAST = 2
    }
    // public int magazinesize = 6;
    // private float lastFire;
    // public float FireDelay;
    // public string weapon = "Revolver";
    // public float ReloadDelay = 0;
    private Weapon weapon = new Revolver();
    public Transform firePoint;
    public GameObject bulletDefaultPrefab;
    public GameObject bulletBouncyPrefab;
    public GameObject bulletPenetratingPrefab;
    // private GameObject bulletActive;
    private AmmoType bulletType;
    // public float bulletforce = 1f;
    // Handle camera shaking
    // public float camShakeAmt = 0.05f;
    // public float camShakeLength = 0.1f;
    CameraShake camShake;


    // Start is called before the first frame update

    void Start()
    {
        camShake = GetComponent<CameraShake>();
        // bulletActive = bulletDefaultPrefab;
        weapon.setBulletType(bulletDefaultPrefab);
        bulletType = AmmoType.DEFAULT;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            // magazinesize = 6;
            // FindObjectOfType<AudioManager>().Play("reload");
            weapon.Reload();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // if (weapon == "Obrzyn")
            // {
            //     weapon = "Revolver";
            // }
            // else
            // {
            //     weapon = "Obrzyn";
            // }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            // bulletType++;
            if (++bulletType > AmmoType.LAST) bulletType = AmmoType.DEFAULT;

            if (bulletType == AmmoType.DEFAULT)
            {
                // bulletActive = bulletDefaultPrefab;
                weapon.setBulletType(bulletDefaultPrefab);
            }
            else if (bulletType == AmmoType.BOUNCY)
            {
                // bulletActive = bulletBouncyPrefab;
                weapon.setBulletType(bulletBouncyPrefab);
            }
            else if (bulletType == AmmoType.PENETRATING)
            {
                // bulletActive = bulletPenetratingPrefab;
                weapon.setBulletType(bulletPenetratingPrefab);
            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            weapon.Shoot(camShake, firePoint);
        }

    }
    void Shoot()
    {
        // if (weapon.Equals("Obrzyn"))
        // {
        //     List<GameObject> bullets = new List<GameObject>();

        //     camShake.Shake(camShakeAmt, camShakeLength);
        //     bullets.Add(Instantiate(bulletActive, firePoint.position, firePoint.rotation));
        //     bullets.Add(Instantiate(bulletActive, firePoint.position, firePoint.rotation));
        //     bullets.Add(Instantiate(bulletActive, firePoint.position, firePoint.rotation));
        //     for (int i = 0; i < bullets.Count; i++)
        //     {
        //         Vector3 dis = firePoint.up;
        //         dis.x += -0.1f + 0.1f * i;

        //         if (i != 1) dis.y += -0.1f;

        //         //bullets[i].AddComponent<Rigidbody2D>().gravityScale = 0;
        //         bullets[i].GetComponent<Rigidbody2D>().AddForce(dis * bulletforce, ForceMode2D.Impulse);
        //         FindObjectOfType<AudioManager>().Play("shotgun");
        //     }
        // }

        // else if (weapon.Equals("Revolver"))
        // {
        //     int rand = Random.Range(1, 7);

        //     GameObject bullet = Instantiate(bulletActive, firePoint.position, firePoint.rotation);
        //     camShake.Shake(camShakeAmt, camShakeLength);

        //     //bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        //     bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletforce, ForceMode2D.Impulse);
        //     FindObjectOfType<AudioManager>().Play("gunshot" + rand);
        // }



    }
}
