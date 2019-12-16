using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShield : Item
{
    private GameObject player;
    public ItemShield(GameObject player)
    {
        this.player = player;
        name = "Shield";
    }

    public override bool use()
    {
        player.GetComponent<PlayerInventory>().activateShield();
        return true;
    }
}
