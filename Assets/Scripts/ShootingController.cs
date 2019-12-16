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

    private Weapon weapon = new Revolver();
    public Transform firePoint;
    public GameObject bulletDefaultPrefab;
    public GameObject bulletBouncyPrefab;
    public GameObject bulletPenetratingPrefab;

    private AmmoType bulletType;
    private int weaponIndex;

    CameraShake camShake;

    void Start()
    {
        camShake = GetComponent<CameraShake>();
        weapon.setBulletType(bulletDefaultPrefab);
        bulletType = AmmoType.DEFAULT;
        weaponIndex = 1;
    }

    void Update()
    {
        // DEBUG
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gameObject.GetComponent<PlayerInventory>().activeNewItemSlot();
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload();
        }

        // WEAPON CHAGE
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // @HARDCODED

            if (++weaponIndex > 3) weaponIndex = 1;

            if (weaponIndex == 1)
            {
                weapon = new Revolver();
                Debug.Log("Revolver");
            }
            if (weaponIndex == 2)
            {
                weapon = new Shotgun();
                Debug.Log("Shotgun");
            }
            if (weaponIndex == 3)
            {
                weapon = new Riffle();
                Debug.Log("Riffle");
            }

            setAmmo();
        }

        // AMMO CHAGE
        if (Input.GetKeyDown(KeyCode.E))
        {
            // @HARDCODED

            if (++bulletType > AmmoType.LAST) bulletType = AmmoType.DEFAULT;

            setAmmo();
        }
        
        if (Input.GetButtonDown("Fire1"))
        {
            weapon.Shoot(camShake, firePoint);
        }
    }

    private void setAmmo()
    {
        if (bulletType == AmmoType.DEFAULT)
        {
            weapon.setBulletType(bulletDefaultPrefab);
            Debug.Log("Normal bullet");
        }
        else if (bulletType == AmmoType.BOUNCY)
        {
            weapon.setBulletType(bulletBouncyPrefab);
            Debug.Log("Bouncy bullet");
        }
        else if (bulletType == AmmoType.PENETRATING)
        {
            weapon.setBulletType(bulletPenetratingPrefab);
            Debug.Log("Penetrating bullet");
        }
    }
}
