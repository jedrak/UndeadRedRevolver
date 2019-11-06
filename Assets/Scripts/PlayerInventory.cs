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
    public void addItem(Item item)
    {
        if(!inventory.Contains(item)) inventory.Add(item);
        Debug.Log(inventory.Count);
    } 
}
