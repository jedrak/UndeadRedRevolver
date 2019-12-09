using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private const int ITEM_SLOTS = 8;
    private const int WEAPON_SLOTS = 2;

    private List<Item> items;
    private List<Weapon> weapons;

    private void Start()
    {
        items = new List<Item>();
        weapons = new List<Weapon>();
    }

    public bool addItem(Item item)
    {
        if (items.Count < ITEM_SLOTS)
        {
            /*bool found = false;

            foreach (var it in items)
            {
                if (it.name == item.name)
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {*/
                items.Add(item);
                return true;
            /*}*/
        }
        
        return false;
        // Debug.Log(inventory.Count);
    }

    public bool addItem(Weapon weapon)
    {
        if (weapons.Count < WEAPON_SLOTS)
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
    }
}
