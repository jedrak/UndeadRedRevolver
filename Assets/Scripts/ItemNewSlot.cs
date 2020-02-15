using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemNewSlot : Item
{
    private PlayerInventory inventory;
    public ItemNewSlot(GameObject player)
    {
        this.inventory = player.GetComponentInParent<PlayerInventory>();
        name = "NewSlot";
    }

    public override bool use()
    {
        inventory.activeNewItemSlot();
        return true;
    }
}
