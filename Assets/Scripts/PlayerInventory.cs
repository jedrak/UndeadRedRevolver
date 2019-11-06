using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Item> inventory;
    private void Start()
    {
        inventory = new List<Item>();
    }
    public bool addItem(Item item)
    {
        // if (!inventory.Contains(item)) inventory.Add(item);
        bool found = false;
        foreach (var it in inventory)
        {
            if (it.itemName == item.itemName)
            {
                found = true;
                break;
            }
        }
        if (!found)
        {
            inventory.Add(item);
            return true;
        }
        return false;
        // Debug.Log(inventory.Count);
    }
}
