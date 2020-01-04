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
    [SerializeField]
    public WeaponManager weaponManager;
    private ShotRotation shotRotation;

    CameraShake camShake;

    void Start()
    {
        shotRotation = GetComponentInChildren<ShotRotation>();
        camShake = GetComponent<CameraShake>();
        weapon.setBulletType(bulletDefaultPrefab);
        bulletType = AmmoType.DEFAULT;
    }

    void Update()
    {
        // DEBUG
        if (Input.GetKeyDown(KeyCode.I))
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
            weapon = weaponManager.changeWeapon();
            shotRotation.weaponChanged(weapon.name);

            setAmmo();
        }

        // WEAPON CHAGE
        if (Input.GetKeyDown(KeyCode.Z))
        {
            weapon = weaponManager.dropWeapon();
            shotRotation.weaponChanged(weapon.name);

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
