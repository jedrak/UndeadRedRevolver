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
        // TODO Resources/Shield.png 
        Sprite shield = Resources.Load<Sprite>(name);
        
        // Create GameObject "Shield" under Player

        // Add CircleCollider

        // That should stop enemies from touching Player

        // Destroy after some peroid of time ( like in BulletController )
        
        return true;
    }
}
