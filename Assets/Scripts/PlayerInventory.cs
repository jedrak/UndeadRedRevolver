using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private const int ITEM_SLOTS = 6;
    /* private const int WEAPON_SLOTS = 2; */

    public bool[] isItem;
    public GameObject[] itemSlots;
    /* 
        public bool[] isWeapon;
        public GameObject[] weapons; */

    private GameObject shield;
    private float shieldLifeTime = 5.0f;

    private void Start()
    {
        shield = GameObject.FindGameObjectWithTag("Shield");
        shield.SetActive(false);
        for (int i = 2; i < ITEM_SLOTS; i++)
        {
            isItem[i] = true;
            itemSlots[i].SetActive(false);
        }
    }

    public bool activateShield()
    {
        shield.SetActive(true);
        StartCoroutine(ShieldTime());
        return true;
    }
    IEnumerator ShieldTime()
    {
        yield return new WaitForSeconds(shieldLifeTime);
        shield.SetActive(false);
    }

    public void activeNewItemSlot()
    {
        for (int i = 0; i < ITEM_SLOTS; i++)
        {
            if (itemSlots[i].activeSelf == false)
            {
                isItem[i] = false;
                itemSlots[i].gameObject.SetActive(true);
                break;
            }
        }
    }

    /* public bool addItem(Weapon weapon)
    {
        if (weapons.Length < WEAPON_SLOTS)
        {
            bool found = false;

            foreach (var it in weapons)
            {
                if (it.name == weapon.name)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                weapons.Add(weapon);
                return true;
            }
        }

        return false;
    } */
}
