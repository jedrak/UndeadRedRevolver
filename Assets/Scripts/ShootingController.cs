using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AmmoType
{
    DEFAULT,
    BOUNCY,
    PENETRATING,
    LAST = 2
}

public class ShootingController : MonoBehaviour
{


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

            // TODO if ammo avaiable
            if (++bulletType > AmmoType.LAST) bulletType = AmmoType.DEFAULT;

            setAmmo();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            weapon.Shoot(camShake, firePoint);
        }
    }

    public void addAmmo(AmmoType ammoType, int bulletCount)
    {
        // TODO 
    }

    private void setAmmo()
    {
        if (bulletType == AmmoType.DEFAULT)
        {
            weapon.setBulletType(bulletDefaultPrefab);
            Debug.Log("Bullet : " + bulletType.ToString());
        }
        else if (bulletType == AmmoType.BOUNCY)
        {
            weapon.setBulletType(bulletBouncyPrefab);
            Debug.Log("Bullet : " + bulletType.ToString());
        }
        else if (bulletType == AmmoType.PENETRATING)
        {
            weapon.setBulletType(bulletPenetratingPrefab);
            Debug.Log("Bullet : " + bulletType.ToString());
        }
    }
}
