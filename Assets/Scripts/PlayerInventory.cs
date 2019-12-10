using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private const int ITEM_SLOTS = 6;
    private const int WEAPON_SLOTS = 2;

    public bool[] isItem;
    public GameObject[] itemSlots;

    private List<Weapon> weapons;

    private void Start()
    {
    }


    public bool addItem(Weapon weapon)
    {
        /*if (weapons.Count < WEAPON_SLOTS)
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
        }*/
        
        return false;
    }
}
