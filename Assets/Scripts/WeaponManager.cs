using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    // WEAPON UI
    [SerializeField]
    private WeaponObject weaponPrefab;
    [SerializeField]
    public GameObject[] weaponSlot;
    [SerializeField]
    public Image[] weaponSlotImage;

    // WEAPON LOGIC
    private int weaponIndex = 0;
    private const int WEAPON_SLOTS = 2;
    public bool[] isWeapon = new bool[WEAPON_SLOTS];
    public Weapon[] weapons = new Weapon[WEAPON_SLOTS];

    void Start()
    {
        isWeapon[0] = true;
        weapons[0] = new Revolver();
        weaponSlotImage[0].sprite = Resources.Load<Sprite>(weapons[0].name);

        isWeapon[1] = false;
        weapons[1] = null;
        weaponSlot[1].SetActive(false);
    }

    void Update()
    {

    }

    public Weapon changeWeapon()
    {
        weaponIndex++;
        if (weaponIndex >= WEAPON_SLOTS) weaponIndex = 0;
        if (isWeapon[weaponIndex] == false)
        {
            return changeWeapon();
        }
        if (weaponIndex == 0)
        {
            weaponSlot[0].GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
            weaponSlot[1].GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);
            return weapons[0];
        }
        else
        {
            weaponSlot[0].GetComponent<RectTransform>().sizeDelta = new Vector2(20, 20);
            weaponSlot[1].GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
            return weapons[1];
        }
    }

    public bool addWeapon(Weapon weapon)
    {
        bool found = false;
        int i = 0, freeplace = 0;

        for (; i < weapons.Length; i++)
        {
            if (isWeapon[i] == false)
            {
                freeplace = i;
                continue;
            }
            if (weapons[i].name == weapon.name)
            {
                found = true;
                break;
            }
        }

        if (!found)
        {
            weapons[freeplace] = weapon;
            isWeapon[freeplace] = true;
            weaponSlot[freeplace].SetActive(true);
            weaponSlotImage[freeplace].sprite = Resources.Load<Sprite>(weapon.name);
            return true;
        }
        return false;
    }

    public Weapon dropWeapon()
    {
        // if ostatnia bron
        int weaponsCount = 0;
        for (int i = 0; i < isWeapon.Length; i++)
        {
            if (isWeapon[i]) weaponsCount++;
        }
        if (weaponsCount < 2) return weapons[weaponIndex];

        // else
        Vector2 weaponPos = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x - 2, GameObject.FindGameObjectWithTag("Player").transform.position.y);
        WeaponObject io = Instantiate(weaponPrefab, weaponPos, Quaternion.identity);
        io.weapon = weapons[weaponIndex];

        isWeapon[weaponIndex] = false;
        weapons[weaponIndex] = null;
        weaponSlot[weaponIndex].SetActive(false);

        return changeWeapon();
    }
}
