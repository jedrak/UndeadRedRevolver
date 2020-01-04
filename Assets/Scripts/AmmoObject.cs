using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public AmmoType ammoType; // BOUNCY or PENETRATING
    public int bulletCount; // 40 - 80


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>(ammoType.ToString());
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            /* if (other.gameObject.GetComponent<ShootingController>().addAmmo(ammoType, bulletCount))
            {
                Destroy(gameObject);
            } */
            other.gameObject.GetComponent<ShootingController>().addAmmo(ammoType, bulletCount);
            Destroy(gameObject);
        }
    }
}
