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


    // Miało zapobiegać strzelaniu gdy naciskamy gui, ale update wykonuje się przed ustawieniem flagi
    public bool uiClicked;
    public void setUiClicked(bool status)
    {
        uiClicked = status;
        //Debug.Log(uiClicked);
    }

    void Start()
    {
        camShake = GetComponent<CameraShake>();
        weapon.setBulletType(bulletDefaultPrefab);
        bulletType = AmmoType.DEFAULT;
        weaponIndex = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            weapon.Reload();
        }
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            // @HARDCODED

            if (++bulletType > AmmoType.LAST) bulletType = AmmoType.DEFAULT;

            setAmmo();
        }
        
        if (Input.GetButtonDown("Fire1")) // TODO  && not_interact_witch_inventory 
        {
            //Debug.Log("strzał: " + uiClicked);
            weapon.Shoot(camShake, firePoint);
        }

        //uiClicked = false;
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
