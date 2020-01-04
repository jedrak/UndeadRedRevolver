using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponObject weaponPrefab;
    [SerializeField]
    public GameObject[] weaponSlot;
    [SerializeField]
    public Image[] weaponSlotImage;

    private int weaponIndex = 0;
    private const int WEAPON_SLOTS = 2;
    public bool[] isWeapon = new bool[WEAPON_SLOTS];
    public Weapon[] weapons = new Weapon[WEAPON_SLOTS];

    // Start is called before the first frame update
    void Start()
    {
        isWeapon[0] = true;
        weapons[0] = new Revolver();
        weaponSlotImage[0].sprite = Resources.Load<Sprite>(weapons[0].name);

        isWeapon[1] = false;
        weapons[1] = null;
        weaponSlot[1].SetActive(false);
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
        int i = 0;

        for (; i < weapons.Length; i++)
        {
            if (isWeapon[i] == false) continue;
            if (weapons[i].name == weapon.name)
            {
                found = true;
                break;
            }
        }

        if (!found)
        {
            weapons[--i] = weapon;
            isWeapon[i] = true;
            weaponSlot[i].SetActive(true);
            weaponSlotImage[i].sprite = Resources.Load<Sprite>(weapon.name);
            return true;
        }
        return false;
    }

    public void dropWeapon()
    {
        // TODO 
    }

    void Update()
    {

    }
}
