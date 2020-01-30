using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum AmmoType
{
    BOUNCY,
    PENETRATING,
    DEFAULT,
    LAST = 2
}

public class ShootingController : MonoBehaviour
{
    private Weapon weapon;
    public Transform firePoint;
    public GameObject bulletDefaultPrefab;
    public GameObject bulletBouncyPrefab;
    public GameObject bulletPenetratingPrefab;

    private AmmoType bulletType;
    private int[] ammo = new int[(int)AmmoType.LAST];
    public GameObject[] ammoText = new GameObject[(int)AmmoType.LAST + 1];

    [SerializeField]
    public WeaponManager weaponManager;
    private ShotRotation shotRotation;
    private PlayerInventory inventory;

    CameraShake camShake;

    void Start()
    {
        shotRotation = GetComponentInChildren<ShotRotation>();
        inventory = GetComponent<PlayerInventory>();
        camShake = GetComponent<CameraShake>();
        weapon = weaponManager.weapons[0];
        bulletType = AmmoType.DEFAULT;
        setAmmo();
        ammo[(int)AmmoType.BOUNCY] = 10;
        ammo[(int)AmmoType.PENETRATING] = 20;
        ammoTextUpdate();
    }

    void Update()
    {
        // DEBUG
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.activeNewItemSlot();
        }

        for (int i = 0; i < 6; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                inventory.UseSlot(i);
            }
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

        // WEAPON DROP
        if (Input.GetKeyDown(KeyCode.Z))
        {
            weapon = weaponManager.dropWeapon();
            shotRotation.weaponChanged(weapon.name);

            setAmmo();
        }

        // AMMO CHAGE
        if (Input.GetKeyDown(KeyCode.E))
        {
            bulletType++;
            if (bulletType > AmmoType.LAST) bulletType = 0;

            if (bulletType != AmmoType.DEFAULT)
            {
                if (bulletType == AmmoType.BOUNCY)
                {
                    if (ammo[0] > 0) { }
                    else bulletType++;
                }
                if (bulletType == AmmoType.PENETRATING)
                {
                    if (ammo[1] > 0) { }
                    else bulletType++;
                }
            }

            setAmmo();
            ammoTextUpdate();
        }

        // SHOT
        if (Input.GetButtonDown("Fire1"))
        {
            int shotBulletsCount = weapon.Shoot(camShake, firePoint);
            if (bulletType == AmmoType.DEFAULT) { }
            else
            {
                ammo[(int)bulletType] -= shotBulletsCount;
                if (ammo[(int)bulletType] < 1)
                {
                    bulletType = AmmoType.DEFAULT;
                    setAmmo();
                }
                ammoTextUpdate();
            }
        }
    }

    public void addAmmo(AmmoType ammoType, int bulletCount)
    {
        if (ammoType == AmmoType.BOUNCY)
        {
            ammo[(int)ammoType] += bulletCount;
            ammoTextUpdate();
        }
        else if (ammoType == AmmoType.PENETRATING)
        {
            ammo[(int)ammoType] += bulletCount;
            ammoTextUpdate();
        }
    }

    private void setAmmo()
    {
        if (bulletType == AmmoType.DEFAULT)
        {
            weapon.setBulletType(bulletDefaultPrefab);
            // Debug.Log("Bullet : " + bulletType.ToString());
        }
        else if (bulletType == AmmoType.BOUNCY)
        {
            weapon.setBulletType(bulletBouncyPrefab);
            // Debug.Log("Bullet : " + bulletType.ToString());
        }
        else if (bulletType == AmmoType.PENETRATING)
        {
            weapon.setBulletType(bulletPenetratingPrefab);
            // Debug.Log("Bullet : " + bulletType.ToString());
        }
    }

    private void ammoTextUpdate()
    {
        if (ammo[(int)AmmoType.BOUNCY] < 1)
        {
            ammoText[(int)AmmoType.BOUNCY].GetComponent<TextMeshProUGUI>().text = "";
        }
        else
        {
            ammoText[(int)AmmoType.BOUNCY].GetComponent<TextMeshProUGUI>().text = "Bouncy : " + ammo[(int)AmmoType.BOUNCY];
        }
        ammoText[(int)AmmoType.BOUNCY].GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
        // color

        if (ammo[(int)AmmoType.PENETRATING] < 1)
        {
            ammoText[(int)AmmoType.PENETRATING].GetComponent<TextMeshProUGUI>().text = "";
        }
        else
        {
            ammoText[(int)AmmoType.PENETRATING].GetComponent<TextMeshProUGUI>().text = "Penetrating : " + ammo[(int)AmmoType.PENETRATING];
        }
        ammoText[(int)AmmoType.PENETRATING].GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
        // color

        ammoText[(int)AmmoType.DEFAULT].GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
        // color

        ammoText[(int)bulletType].GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
        // color
    }
}
