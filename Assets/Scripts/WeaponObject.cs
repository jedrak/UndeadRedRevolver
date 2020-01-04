using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Weapon weapon;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>(weapon.name);
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<ShootingController>().weaponManager.addWeapon(weapon))
            {
                Destroy(gameObject);
            }
        }
    }
}
